using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    public class AppUser:IdentityUser
    {
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public DateTime BirthDay { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
