using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SmartHome.Client.Classes;
using SmartHome.Shared.Models;

namespace SmartHome.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;

        }

        public async Task<Response> Register(RegisterRequestModel registerRequestModel)
        {
            var result = await _httpClient.PostAsJsonAsync<RegisterRequestModel>("api/authenticate/register", registerRequestModel);

            return JsonSerializer.Deserialize<Response>(await result.Content.ReadAsStringAsync());
        }

        public async Task<Response> EditUser(EditUserRequestModel editUserModel)
        {
            var result = await _httpClient.PostAsJsonAsync<EditUserRequestModel>("api/authenticate/editUser", editUserModel);

            return JsonSerializer.Deserialize<Response>(await result.Content.ReadAsStringAsync());
        }

        public async Task<Response> DeleteUser(string username)
        {
            var result = await _httpClient.PostAsJsonAsync<string>("api/authenticate/deleteUser", username);

            return JsonSerializer.Deserialize<Response>(await result.Content.ReadAsStringAsync());
        }

        public async Task<Response> ChangePassword(ChangePasswordRequestModel changePasswordRequestModel)
        {
            var result = await _httpClient.PostAsJsonAsync<ChangePasswordRequestModel>("api/authenticate/changePassword", changePasswordRequestModel);
            return JsonSerializer.Deserialize<Response>(await result.Content.ReadAsStringAsync());
        }

        public async Task<string> Login(LoginRequestModel loginRequestModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginRequestModel);
            var response = await _httpClient.PostAsync("api/authenticate/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            //var loginResult = JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var loginResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequestModel.username);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> GetToken()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }

    }
}
