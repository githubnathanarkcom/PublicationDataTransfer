using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class FutureNewsModel : NewsModel
    {
        public string RouteURL { get; set; }
        public string PublishingDate { get; set; }
        public string Author { get; set; }
        public int TotalDataCount { get; set; }
        public string EventDifferentType { get; set; }
        public string Tag { get; set; }
        public string ManualCanonical { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string ImageAltTag { get; set; }
        public string Keywords { get; set; }
        public string Read_time { get; set; }
        public int ISINDEX { get; set; }
        public int IsFollow { get; set; }
        public int NewsType { get; set; }

        public int SourceType { get; set; }
    }
}