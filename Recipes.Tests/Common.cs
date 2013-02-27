using System.Data.Entity;
using Recipes.Models;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Recipes.Tests
{
    public static class Common
    {
        public static void SetupDatabase()
        {
            //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            //Database.SetInitializer<RecipesEntities>(new TestDatabaseInitializer());

            //using (var db = new RecipesEntities())
            //{
            //    db.Database.Initialize(true);
            //}
        }

        public static string GetValidationError(List<ValidationResult> results)
        {
            foreach (var result in results)
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    return result.ErrorMessage;
                }
            }
            return string.Empty;
        }

        public static string GetFirstErrorMessage(ActionResult result)
        {
            ViewResult vr = (ViewResult)result;

            foreach (ModelState error in vr.ViewData.ModelState.Values)
            {
                foreach (var innerError in error.Errors)
                {
                    if (!string.IsNullOrEmpty(innerError.ErrorMessage))
                    {
                        return innerError.ErrorMessage;
                    }
                }
            }
            return string.Empty;
        }

        public static Category GetNewTestCategory()
        {
            return new Category()
                       {
                           CategoryName = "test",
                           Description = "test description"
                       };
        }
    }
}
