using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Models
{
    public class AppUser
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
