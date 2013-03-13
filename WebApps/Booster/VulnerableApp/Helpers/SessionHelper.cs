using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace VulnerableApp.Helpers
{
    public class SessionHelper
    {
        private const string SessionKey = "secretSessionStuff";

        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static void AddToSession(string value)
        {
            if (Session[SessionKey] == null)
            {
                Session[SessionKey] = new List<string>();
            }
            var list = (List<string>)Session[SessionKey];
            list.Add(value);
        }

        public static List<string> GetSessionValues()
        {
            return Session[SessionKey] as List<String> ?? new List<string>();
        }
    }
}