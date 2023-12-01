using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportManagement.Models.Entities
{
    public class LoginFromApi
    {
        public string Email { get; set; }
        public string password { get; set; }
        public string type { get; set; }
    }
}