using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.Models.Yahoo;

namespace Recipes.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

        RecipesEntities db = new RecipesEntities();

        public ActionResult Details(int id)
        {
            YahooSymbol symbol = db.YahooSymbols.Where(s => s.YahooSymbolID == id).FirstOrDefault();
            return View(symbol);
        }

    }
}
