using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Recipes.HtmlHelpers;

namespace Recipes.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        [MetaKeywords(Constants.Constants.SearchMetaKeywords)]
        [MetaDescription(Constants.Constants.SearchMetaDescription)]
        public ActionResult Index()
        {
            return View();
        }
        [MetaKeywords(Constants.Constants.SearchMetaKeywords)]
        [MetaDescription(Constants.Constants.SearchMetaDescription)]
        public ActionResult Theory()
        {
            return View();
        }

        public ActionResult Run(string keywords)
        {
            return PartialView("_List", DoSearch(keywords));
        }

        public HtmlString DoSearch(string keywords)
        {
            string s = SearchHelpers.GetSearchResultHtlm(keywords);

            List<String> results = SearchHelpers.ParseSearchResultHtml(s);

            List<string> apiresults = SearchHelpers.GoogleAPIStringResultList(keywords, 100);

            string stringresults = SearchHelpers.ResultList("Browser Results", results);
            string apistringresults = SearchHelpers.ResultList("Google API Results", apiresults);
            
            return new HtmlString(stringresults + apistringresults);
        }

        //public HtmlString DoGoogleAPISearch(string keywords)
        //{
        //    List<string> results = SearchHelpers.GoogleAPIStringResultList(keywords, 100);
        //    return new HtmlString(SearchHelpers.ResultList(results));
        //}
    }
}
