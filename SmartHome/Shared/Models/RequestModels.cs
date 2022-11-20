using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartHome.Shared.Models
{
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        public string role { get; set; }
    }

    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }

    public class EditUserRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        public string previousUsername { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }
        
        public string password { get; set; }
    }

    public class ChangePasswordRequestModel
    {
        public string username { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Compare("newPassword", ErrorMessage = "Passwords do not match")]
        public string confirmPassword { get; set; }
    }
}
