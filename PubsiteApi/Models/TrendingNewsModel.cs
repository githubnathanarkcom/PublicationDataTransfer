using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class TrendingNewsModel: NewsModel
    {
        public string Date2 { get; set; }
        public string PublishingDate { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public int TotalDataCount { get; set; }
        public string RouteURL { get; set; }
        public string EventDifferentType { get; set; }
        public string Tag { get; set; }
    }
}