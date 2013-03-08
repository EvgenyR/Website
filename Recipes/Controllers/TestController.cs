using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index(int? TestValue)
        {
            TestModel model = new TestModel();
            model.TestValue = 0;
            return View(model);
        }
    }

    public class TestModel
    {
        public int TestValue { get; set; }
    }

    public static class Helper
    {
        public static IEnumerable<SelectListItem> Items
        {
            get{
                return new List<SelectListItem>
                           {
                               new SelectListItem {Text = "0", Value = "0"},
                               new SelectListItem {Text = "10", Value = "10"}
                           };
            }
        }
    }
}
