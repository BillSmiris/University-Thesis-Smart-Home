using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Shared.Models
{
    public class DeviceUser
    {
        public string name { get; set; }
        public string devicetype { get; set; }
        public string displayname { get; set; }
        public Dictionary<string, Dictionary<string, string>> settings { get; set; }
    }
}
