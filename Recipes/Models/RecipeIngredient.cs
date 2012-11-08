using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    public class RecipeIngredient
    {
        [DisplayName("Recipe Ingredient")]
        public int RecipeIngredientID { get; set; }
        public int IngredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        [DisplayName("Amount, grams")]
        [Required(ErrorMessage="Please enter amount in grams")]
        [Range(0.1,10000, ErrorMessage="Too much or too little. Not less than 0.1g but no more than 10 kilos please")]
        public decimal Quantity { get; set; }
        public virtual ICollection<Ingredient> AllIngredients { get; set; }
    }
}