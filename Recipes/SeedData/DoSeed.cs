using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recipes.Models;
using System.Data.Entity.Validation;

namespace Recipes.SeedData
{
    public static class DoSeed
    {
        public static void Execute(RecipesEntities context)
        {
            try
            {
                //recipes 

                AddBasicRecipeData.Execute(context);
                AddDetailedRecipeData.Execute(context);

                //blogs

                AddBlogEngineBloggerData.PopulateBloggers(context);
                AddBlogEngineBlogData.PopulateBlogs(context);

                AddDigitalBiologyBlogData.AddPosts(context);
                AddDevelopmentBlogData.AddPosts(context);

                //yahoo

                AddYahoo.AddSymbols(context);

            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        string msg = err2.ErrorMessage;
                    }
                }
            }       
        }
    }
}