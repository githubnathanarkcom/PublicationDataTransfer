using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class SingleInterviewModel
    {
        public class SingleInterviewEvent
        {
            public int EventID { get; set; }
            public string Name { get; set; }
            public int EventType { get; set; }
            public string ImageUrl { get; set; }
            public string StartEndDate { get; set; }
            public int IsSponcered { get; set; }
            public string Description { get; set; }
            public string Sponsors { get; set; }
        }
    }
}