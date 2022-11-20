using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Shared.Models
{
    public class Device
    {
        public WebSocket webSocket;
        public string info;

        public Device(WebSocket webSocket, string info)
        {
            this.webSocket = webSocket;
            this.info = info;
        }
    }
}
