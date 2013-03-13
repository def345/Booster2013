using System.Web;
using System.Web.Mvc;
using NWebsec.Csp;
using NWebsec.HttpHeaders;
using NWebsec.Mvc.HttpHeaders;
using NWebsec.Mvc.HttpHeaders.Csp;

namespace VulnerableApp.Controllers
{
    public class XssController : Controller
    {
        //
        // GET: /Xss/
        [ValidateInput(false)]
        [XXssProtection(Policy = XXssProtectionPolicy.FilterDisabled)]
        [Csp(XContentSecurityPolicyHeader = true)]
        [CspDefaultSrc(Self = Source.Enable)]
        public ActionResult Index(string input)
        {
            ViewBag.Input = new HtmlString(input);
            return View();
        }

    }
}