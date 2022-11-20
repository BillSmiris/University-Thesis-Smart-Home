using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Shared.Models
{
    public class DeviceListModel
    {
        public string name { get; set; }
        public string devicetype { get; set; }
        public string displayname { get; set; }

        public DeviceListModel(string name, string devicetype, string displayname)
        {
            this.name = name;
            this.devicetype = devicetype;
            this.displayname = displayname;
        }
    }
}
