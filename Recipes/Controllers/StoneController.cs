using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipes.HtmlHelpers;
using System.Web.UI;

namespace Recipes.Controllers
{
    public class StoneController : Controller
    {
        //
        // GET: /Stone/

        public ActionResult Index()
        {
            SteppingStoneHelpers.CreateNewTable();
            HtmlString table = new HtmlString(SteppingStoneHelpers.table.ToString());
            return View(table);
        }

        public ActionResult Theory()
        {
            return View();
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 1)]
        public ActionResult Step()
        {
            return PartialView("_Table", StepStone());
        }

        public ActionResult Reset()
        {
            return PartialView("_Table", NewRandomTable());
        }

        public HtmlString StepStone()
        {
            SteppingStoneHelpers.CalculateNextIteration();
            return new HtmlString(SteppingStoneHelpers.table.ToString());
        }

        public HtmlString NewRandomTable()
        {
            SteppingStoneHelpers.CreateNewTable();
            return new HtmlString(SteppingStoneHelpers.table.ToString());
        }
    }
}
