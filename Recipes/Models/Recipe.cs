using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    //Validation rules
    //Name has to be 2 to 50 characters
    //At least one ingredient
    //Category has to be selected

    public class Recipe : IValidatableObject
    {
        [ScaffoldColumn(false)]
        [DisplayName("Recipe")]
        public int RecipeID { get; set; }
        [DisplayName("Recipe Name")]
        public string RecipeName { get; set; }

        public virtual Category Category{get;set;}

        [DisplayName("SubCategory")]
        public int SubCategoryID { get; set;}
        public virtual SubCategory SubCategory { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

        //public string test { get; set; }

        //total caloric content - calculated fields
        public decimal TotalFatCalories { get; set; }
        public decimal TotalCarbCalories { get; set; }
        public decimal TotalProteinCalories { get; set; }
        public decimal TotalCalories { get; set; }

        [DisplayName("Recipe Ingredients")]
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.RecipeName == null || this.RecipeName.Length < 2)
            {
                yield return new ValidationResult(Constants.Constants.RecipeNameTooShort, new string[] {"RecipeName"} );
            }
            else if (this.RecipeName.Length > 100)
            {
                yield return new ValidationResult(Constants.Constants.RecipeNameTooLong, new string[] { "RecipeName" });
            }
        }
    }
}