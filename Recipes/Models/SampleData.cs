using System.Data.Entity;
using System.Data.Entity.Validation;
using Recipes.SeedData;

namespace Recipes.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<RecipesEntities>
    {
        protected override void Seed(RecipesEntities context)
        {
            DoSeed.Execute(context);
        }
    }
}