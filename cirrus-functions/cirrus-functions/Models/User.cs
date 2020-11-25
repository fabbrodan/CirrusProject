using System;
using System.Collections.Generic;
using System.Text;

namespace cirrus_functions.Models
{
    class User
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
