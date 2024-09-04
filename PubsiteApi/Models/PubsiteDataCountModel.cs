using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class PubsiteDataCountModel
    {
        public string UpcommingConferencesCount { get; set; }
        public string PastConferencesCount { get; set; }
        public string TotalLivewebinarCount { get; set; }
        public string UpcommingLivewebinarCount { get; set; }
        public string OndemandwebinarCount { get; set; }
        public string WhitepaperCount { get; set; }
        public string VideoCount { get; set; }
        public string InfographicsCount { get; set; }
        public string ArticleCount { get; set; }
        public string FeaturedNewsCount { get; set; }
        public string TrendingNewsCount { get; set; }
        public string CompanyCount { get; set; }
    }
}