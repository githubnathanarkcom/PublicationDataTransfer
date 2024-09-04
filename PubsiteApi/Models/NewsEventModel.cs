using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class NewsEventModel
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string RouteURL { get; set; }
        public string EventType { get; set; }
        public int IsSponcered { get; set; }
        public string Description { get; set; }
    }
}