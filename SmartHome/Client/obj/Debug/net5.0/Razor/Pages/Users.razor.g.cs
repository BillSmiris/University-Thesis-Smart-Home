#pragma checksum "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf27c2aaa5b85e2f8c22be80cb91e4434483e963"
// <auto-generated/>
#pragma warning disable 1591
namespace SmartHome.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\_Imports.razor"
using SmartHome.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
using System.Net.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/users")]
    public partial class Users : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Users</h3>\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(1);
            __builder.AddAttribute(2, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(3, "button");
                __builder2.AddAttribute(4, "class", "btn btn-primary text-center");
                __builder2.AddAttribute(5, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                                                                ()=>modal.Show<SmartHome.Client.Shared.Register>("Add User")

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(6, "<span class=\"oi oi-plus\" aria-hidden=\"true\"></span> Add User");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(7, "\r\n        ");
                __builder2.OpenElement(8, "button");
                __builder2.AddAttribute(9, "class", "btn btn-primary text-center");
                __builder2.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                                                                ()=>ChangeAdminPassword()

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(11, "<span class=\"oi oi-key\" aria-hidden=\"true\"></span> Change Admin Password");
                __builder2.CloseElement();
#nullable restore
#line 17 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
         if (webSocket.State == WebSocketState.Open && list.Count > 0)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "mt-2");
                __builder2.OpenElement(14, "table");
                __builder2.AddAttribute(15, "class", "table table-hover");
                __builder2.AddMarkupContent(16, "<thead><tr><th>Username</th>\r\n                            <th>Email</th>\r\n                            <th></th>\r\n                            <th></th></tr></thead>\r\n                    ");
                __builder2.OpenElement(17, "tbody");
#nullable restore
#line 30 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                         foreach (var item in list)
                        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(18, "tr");
                __builder2.AddAttribute(19, "class", "user-row");
                __builder2.OpenElement(20, "td");
                __builder2.AddContent(21, 
#nullable restore
#line 33 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                                     item.username

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(22, "\r\n                                ");
                __builder2.OpenElement(23, "td");
                __builder2.AddContent(24, 
#nullable restore
#line 34 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                                     item.email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n                                ");
                __builder2.OpenElement(26, "td");
                __builder2.OpenElement(27, "button");
                __builder2.AddAttribute(28, "class", "btn btn-primary");
                __builder2.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                                                                                ()=>OpenEditUserModal(item)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(30, "<span class=\"oi oi-pencil\" aria-hidden=\"true\"></span> Edit");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n                                ");
                __builder2.OpenElement(32, "td");
                __builder2.OpenElement(33, "button");
                __builder2.AddAttribute(34, "class", "btn btn-danger");
                __builder2.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 36 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                                                                               ()=>DeleteUser(item)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(36, "<span class=\"oi oi-x\" aria-hidden=\"true\"></span> Delete");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 38 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
                        }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 42 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(37, "<h4 class=\"mt-2\">No users found.</h4>");
#nullable restore
#line 46 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
        }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.AddAttribute(38, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(39, "<h3>Unauthorized Access!</h3>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(40, "\r\n\r\n");
            __builder.OpenComponent<Blazored.Toast.BlazoredToasts>(41);
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 55 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Users.razor"
       
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    CancellationTokenSource disposalTokenSource = new CancellationTokenSource();
    ClientWebSocket webSocket = new ClientWebSocket();
    List<UserListResponseModel> list = new List<UserListResponseModel>() { };

    public UserListResponseModel selectedItem;

    protected override async Task OnInitializedAsync()
    {
        await webSocket.ConnectAsync(new Uri("ws://server:60648/api/authenticate/users"), disposalTokenSource.Token);
        _ = ReceiveLoop();
        //await SendMessageAsync();
    }

    async Task SendMessageAsync()
    {
        var data = new ArraySegment<byte>(Encoding.UTF8.GetBytes("ok"));
        await webSocket.SendAsync(data, WebSocketMessageType.Text, true, disposalTokenSource.Token);

    }

    async Task ReceiveLoop()
    {
        var buffer = new ArraySegment<byte>(new byte[1024 * 4]);
        while (!disposalTokenSource.IsCancellationRequested)
        {
            var received = await webSocket.ReceiveAsync(buffer, disposalTokenSource.Token);
            var receivedAsText = Encoding.UTF8.GetString(buffer.Array, 0, received.Count);
            list = System.Text.Json.JsonSerializer.Deserialize<List<UserListResponseModel>>(receivedAsText);
            StateHasChanged();
        }
    }

    public void Dispose()
    {
        disposalTokenSource.Cancel();
        _ = webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
    }

    public void OpenEditUserModal(UserListResponseModel user)
    {
        var parameters = new ModalParameters();
        parameters.Add(nameof(EditUser.selectedItem), user);
        var messageForm = modal.Show<EditUser>("Edit User", parameters);
    }

    public async void DeleteUser(UserListResponseModel user)
    {
        var parameters = new ModalParameters();
        parameters.Add(nameof(ConfirmationDialog.message), "Are you sure you want to delete user " + user.username + "?");
        var dialogModal = modal.Show<ConfirmationDialog>("Delete User", parameters);
        var modalResult = await dialogModal.Result;
        if (!modalResult.Cancelled)
        {
            if ((bool)modalResult.Data)
            {
                var result = await AuthService.DeleteUser(user.username);
                if (result.status == "Success")
                {
                    toastService.ShowSuccess(result.message);
                }
                else
                {
                    toastService.ShowError(result.message);
                }
            }
        }
    }

    public async void ChangeAdminPassword()
    {
        var parameters = new ModalParameters();
        parameters.Add(nameof(ChangePassword.username), "admin");
        var changePasswordModal = modal.Show<ChangePassword>("Change Admin Password", parameters);
        var modalResult = await changePasswordModal.Result;
        if (!modalResult.Cancelled)
        {
            toastService.ShowSuccess("Admin password changed susseccfully!");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService AuthService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IModalService modal { get; set; }
    }
}
#pragma warning restore 1591
