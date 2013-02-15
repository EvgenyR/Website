using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class JQGameController : Controller
    {
        //
        // GET: /JQGame/
        [MetaKeywords(Constants.Constants.JQGameMetaKeywords)]
        [MetaDescription(Constants.Constants.JQGameMetaDescription)]
        public ActionResult Index()
        {
            return View();
        }

        [MetaKeywords(Constants.Constants.JQGameMetaKeywords)]
        [MetaDescription(Constants.Constants.JQGameMetaDescription)]
        public ActionResult Theory()
        {
            return View();
        }
    }
}
