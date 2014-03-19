using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Areas.Examples.Controllers
{
    public class GlobalAlignmentController : Controller
    {
        //
        // GET: /Examples/GlobalAlignment/

        public ActionResult Index()
        {
            return View("~/Areas/Examples/Views/BioInformatics/GlobalAlignment/Index.cshtml");
        }

        public ActionResult Theory()
        {
            return View("~/Areas/Examples/Views/BioInformatics/GlobalAlignment/Theory.cshtml");
        }
    }
}
