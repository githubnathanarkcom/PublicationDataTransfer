using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class GlobalEventWebinarsModel
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string URL { get; set; }
        public Boolean IsSponcered { get; set; }
        public string RouteURL { get; set; }
        public string Country { get; set; }
        public string DateWithStartTime { get; set; }
        public int TotalDataCount { get; set; }
        public string ManualCanonical { get; set; }
        public int ISINDEX { get; set; }
        public int IsFollow { get; set; }
        public string Sponsors { get; set; }
        public int IsActive { get; set; }
        public int EventType { get; set; }
        public string EventDifferentType { get; set; }
        public string  Keywords{get;set;}
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string  MetaTitle{get;set;}
        public string MetaDescription { get; set; }
        public string ImageAltTag { get; set; }
        public string EventTypeSchema { get; set; }
        public string location_Name { get; set; }
        public string StreetAddress { get; set; }
        public string AddressLocality { get; set; }
        public string PostalCode { get; set; }
        public string Performer_Name { get; set; }
        public string Organizer_Url { get; set; }
        public string Region { get; set; }

    }
}