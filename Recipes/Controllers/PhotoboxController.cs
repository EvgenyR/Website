using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recipes.Controllers
{
    public class PhotoboxController : Controller
    {
        //
        // GET: /Photobox/

        [MetaKeywords(Constants.Constants.PhotoboxMetaKeywords)]
        [MetaDescription(Constants.Constants.PhotoboxMetaDescription)]
        public ActionResult Index()
        {
            return View();
        }

        [MetaKeywords(Constants.Constants.PhotoboxMetaKeywords)]
        [MetaDescription(Constants.Constants.PhotoboxMetaDescription)]
        public ActionResult Theory()
        {
            return View();
        }
    }
}
