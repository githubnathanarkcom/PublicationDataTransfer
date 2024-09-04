using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GlobalCompanyCSuiteOnDecModel
    {
        public int InterviewID { get; set; }
        public string InterviewImage { get; set; }
        public string InterviewTitle { get; set; }
        public string InterviewDetails { get; set; }
        public string InterviewDate { get; set; }
        public string Name { get; set; }
        public string PublishedSite { get; set; }
        public string RouteURL { get; set; }
        public string Categorytag { get; set; }
        public int TotalDataCount { get; set; }
    }
}