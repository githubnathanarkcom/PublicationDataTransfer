using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class NewsLetterSignup
    {
        public string email { get; set; }
        public bool acceptTerms { get; set; }
        public string siteName { get; set; }
        public string IP { get; set; }
    }
}