using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CirrusApp.Models.Account
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime UserRegistered { get; set; }
        public Guid id { get; set; }
    }
}
