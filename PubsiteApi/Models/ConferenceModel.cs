using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class ConferenceModel
    {

        public int EventID { get; set; }
        public string Name { get; set; }
        public string StartEndDate { get; set; }
        public string Details { get; set; }
        public int IsSponcered { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public string RouteURL { get; set; }
         public string EventDifferentType { get; set; }
    }
}