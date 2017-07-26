using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DriveMe.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Mobile number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Password should be atmost 10 char length")]        
        public string Password { get; set; }
    }
}