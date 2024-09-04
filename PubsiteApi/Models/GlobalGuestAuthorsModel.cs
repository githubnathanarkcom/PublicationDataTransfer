using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GlobalGuestAuthorsModel
    {
        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string ImageUrl { get; set; }

        public string RouteURL { get; set; }

        public string JobTitle { get; set; }

        public string CompanyName { get; set; }

        public string SiteName { get; set; }

        public string RoleName { get; set; }

        public string Role { get; set; }

        public int TotalDataCount { get; set; }
        public int UserDetailsId { get; set; }
        public string AuthorSummary { get; set; }

        public string UserName { get; set; }
    }
}