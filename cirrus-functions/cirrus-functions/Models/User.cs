using System;

namespace cirrus_functions.Models
{
    class User
    {
        public string id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime UserRegistered { get; set; }
    }
}
