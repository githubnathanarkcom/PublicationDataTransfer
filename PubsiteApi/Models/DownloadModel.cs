using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class DownloadModel
    {
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public string ResourceType { get; set; }
        public int ResourceID { get; set; }
        public Boolean AcceptTermsOnDownload { get; set; }
        public string SiteName { get; set; }

    }
}