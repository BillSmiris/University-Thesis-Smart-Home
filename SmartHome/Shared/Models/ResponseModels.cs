using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Shared.Models
{
    public class Response
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class UserListResponseModel
    {
        public string username { get; set; }
        public string email { get; set; }
    }
}
