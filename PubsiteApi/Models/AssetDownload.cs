using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class AssetDownload
    {
        public string siteName { get; set; }
        public string email { get; set; }
        public string iPAddress { get; set; }
        public string resourceID { get; set; }
        public string resourceType { get; set; }
        public bool acceptTerms { get; set; }
    }
}