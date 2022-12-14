// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SmartHome.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using SmartHome.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using SmartHome.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\_Imports.razor"
using SmartHome.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\Pages\DevicePanel.razor"
using System.Net.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\Pages\DevicePanel.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\Pages\DevicePanel.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\Pages\DevicePanel.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\Pages\DevicePanel.razor"
using SmartHome.Shared.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/devicepanel/{devicename}")]
    public partial class DevicePanel : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "C:\Users\billy\source\repos\SmartHomeAuthTest2\Client\Pages\DevicePanel.razor"
       
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    CancellationTokenSource disposalTokenSource = new CancellationTokenSource();
    ClientWebSocket webSocket = new ClientWebSocket();
    string data = "";
    DeviceUser device = null;
    bool livePreview = false;
    bool isEditing = false;

    [Parameter]
    public string devicename { get; set; }

    protected override void OnInitialized()
    {
        devicename = devicename;

    }

    protected override async Task OnInitializedAsync()
    {
        await webSocket.ConnectAsync(new Uri("wss://localhost:44322/api/devices/devicepanel/" + devicename), disposalTokenSource.Token);
        _ = ReceiveLoop();
        //await SendMessageAsync();
    }

    async Task SendMessageAsync()
    {
        var data = new ArraySegment<byte>(Encoding.UTF8.GetBytes(await JS.InvokeAsync<string>("PrepareData")));
        await webSocket.SendAsync(data, WebSocketMessageType.Text, true, disposalTokenSource.Token);
    }

    async Task ReceiveLoop()
    {
        var buffer = new ArraySegment<byte>(new byte[1024 * 4]);
        while (!disposalTokenSource.IsCancellationRequested)
        {
            var received = await webSocket.ReceiveAsync(buffer, disposalTokenSource.Token);
            var receivedAsText = Encoding.UTF8.GetString(buffer.Array, 0, received.Count);
            Console.WriteLine(receivedAsText);
            device = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceUser>(receivedAsText);
            StateHasChanged();
        }
    }

    public string CapitalizeFirst(string str)
    {
        return str[0].ToString().ToUpper() + str.Substring(1);
    }

    public void Dispose()
    {
        disposalTokenSource.Cancel();
        _ = webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
    }

    public async void LivePreview()
    {
        if (livePreview)
        {
            await SendMessageAsync();
        }
    }

    public async void EditDisplayName()
    {
        device.displayname = await JS.InvokeAsync<string>("EditDisplayName", isEditing);
        isEditing = !isEditing;
        if (!isEditing)
        {
            var data = new ArraySegment<byte>(Encoding.UTF8.GetBytes(device.displayname + "}"));
            await webSocket.SendAsync(data, WebSocketMessageType.Text, true, disposalTokenSource.Token);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService AuthService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
    }
}
#pragma warning restore 1591
