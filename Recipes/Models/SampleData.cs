using System.Data.Entity;
using System.Data.Entity.Validation;
using Recipes.Models.BlogContents;
using Recipes.Models.Recipes;
using Recipes.Models.Yahoo;

namespace Recipes.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<RecipesEntities>
    {
        protected override void Seed(RecipesEntities context)
        {
            try
            {
                //recipes 

                AddBasics.Execute(context);
                AddRecipes.Execute(context);

                //blogs

                PopulateBlogBasics.PopulateBloggers(context);
                PopulateBlogBasics.PopulateBlogs(context);

                PopulateEvgeny.AddPosts(context);
                PopulateSomeoneElse.AddPosts(context);

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