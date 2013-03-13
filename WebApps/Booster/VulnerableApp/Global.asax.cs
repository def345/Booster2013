using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VulnerableApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //EnforceHttps();
        }

        private void EnforceHttps()
        {
            var context = HttpContext.Current;
            if (context.Request.IsSecureConnection) return;

            var url = new UriBuilder(context.Request.Url) { Scheme = "https", Port = 443 };
            context.Response.Redirect(url.Uri.ToString());
            context.Response.End();
        }
    }
}