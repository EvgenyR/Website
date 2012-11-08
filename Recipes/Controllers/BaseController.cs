using System;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Net.Mail;

namespace Recipes.Controllers
{
    public abstract class BaseController : Controller
    {
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