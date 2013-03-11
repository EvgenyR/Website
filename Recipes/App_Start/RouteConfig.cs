using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Recipes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
            name: "Display",
            url: "Post/{id}/{seofriendly}",
            defaults: new { controller = "Post", action = "Display", id = UrlParameter.Optional, seofriendly = ""}
                );

            routes.MapRoute(
                name: "SEOFriendly",
                url: "{controller}/{action}/{id}/{seofriendly}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, seofriendly = "" }
            );

            routes.MapRoute(
                name: "SEOFriendlyNoId",
                url: "{controller}/{action}/{seofriendly}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, seofriendly = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}