using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class BioInfController : Controller
    {
        //
        // GET: /BioInf/

        public ActionResult GlobalIndex()
        {
            return View();
        }

        public ActionResult GlobalTheory()
        {
            return View();
        }

    }
}
