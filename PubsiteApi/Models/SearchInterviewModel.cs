using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SearchInterviewModel
    {
        public int InterviewID { get; set; }

        public string InterviewTitle { get; set; }

        public string InterviewImage { get; set; }


        public string InterviewDate { get; set; }

        public string InterviewDetails { get; set; }

        public string IntervieweePerson { get; set; }


        public string InterviewType { get; set; }

        public string Keywords { get; set; }

        public string CompanyDomain { get; set; }

        public string AboutCompany { get; set; }

        public string RouteURL { get; set; }


        public string CompanyName { get; set; }

    }
}