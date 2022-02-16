using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Users.Models;

namespace WorkManagement.Models.Shared
{
    public static class SessionHelper
    {
        public static User SessionUser { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public bool IsAdmin { get; set; }
    }
}
