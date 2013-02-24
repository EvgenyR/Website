using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    //Validation rules:
    //Name has to be between 2 and 50 characters long

    public class Ingredient : IValidatableObject
    {
        [ScaffoldColumn(false)]
        [DisplayName("Ingredient")]
        public int IngredientID { get; set; }
        [DisplayName("Ingredient Name")]
        public string IngredientName { get; set; }
        //public string Test { get; set; }

        [DisplayName("Protein, %")]
        [Required(ErrorMessage = "Protein content is required, or 0 if none")]
        [Range(0, 100, ErrorMessage = "Cannot be less than 0 or over than 100 percent")]
        public decimal Protein { get; set; } //percentage
        [DisplayName("Fat, %")]
        [Required(ErrorMessage = "Fat content is required, or 0 if none")]
        [Range(0, 100, ErrorMessage = "Cannot be less than 0 or over than 100 percent")]
        public decimal Fat { get; set; } //percentage
        [DisplayName("Carbs, %")]
        [Required(ErrorMessage = "Carbohydrate content is required, or 0 if none")]
        [Range(0, 100, ErrorMessage = "Cannot be less than 0 or over than 100 percent")]
        public decimal Carb { get; set; } //percentage

        [DisplayName("Estimated price, dollars per kilo")]
        [Required(ErrorMessage = "Please provide price estimate")]
        [Range(0, 1000, ErrorMessage = "Too cheap or too expensive? No more than $1000/kg.")]
        public decimal Price { get; set; }

        [DisplayName("Measured in: ")]
        public int MeasureID { get; set; }
        public virtual Measure Measure { get; set; }

        public int GramsPerItem { get; set; }

        [DisplayName("Ingredients")]
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        private int GramsPerMeasure()
        {
            int grams = 0;
            switch (MeasureID)
            {
                case 1: //grams
                    grams = 1;
                    break;
                case 2: //cups
                    grams = 100;
                    break;
                case 3: //items
                case 5: //slices
                    grams = GramsPerItem;
                    break;
                case 4: //table spoons
                    grams = 8;
                    break;
                default:
                    grams = 1;
                    break;
            }
            return grams;
        }

        public decimal ProteinCaloriesPerMeasure()
        {
            return GramsPerMeasure() * Protein * Constants.Constants.ProtCalPerGram / 100;
        }

        public decimal CarbCaloriesPerMeasure()
        {
            return GramsPerMeasure() * Protein * Constants.Constants.CarbCalPerGram / 100;
        }

        public decimal FatCaloriesPerMeasure()
        {
            return GramsPerMeasure() * Protein * Constants.Constants.FatCalPerGram / 100;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.IngredientName == null || this.IngredientName.Length < 2)
            {
                yield return new ValidationResult(Constants.Constants.IngredientNameTooShort, new string[] { "IngredientName" });
            }
            else if (this.IngredientName.Length > 50)
            {
                yield return new ValidationResult(Constants.Constants.IngredientNameTooLong, new string[] { "IngredientName" });
            }
        }
    }
}