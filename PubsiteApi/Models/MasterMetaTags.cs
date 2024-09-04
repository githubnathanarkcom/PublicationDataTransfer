using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class MasterMetaTags
    {
        public int Masterid { get; set; } 
        public string Site_Name { get; set; }
        public string Site_Domain { get; set; }
        public string Logo { get; set; }
        public string Flogo { get; set; }
        public string TagManager_Head { get; set; }
        public string TagManager_Body { get; set; }
        public string GA_Code { get; set; }
        public string AdRoll_Code { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string GO_sosiallink { get; set; }
        public string Media7AdvertiseLink { get; set; }
        public string PubSiteUniqueId { get; set; }
        public string color { get; set; }
        public string siteName { get; set; }

        public string ColorHover { get; set; }

        public string Headertext { get; set; }

        public string PreSite { get; set; }

    }
}