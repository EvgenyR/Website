
using System.Collections.Generic;
using Recipes.Models;
namespace Recipes.ViewModels
{
    public class IngredientViewModel
    {
        public Ingredient Ingredient { get; set; }
        public List<Measure> Measures { get; set; }

        public IngredientViewModel(Ingredient ingredient, List<Measure> measures)
        {
            Ingredient = ingredient;
            Measures = measures;
        }
    }
}