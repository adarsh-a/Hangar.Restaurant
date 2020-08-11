using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class AdminUser : IdentityUser
    {

    }

    public class RegisterVM
    {
        [Required(ErrorMessage ="Enter your email addess")]
        [EmailAddress(ErrorMessage ="Not a valid email adress")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Does not match with password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginVM
    {
        [Required(ErrorMessage = "Enter your email addess")]
        [EmailAddress(ErrorMessage = "Not a valid email adress")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}