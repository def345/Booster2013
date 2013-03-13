using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VulnerableApp.Helpers;

namespace VulnerableApp.Controllers
{
    public class ClickJackingController : Controller
    {
        //
        // GET: /ClickJacking/

        public ActionResult Index()
        {
            var list = new List<string>();
            list.AddRange(SessionHelper.GetSessionValues());
            return View(list);
        }

        public ActionResult Submit()
        {
            SessionHelper.AddToSession("Submitted: " + DateTime.Now.ToLongTimeString());
            return View();
        }

    }
}
