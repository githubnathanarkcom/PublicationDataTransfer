using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GetmetaCodemodel
    {
        public int Dtl_id { get; set; }
        public string PageName { get; set; }
        public string HeaderText { get; set; }
        public string PageUrl { get; set; }
        public string OgImageURL { get; set;}
        public string PageTitle { get; set; }
        public string OgKeyWords { get; set; }
        public string OgDescription { get; set; }
        public string OgTitle { get; set; }
        public string LogoUrl { get; set; }
        public string PubsiteName { get; set; }
        public string PubsitePage { get; set; }
        public int IsSponcered { get; set; }
    }
}