using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriveMe.Models
{
    public class LoginViewModel
    {        
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}