#pragma checksum "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c259a3a11c7b9c98f050642bd0cc8ac5b6f6499"
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
#line 2 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
using System.Net.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "<h1>Devices</h1>");
#nullable restore
#line 14 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
         if (webSocket.State == WebSocketState.Open && list.Count > 0)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "col");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "row");
#nullable restore
#line 18 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                     foreach (var item in list)
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(7, "a");
                __builder2.AddAttribute(8, "class", "device");
                __builder2.AddAttribute(9, "href", "/devicepanel/" + (
#nullable restore
#line 20 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                                                              item.name

#line default
#line hidden
#nullable disable
                ));
#nullable restore
#line 21 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                             if (darkTheme)
                            {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(10, "img");
                __builder2.AddAttribute(11, "class", "dark-theme-img");
                __builder2.AddAttribute(12, "src", 
#nullable restore
#line 23 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                                                                  "svg/dark/" + item.devicetype + ".svg"

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(13, "alt", 
#nullable restore
#line 23 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                                                                                                                item.devicetype

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 24 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                            }
                            else 
                            {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(14, "img");
                __builder2.AddAttribute(15, "class", "dark-theme-img");
                __builder2.AddAttribute(16, "src", 
#nullable restore
#line 27 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                                                                  "svg/light/" + item.devicetype + ".svg"

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(17, "alt", 
#nullable restore
#line 27 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                                                                                                                 item.devicetype

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 28 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                            }

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(18, "span");
                __builder2.AddContent(19, 
#nullable restore
#line 29 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                                   item.displayname

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 31 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 34 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(20, "<h4>No devices found.</h4>");
#nullable restore
#line 38 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
        }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.AddAttribute(21, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(22, "<h3>Unauthorized Access!</h3>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "C:\Users\billy\source\repos\SmartHomeNoSSL\Client\Pages\Index.razor"
       
    CancellationTokenSource disposalTokenSource = new CancellationTokenSource();
    ClientWebSocket webSocket = new ClientWebSocket();
    List<DeviceListModel> list = new List<DeviceListModel>() { };
    bool darkTheme;

    protected override async Task OnInitializedAsync()
    {
        darkTheme = await JS.InvokeAsync<bool>("GetDarkThemeStatus");
        await webSocket.ConnectAsync(new Uri("ws://server:60648/api/devices/user"), disposalTokenSource.Token);
        _ = ReceiveLoop();
        await LogUserAuthenticationState();
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
            list = System.Text.Json.JsonSerializer.Deserialize<List<DeviceListModel>>(receivedAsText);
            StateHasChanged();
        }
    }

    public void Dispose()
    {
        disposalTokenSource.Cancel();
        _ = webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
    }

    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    private async Task LogUserAuthenticationState()
    {
        var authState = await authenticationStateTask;
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            Console.WriteLine($"User {user.Identity.Name} is authenticated.");
        }
        else
        {
            Console.WriteLine("User is NOT authenticated.");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService AuthService { get; set; }
    }
}
#pragma warning restore 1591