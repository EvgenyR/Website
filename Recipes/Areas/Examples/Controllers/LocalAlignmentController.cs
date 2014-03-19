using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Areas.Examples.Controllers
{
    public class LocalAlignmentController : Controller
    {
        //
        // GET: /Examples/LocalAlignment/

        public ActionResult Index()
        {
            return View("~/Areas/Examples/Views/BioInformatics/LocalAlignment/Index.cshtml");
        }

        public ActionResult Theory()
        {
            return View("~/Areas/Examples/Views/BioInformatics/LocalAlignment/Theory.cshtml");
        }
    }
}
