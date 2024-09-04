using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace PubsiteApi.Controllers
{
    public class PubSiteDataNewController : ApiController
    {
        private SqlConnection Connection()
        {
            string tableName = "abm";
            if (CurrentSite != null)
                tableName = CurrentSite.SiteTableName;
            if (tableName == "pharmaceutical" || tableName == "smallbusiness")
                return new SqlConnection("Data Source=3.108.12.178; Initial Catalog=GeneReport; User ID=GeneReport1; Password=75j]G)sC");
            else
                return new SqlConnection("Data Source=3.108.12.178; Initial Catalog=theiotrep; User ID=theiotrep1; Password=8g)mB9w3");
            //return new SqlConnection("Data Source=MACH-PC189; Initial Catalog=NAEventuallyDB; User ID=sa; Password=machintel@123");
        }

        private SqlConnection NAMedia7Connection()
        {
            try
            {
                return new SqlConnection("Data Source=3.108.12.178;User ID=NAMEDIA7io1;Initial Catalog=NAMEDIA7io; Password=L/[BBe9D");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //private string DomainName
        //{
        //    get
        //    {
        //        return "https://humanresources.report/";
        //    }
        //}

        //private string DbName
        //{
        //    get
        //    {
        //        return "humanresources";
        //    }
        //}

        private Sites CurrentSite
        {
            get; set;
        }

        private string NewImageUrl
        {
            get
            {
                return "https://mmpubsitesv2.s3.ap-south-1.amazonaws.com/";
            }
        }

        private string OldImageUrl
        {
            get
            {
                return "https://HumanResources.Report";
            }
        }

        private List<Sites> siteList = new List<Sites>();


        [HttpGet]
        public IHttpActionResult GetSites()
        {
            DataSet dsSites = null;
            dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            return Ok(sites);
        }

        [HttpGet]
        public IHttpActionResult GetCompanies()
        {
            DataSet dsCompanies = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            //sites = sites.Where(site => site.SiteSlug == "humanresources").ToList();
            List<Companies> allCompanies = new List<Companies>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsCompanies = GetCompanyDetails();
                List<Companies> companies = PopulateCompanyList(dsCompanies);
                allCompanies.AddRange(companies);
            }
            if (allCompanies.Count == 0)
                return NotFound();
            DataTable dt = allCompanies.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\Companies.xlsx");
            return Ok(allCompanies);
        }


        [HttpGet]
        public IHttpActionResult GetGlobalCompaniesPage()
        {
            DataSet dsGlobalCompaniesPage = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            List<GlobalCompaniesPage> allGlobalCompanies = new List<GlobalCompaniesPage>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsGlobalCompaniesPage = GetGlobalCompaniesPageDetails();
                List<GlobalCompaniesPage> globalCompanies = PopulateGlobalCompaniesPageList(dsGlobalCompaniesPage);
                allGlobalCompanies.AddRange(globalCompanies);
            }
            if (allGlobalCompanies.Count == 0)
                return NotFound();
            DataTable dt = allGlobalCompanies.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\GlobalCompaniesPage.xlsx");

            return Ok(allGlobalCompanies);
        }

        public IHttpActionResult GetGuestAuthors()
        {
            DataSet dsGuestAuthors = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            //sites = sites.Where(site => site.SiteSlug == "humanresources").ToList();
            List<GuestAuthors> allGuestAuthors = new List<GuestAuthors>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsGuestAuthors = GetGuestAuthorDetails();
                List<GuestAuthors> guestAuthor = PopulateGuestAuthorsList(dsGuestAuthors);
                allGuestAuthors.AddRange(guestAuthor);
            }
            if (allGuestAuthors.Count == 0)
                return NotFound();
            DataTable dt = allGuestAuthors.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\GuestAuthors.xlsx");

            return Ok(allGuestAuthors);

        }

        public IHttpActionResult GetInterviews()
        {
            DataSet dsInterviews = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            List<Interviews> allInterviews = new List<Interviews>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsInterviews = GetInterviewDetails();
                List<Interviews> interviews = PopulateInterviewList(dsInterviews);
                allInterviews.AddRange(interviews);
            }
            if (allInterviews.Count == 0)
                return NotFound();

            DataTable dt = allInterviews.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\Interviews.xlsx");

            return Ok(allInterviews);
        }

        public IHttpActionResult GetNews()
        {
            DataSet dsNews = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            List<News> allNews = new List<News>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsNews = GetNewsDetails();
                List<News> news = PopulateNewsList(dsNews);
                allNews.AddRange(news);
            }
            if (allNews.Count == 0)
                return NotFound();
            DataTable dt = allNews.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\News.xlsx");

            return Ok(allNews);
        }

        public IHttpActionResult GetEvents()
        {
            DataSet dsEvents = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            List<Events> allEvents = new List<Events>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsEvents = GetEventDetails();
                List<Events> events = PopulateEventsList(dsEvents);
                allEvents.AddRange(events);
            }
            if (allEvents.Count == 0)
                return NotFound();

            DataTable dt = allEvents.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\Events.xlsx");

            return Ok(allEvents);
        }

        public IHttpActionResult GetResources()
        {
            DataSet dsResources = null;
            DataSet dsSites = GetSiteDetails();
            List<Sites> sites = PopulateSiteList(dsSites);
            List<Resources> allResources = new List<Resources>();
            foreach (Sites site in sites)
            {
                CurrentSite = site;
                dsResources = GetResourceDetails();
                List<Resources> resources = PopulateResourcesList(dsResources);
                allResources.AddRange(resources);
            }

            if (allResources.Count == 0)
                return NotFound();
            DataTable dt = allResources.ToDataTable();
            StaticClass.WriteToExcel(dt, @"C:\office\Terminus\Data\Resources.xlsx");
            return Ok(allResources);
        }

        private List<Sites> PopulateSiteList(DataSet dsSites)
        {
            DataTable dt = dsSites.Tables[0];
            List<Sites> sites = new List<Sites>();
            siteList = new List<Sites>();

            foreach (DataRow dr in dt.Rows)
            {
                Sites site = new Sites();
                site.SiteName = dr["SiteName"].ToString();
                site.SiteSlug = CalculateSlug(dr["SiteSlug"] as string);
                site.SiteUrl = (dr["SiteUrl"] as string);
                site.SiteOldUrl = (dr["SiteUrl"] as string);
                site.SiteUrl = NewImageUrl + site.SiteSlug;
                site.SiteTableName = site.SiteSlug;
                if (site.SiteSlug == "biotechnology")
                    site.SiteTableName = "biotech";
                site.InterviewMedia7FlagName = site.SiteSlug + "_report";
                if (site.SiteSlug == "virtualization")
                    site.InterviewMedia7FlagName = site.SiteSlug + "_network";
                //company.Interviews = new string[0];
                //if (!(site.SiteSlug=="pharmaceutical" || site.SiteSlug == "smallbusiness" || site.SiteSlug=="virtualization"))
                sites.Add(site);
                siteList.Add(site);
            }
            //sites = sites.Where(s => s.SiteSlug == "informationsecurity").ToList();
            //sites = sites.Where(s => s.SiteSlug == "cloud").ToList();
            //sites = sites.Where(s => s.SiteSlug == "dataanalytics").ToList();
            //sites = sites.Where(s => s.SiteSlug == "infotech").ToList();
            //sites = sites.Where(s => s.SiteSlug == "advertising").ToList();
            //sites = sites.Where(s => s.SiteSlug == "capital").ToList();

            //sites = sites.Where(s => s.SiteSlug == "channel").ToList();
            //sites = sites.Where(s => s.SiteSlug == "manufacturing").ToList();
            //sites = sites.Where(s => s.SiteSlug == "pos").ToList();
            //sites = sites.Where(s => s.SiteSlug == "humanresources").ToList();
            //sites = sites.Where(s => s.SiteSlug == "abm").ToList();
            //sites = sites.Where(s => s.SiteSlug == "aviation").ToList();
            sites = sites.Where(s => s.SiteSlug == "biotechnology").ToList();
            return sites;
        }

        private List<GlobalCompaniesPage> PopulateGlobalCompaniesPageList(DataSet dsGlobalCompanies)
        {
            DataTable dt = dsGlobalCompanies.Tables[0];
            List<GlobalCompaniesPage> globalCompanies = new List<GlobalCompaniesPage>();

            foreach (DataRow dr in dt.Rows)
            {
                GlobalCompaniesPage globalCompanyPage = new GlobalCompaniesPage();
                globalCompanyPage.ID = (dr["CompanyID"] as string);
                globalCompanyPage.CompanyName = (dr["CompanyName"] as string);
                globalCompanyPage.Description = (dr["Description"] as string);
                globalCompanyPage.Logo = ReplaceTilda(dr["Logo"] as string);
                globalCompanyPage.DomainName = (dr["DomainName"] as string);
                globalCompanyPage.IsActive = (dr["IsActive"] as string).ToLower();
                globalCompanyPage.PageSection = (dr["PageSection"] as string);
                globalCompanyPage.Site = (dr["Site"] as string);
                globalCompanyPage.SiteSlug = (dr["SiteSlug"] as string);
                globalCompanyPage.CategoryTag = (dr["CategoryTag"] as string);

                globalCompanyPage.RouteUrl = (dr["RouteURL"] as string);
                globalCompanyPage.LogoAltTag = (dr["ImageAltTag"] as string);
                globalCompanyPage.Url = null;
                globalCompanyPage.EntryDate = ConvertDateTimeToString(dr["EntryDate"] as DateTime?);
                if (!string.IsNullOrWhiteSpace((dr["DomainName"] as string)))
                    globalCompanyPage.Url = "https://" + (dr["DomainName"] as string);
                globalCompanyPage.Interviews = SplitString(Uri.EscapeDataString(dr["InterviewDetails"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                globalCompanyPage.News = SplitString(Uri.EscapeDataString(dr["News"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                globalCompanyPage.Events = SplitString(Uri.EscapeDataString(dr["Events"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                globalCompanyPage.Resources = SplitString(Uri.EscapeDataString(dr["Resources"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                globalCompanyPage.Metadata = GetMetadata(dr);
                //globalCompanyPage.Interviews = new string[0];
                //globalCompanyPage.News = new string[0];
                //globalCompanyPage.Events = new string[0];
                //globalCompanyPage.Resources = new string[0];
                globalCompanies.Add(globalCompanyPage);
            }

            return globalCompanies;
        }


        private List<Companies> PopulateCompanyList(DataSet dsCompanyDetails)
        {
            DataTable dt = dsCompanyDetails.Tables[0];
            List<Companies> companies = new List<Companies>();

            foreach (DataRow dr in dt.Rows)
            {
                Companies company = new Companies();
                company.ID = dr["ID"].ToString();
                company.DomainName = (dr["Domain_Name"] as string);
                company.RouteUrl = (dr["RouteURL"] as string);
                company.Name = (dr["Company_Name"] as string);
                company.IsActive = dr["IsActive"].ToString().ToLower();
                company.Description = (dr["Description"] as string);
                //company.Logo = CurrentSite.SiteUrl + (dr["Logo"].ToString().Substring(1) as string);
                company.Logo = ReplaceTilda(dr["Logo"] as string);
                company.LogoAltTag = (dr["ImageAltTag"] as string);
                company.CategoryTag = (dr["Category"] as string);
                company.Url = null;
                company.EntryDate = ConvertDateTimeToString(dr["EntryDate"] as DateTime?);
                if (!string.IsNullOrWhiteSpace((dr["Domain_Name"] as string)))
                    company.Url = "https://" + (dr["Domain_Name"] as string);
                company.Metadata = GetMetadata(dr);
                company.IsIndex = company.Metadata.IsIndex;
                company.IsFollow = company.Metadata.IsFollow;
                company.ManualCanonical = company.Metadata.ManualCanonical;
                company.MetaTitle = company.Metadata.MetaTitle;
                company.MetaDescription = company.Metadata.MetaDescription;
                company.Keywords = company.Metadata.Keywords;
                //company.Interviews = SplitString(dr["InterviewDetails"].ToString());
                company.Interviews = SplitString(Uri.EscapeDataString(dr["InterviewDetails"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                company.News = SplitString(Uri.EscapeDataString(dr["News"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                company.Events = SplitString(Uri.EscapeDataString(dr["Events"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                company.Resources = SplitString(Uri.EscapeDataString(dr["Resources"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                company.Site = (dr["Site"] as string);
                company.SiteSlug = (dr["SiteSlug"] as string);
                //company.Interviews = new string[0];
                //company.News = new string[0];
                //company.Events = new string[0];
                //company.Resources = new string[0];
                companies.Add(company);
            }

            return companies;
        }

        private List<GuestAuthors> PopulateGuestAuthorsList(DataSet dsGuestAuthors)
        {
            DataTable dt = dsGuestAuthors.Tables[0];
            List<GuestAuthors> guestAuthors = new List<GuestAuthors>();

            foreach (DataRow dr in dt.Rows)
            {
                GuestAuthors guestAuthor = new GuestAuthors();
                guestAuthor.ID = dr["ID"].ToString();
                guestAuthor.FirstName = (dr["FirstName"] as string);
                guestAuthor.LastName = (dr["LastName"] as string);
                guestAuthor.Company = (dr["Company"] as string);
                guestAuthor.IsActive = dr["IsActive"].ToString().ToLower();
                guestAuthor.JobTitle = (dr["JobTitle"] as string);
                //company.Logo = CurrentSite.SiteUrl + (dr["Logo"].ToString().Substring(1) as string);
                guestAuthor.Email = (dr["Email"] as string);
                guestAuthor.ProfileImage = (dr["ProfileImage"] as string);
                guestAuthor.Role = (dr["Role"] as string);
                guestAuthor.RouteUrl = (dr["RouteUrl"] as string);
                guestAuthor.Bio = (dr["Bio"] as string);
                guestAuthor.FacebookLink = (dr["FacebookLink"] as string);
                guestAuthor.TwitterLink = (dr["TwitterLink"] as string);
                guestAuthor.LinkedinLink = (dr["LinkedinLink"] as string);
                guestAuthor.AuthorName = (dr["AuthorName"] as string);
                guestAuthor.Slug = (dr["Slug"] as string);
                //guestAuthor.Metadata = GetMetadata(dr);
                guestAuthor.Site = (dr["Site"] as string);
                guestAuthor.SiteSlug = (dr["SiteSlug"] as string);

                guestAuthor.CompanyName = (dr["CompanyName"] as string);
                guestAuthor.CompanyWebsite = (dr["CompanyWebsite"] as string);
                guestAuthor.CompanyLogo = (dr["CompanyLogo"] as string);
                guestAuthor.CompanyDescription = (dr["CompanyDescription"] as string);
                guestAuthor.Resources = (SplitString(Uri.EscapeDataString(dr["Resources"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ",")));

                guestAuthors.Add(guestAuthor);
            }

            return guestAuthors;
        }

        private List<Companies> PopulateGuestAuthorList(DataSet dsGuestAuthorDetails)
        {
            DataTable dt = dsGuestAuthorDetails.Tables[0];
            List<Companies> companies = new List<Companies>();

            foreach (DataRow dr in dt.Rows)
            {
                Companies company = new Companies();
                company.ID = dr["ID"].ToString();
                company.DomainName = (dr["Domain_Name"] as string);
                company.RouteUrl = (dr["RouteURL"] as string);
                company.Name = (dr["Company_Name"] as string);
                company.IsActive = dr["IsActive"].ToString().ToLower();
                company.Description = (dr["Description"] as string);
                //company.Logo = CurrentSite.SiteUrl + (dr["Logo"].ToString().Substring(1) as string);
                company.Logo = ReplaceTilda(dr["Logo"] as string);
                company.LogoAltTag = (dr["ImageAltTag"] as string);
                company.CategoryTag = (dr["Category"] as string);
                company.Url = null;
                company.EntryDate = ConvertDateTimeToString(dr["EntryDate"] as DateTime?);
                if (!string.IsNullOrWhiteSpace((dr["Domain_Name"] as string)))
                    company.Url = "https://" + (dr["Domain_Name"] as string);
                company.Metadata = GetMetadata(dr);
                company.Interviews = SplitString(Uri.EscapeDataString(dr["InterviewDetails"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","));
                company.Site = (dr["Site"] as string);
                company.SiteSlug = (dr["SiteSlug"] as string);
                //company.Interviews = new string[0];
                companies.Add(company);
            }

            return companies;
        }

        private string[] SplitString(string commaSeparatedString)
        {
            string[] array = new string[0];
            if (!string.IsNullOrWhiteSpace(commaSeparatedString))
                array = commaSeparatedString.Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            return array;
        }

        private List<Interviews> PopulateInterviewList(DataSet dsInterViewDetails)
        {
            DataTable dt = dsInterViewDetails.Tables[0];
            List<Interviews> interviews = new List<Interviews>();
            foreach (DataRow dr in dt.Rows)
            {
                Interviews interview = new Interviews();
                interview.ID = dr["InterviewID"].ToString();
                interview.InterviewTitle = (dr["InterviewTitle"] as string);
                interview.CategoryTag = (dr["CategoryTag"] as string);
                interview.Designation = (dr["Designation"] as string);
                interview.InterviewDetails = (dr["InterviewDetails"] as string);
                interview.IntervieweePerson = (dr["IntervieweePerson"] as string);
                interview.InterviewImageAltTag = (dr["ImageAltTag"] as string);
                interview.InterviewImage = (dr["InterviewImage"] as string);
                interview.InterviewType = ConvertToEnumInterviewType(dr["InterviewType"].ToString());
                interview.InterviewDate = ConvertDateTimeToString(dr["InterviewDate"] as DateTime?);
                interview.IsActive = dr["IsActive"].ToString().ToLower();
                interview.MobileImage = (dr["MobileImage"] as string);
                interview.Desc2 = (dr["Desc2"] as string);
                interview.Desc3 = (dr["Desc3"] as string);
                interview.Desc4 = (dr["Desc4"] as string);
                interview.Quote1 = (dr["Quote1"] as string);
                interview.Quote2 = (dr["Quote2"] as string);
                interview.Quote3 = (dr["Quote3"] as string);
                interview.AboutCompany = (dr["AboutCompany"] as string);
                interview.InterviewTakenBy = (dr["InterviewTakenBy"] as string);
                interview.CompanyDomain = (dr["CompanyDomain"] as string);
                interview.CompanyName = (dr["CompanyName"] as string);
                interview.CompanyLogo = ReplaceTilda(dr["CompanyLogo"] as string);
                interview.RouteURL = (dr["RouteURL"] as string);
                interview.ReadTime = (dr["ReadTime"] as string);
                interview.PublishedSite = (dr["PublishedSite"] as string);
                interview.InterviewCategory = (dr["InterviewCategory"] as string);
                interview.Company = Uri.EscapeDataString(dr["Company"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ",");
                if (string.IsNullOrWhiteSpace(interview.Company))
                    interview.Company = null;
                interview.Site = (dr["Site"] as string);
                interview.SiteSlug = (dr["SiteSlug"] as string);
                interview.Metadata = GetMetadata(dr);
                interview.IsIndex = interview.Metadata.IsIndex;
                interview.IsFollow = interview.Metadata.IsFollow;
                interview.ManualCanonical = interview.Metadata.ManualCanonical;
                interview.MetaTitle = interview.Metadata.MetaTitle;
                interview.MetaDescription = interview.Metadata.MetaDescription;
                interview.Keywords = interview.Metadata.Keywords;

                if (string.IsNullOrWhiteSpace(interview.Company))
                    interview.Company = null;
                if (!string.IsNullOrWhiteSpace(interview.InterviewImage))
                {
                    //interview.InterviewImage = TransformUrl(interview.InterviewImage.Replace(CurrentSite.SiteOldUrl, CurrentSite.SiteUrl));
                    interview.InterviewImage = ReplaceUrlNormal(interview.InterviewImage);
                }
                if (!string.IsNullOrWhiteSpace(interview.MobileImage))
                {
                    //interview.MobileImage = TransformUrl(interview.MobileImage.Replace(CurrentSite.SiteOldUrl, CurrentSite.SiteUrl));
                    interview.MobileImage = ReplaceUrlNormal(interview.MobileImage);
                }

                interviews.Add(interview);
            }

            return interviews;
        }

        private List<News> PopulateNewsList(DataSet dsNews)
        {
            DataTable dt = dsNews.Tables[0];
            List<News> news = new List<News>();
            foreach (DataRow dr in dt.Rows)
            {
                News newsDetails = new News();
                newsDetails.ID = dr["ID"].ToString();
                newsDetails.Title = (dr["Title"] as string);
                newsDetails.Description = (dr["Description"] as string);
                newsDetails.PublishDate = ConvertDateTimeToString((DateTime?)dr["Date"]);
                //newsDetails.ImageUrl = CurrentSite.SiteUrl + "/" + ReplaceTilda(dr["ImageUrl"] as string);
                newsDetails.ImageUrl = ReplaceTilda(dr["ImageUrl"] as string);
                newsDetails.NewsType = ConvertToEnumNews(dr["NewsType"].ToString());
                newsDetails.CompanyName = (dr["CompanyName"] as string);
                newsDetails.IsActive = dr["IsActive"].ToString().ToLower();
                newsDetails.RouteURL = (dr["RouteURL"] as string);
                newsDetails.CategoryTag = (dr["Tag"] as string);
                newsDetails.ImageAltTag = (dr["ImageAltTag"] as string);
                newsDetails.ReadTime = (dr["Read_Time"] as string);
                newsDetails.Site = (dr["Site"] as string);
                newsDetails.SiteSlug = (dr["SiteSlug"] as string);
                newsDetails.Company = Uri.EscapeDataString(dr["Company"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ",");
                if (string.IsNullOrWhiteSpace(newsDetails.Company))
                    newsDetails.Company = null;
                newsDetails.Metadata = GetMetadata(dr);
                newsDetails.IsIndex = newsDetails.Metadata.IsIndex;
                newsDetails.IsFollow = newsDetails.Metadata.IsFollow;
                newsDetails.ManualCanonical = newsDetails.Metadata.ManualCanonical;
                newsDetails.MetaTitle = newsDetails.Metadata.MetaTitle;
                newsDetails.MetaDescription = newsDetails.Metadata.MetaDescription;
                newsDetails.Keywords = newsDetails.Metadata.Keywords;
                news.Add(newsDetails);
            }

            return news;
        }


        private List<Events> PopulateEventsList(DataSet dsEvents)
        {
            DataTable dt = dsEvents.Tables[0];
            List<Events> events = new List<Events>();
            foreach (DataRow dr in dt.Rows)
            {
                Events eventDetails = new Events();
                eventDetails.ID = dr["ID"].ToString();
                eventDetails.Name = (dr["Name"] as string);
                eventDetails.Description = (dr["Details"] as string);
                eventDetails.StartDate = ConvertDateTimeToString(dr["StartDate"] as DateTime?);
                eventDetails.EndDate = ConvertDateTimeToString(dr["EndDate"] as DateTime?);
                eventDetails.CompanyName = (dr["CompanyName"] as string);
                //eventDetails.ImageUrl = CurrentSite.SiteUrl + "/" + ReplaceTilda(dr["ImageUrl"] as string);
                eventDetails.ImageUrl = ReplaceTilda(dr["ImageUrl"] as string);
                eventDetails.Url = (dr["Url"] as string);
                eventDetails.RouteUrl = (dr["RouteURL"] as string);
                eventDetails.EventType = ConvertToEnumEvents(dr["EventType"].ToString());
                eventDetails.Country = (dr["Country"] as string);
                eventDetails.City = (dr["City"] as string);
                eventDetails.Sponsors = (dr["Sponsors"] as string);
                eventDetails.IsActive = dr["IsActive"].ToString().ToLower();
                eventDetails.ImageAltTag = (dr["ImageAltTag"] as string);
                eventDetails.CategoryTag = (dr["CategoryTag"] as string);
                eventDetails.PerformerName = (dr["Performer_Name"] as string);
                eventDetails.OrganizerUrl = (dr["Organizer_Url"] as string);
                eventDetails.Site = (dr["Site"] as string);
                eventDetails.SiteSlug = (dr["SiteSlug"] as string);
                eventDetails.Metadata = GetMetadata(dr);
                eventDetails.IsIndex = eventDetails.Metadata.IsIndex;
                eventDetails.IsFollow = eventDetails.Metadata.IsFollow;
                eventDetails.ManualCanonical = eventDetails.Metadata.ManualCanonical;
                eventDetails.MetaTitle = eventDetails.Metadata.MetaTitle;
                eventDetails.MetaDescription = eventDetails.Metadata.MetaDescription;
                eventDetails.Keywords = eventDetails.Metadata.Keywords;
                eventDetails.Company = Uri.EscapeDataString(dr["Company"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ",");
                if (string.IsNullOrWhiteSpace(eventDetails.Company))
                    eventDetails.Company = null;
                events.Add(eventDetails);
            }

            return events;
        }

        private List<Resources> PopulateResourcesList(DataSet dsResources)
        {
            DataTable dt = dsResources.Tables[0];
            List<Resources> resources = new List<Resources>();
            string resourceType = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                Resources resourceDetails = new Resources();
                resourceDetails.ID = dr["ID"].ToString();
                resourceDetails.Title = (dr["WhitePaperTitle"] as string);
                resourceDetails.Description = Utils.HtmlDecode(dr["Description"] as string);
                resourceDetails.AuthorName = (dr["Author"] as string);
                resourceDetails.CompanyName = (dr["AuthorReal"] as string);
                resourceDetails.PdfUrl = ReplaceTilda(dr["PdfUrl"] as string);
                resourceDetails.ImageUrl = ReplaceTilda(dr["ImageUrl"] as string);
                resourceDetails.EmbeddedVideoURl = (dr["EmbadedVideoURl"] as string);
                resourceDetails.HitCounter = checkIfNum(dr["Hit_Counter"].ToString());
                resourceDetails.ResourceType = ConvertToEnumResources(dr["ResourceType"] as string);
                resourceDetails.IsActive = dr["IsActive"].ToString().ToLower();
                resourceDetails.IsSponcered = dr["IsSponcered"].ToString().ToLower();
                resourceDetails.PublishingDate = ConvertDateTimeToString((DateTime?)dr["PublishingDate"]);
                resourceDetails.RouteURL = (dr["RouteURL"] as string);
                resourceDetails.CategoryTag = (dr["Tag"] as string);
                resourceDetails.ImageAltTag = (dr["ImageAltTag"] as string);
                resourceDetails.ReadTime = (dr["Read_Time"] as string);
                resourceDetails.UserName = (dr["UserName"] as string);
                resourceDetails.Site = (dr["Site"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ","); ;
                resourceDetails.SiteSlug = (dr["SiteSlug"] as string);
                resourceDetails.Metadata = GetMetadata(dr);
                resourceDetails.IsIndex = resourceDetails.Metadata.IsIndex;
                resourceDetails.IsFollow = resourceDetails.Metadata.IsFollow;
                resourceDetails.ManualCanonical = resourceDetails.Metadata.ManualCanonical;
                resourceDetails.MetaTitle = resourceDetails.Metadata.MetaTitle;
                resourceDetails.MetaDescription = resourceDetails.Metadata.MetaDescription;
                resourceDetails.Keywords = resourceDetails.Metadata.Keywords;
                resourceType = dr["ResourceType"] as string;
                resourceDetails.Company = Uri.EscapeDataString(dr["Company"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ",");
                if (string.IsNullOrWhiteSpace(resourceDetails.Company))
                    resourceDetails.Company = null;
                if (!string.IsNullOrWhiteSpace(resourceType) && Regex.IsMatch(resourceType, "landingpage|whitePaper|blog article|GuestAuthor", RegexOptions.IgnoreCase))
                    resourceDetails.GuestAuthors = (SplitString(Uri.EscapeDataString(dr["GuestAuthors"].ToString()).Replace("slash", "/").Replace("plus", "+").Replace("comma", ",")));
                else
                    resourceDetails.GuestAuthors = new string[0];
                //resourceDetails.GuestAuthors = new string[0];
                resourceDetails.Description = ReplaceUrl(resourceDetails.Description);
                resources.Add(resourceDetails);
            }

            return resources;
        }

        public string checkIfNum(string num)
        {
            string retValue = null;
            long result;
            if (long.TryParse(num, out result))
            {
                retValue = num;
            }

            return retValue;
        }
        private string ReplaceTilda(string value)
        {
            string retval = null;
            if (!string.IsNullOrWhiteSpace(value))
            {
                retval = value.Replace("~", "").Trim();
                if (!retval.StartsWith("/"))
                    retval = "/" + retval;
                retval = CurrentSite.SiteUrl + retval;
            }
            retval = TransformUrl(retval);
            return retval;
        }

        private string ConvertToEnumNews(string value)
        {
            return (value == "1" ? "trending" : "featured");
        }

        private string ConvertToEnumEvents(string value)
        {
            string enumVal = null;
            switch (value)
            {
                case "1":
                    enumVal = "conference";
                    break;
                case "2":
                    enumVal = "on-demand-webinar";
                    break;
                case "3":
                    enumVal = "live-webinar";
                    break;
                case "5":
                    enumVal = "landing-page-live-webinar";
                    break;
                case "6":
                    enumVal = "landing-page-on-demand-webinar";
                    break;
            }

            return enumVal;
        }

        private string ConvertToEnumInterviewType(string value)
        {
            value = value.ToLower();
            string enumVal = null;
            switch (value)
            {
                case "audio":
                    enumVal = "audio";
                    break;
                case "text":
                    enumVal = "text";
                    break;
                case "video":
                    enumVal = "video";
                    break;
            }

            return enumVal;
        }

        private string ConvertToEnumResources(string value)
        {
            string enumVal = null;
            value = value.ToLower();
            switch (value)
            {
                case "whitepaper":
                    enumVal = "white-paper";
                    break;
                case "blog article":
                    enumVal = "blog-article";
                    break;
                case "guestauthor":
                    enumVal = "guest-author";
                    break;
                case "infographic":
                    enumVal = "infographic";
                    break;
                case "video":
                    enumVal = "video";
                    break;
                case "landingpage":
                    enumVal = "landingpage";
                    break;
            }

            return enumVal;
        }

        private Metadata GetMetadata(DataRow dr)
        {
            Metadata meta = new Metadata();
            meta.IsIndex = dr["IsIndex"].ToString().ToLower();
            meta.IsFollow = dr["IsFollow"].ToString().ToLower();
            meta.MetaTitle = (dr["MetaTitle"] as string);
            meta.MetaDescription = (dr["MetaDescription"] as string);
            meta.ManualCanonical = (dr["ManualCanonical"] as string);
            meta.Keywords = (dr["KeyWords"] as string);

            return meta;
        }

        private string NullOrString(string val)
        {
            string stringval = null;
            if (!string.IsNullOrWhiteSpace(val))
            {
                stringval = val;
            }

            return stringval;
        }

        private string ConvertDateTimeToString(DateTime? date)
        {
            string returnValue = null;
            if (date != null && date.Value.ToString("yyyy-MM-dd HH:mm:ss") != "1900-01-01 00:00:00")
            {
                returnValue = date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return returnValue;
        }

        private string CalculateSlug(string slug)
        {
            slug = slug.Trim();
            slug = Regex.Replace(slug, @"[&]+", "and");
            slug = Regex.Replace(slug, @"[ ]+", " ");
            // replace .report,.network
            slug = Regex.Replace(slug, @"[.][\w]+$", "");
            //slug = Regex.Replace(slug, @"[^-\w]+", "-");
            slug = Regex.Replace(slug, @"[^-a-zA-Z0-9_]+", "-");
            slug = Regex.Replace(slug, @"[_]", "-");
            slug = Regex.Replace(slug, @"[ ]", "-");
            slug = Regex.Replace(slug, @"[-]+", "-");
            slug = Regex.Replace(slug, @"-+$", "");
            slug = Regex.Replace(slug, @"^-+", "");
            slug = slug.Trim();
            slug = slug.ToLower();

            return slug;
        }

        private DataSet GetSiteDetails()
        {
            string stmt = @"
            select SiteName AS SiteName,SiteName AS SiteSlug,LOWER('https://'+SiteName) AS SiteUrl FROM (VALUES ('ABM.Report'),('Advertising.Report'),('Aviation.Report'),('Biotechnology.Report'),('Capital.Report'),('Channel.Report'),('Chemical.Report'),('Cloud.Report'),('DataAnalytics.Report'),('Engineering.Report'),('Government.Report'),('GreenEnergy.Report'),('Healthcare.Report'),('HumanResources.Report'),('InformationSecurity.Report'),('InfoTech.Report'),('ITInfrastructure.Report'),('Networking.Report'),('NonProfit.Report'),('Pharmaceutical.Report'),('RE.Report'),('SmallBusiness.Report'),('TheInternetOfThings.Report'),('Virtualization.Network'),('Wheels.Report'),('Policy.Report'),('Entertainment.Report'),('Travel.Report'),('POS.Report'),('Education.Report'),('Manufacturing.report')) AS T(SiteName)
            ";
            return ExecuteStmt(stmt);
        }

        private DataSet GetCompanyDetails()
        {
            string stmt =
            string.Format(@"
                WITH InterviewDetails
                AS (   
                    SELECT a.CompanyDomain,
                    --STRING_AGG('Interviews/' + CONVERT(NVARCHAR(100),a.InterviewID), ',') AS InterviewDetails
                    --STRING_AGG('Interviewsslash{1}' + 'plus'+ CONVERT(NVARCHAR(100),a.InterviewID), 'comma') AS InterviewDetails
                    STRING_AGG(CONVERT(NVARCHAR(100),a.InterviewID), 'comma') AS InterviewDetails
		            FROM   [dbo].[interview_details] a
		                JOIN [dbo].[interview_media7_visibility] b
                            ON a.interviewid = b.interviewid
		            WHERE  b.isactive = 1 AND a.isactive = 1
                        and b.{0}=1
                    GROUP BY a.CompanyDomain),
                NewsT AS (
                    SELECT CompanyID,STRING_AGG(CONVERT(NVARCHAR(MAX),'Newsslash' + '{1}' + 'plus' + CONVERT(NVARCHAR(5),NewsID)),'comma') AS News 
                    FROM CompaniesNews
                    WHERE ISNULL(CompanyID,'')!=''
                    GROUP BY CompanyID
                ),
                EventsT AS (
                    SELECT CompanyID,STRING_AGG(CONVERT(NVARCHAR(MAX),'Eventsslash' + '{1}' + 'plus' + CONVERT(NVARCHAR(5),EventID)),'comma') AS Events 
                    FROM CompaniesEvents
                    WHERE ISNULL(CompanyID,'')!='' AND IsActive=1
                    GROUP BY CompanyID
                ),
                ResourcesT AS (
                    SELECT CompanyID,STRING_AGG(CONVERT(NVARCHAR(MAX),'Resourcesslash' + '{1}' + 'plus' +  CONVERT(NVARCHAR(5),ResourceID)),'comma') AS Resources 
                    FROM CompaniesResources
                    WHERE ISNULL(CompanyID,'')!='' AND IsActive=1
                    GROUP BY CompanyID
                )


                    SELECT ID,EntryDate,IsActive,Domain_Name,RouteURL,Company_Name,Description,Logo,ImageAltTag,Category,IsIndex,IsFollow,MetaTitle,MetaDescription,Keywords,
                    ManualCanonical,InterviewDetails,Site,SiteSlug,RowNumber,News,Events,Resources FROM (
                    SELECT  CDetails.ID AS ID,EntryDate,IsActive,
--(CASE WHEN ISNULL(Domain_Name,'')='' THEN CONVERT(NVARCHAR(5),ID) ELSE Domain_Name END) AS Domain_Name,
Domain_Name,
RouteURL,Company_Name,Description,Logo,ImageAltTag,REPLACE(Category,',','') AS Category,IsIndex,IsFollow,MetaTitle,MetaDescription,CONVERT(NVARCHAR(250),'') AS Keywords,
                    CONVERT(NVARCHAR(250),'') AS ManualCanonical,
                    InterviewDetails.InterviewDetails,'Sites/{1}' AS Site,'{1}' AS SiteSlug,
                    ROW_NUMBER() OVER(PARTITION BY Domain_Name ORDER BY ID DESC) AS RowNumber,
                    NewsT.News,EventsT.Events,ResourcesT.Resources
                    FROM {2}RptDB_CompanyDetails AS CDetails
	                LEFT JOIN InterviewDetails ON CDetails.Domain_Name=InterviewDetails.CompanyDomain 
                    LEFT JOIN NewsT ON Cdetails.ID = NewsT.CompanyID
                    LEFT JOIN EventsT ON CDetails.ID = EventsT.CompanyID
                    LEFT JOIN ResourcesT ON CDetails.ID = ResourcesT.CompanyID
                    WHERE IsActive=1) AS T 
        --WHERE ID=264
    --WHERE T.RowNumber=1 AND ID=264
    --WHERE EntryDate >= '2022-01-01 00:00:00'
    ORDER BY ID
", CurrentSite.InterviewMedia7FlagName, CurrentSite.SiteSlug, CurrentSite.SiteTableName);
            return ExecuteStmt(stmt);
        }



        private DataSet GetGuestAuthorDetails()
        {
            string stmt =
            string.Format(@"
WITH Resources AS (
--SELECT 'Resourcesslash{0}plus' + CONVERT(NVARCHAR(10),ID) AS ID,UserName 
SELECT  CONVERT(NVARCHAR(10),ID) AS ID,UserName 
FROM theiotrep..{2}RptDB_Resources
WHERE IsActive = 1 AND (ResourceType = 'landingpage' OR ResourceType = 'whitePaper' OR ResourceType = 'blog article' OR ResourceType='GuestAuthor')
)
SELECT IsActive,Site,SiteSlug,User_FirstName AS FirstName,User_LastName AS LastName,User_Company AS Company,User_JobTitle AS Jobtitle,
User_Email AS Email,UserImageProfile AS ProfileImage,SiteName,Role AS Role,RouteURL,userdetails_id AS ID,user_bio AS Bio,user_facebookLink AS FaceBookLink,
user_twitterLink AS TwitterLink,user_linkedinLink AS LinkedinLink,AuthorName AS AuthorName,Slug AS Slug,
RowNumber,CompanyName,CompanyWebsite,CompanyLogo,CompanyDescription,
(SELECT STRING_AGG(ID,'comma') FROM Resources WHERE UserName LIKE '%' + User_Email + '%') AS Resources
FROM (
SELECT ud.IsActive,ud.UserID,ud.User_FirstName,ud.User_LastName,ud.User_Company,ud.User_JobTitle,ud.User_Email,
		'https://Media7.io'+  RIGHT(ud.User_ImageProfile, LEN(ud.User_ImageProfile) - 1) AS UserImageProfile,
		c.SiteName, usd.Role, 'https://humanresources.report/guest-contributors/' + LOWER(replace(Replace(Replace(User_FirstName,',',''),'.',''), ' ', '-')+'-'+replace(Replace(Replace(User_LastName,',',''),'.',''), ' ', '-')) as RouteURL,
		ud.userdetails_id as userdetails_id,user_bio,
		'https://'+Replace(Replace(Replace(user_facebookLink,'https//',''),'https://',''),'http//','') as user_facebookLink,
		 'https://'+Replace(Replace(Replace(user_twitterLink,'https//',''),'https://',''),'http//','')  as user_twitterLink,
		 'https://'+ Replace(Replace(Replace(user_linkedinLink,'https://',''),'https://',''),'http//','')  as  user_linkedinLink,
		 --'https://media7.io'+replace(replace(user_imageprofile,'ttps//media7.io',''),'~','') as user_imageprofile,
		 user_firstname  +' '+   user_lastname  AS AuthorName,
		 lower(Replace(Replace(user_firstname,' ','-'),'.','' ) +'-'+  Replace(Replace(user_lastname,' ','-'),'.','')) AS Slug,
		 Row_Number() over(PARTITION BY userdetails_id ORDER BY (SELECT 0)) as RowNumber,
        'Sites/{0}' AS Site,'{0}' AS SiteSlug,
        comp.Comapanyname AS CompanyName,CASE
                WHEN companyWebsite LIKE 'http://%' THEN 'http://' + REPLACE(CompanyWebsite, 'http://', '')
                WHEN companyWebsite LIKE 'https://%' THEN 'https://' + REPLACE(CompanyWebsite, 'https://', '')
                WHEN companyWebsite LIKE 'www.%' THEN 'https://' + CompanyWebsite
                ELSE 'https://' + companyWebsite
            END AS CompanyWebsite,'https://Media7.io/' + RIGHT(ComapanyLogo, LEN(ComapanyLogo) - 0) AS CompanyLogo,
        comp.CompanyDescription AS CompanyDescription,comp.CompanyId AS CompanyId
		FROM [NAMEDIA7io]..User_Details ud
		INNER JOIN [NAMEDIA7io]..Site_Users b ON b.UserID = ud.UserID
		INNER JOIN [NAMEDIA7io]..Site_Master c ON c.SiteId = b.SiteId
		INNER JOIN [NAMEDIA7io]..aspnet_Users  d ON d.UserID = b.UserID 
	    inner join [NAMEDIA7io]..usersignupdetails usd on usd.UserId =  ud.UserID
	    LEFT JOIN  [NAMEDIA7io].[NAMEDIA7io].[AuthorsAffilatedCompanies] AS Comp ON ud.user_email = comp.UserName
		WHERE c.SiteName LIKE  '%{1}%'
		and 
		( usd.Role = 'GuestAuthor' or usd.Role='Contributor')
	    AND b.IsActive=1) AS T
		where RowNumber = 1

		
		--ORDER BY UserID ASC
", CurrentSite.SiteSlug, CurrentSite.SiteName, CurrentSite.SiteTableName);
            return ExecuteStmtMedia7(stmt);
        }

        private DataSet GetInterviewDetails()
        {
            //            WITH Company
            //AS(SELECT
            //        Domain_Name,
            //        STRING_AGG('Companiesslash{0}' + 'plus' + CONVERT(NVARCHAR(5), ID), 'comma') AS Company

            //        FROM  { 1}
            //            RptDB_CompanyDetails AS CDetails
            //   WHERE  IsActive = 1
            //       GROUP BY Domain_Name)

            string stmt = string.Format(@"
WITH Company AS 
		 ( SELECT Domain_Name,ID,
		 --'Companiesslash{1}' + 'plus' + CONVERT(NVARCHAR(5),ID) AS Company
         CONVERT(NVARCHAR(5),ID) AS Company
		 FROM 
						(SELECT ID,
                        Domain_Name,
						ROW_NUMBER() OVER (PARTITION BY Domain_Name ORDER BY (SELECT 0)) AS RowNumber
		                FROM  {1}RptDB_CompanyDetails AS CDetails
		                WHERE  IsActive=1) AS T
						WHERE RowNumber=1
                        )
SELECT a.InterviewID,
       a.InterviewTitle,
       a.InterviewDetails,
       a.IntervieweePerson,
       CategoryTag,
       Designation,
       KeyWords,
       ISINDEX,
       IsFollow,
       ManualCanonical,
       MetaTitle,
       MetaDescription,
       KeyWords,
       ImageAltTag,
       a.Desc2,
       a.Desc3,
       a.Quote1,
       a.Quote2,
       a.Quote3,
       a.Desc4,
       Read_time AS ReadTime,
       a.AboutCompany,
       a.Interviewtakenby,
       dbo.Getdomailfromurl(a.companydomain) AS 'CompanyDomain',
       a.CompanyName,
       a.companylogo AS CompanyLogo,
       a.InterviewType,
       'https://' + '' + b.PublishedSite
       + RIGHT(a.interviewimage, Len(a.interviewimage) - 1) AS InterviewImage,
       'https://' + '' + b.publishedsite
       + RIGHT(a.mobileimage, Len(a.mobileimage) - 1)       AS MobileImage,
       a.InterviewTitle,
       dbo.Removehtmltag(LEFT(a.interviewdetails, 2000))    AS InterviewDetails,
       InterviewDate  AS InterviewDate,
       a.IsActive,
       a.MetaDescription,
       a.InterviewTakenBy,
       b.PublishedSite,
       b.InterviewCategory,
	   RouteURL,
	   Company.Company
        ,'Sites/{0}' AS Site,'{0}' AS SiteSlug
FROM   [dbo].[interview_details] a
       JOIN [dbo].[interview_media7_visibility] b
         ON a.interviewid = b.interviewid
	   LEFT JOIN Company ON a.CompanyDomain = company.Domain_Name
WHERE  b.{2} = 1
       AND b.isactive = 1
       AND a.isactive = 1
ORDER  BY a.interviewid DESC 
            ", CurrentSite.SiteSlug, CurrentSite.SiteTableName, CurrentSite.InterviewMedia7FlagName);
            return ExecuteStmt(stmt);
        }

        private DataSet GetNewsDetails()
        {
            return ExecuteStmt(string.Format(@"
                WITH Company
                    AS (   SELECT ID,
                        Domain_Name,
                        'Companiesslash{0}' + 'plus' + CONVERT(NVARCHAR(5),ID) AS Company
		                FROM  {1}RptDB_CompanyDetails AS CDetails
		                WHERE  IsActive=1
                        )
            SELECT News.ID,Title,Description,date,ImageUrl,NewsType,News.CompanyName,IsActive,RouteURL,Tag,ImageAltTag,Read_Time,IsIndex,IsFollow,MetaTitle,MetaDescription,ManualCanonical,Keywords,
            'Sites/{0}' AS Site,'{0}' AS SiteSlug,
            Company.Company
            FROM {1}RptDB_News_NewsDetails AS News
                LEFT JOIN CompaniesNews ON News.ID = CompaniesNews.NewsID
                LEFT JOIN Company ON CompaniesNews.CompanyID = Company.ID
            --WHERE IsActive=1 and date >= '2022-01-01 00:00:00'
            WHERE IsActive=1
            ORDER BY ID", CurrentSite.SiteSlug, CurrentSite.SiteTableName));
        }
        private DataSet GetGlobalCompaniesPageDetails()
        {
            return ExecuteStmt(string.Format(@"
WITH InterviewDetails
                AS (   
                    SELECT a.CompanyDomain,
                    --STRING_AGG('Interviews/' + CONVERT(NVARCHAR(100),a.InterviewID), ',') AS InterviewDetails
                    STRING_AGG('Interviewsslash{1}' + 'plus'+ CONVERT(NVARCHAR(100),a.InterviewID), 'comma') AS InterviewDetails
		            FROM   [dbo].[interview_details] a
		                JOIN [dbo].[interview_media7_visibility] b
                            ON a.interviewid = b.interviewid
		            WHERE  b.isactive = 1 AND a.isactive = 1
                        and b.{2}=1
                    GROUP BY a.CompanyDomain),
                NewsT AS (
                    SELECT CompanyID,STRING_AGG(CONVERT(NVARCHAR(MAX),'Newsslash' + '{1}' + 'plus' + CONVERT(NVARCHAR(5),NewsID)),'comma') AS News 
                    FROM CompaniesNews
                    WHERE ISNULL(CompanyID,'')!=''
                    GROUP BY CompanyID
                ),
                EventsT AS (
                    SELECT CompanyID,STRING_AGG(CONVERT(NVARCHAR(MAX),'Eventsslash' + '{1}' + 'plus' + CONVERT(NVARCHAR(5),EventID)),'comma') AS Events 
                    FROM CompaniesEvents
                    WHERE ISNULL(CompanyID,'')!='' AND IsActive=1
                    GROUP BY CompanyID
                ),
                ResourcesT AS (
                    SELECT CompanyID,STRING_AGG(CONVERT(NVARCHAR(MAX),'Resourcesslash' + '{1}' + 'plus' +  CONVERT(NVARCHAR(5),ResourceID)),'comma') AS Resources 
                    FROM CompaniesResources
                    WHERE ISNULL(CompanyID,'')!='' AND IsActive=1
                    GROUP BY CompanyID
                )
            SELECT GlobalComp.CompanyID,GlobalComp.CompanyName,GlobalComp.Description,GlobalComp.Logo,
            GlobalComp.DomainName,GlobalComp.IsActive,GlobalComp.PageSection,
            'Sites/{0}' AS Site,'{0}' AS SiteSlug,REPLACE(CDetails.Category,',','') AS CategoryTag,
            CDetails.RouteURL,CDetails.ImageAltTag,CDetails.EntryDate,
            CDetails.IsIndex,CDetails.IsFollow,CDetails.MetaTitle,CDetails.MetaDescription,
            CONVERT(NVARCHAR(250),'') AS Keywords,
            CONVERT(NVARCHAR(250),'') AS ManualCanonical,InterviewDetails.InterviewDetails,
            NewsT.News,EventsT.Events,ResourcesT.Resources
            FROM {1}GlobalCompaniesPage AS GlobalComp
                INNER JOIN {1}RptDB_CompanyDetails AS CDetails ON GlobalComp.CompanyID = CDetails.ID
                LEFT JOIN InterviewDetails ON CDetails.Domain_Name=InterviewDetails.CompanyDomain 
                LEFT JOIN NewsT ON Cdetails.ID = NewsT.CompanyID
                LEFT JOIN EventsT ON CDetails.ID = EventsT.CompanyID
                LEFT JOIN ResourcesT ON CDetails.ID = ResourcesT.CompanyID
            WHERE GlobalComp.IsActive=1 
            ORDER BY CompanyID", CurrentSite.SiteSlug, CurrentSite.SiteTableName, CurrentSite.InterviewMedia7FlagName));
        }

        private DataSet GetEventDetails()
        {
            return ExecuteStmt(string.Format(@"
                    WITH Company
                    AS (SELECT ID,
                        'Companiesslash{0}' + 'plus' + CONVERT(NVARCHAR(5),ID) AS Company
		                FROM  {1}RptDB_CompanyDetails AS CDetails
		                WHERE  IsActive=1
                        )
SELECT Events.EventID AS ID,Name,Details,StartDate,EndDate,Events.Company AS CompanyName,ImageUrl,URL,RouteURL,EventType,Country,
City,Sponsors,Events.IsActive,ImageAltTag,CategoryTag,Performer_Name,Organizer_Url,
IsFollow,IsIndex,ManualCanonical,MetaTitle,MetaDescription,Keywords,
'Sites/{0}' AS Site,'{0}' AS SiteSlug,Company.Company
FROM {1}RptDB_Events AS Events
LEFT JOIN CompaniesEvents ON Events.EventID = CompaniesEvents.EventID
LEFT JOIN Company ON CompaniesEvents.CompanyID = Company.ID
WHERE Events.IsActive=1
--AND StartDate >= '2022-01-01 00:00:00'
ORDER BY Events.EventID
            ", CurrentSite.SiteSlug, CurrentSite.SiteTableName));
        }

        private DataSet GetResourceDetails()
        {
            return ExecuteStmt(string.Format(@"
                WITH GuestAuthors AS (
                        --SELECT 'GuestAuthorsslash{0}plus' + CONVERT(NVARCHAR(10),ID) AS ID,Email 
                        SELECT  CONVERT(NVARCHAR(10),ID) AS ID,Email
                        FROM (
                        SELECT ud.userdetails_id AS ID,ud.User_Email AS Email,Row_Number() over(PARTITION BY userdetails_id ORDER BY (SELECT 0)) as RowNumber
                        FROM [NAMEDIA7io]..User_Details ud
		                INNER JOIN [NAMEDIA7io]..Site_Users b ON b.UserID = ud.UserID
		                INNER JOIN [NAMEDIA7io]..Site_Master c ON c.SiteId = b.SiteId
		                INNER JOIN [NAMEDIA7io]..aspnet_Users  d ON d.UserID = b.UserID 
	                    inner join [NAMEDIA7io]..usersignupdetails usd on usd.UserId =  ud.UserID
	                    LEFT JOIN  [NAMEDIA7io].[NAMEDIA7io].[AuthorsAffilatedCompanies] AS Comp ON ud.user_email = comp.UserName
		            WHERE c.SiteName LIKE  '%{1}%'
		            and 
		            ( usd.Role = 'GuestAuthor' or usd.Role='Contributor')
	                AND b.IsActive=1) AS T
		            where RowNumber = 1),
                    Company
                    AS (   SELECT ID,
                        Domain_Name,
                        'Companiesslash{0}' + 'plus' + CONVERT(NVARCHAR(5),ID) AS Company
		                FROM  {1}RptDB_CompanyDetails AS CDetails
		                WHERE  IsActive=1
                        )

SELECT Resources.ID,WhitePaperTitle,Description,Author,Resources.AuthorReal,PdfUrl,ImageUrl,EmbadedVideoURl,Hit_Counter,ResourceType,
Resources.IsActive,IsSponcered,PublishingDate,RouteURL,Tag,ImageAltTag,Read_Time,UserName,
IsFollow,IsIndex,ManualCanonical,MetaTitle,MetaDescription,keywords,
'Sitesslash{0}' AS Site,'{0}' AS SiteSlug,
(SELECT STRING_AGG(GuestAuthors.ID,'comma') FROM GuestAuthors WHERE Email LIKE '%' + UserName + '%') AS GuestAuthors,
Company.Company
FROM {1}RptDB_Resources AS Resources
LEFT JOIN CompaniesResources ON Resources.ID = CompaniesResources.ResourceID
LEFT JOIN Company ON CompaniesResources.CompanyID = Company.ID
WHERE Resources.IsActive=1 
--AND CompaniesResources.IsActive=1
--AND PublishingDate >= '2022-01-01 00:00:00'
--AND Resources.ID = 10412
ORDER BY ID
            ", CurrentSite.SiteSlug, CurrentSite.SiteTableName));
        }

        private DataSet ExecuteStmt(string stmt, params Tuple<string, object>[] args)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandTimeout = 0;
            foreach (var arg in args)
            {
                sqlCmd.Parameters.AddWithValue(arg.Item1, arg.Item2 == null ? DBNull.Value : arg.Item2);
            }
            sqlCmd.CommandText = stmt;
            sqlCmd.Connection = Connection();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        private DataSet ExecuteStmtMedia7(string stmt, params Tuple<string, object>[] args)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandTimeout = 0;
            foreach (var arg in args)
            {
                sqlCmd.Parameters.AddWithValue(arg.Item1, arg.Item2 == null ? DBNull.Value : arg.Item2);
            }
            sqlCmd.CommandText = stmt;
            //sqlCmd.Connection = NAMedia7Connection();
            sqlCmd.Connection = Connection();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        public string TransformUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return url;
            url = Regex.Replace(url, "(.*/)(.*[.].*)", m => { return m.Groups[1].Value.ToLower() + m.Groups[2]; });
            return url;
        }

        public string ReplaceUrl(string str)
        {
            Regex regexImageTag = new Regex(@"<img.*?src=[""']([^""']*)[""'].*?>", RegexOptions.IgnoreCase);
            Regex regexOldSiteUrl = new Regex(CurrentSite.SiteOldUrl, RegexOptions.IgnoreCase);
            MatchCollection collection = regexImageTag.Matches(str);
            foreach (Match match in collection)
            {
                string imgTag = match.Value;
                string url = match.Groups[1].Value;
                if (!regexOldSiteUrl.IsMatch(url))
                    continue;
                string newUrl = regexOldSiteUrl.Replace(url, CurrentSite.SiteUrl);
                newUrl = TransformUrl(newUrl);
                str = str.Replace(url, newUrl);
            }

            return str;
        }


        public string ReplaceUrlNormal(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            string newUrl = string.Empty;
            foreach (Sites mysite in siteList)
            {
                Regex regexOldSiteUrl = new Regex(mysite.SiteOldUrl, RegexOptions.IgnoreCase);
                if (!regexOldSiteUrl.IsMatch(str))
                    continue;
                else
                {
                    newUrl = regexOldSiteUrl.Replace(str, mysite.SiteUrl);
                    newUrl = TransformUrl(newUrl);
                    break;
                }
            }
            return newUrl;
        }

        public class Sites
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "Sites";
                }
            }
            public string SiteName { get; set; }
            public string SiteSlug { get; set; }
            public string SiteUrl { get; set; }
            public string SiteOldUrl { get; set; }
            [JsonIgnore]
            public string SiteTableName { get; set; }
            [JsonIgnore]
            public string InterviewMedia7FlagName { get; set; }
        }


        public class Companies
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "Companies";
                }
            }
            public string ID { get; set; }
            public string IsActive { get; set; }
            public string DomainName { get; set; }
            public string RouteUrl { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Logo { get; set; }
            public string LogoAltTag { get; set; }
            public string CategoryTag { get; set; }
            public string Url { get; set; }
            public Metadata Metadata { get; set; }
            public string[] Interviews { get; set; }
            public string[] News { get; set; }
            public string[] Events { get; set; }
            public string[] Resources { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
            public string EntryDate { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
        }

        public class GlobalCompaniesPage
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "HumanResourcesGlobalCompaniesPage";
                }
            }
            public string ID { get; set; }
            public string CompanyName { get; set; }
            public string IsActive { get; set; }
            public string DomainName { get; set; }
            public string PageSection { get; set; }
            public string Description { get; set; }
            public string Logo { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
            public string CategoryTag { get; set; }

            // Newly added company fields begin
            public string RouteUrl { get; set; }
            public string LogoAltTag { get; set; }
            public string Url { get; set; }
            public Metadata Metadata { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
            public string[] Interviews { get; set; }
            public string[] News { get; set; }
            public string[] Events { get; set; }
            public string[] Resources { get; set; }
            public string EntryDate { get; set; }
            // Newly added company fields end
        }

        public class GuestAuthors
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "GuestAuthors";
                }
            }
            public string ID { get; set; }
            public string IsActive { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Company { get; set; }
            public string JobTitle { get; set; }
            public string Email { get; set; }
            public string ProfileImage { get; set; }
            public string Role { get; set; }
            public string Bio { get; set; }
            public string FacebookLink { get; set; }
            public string TwitterLink { get; set; }
            public string LinkedinLink { get; set; }
            public string AuthorName { get; set; }
            public string Slug { get; set; }
            public string RouteUrl { get; set; }
            public Metadata Metadata { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
            public string CompanyName { get; set; }
            public string CompanyWebsite { get; set; }
            public string CompanyLogo { get; set; }
            public string CompanyDescription { get; set; }
            public string[] Resources { get; set; }
        }

        public class Interviews
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "Interviews";
                }
            }
            public string ID { get; set; }
            public string InterviewTitle { get; set; }
            public string CategoryTag { get; set; }
            public string Designation { get; set; }
            public string InterviewDetails { get; set; }
            public string IntervieweePerson { get; set; }
            public string InterviewImage { get; set; }
            public string InterviewImageAltTag { get; set; }
            public string InterviewType { get; set; }
            public string InterviewDate { get; set; }
            public string IsActive { get; set; }
            public string MobileImage { get; set; }
            public string Desc2 { get; set; }
            public string Desc3 { get; set; }
            public string Desc4 { get; set; }

            public string Quote1 { get; set; }
            public string Quote2 { get; set; }
            public string Quote3 { get; set; }
            public string AboutCompany { get; set; }
            public string InterviewTakenBy { get; set; }
            public string CompanyDomain { get; set; }
            public string CompanyName { get; set; }
            public string CompanyLogo { get; set; }
            public string RouteURL { get; set; }

            public string ReadTime { get; set; }
            public string PublishedSite { get; set; }
            public string InterviewCategory { get; set; }
            public string Company { get; set; }
            public Metadata Metadata { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
        }

        public class News
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "News";
                }
            }
            public string ID { get; set; }
            public string Description { get; set; }
            public string Title { get; set; }
            public string PublishDate { get; set; }
            public string ImageUrl { get; set; }
            public string NewsType { get; set; }
            public string CompanyName { get; set; }
            public string IsActive { get; set; }
            public string RouteURL { get; set; }
            public string CategoryTag { get; set; }
            public Metadata Metadata { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
            public string ImageAltTag { get; set; }
            public string ReadTime { get; set; }
            public string Company { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
        }

        public class Events
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "Events";
                }
            }
            public string ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string CompanyName { get; set; }
            public string ImageUrl { get; set; }
            public string Url { get; set; }
            public string RouteUrl { get; set; }
            public string EventType { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Sponsors { get; set; }
            public string IsActive { get; set; }
            public string ImageAltTag { get; set; }
            public string CategoryTag { get; set; }
            public string PerformerName { get; set; }
            public string OrganizerUrl { get; set; }
            public Metadata Metadata { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }

            public string Company { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
        }

        public class Resources
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "Resources";
                }
            }
            public string ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string AuthorName { get; set; }
            public string CompanyName { get; set; }
            public string PdfUrl { get; set; }
            public string ImageUrl { get; set; }
            public string EmbeddedVideoURl { get; set; }
            public string HitCounter { get; set; }
            public string ResourceType { get; set; }
            public string IsActive { get; set; }
            public string IsSponcered { get; set; }
            public string PublishingDate { get; set; }
            public string RouteURL { get; set; }
            public string CategoryTag { get; set; }
            public string ImageAltTag { get; set; }
            public string ReadTime { get; set; }
            public string UserName { get; set; }
            public Metadata Metadata { get; set; }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
            public string Company { get; set; }
            public string Site { get; set; }
            public string SiteSlug { get; set; }
            public string[] GuestAuthors { get; set; }

        }

        public class Metadata
        {
            [JsonProperty("@type")]
            public string TerminusType
            {
                get
                {
                    return "Metadata";
                }
            }
            public string IsIndex { get; set; }
            public string IsFollow { get; set; }
            public string ManualCanonical { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public string Keywords { get; set; }
        }
    }
}

