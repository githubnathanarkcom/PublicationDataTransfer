using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SearchOnDemandWebinar
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Keywords { get; set; }
        public string RouteURL { get; set; }
        public string ImageUrl { get; set; }
        public string StartEndDate { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string EventDifferentType { get; set; }
    }
}