using Recipes.Models;

namespace Constants
{
    public static class Constants
    {
        public static string DataExceptionMessage = "Unable to save changes - data exception";

        public static string IngredientNameTooShort = "Ingredient Name has to be at least 3 characters long!";
        public static string IngredientNameTooLong = "Ingredient Name has to be less than 50 characters long!";

        public static string CategoryNameTooShort = "Category Name has to be at least 3 characters long!";
        public static string CategoryNameTooLong = "Category Name has to be less than 50 characters long!";
        public static string CategoryDescTooShort = "Category Description has to be at least 10 characters long!";
        public static string CategoryDescTooLong = "Category Descripton has to be less than 100 characters long!";

        public static string RecipeNameTooShort = "Recipe Name has to be at least 3 characters long!";
        public static string RecipeNameTooLong = "Recipe Name is too long! Sure you can make it shorter.";
        public static string RecipeHasNoIngredients = "The recipe needs at least one ingredient!";
        public static string RecipeHasNoCategory = "The recipe needs to belong to a category, please choose one!";
        public static string RecipeHasNoSubCategory = "The recipe needs to belong to a subcategory, please choose one!";

        public static decimal FatCalPerGram = 9;
        public static decimal ProtCalPerGram = 4;
        public static decimal CarbCalPerGram = 4;


    }
}