using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CirrusApp.Models.Account
{
    public class RegisterUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [MinLength(7, ErrorMessage = "The password must be at least 7 characters long")]
        public string Password { get; set; }
    }
}
