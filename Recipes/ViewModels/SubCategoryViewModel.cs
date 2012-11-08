
using System.Collections.Generic;
using Recipes.Models;
namespace Recipes.ViewModels
{
    public class SubCategoryViewModel
    {
        public SubCategory SubCategory { get; set; }
        public List<Category> Categories { get; set; }

        public SubCategoryViewModel(SubCategory subCategory, List<Category> categories)
        {
            SubCategory = subCategory;
            Categories = categories;
        }
    }
}