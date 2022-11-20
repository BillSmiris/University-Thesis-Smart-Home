using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using SmartHome.Shared.Models;

namespace SmartHome.Client.Services
{
    interface IAuthService
    {
        Task<string> Login(LoginRequestModel loginRequestModel);
        Task Logout();
        Task<Response> Register(RegisterRequestModel registerRequestModel);
        Task<Response> EditUser(EditUserRequestModel editUserModel);
        Task<Response> DeleteUser(string username);
        Task<Response> ChangePassword(ChangePasswordRequestModel changePasswordRequestModel);
        Task<string> GetToken();
    }
}
