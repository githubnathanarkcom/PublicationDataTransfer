using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string sitename { get; set; }
    }
}