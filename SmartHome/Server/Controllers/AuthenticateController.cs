using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;  
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;  
using System.Security.Claims;  
using System.Text;
using SmartHome.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net.WebSockets;
using System.Threading;
using System.Text.Json;

namespace SmartHome.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DeviceController> _logger;
        private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        private static List<WebSocket> userListConnections = new List<WebSocket>();

        public AuthenticateController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ILogger<DeviceController> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMonths(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(
                    new JwtSecurityTokenHandler().WriteToken(token)
                );
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "User already exists!" });

            User user = new User()
            {
                Email = model.email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.username
            };
            var result = await userManager.CreateAsync(user, model.password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "User creation failed! Please check user details and try again." });
            }

            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            if (!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            if (!await roleManager.RoleExistsAsync(Roles.Device))
                await roleManager.CreateAsync(new IdentityRole(Roles.Device));

            if (await roleManager.RoleExistsAsync(model.role))
            {
                await userManager.AddToRoleAsync(user, model.role);
            }
            _logger.Log(LogLevel.Information, "User created successfully!");

            await UpdateUserLists(userManager.Users.ToList(), userListConnections);
            return Ok(new Response { status = "Success", message = "User created successfully!" });
        }

        [Authorize(Roles=Roles.Admin)]
        [HttpPost]
        [Route("editUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUserRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.previousUsername);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "User does not exist!" });
            if(model.password != null)
            {
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(user, resetToken, model.password);
                if (!passwordChangeResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "Invalid password format!" });
                }
            }
            var userExists = await userManager.FindByNameAsync(model.username);
            if(userExists == null)
            {
                user.UserName = model.username;
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "Username already taken!" });
            }
            user.Email = model.email;
            await userManager.UpdateAsync(user);
            await UpdateUserLists(userManager.Users.ToList(), userListConnections);
            return Ok(new Response { status = "Success", message = "User info updated successfully!" });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "User does not exist!" });
            await userManager.DeleteAsync(user);
            await UpdateUserLists(userManager.Users.ToList(), userListConnections);
            return Ok(new Response { status = "Success", message = "User deleted successfully!" });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestModel model)
        {
            var user = await userManager.FindByNameAsync(model.username);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "User does not exist!" });
            string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(user, resetToken, model.newPassword);
            if (!passwordChangeResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "Error", message = "Invalid password format!" });
            }
            return Ok(new Response { status = "Success", message = "Password changed successfully!" });
        }

        [HttpGet("users")]
        public async Task UserList()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                userListConnections.Add(webSocket);
                _logger.Log(LogLevel.Information, "" + userListConnections.Count);
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                string users = await SerializeUserList(userManager.Users.ToList());
                var data = Encoding.UTF8.GetBytes(users);
                await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(new byte[1]), CancellationToken.None);
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                userListConnections.Remove(webSocket);
                _logger.Log(LogLevel.Information, "WebSocket connection closed");
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private async Task<string> SerializeUserList(List<User> users)
        {
            List<UserListResponseModel> userList = new List<UserListResponseModel>();

            foreach(var user in users)
            {
                var roles = (await userManager.GetRolesAsync(user)).ToList();
                if (!IsRole(Roles.Admin, roles) && !IsRole(Roles.Device, roles))
                {
                    userList.Add(new UserListResponseModel { username = user.UserName, email = user.Email });
                }
            }
            return JsonSerializer.Serialize(userList);
        }

        private bool IsRole(string roleToCheck, List<string> roles)
        {
            foreach(string role in roles)
            {
                if(roleToCheck == role)
                {
                    return true;
                }
            }
            return false;
        }

        private async Task UpdateUserLists(List<User> ul, List<WebSocket> conn)
        {
            string userList = await SerializeUserList(ul);
            var data = Encoding.UTF8.GetBytes(userList);
            foreach (var item in conn)
            {
                await item.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
