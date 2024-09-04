using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SpotLightModel
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string RouteURL { get; set; }
        public int IsSponcered { get; set; }
        public string URL { get; set; }
        public string StartEndDate { get; set; }

        public string domain_name { get; set; }
        public string Tag { get; set; }
    }
}