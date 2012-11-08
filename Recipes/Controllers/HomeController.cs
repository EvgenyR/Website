using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Todo()
        {
            return View();
        }
    }
}
