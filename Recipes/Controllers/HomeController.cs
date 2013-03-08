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
            //Exception ex = new Exception("test");
            //Logger.WriteEntry(ex);

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
