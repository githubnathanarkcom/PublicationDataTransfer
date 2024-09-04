using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class NewsletterSubscriptions
    {
        public string Email { get; set; }
        public string IP { get; set; }
        public DateTime? Date { get; set; }
        public bool ActiveTermsandPolicy { get; set; }
        public string SiteName { get; set; }
        public string DisplayMessage { get; set; }

    }
}