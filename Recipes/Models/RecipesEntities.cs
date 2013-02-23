using System.Data.Entity;
using Recipes.SeedData;

namespace Recipes.Models
{
    public class RecipesEntities : DbContext
    {
        static RecipesEntities()
        {
            Database.SetInitializer<RecipesEntities>(new SampleData());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Measure> Measures { get; set; }

        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<YahooSymbol> YahooSymbols { get; set; }
        public DbSet<YahooData> YahooData { get; set; }
    }
}