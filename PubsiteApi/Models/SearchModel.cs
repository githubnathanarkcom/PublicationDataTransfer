using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SearchModel
    {

        public int EventID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public string Keywords { get; set; }
        public string RouteURL { get; set; }
       

        public string ImageUrl { get; set; }


        public string StartEndDate { get; set; }

    

        public string Country { get; set; }
        public string Timezone { get; set; }


        public string EventDifferentType { get; set; }

        //public string Sponsors { get; set; }

        //public string WhitePaperTitle { get; set; }


        //public string Description { get; set; }

        //public string Author { get; set; }

        //public string AuthorReal { get; set; }

        //public string company_description { get; set; }


        //public string author_description { get; set; }


        //public string description2 { get; set; }


        //public string description3 { get; set; }

        //public string description4 { get; set; }


    }
}