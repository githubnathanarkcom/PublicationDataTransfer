using System;

namespace PubsiteApi.Models
{
    public class GlobalWebinarsModel
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string StartEndDate { get; set; }
        public string ImageUrl { get; set; }
        public string URL { get; set; }
        public string DateWithStartTime { get; set; }
        public int IsSponcered { get; set; }
        public string RouteURL { get; set; }
        public string Country { get; set; }
        public string eventtype { get; set; }
        public Boolean IsActive { get; set; }
        public int TotalDataCount { get; set; }

        public string EventDifferentType { get; set; }
    }
}