using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using SmartHome.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SmartHome.Server.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private static List<WebSocket> deviceListConnections = new List<WebSocket>();
        private static List<WebSocket> unauthorizedDeviceListConnections = new List<WebSocket>();
        private static List<Device> devices = new List<Device>();
        private static List<Device> unauthorizedDevices = new List<Device>();

        private readonly ILogger<DeviceController> _logger;
        private readonly UserManager<User> _userManager;
        public DeviceController(ILogger<DeviceController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        
        [HttpGet("user")]
        public async Task DeviceList()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                deviceListConnections.Add(webSocket);
                _logger.Log(LogLevel.Information, "" + deviceListConnections.Count);
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                var data = Encoding.UTF8.GetBytes(SerializeDeviceList(devices));
                await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(new byte[1]), CancellationToken.None);
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                deviceListConnections.Remove(webSocket);
                _logger.Log(LogLevel.Information, "WebSocket connection closed");
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpGet("discover")]
        public async Task UnauthorizedDeviceList()
        {
            //_logger.Log(LogLevel.Information, "try");
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                //_logger.Log(LogLevel.Information, "try2");
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                unauthorizedDeviceListConnections.Add(webSocket);
                _logger.Log(LogLevel.Information, "" + unauthorizedDeviceListConnections.Count);
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                var data = Encoding.UTF8.GetBytes(SerializeDeviceList(unauthorizedDevices));
                await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(new byte[1]), CancellationToken.None);
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                unauthorizedDeviceListConnections.Remove(webSocket);
                _logger.Log(LogLevel.Information, "WebSocket connection closed");
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [Authorize(Roles=Roles.Device)]
        [HttpGet("device")]
        public async Task DeviceConnectionManager()
        {
            _logger.Log(LogLevel.Information, "try");
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                _logger.Log(LogLevel.Information, "try2");
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var buffer = new byte[1024 * 4];
                //var data = Encoding.UTF8.GetBytes(GenerateDeviceName());

                //await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                var data = Encoding.UTF8.GetBytes("device ok");
                await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);

                _logger.Log(LogLevel.Information, Encoding.UTF8.GetString(buffer));
                var device = new Device(webSocket, Encoding.UTF8.GetString(buffer));
                devices.Add(device);
                await UpdateDeviceLists(devices, deviceListConnections);
                try
                {
                    while (!result.CloseStatus.HasValue)
                    {
                        buffer = new byte[1024 * 4];
                        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        if (!result.CloseStatus.HasValue)
                        {
                            device.info = Encoding.UTF8.GetString(buffer);
                            buffer = new byte[1024 * 4];
                        }
                    }
                    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                }
                catch(Exception e){

                }
                _logger.Log(LogLevel.Information, "WebSocket connection closed");
                devices.Remove(device);
                await UpdateDeviceLists(devices, deviceListConnections);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpGet("deviceAuth")]
        public async Task DeviceAuthConnectionManager()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var buffer = new byte[1024 * 4];
                var data = Encoding.UTF8.GetBytes(GenerateDeviceName());

                await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                //data = Encoding.UTF8.GetBytes("device ok");
                //await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);

                var device = new Device(webSocket, Encoding.UTF8.GetString(buffer));
                unauthorizedDevices.Add(device);
                await UpdateDeviceLists(unauthorizedDevices, unauthorizedDeviceListConnections);

                try
                {
                    while (!result.CloseStatus.HasValue)
                    {
                        buffer = new byte[1024 * 4];
                        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        if (!result.CloseStatus.HasValue)
                        {
                            device.info = Encoding.UTF8.GetString(buffer);
                            buffer = new byte[1024 * 4];
                        }
                    }
                    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                }
                catch (Exception e)
                {

                }
                _logger.Log(LogLevel.Information, "WebSocket connection closed");
                unauthorizedDevices.Remove(device);
                await UpdateDeviceLists(unauthorizedDevices, unauthorizedDeviceListConnections);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpGet("devicepanel/{devicename}")]
        public async Task DevicePanelConnectionManager(string devicename)
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                Device device = null;
                try
                {
                    foreach(var item in devices)
                    {
                        if (item.info.Contains(devicename))
                        {
                            device = item;
                            break;
                        }
                    }
                    var buffer = new byte[1024 * 4];
                    var data = Encoding.UTF8.GetBytes(device.info);

                    await webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    while (!result.CloseStatus.HasValue)
                    {
                        data = buffer;
                        if(Encoding.UTF8.GetString(buffer).Split("}")[0] == "delete")
                        {
                            var deviceUser = await _userManager.FindByNameAsync(devicename);
                            await _userManager.DeleteAsync(deviceUser);
                        }
                        await device.webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    }
                    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                }
                catch(Exception e)
                {
                    HttpContext.Response.StatusCode = 400;
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpGet("authorizeDevice/{devicename}")]
        public async Task AuthorizeDevice(string devicename)
        {
            _logger.Log(LogLevel.Information, "Enter function");
            try
            {
                foreach (var item in unauthorizedDevices)
                {
                    if (item.info.Contains(devicename))
                    {
                        _logger.Log(LogLevel.Information, "found");
                        var buffer = new byte[1024 * 4];
                        var data = Encoding.UTF8.GetBytes("ok");
                        await item.webSocket.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                        _logger.Log(LogLevel.Information, "ok");
                        break;
                    }
                }
                HttpContext.Response.StatusCode = 204;
            }
            catch
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private static string SerializeDeviceList(List<Device> dl)
        {
            var devicelist = new List<DeviceListModel>();
            foreach (var item in dl)
            {
                var temp = item.info.Split(',');
                devicelist.Add(new DeviceListModel(temp[0].Split(':')[1].Split('\"')[1], temp[1].Split(':')[1].Split('\"')[1], temp[2].Split(':')[1].Split('\"')[1]));
            }
            return JsonSerializer.Serialize(devicelist);
        }

        private static async Task UpdateDeviceLists(List<Device> dl, List<WebSocket> conn)
        {
            var data = Encoding.UTF8.GetBytes(SerializeDeviceList(dl));
            foreach (var item in conn)
            {
                await item.SendAsync(new ArraySegment<byte>(data, 0, data.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private static string GenerateDeviceName()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 12; i++)
            {
                stringBuilder.Append((char)random.Next('a', 'z'));
            }
            return stringBuilder.ToString();
        }
    }
}
