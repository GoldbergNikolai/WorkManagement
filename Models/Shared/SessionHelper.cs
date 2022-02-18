using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Users.Models;

namespace WorkManagement.Models.Shared
{
    public class SessionHelper
    {
        public int UserId { get; set; }
        public bool Active { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
