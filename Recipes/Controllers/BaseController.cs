using System.Web.Mvc;

namespace Recipes.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var keywords = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MetaKeywordsAttribute), false);
            if (keywords.Length == 1)
                ViewData["MetaKeywords"] = ((MetaKeywordsAttribute)(keywords[0])).Parameter;

            var description = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MetaDescriptionAttribute), false);
            if (description.Length == 1)
                ViewData["MetaDescription"] = ((MetaDescriptionAttribute)(description[0])).Parameter;

            base.OnActionExecuting(filterContext);
        }

        //these may be used in the future

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    string ex = filterContext.Exception.ToString();
        //    var fileName = Path.Combine(Request.MapPath("~/App_Data"), "log.txt");
        //    WriteLog(fileName, ex);
        //    //SendEmail(ex);
        //    if (filterContext.HttpContext.IsCustomErrorEnabled)
        //    {
        //        filterContext.ExceptionHandled = true; 
        //        this.View("Error").ExecuteResult(this.ControllerContext);
        //    }
        //}

        //static StringBuilder ErrorText(string text)
        //{
        //    StringBuilder message = new StringBuilder();
        //    message.AppendLine(DateTime.Now.ToString());
        //    message.AppendLine(text);
        //    message.AppendLine("=========================================");
        //    return message;
        //}

        //static void WriteLog(string logFile, string text)
        //{
        //    System.IO.File.AppendAllText(logFile, ErrorText(text).ToString());
        //}

        //static void SendEmail(string text)
        //{
        //    MailMessage mail = new MailMessage();
        //    SmtpClient client = new SmtpClient("smtp.example.com");
        //    client.Credentials = new System.Net.NetworkCredential("u$3r", "pa$$word"); client.Port = 587;

        //    mail.From = new MailAddress("mvc@example.com");
        //    mail.To.Add("developer@example.com");
        //    mail.Subject = "Error on your website";
        //    mail.Body = ErrorText(text).ToString();

        //    client.Send(mail); 
        //}
    }
}