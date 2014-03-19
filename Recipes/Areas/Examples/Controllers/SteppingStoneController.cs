using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Areas.Examples.Controllers
{
    public class SteppingStoneController : Controller
    {
        //
        // GET: /Examples/SteppingStone/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Theory()
        {
            return View();
        }
    }
}
