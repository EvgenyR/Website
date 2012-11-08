
using Recipes.Models;
namespace Recipes.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }

        public CategoryViewModel(Category category)
        {
            Category = category;
        }
    }
}