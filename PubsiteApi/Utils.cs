using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsiteApi
{
    public static class Utils
    {
        public static string HtmlDecode(string s)
        {
            return HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(s));
        }
    }
}