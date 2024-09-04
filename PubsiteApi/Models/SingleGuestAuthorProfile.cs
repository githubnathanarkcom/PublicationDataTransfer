using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SingleGuestAuthorProfile
    {
        public string UserCompany { get; set; }
        public string UserBio { get; set; }
        public int UserDetailsId { get; set; }
        public string UserImageprofile { get; set; }
        public string AuthorName { get; set; }
        public string LogoNew { get; set; }
        public string UserEmail { get; set; }
        public string UserJobTitle { get; set; }
        public string AuthorNameForUrl { get; set; }
        public string RouteURL { get; set; }
        public string user_facebookLink { get; set; }
        public string user_twitterLink { get; set; }
        public string user_linkedinLink { get; set; }

    }
}