using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Recipes.HtmlHelpers;

namespace Recipes.Controllers
{
    public class GameController : BaseController
    {
        //
        // GET: /Game/

        public ActionResult Index()
        {
            GameOfLifeHelpers.InitializeGame();
            GameOfLifeHelpers.AddGlider(GameOfLifeHelpers.arrOne, 10, 10);
            GameOfLifeHelpers.DrawStartIteration();
            HtmlString table = new HtmlString(GameOfLifeHelpers.table.ToString());
            return View(table);
        }

        public ActionResult Theory()
        {
            return View();
        }

        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 1)]
        public ActionResult Update()
        {
            return PartialView("_Table", NextIteration());
        }

        public ActionResult Reset()
        {
            return PartialView("_Table", CleanTable());
        }

        public ActionResult AddGlider()
        {
            return PartialView("_Table", AddGliderToTable());
        }

        public HtmlString AddGliderToTable()
        {
            GameOfLifeHelpers.AddGlider(GameOfLifeHelpers.arrOne, 10, 10);
            GameOfLifeHelpers.DrawNextIteration();
            GameOfLifeHelpers.DrawNextIteration();
            GameOfLifeHelpers.DrawNextIteration();
            GameOfLifeHelpers.DrawNextIteration();
            return new HtmlString(GameOfLifeHelpers.table.ToString());
        }

        public HtmlString CleanTable()
        {
            GameOfLifeHelpers.InitializeGame();
            GameOfLifeHelpers.NewGameTable();
            return new HtmlString(GameOfLifeHelpers.table.ToString());
        }

        public HtmlString NextIteration()
        {
            GameOfLifeHelpers.DrawNextIteration();
            return new HtmlString(GameOfLifeHelpers.table.ToString());
        }
    }
}
