using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.SeedData;

namespace Recipes.Controllers
{
    public class DoggyController : Controller
    {

        RecipesEntities db = new RecipesEntities();
        //
        // GET: /Doggy/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Tell()
        {
            List<YahooSymbol> symbols = db.YahooSymbols.ToList();

            string s = "";
            foreach (var yahooSymbol in symbols)
            {
                s = s + yahooSymbol.YahooSymbolName + "<br/>";
            }

            return Json(new { o = s });
        }
    }
}
