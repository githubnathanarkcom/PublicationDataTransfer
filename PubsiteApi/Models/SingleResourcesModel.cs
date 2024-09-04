using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SingleResourcesModel
    {
        public int ID { get; set; }
        public string WhitePaperTitle { get; set; }
        public string Description { get; set; }
        public string author { get; set; }
        public DateTime EntryDate { get; set; }
        public string description2 { get; set; }
        public string description3 { get; set; }
        public string description4 { get; set; }
        public string author_description { get; set; }
        public string author_ImageURL { get; set; }
        public string webpageurl { get; set; }
        public string pdfurl { get; set; }
        public string imageurl { get; set; }
        public string imageurl2 { get; set; }
        public string imageurl3 { get; set; }
        public string imageurl4 { get; set; }
        public string ResourceType { get; set; }
        public string EmbadedVideoUrl { get; set; }
        public string VideoType { get; set; }
        public string EmbedVideoCode { get; set; }
        public string AuthorReal { get; set; }
        public string keywords { get; set; }
        public string PublishingDate1 { get; set; }
        public DateTime PublishingDate { get; set; }
        //public bool IsSponcered { get; set; }
        public bool IsSponcered { get; set; }
        public string DisplayPreviewImage { get; set; }
        public string tag { get; set; }
        public int SourcceType { get; set; }
        public string UserName { get; set; }
        public string RouteURL { get; set; }
        public int UserId { get; set; }
        public string authorName { get; set; }
        public string ManualCanonical { get; set; }
        public int ISINDEX { get; set; }
        public int IsFollow { get; set; }
        public int Hit_Counter { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string ImageAltTag { get; set; }
        public string Read_time { get; set; }
        public string TagURL { get; set; }
    }
}