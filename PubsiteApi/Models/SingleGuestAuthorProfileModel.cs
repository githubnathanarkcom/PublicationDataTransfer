using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SingleGuestAuthorProfileModel
    {
        public int CompanyId { get; set; }
        public string Comapanyname { get; set; }

        public string ImageUrl { get; set; }

        public string CompanyWebsite { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public int IsSponcered { get; set; }
    }
}