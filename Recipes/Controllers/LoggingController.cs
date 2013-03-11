using System.Web.Mvc;
using Recipes.HtmlHelpers;
using Recipes.Models;
using Recipes.Repository;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class LoggingController : BaseController
    {
        private readonly LoggingRepository repository = new LoggingRepository();
        //
        // GET: /Logging/
        [MetaKeywords(Constants.Constants.LoggingMetaKeywords)]
        [MetaDescription(Constants.Constants.LoggingMetaDescription)]
        public ActionResult Index(string Period = null, int? PageSize = null, int? page = null, string LogLevel = null)
        {
            string defaultPeriod = Session["Period"] == null ? "All" : Session["Period"].ToString();
            string defaultLogLevel = Session["LogLevel"] == null ? "All" : Session["LogLevel"].ToString();

            LoggingIndexModel model = new LoggingIndexModel();

            model.Period = Period ?? defaultPeriod;
            model.LogLevel = LogLevel ?? defaultLogLevel;
            model.CurrentPageIndex = page.HasValue ? page.Value - 1 : 0;
            model.PageSize = PageSize.HasValue ? PageSize.Value : 20;

            TimePeriod timePeriod = TimePeriodHelper.GetUtcTimePeriod(model.Period);

            model.LogEvents = repository.GetByDateRangeAndType(model.CurrentPageIndex, model.PageSize, timePeriod.Start, timePeriod.End, model.LogLevel);

            ViewData["Period"] = model.Period;
            ViewData["LogLevel"] = model.LogLevel;
            ViewData["PageSize"] = model.PageSize;

            Session["Period"] = model.Period;
            Session["LogLevel"] = model.LogLevel;

            return View(model);
        }

        //
        // GET: /Logging/Details/5
        [MetaKeywords(Constants.Constants.LoggingMetaKeywords)]
        [MetaDescription(Constants.Constants.LoggingMetaDescription)]
        public ActionResult Details(string loggerProviderName, string id)
        {
            LogEntry logEvent = repository.GetById(id);

            return View(logEvent);
        }

        [MetaKeywords(Constants.Constants.LoggingMetaKeywords)]
        [MetaDescription(Constants.Constants.LoggingMetaDescription)]
        public ActionResult Theory()
        {
            return View();
        }
    }
}
