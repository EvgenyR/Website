using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class ResumeController : BaseController
    {
        //
        // GET: /Resume/
        [MetaKeywords(Constants.Constants.MainMetaKeywords)]
        [MetaDescription(Constants.Constants.MainMetaDescription)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
