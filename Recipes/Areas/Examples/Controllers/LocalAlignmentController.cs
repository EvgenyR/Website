using Recipes.Controllers;
using Recipes.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Recipes.Areas.Examples.Controllers
{
    public class LocalAlignmentController : BaseController
    {
        //
        // GET: /Examples/LocalAlignment/

        //
        // GET: /Stone/

        public ActionResult Index()
        {
            SteppingStoneHelpers.CreateNewTable();
            HtmlString table = new HtmlString(SteppingStoneHelpers.table.ToString());
            //return View(table);
            return View("~/Areas/Examples/Views/BioInformatics/LocalAlignment/Index.cshtml", table);
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
            return PartialView("~/Areas/Examples/Views/Shared/_Table", NewRandomTable());
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

        //public ActionResult Index()
        //{
        //    return View("~/Areas/Examples/Views/BioInformatics/LocalAlignment/Index.cshtml");
        //}

        //public ActionResult Theory()
        //{
        //    return View("~/Areas/Examples/Views/BioInformatics/LocalAlignment/Theory.cshtml");
        //}
    }
}
