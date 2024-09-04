using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SearchNewsModel
    {
        public int ID { get; set; }
        public string  Description { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string CompanyName { get; set; }
        public string Author { get; set; }
        public string RouteURL { get; set; }
        public string NewsTypeName { get; set; }

        public string Tag { get; set; }
    }
}