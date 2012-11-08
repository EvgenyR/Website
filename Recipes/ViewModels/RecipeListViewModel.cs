
using System.Collections.Generic;
using Recipes.Models;
using System.ComponentModel;
namespace Recipes.ViewModels
{
    public class RecipeListViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public List<Recipe> RecipesList { get; set; }
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        [DisplayName("Sub Category")]
        public int SubCategoryID { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }

        public RecipeListViewModel(List<Recipe> recipes, List<Recipe> recipeList, List<Category> categories, List<SubCategory> subCategories, int id, int sid)
        {
            Recipes = recipes;
            RecipesList = recipeList;
            Categories = categories;
            SubCategories = subCategories;
            CategoryID = id;
            SubCategoryID = sid;
        }

        public RecipeListViewModel()
        {

        }
    }
}