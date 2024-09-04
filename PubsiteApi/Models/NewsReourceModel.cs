using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class NewsReourceModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string WhitePaperTitle { get; set; }
        public string Description { get; set; }
        public string ResourceType { get; set; }
        public int IsSponcered { get; set; }
        public string RouteURL { get; set; }
        public string keywords { get; set; }
        public string Tag { get; set; }
    }
}