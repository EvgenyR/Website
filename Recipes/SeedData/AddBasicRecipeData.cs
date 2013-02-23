using System.Collections.Generic;
using Recipes.Models;
using System.Data.Entity.Validation;

namespace Recipes.SeedData
{
    public static class AddBasicRecipeData
    {
        public static void Execute(RecipesEntities context)
        {
            try
            {
                var category1 = new Category { CategoryID = 1, CategoryName = "Main Dishes", Description = "Main Dishes" };
                var category2 = new Category { CategoryID = 2, CategoryName = "Soups and Stuff", Description = "Soups and Stuff" };
                var category3 = new Category { CategoryID = 3, CategoryName = "Baked Goods", Description = "Baked Goods" };
                var category4 = new Category { CategoryID = 4, CategoryName = "Sweets and Desserts", Description = "Sweets and Desserts" };
                var category5 = new Category { CategoryID = 5, CategoryName = "Holiday Foods", Description = "Holiday Foods" };

                var categories = new List<Category> { category1, category2, category3, category4, category5 };
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

                var subcategories = new List<SubCategory>{subcategory1, subcategory2, subcategory3, subcategory4, subcategory5,
                subcategory6, subcategory7, subcategory8, subcategory9, subcategory10,
                subcategory11, subcategory12, subcategory13, subcategory14, subcategory15,
                subcategory16, subcategory17, subcategory18, subcategory19, subcategory20,
                subcategory21, subcategory22, subcategory23, subcategory24, subcategory25};

                subcategories.ForEach(s => context.SubCategories.Add(s));

                var measure0 = new Measure { MeasureID = 1, MeasureName = "grams" };
                var measure1 = new Measure { MeasureID = 2, MeasureName = "cups" };
                var measure2 = new Measure { MeasureID = 3, MeasureName = "items" };
                var measure3 = new Measure { MeasureID = 4, MeasureName = "table spoons" };
                var measure4 = new Measure { MeasureID = 5, MeasureName = "slices" };

                var measures = new List<Measure> { measure0, measure1, measure2, measure3, measure4 };
                measures.ForEach(m => context.Measures.Add(m));
            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        string msg = err2.ErrorMessage;
                    }
                }
            }
        }
    }
}