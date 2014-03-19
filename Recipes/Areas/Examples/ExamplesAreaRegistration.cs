using System.Web.Mvc;

namespace Recipes.Areas.Examples
{
    public class ExamplesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Examples";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Examples_subfolder",
                "Examples/BioInformatics/{controller}/{action}/{id}",
                new { action = "Areas/Examples/Views/BioInformatics/GlobalAlignment/Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Examples_default",
                "Examples/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
