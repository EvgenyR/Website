using Recipes.SeedData;

namespace Recipes.UnitTests
{
    public class Class1
    {
        public void Do()
        {
            DoSeed.Execute(new Models.RecipesEntities());
        }
    }
}
