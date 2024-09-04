using PubsiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PubsiteApi.Models
{
    public class Home
    {
    }
    public class Interview
    {
        
        public int InterviewId { get; set; }
        public string InterviewTitle { get; set; }
        public string CategoryTag { get; set; }
        public string Designation { get; set; }
        public string InterviewDetails { get; set; }
        public string IntervieweePerson { get; set; }
        public int InterviewerID { get; set; }
        public string InterviewImage { get; set; }
        public int CompanyID { get; set; }
        public string InterviewType { get; set; }
        public DateTime Interviewdate { get; set; }

        public string NewInterviewDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IsActive { get; set; }
        public string AudioVideoURL { get; set; }
        public string KeyWords { get; set; }
        public string VideoType { get; set; }
        public string ViewCount { get; set; }
        public string MainImage { get; set; }
        public string MobileImage { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public string Quote1 { get; set; }
        public string Quote2 { get; set; }
        public string Quote3 { get; set; }
        public string Desc4 { get; set; }
        public string AboutCompany { get; set; }
        public string InterviewTakenBy { get; set; }
        public string CompanyDomain { get; set; }
        public string CompanyName { get; set; }
        public DateTime UpdateDate { get; set; }
        public string InterviewPDFImage { get; set; }
        public string CompanyLogo { get; set; }
        public string RouteURL { get; set; }
        public string MetaDescription { get; set; }
        public string IsshowonDeck7 { get; set; }

        public string InterviewDate { get; set; }
        public string Publishedsite { get; set; }
        public string ManualCanonical { get; set; }
        public int ISINDEX { get; set; }
        public int IsFollow { get; set; }
        public string MetaTitle { get; set; }
        public string ImageAltTag { get; set; }
        public string Read_time { get; set; }
    }
    public class Spotlite
    {
        public int id { get; set; }
        public string company_name { get; set; }

        public string description { get; set; }

        public string logo { get; set; }

        public string domain_name { get; set; }

        public string RouteURL { get; set; }

    }
    /// <summary>
    /// Event and webinar the detabase feild is common
    /// </summary>
    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string NamURLe { get; set; }
        public string EventType { get; set; }
        public string Keywords { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string Sponsors { get; set; }
        public DateTime EntryDate { get; set; }
        public Boolean IsSponcered { get; set; }
        public string Username { get; set; }
        public int RedirectID { get; set; }
        public string isNotificationSent { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string UniqueAnkTokenM7 { get; set; }
        public string ApprovePending { get; set; }

        public string NotApproved { get; set; }
        public string IsActive { get; set; }
        public string RouteURL { get; set; }
        public string StartEndDate { get; set; }
        public string DateWithStartTime { get; set; }

        public string CompanyName { get; set; }
        public string EventDifferentType { get; set; }

        public string URL { get; set; }

   
    }
    public class News
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string date { get; set; }
        public string Month { get; set; }
        public string SourceType { get; set; }
        public string CompanyName { get; set; } 
        public string Tag { get; set; }
    }

    public class Resources
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }
        public string ImageURL { get; set; }
        public string WhitePaperTitle { get; set; }
        public string Description { get; set; }

        public string ResourceType { get; set; }

        public string RouteURL { get; set; }
        public int TotalDataCount { get; set; }
        public string Tag { get; set; }
        public string EntryDate { get; set; }
    }
}
