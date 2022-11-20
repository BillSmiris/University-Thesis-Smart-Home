using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartHome.Shared.Models
{
    public class User: IdentityUser
    {
        
    }

    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Device = "Device";
    }
}
