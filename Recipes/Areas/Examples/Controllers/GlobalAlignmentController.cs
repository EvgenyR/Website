using Recipes.Controllers;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Areas.Examples.Controllers
{
    public class GlobalAlignmentController : BaseController
    {
        public ActionResult Index()
        {
            string s1 = "PLEASANTLY";
            string s2 = "MEANLY";

            string[] result = ExamplesHelpers.GlobalAlignment(s1, s2);

            return View("~/Areas/Examples/Views/BioInformatics/GlobalAlignment/Index.cshtml", 
                new HtmlString("<table><tr><td>my not yet aligned string</td></tr></table>"));
        }

        public ActionResult Theory()
        {
            return View("~/Areas/Examples/Views/BioInformatics/GlobalAlignment/Theory.cshtml");
        }

        public ActionResult Align()
        {
            HtmlString s = new HtmlString("<table><tr><td>blah</td></tr></table>");
            return PartialView("~/Areas/Examples/Views/Shared/_GlobalAlignment.cshtml", s);
        }
    }
}
