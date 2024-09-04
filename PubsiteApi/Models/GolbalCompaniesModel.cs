using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GolbalCompaniesModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string DomainName { get; set; }
        public string DomainURL { get; set; }
        public string Description { get; set; }
        public string EntryDate { get; set; }
        public string RouteURL { get; set; }
        public int TotalDataCount { get; set; }
        public string ManualCanonical { get; set; }
        public int ISINDEX { get; set; }
        public int IsFollow { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string ImageAltTag { get; set; }
        public string Keywords { get; set; }

    }
}