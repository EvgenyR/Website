using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        [MetaKeywords(Constants.Constants.MainMetaKeywords)]
        [MetaDescription(Constants.Constants.MainMetaDescription)]
        public ActionResult Index()
        {
            return View();
        }
        [MetaKeywords(Constants.Constants.MainMetaKeywords)]
        [MetaDescription(Constants.Constants.MainMetaDescription)]
        public ActionResult Resume()
        {
            return View();
        }
        [MetaKeywords(Constants.Constants.MainMetaKeywords)]
        [MetaDescription(Constants.Constants.MainMetaDescription)]
        public ActionResult Todo()
        {
            return View();
        }
    }
}
