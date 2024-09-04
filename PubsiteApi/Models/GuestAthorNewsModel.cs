using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GuestAthorNewsModel
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublishingDate { get; set; }
        public int TotalDataCount { get; set; }
    }
}