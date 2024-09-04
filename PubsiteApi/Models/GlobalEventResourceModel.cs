using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GlobalEventResourceModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }

        public string WhitePaperTitle { get; set; }

        public int IsSponcered { get; set; }

        public string RouteURL { get; set; }
        public string Tag { get; set; }
        public string ResourceType { get; set; }

    }
}