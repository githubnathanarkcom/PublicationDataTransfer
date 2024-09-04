using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class NewsSpotLightModel
    {
        public int ID { get; set; }
        public string WhitePaperTitle { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string RouteURL { get; set; }
    }
}