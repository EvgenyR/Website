using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recipes.Models;
using System.ComponentModel;

namespace Recipes.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        [DisplayName("Sub Category")]
        public int SubCategoryID { get; set; }

        public RecipeViewModel(Recipe recipe, List<Category> categories, List<SubCategory> subCategories, int id, int sid)
        {
            Recipe = recipe;
            Categories = categories;
            SubCategories = subCategories;
            CategoryID = id;
            SubCategoryID = sid;
        }

        public RecipeViewModel()
        { 
        
        }
    }
}