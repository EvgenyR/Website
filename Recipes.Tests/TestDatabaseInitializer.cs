using System.Data.Entity;
using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Tests
{
    public class TestDatabaseInitializer : DropCreateDatabaseAlways<RecipesEntities>
    {
        protected override void Seed(RecipesEntities context)
        {
            var category1 = new Category { CategoryID = 1, CategoryName = "Main Dishes", Description = "Main Dishes" };
            var category2 = new Category { CategoryID = 2, CategoryName = "Soups and Stuff", Description = "Soups and Stuff" };
            var category3 = new Category { CategoryID = 3, CategoryName = "Baked Goods", Description = "Baked Goods" };
            var category4 = new Category { CategoryID = 4, CategoryName = "Sweets and Desserts", Description = "Sweets and Desserts" };
            var category5 = new Category { CategoryID = 5, CategoryName = "Holiday Foods", Description = "Holiday Foods" };

            var categories = new List<Category>() { category1, category2, category3, category4, category5 };
            categories.ForEach(c => context.Categories.Add(c));

            var subcategory1 = new SubCategory { SubCategoryID = 1, CategoryID = 1, SubCategoryName = "Breakfast Dishes", Description = "Breakfast Dishes" };
            var subcategory2 = new SubCategory { SubCategoryID = 2, CategoryID = 1, SubCategoryName = "Burgers", Description = "Burgers" };
            var subcategory3 = new SubCategory { SubCategoryID = 3, CategoryID = 1, SubCategoryName = "Casseroles", Description = "Casseroles" };
            var subcategory4 = new SubCategory { SubCategoryID = 4, CategoryID = 1, SubCategoryName = "Crockpot Cooking", Description = "Crockpot Cooking" };
            var subcategory5 = new SubCategory { SubCategoryID = 5, CategoryID = 1, SubCategoryName = "Dinner Pies", Description = "Dinner Pies" };

            var subcategory6 = new SubCategory { SubCategoryID = 6, CategoryID = 2, SubCategoryName = "Chili", Description = "Chili" };
            var subcategory7 = new SubCategory { SubCategoryID = 7, CategoryID = 2, SubCategoryName = "Soups", Description = "Soups" };
            var subcategory8 = new SubCategory { SubCategoryID = 8, CategoryID = 2, SubCategoryName = "Stews", Description = "Stews" };
            var subcategory9 = new SubCategory { SubCategoryID = 9, CategoryID = 2, SubCategoryName = "Stocks", Description = "Stocks" };
            var subcategory10 = new SubCategory { SubCategoryID = 10, CategoryID = 2, SubCategoryName = "Other", Description = "Other" };

            var subcategory11 = new SubCategory { SubCategoryID = 11, CategoryID = 3, SubCategoryName = "Bagels", Description = "Bagels" };
            var subcategory12 = new SubCategory { SubCategoryID = 12, CategoryID = 3, SubCategoryName = "Biscuits", Description = "Biscuits" };
            var subcategory13 = new SubCategory { SubCategoryID = 13, CategoryID = 3, SubCategoryName = "Breads", Description = "Breads" };
            var subcategory14 = new SubCategory { SubCategoryID = 14, CategoryID = 3, SubCategoryName = "Muffins", Description = "Muffins" };
            var subcategory15 = new SubCategory { SubCategoryID = 15, CategoryID = 3, SubCategoryName = "Pastries", Description = "Pastries" };

            var subcategory16 = new SubCategory { SubCategoryID = 16, CategoryID = 4, SubCategoryName = "Brownies", Description = "Brownies" };
            var subcategory17 = new SubCategory { SubCategoryID = 17, CategoryID = 4, SubCategoryName = "Cakes", Description = "Cakes" };
            var subcategory18 = new SubCategory { SubCategoryID = 18, CategoryID = 4, SubCategoryName = "Cheesecakes", Description = "Cheesecakes" };
            var subcategory19 = new SubCategory { SubCategoryID = 19, CategoryID = 4, SubCategoryName = "Frozen Yogurts", Description = "Frozen Yogurts" };
            var subcategory20 = new SubCategory { SubCategoryID = 20, CategoryID = 4, SubCategoryName = "Mousses", Description = "Mousses" };

            var subcategory21 = new SubCategory { SubCategoryID = 21, CategoryID = 5, SubCategoryName = "Easter", Description = "Easter" };
            var subcategory22 = new SubCategory { SubCategoryID = 22, CategoryID = 5, SubCategoryName = "Halloween", Description = "Halloween" };
            var subcategory23 = new SubCategory { SubCategoryID = 23, CategoryID = 5, SubCategoryName = "Thanksgiving", Description = "Thanksgiving" };
            var subcategory24 = new SubCategory { SubCategoryID = 24, CategoryID = 5, SubCategoryName = "Christmas", Description = "Christmas" };
            var subcategory25 = new SubCategory { SubCategoryID = 25, CategoryID = 5, SubCategoryName = "Other Holidays", Description = "Other Holidays" };

            var subcategories = new List<SubCategory>(){subcategory1, subcategory2, subcategory3, subcategory4, subcategory5,
                subcategory6, subcategory7, subcategory8, subcategory9, subcategory10,
                subcategory11, subcategory12, subcategory13, subcategory14, subcategory15,
                subcategory16, subcategory17, subcategory18, subcategory19, subcategory20,
                subcategory21, subcategory22, subcategory23, subcategory24, subcategory25};

            subcategories.ForEach(s => context.SubCategories.Add(s));

            var ingredient0 = new Ingredient { IngredientID = 1, IngredientName = "Meat", Carb = 1, Fat = 5, Protein = 20 };
            var ingredient1 = new Ingredient { IngredientID = 2, IngredientName = "Fish", Carb = 1, Fat = 10, Protein = 20 };
            var ingredient2 = new Ingredient { IngredientID = 3, IngredientName = "Potato", Carb = 30, Fat = 2, Protein = 10 };

            var ingredients = new List<Ingredient>() { ingredient0, ingredient1, ingredient2 };

            ingredients.ForEach(i => context.Ingredients.Add(i));

            var recipe0 = new Recipe
            {
                RecipeID = 1,
                RecipeName = "Grilled fish with potatoes",
                SubCategoryID = 1,
                Description = @"asdfasf sdf asdfa sfas df asdfjasl;dfja;sijdifasoj;fkja;slkjfklasj;dfkasjdfklasjf aslkdjf
                            asldjf alsjdf;lasjdfkl jasldjf ;ajs;dkljf la;sdkfj a;lskdjf ;alsjkdf ;ajslkdf ;alskdh j;asdklfal"
            };
            var recipe1 = new Recipe
            {
                RecipeID = 2,
                RecipeName = "Grilled steak with potatoes",
                SubCategoryID = 2,
                Description = @"asdlfj;ask la;sdf; oASOJFIOAWENF ;ACJOSDLKF Ja'lkf SADKFJ SDKJF A;LSJDFL;ASJ KLAJSDFK hj
                            sl;dfj lasldjf;l asdjf;kajsdf;ahsof ;asdf sja;kdfkljasdhf a;sdfkl hjl;kASFKHJSALK;DHJ ASLKD HSDF"
            };

            var recipes = new List<Recipe>() { recipe0, recipe1 };

            recipes.ForEach(r => context.Recipes.Add(r));

            var ri0 = new RecipeIngredient // meat (1) to meat with potato (1)
                //{RecipeIngredientID = 0, IngredientID = 0, Ingredient = ingredient0, RecipeID = 1, Recipe = recipe1};
                { RecipeIngredientID = 1, IngredientID = 1, RecipeID = 2, Quantity = 200 };
            var ri1 = new RecipeIngredient // fish (2) to fish with potato (0)
                //{RecipeIngredientID = 1, IngredientID = 1, Ingredient = ingredient1, RecipeID = 0, Recipe = recipe1};
                { RecipeIngredientID = 2, IngredientID = 2, RecipeID = 1, Quantity = 150 };
            var ri2 = new RecipeIngredient // potato (3) to meat with potato (1)
                //{RecipeIngredientID = 2, IngredientID = 2, Ingredient = ingredient2, RecipeID = 1, Recipe = recipe1};
                { RecipeIngredientID = 3, IngredientID = 3, RecipeID = 2, Quantity = 300 };
            var ri3 = new RecipeIngredient // potato (3) to fish with potato (0)
                //{RecipeIngredientID = 3, IngredientID = 2, Ingredient = ingredient2, RecipeID = 0, Recipe = recipe1};
                { RecipeIngredientID = 4, IngredientID = 3, RecipeID = 1, Quantity = 250 };

            var recipeIngredients = new List<RecipeIngredient>() { ri0, ri1, ri2, ri3 };

            recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
            context.SaveChanges();
        }
    }
}
