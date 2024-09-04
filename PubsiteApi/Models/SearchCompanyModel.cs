using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SearchCompanyModel
    {
        public int id { get; set; }

        public string company_name{get;set;}


        public string description { get; set; }

        public string logo { get; set; }


        public string category { get; set; }

        //public string URL { get; set; }

        public string domain_name { get; set; }

        public string Domain_Url { get; set; }

        public string RouteURL { get; set; }






    }
}