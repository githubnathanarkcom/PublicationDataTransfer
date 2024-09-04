using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SearchResouceModel
    {
        public int ID { get; set; }

        public string WhitePaperTitle { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }
        public DateTime EntryDate { get; set; }
        public string PublishingDate1 { get; set; }

        public string PublishingDate { get; set; }


        public string RouteURL { get; set; }

        public string ResourceType { get; set; }
        public string ResourceType2 { get; set; }



        //public string CompanyDomain { get; set; }

        //public string AboutCompany { get; set; }

        ////public string InterViewTakenBy { get; set; }



        //public string Title { get; set; }

        //public string Source { get; set; }


        //public string Keywords { get; set; }

        //public string Industry { get; set; }


        //public string CompanyName { get; set; }





        //public string AuthorReal { get; set; }

        //public string company_description { get; set; }


        //public string author_description { get; set; }


        //public string description2 { get; set; }


        //public string description3 { get; set; }

        //public string description4 { get; set; }

        //public string Sponsors { get; set; }


    }
}