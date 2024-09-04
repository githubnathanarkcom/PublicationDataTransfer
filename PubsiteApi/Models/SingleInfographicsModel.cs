using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SingleInfographicsModel
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string WhitePaperTitle { get; set; }
        public string PublishingDate1 { get; set; }
        public DateTime PublishingDate { get; set; }
        public string ResourceType { get; set; }
        public string Description { get; set; }
        public string WebPageURL { get; set; }
        public string RouteURL { get; set; }
        public DateTime EntryDate { get; set; }
        public Boolean IsSponcered { get; set; }
        public string PDFUrl { get; set; }

        public string tag { get; set; }
        public string ManualCanonical { get; set; }
        public int ISINDEX { get; set; }
        public int IsFollow { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string ImageAltTag { get; set; }
        public string Keywords { get; set; }
    }
}