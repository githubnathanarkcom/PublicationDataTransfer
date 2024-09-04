using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SessionModel
    {
        public string UserID { get; set; }
        public string IPAddress { get; set; }
        public long IPAddressConverted { get; set; }
        public string EmailID { get; set; }
        public string SiteName { get; set; }
        public string Medium { get; set; }
        public string Url { get; set; }
        public string PreviousUrl { get; set; }
        public string Details { get; set; }
    }
}