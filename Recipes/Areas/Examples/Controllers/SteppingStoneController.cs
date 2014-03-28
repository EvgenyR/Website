using Recipes.Controllers;
using Recipes.HtmlHelpers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Recipes.Areas.Examples.Controllers
{
    public class SteppingStoneController : BaseController
    {
        //
        // GET: /Stone/

        [MetaKeywords(Constants.Constants.StoneMetaKeywords)]
        [MetaDescription(Constants.Constants.StoneMetaDescription)]
        public ActionResult Index()
        {
            SteppingStoneHelpers.CreateNewTable();
            HtmlString table = new HtmlString(SteppingStoneHelpers.table.ToString());
            return View(table);
        }

        [MetaKeywords(Constants.Constants.StoneMetaKeywords)]
        [MetaDescription(Constants.Constants.StoneMetaDescription)]
        public ActionResult Theory()
        {
            return View();
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 1)]
        public ActionResult Step()
        {
            return PartialView("~/Areas/Examples/Views/Shared/_Table.cshtml", StepStone());
        }

        public ActionResult Reset()
        {
            return PartialView("~/Areas/Examples/Views/Shared/_Table.cshtml", NewRandomTable());
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
