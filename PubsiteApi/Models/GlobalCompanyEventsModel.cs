using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GlobalCompanyEventsModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string URL { get; set; }
        public string Keywords { get; set; }
        public int IsSponcered { get; set; }
        public string RouteURL { get; set; }
        public string EventType { get; set; }
        public string ImageUrl { get; set; }
    }
}