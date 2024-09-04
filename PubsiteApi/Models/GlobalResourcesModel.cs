using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GlobalResourcesModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string WhitePaperTitle { get; set; }
        public string PublishingDate1 { get; set; }
        public DateTime PublishingDate { get; set; }
        public string ResourceType { get; set; }
        public string Description { get; set; }
        public string WebPageURL { get; set; }
        public string RouteURL { get; set; }
        public DateTime EntryDate { get; set; }
        public Boolean IsSponcered { get; set; }
        public int TotalDataCount { get; set; }
        public string Tag { get; set; }
    }
}