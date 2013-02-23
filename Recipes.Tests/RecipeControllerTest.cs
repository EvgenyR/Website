using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Models;
using Recipes.Controllers;
using System.Web.Mvc;
using System.Data.Entity;
using Recipes.ViewModels;

namespace Recipes.Tests
{
    /// <summary>
    ///This is a test class for RecipeControllerTest and is intended
    ///to contain all RecipeControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecipeControllerTest
    {
        private Recipe GetNewCorrectTestRecipe()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                Ingredient ingredient = db.Ingredients.Where(x => x.IngredientName == "Meat").FirstOrDefault();
                Category category = db.Categories.Where(x => x.CategoryName == "Mains").FirstOrDefault();

                return new Recipe()
                           {
                               RecipeName = "test",
                               Category = new Category(){CategoryID = 5},
                               SubCategoryID = 25,
                               RecipeIngredients = new List<RecipeIngredient>(){new RecipeIngredient(){RecipeID = 0, IngredientID = 1, Quantity = 20}}
                           };
            }
        }

        [TestMethod()]
        public void CreateTest()
        {
            Common.SetupDatabase();
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeController target = new RecipeController();
            
            ActionResult actual = target.Create(GetRecipeViewModel(recipe));

            Assert.IsTrue(recipe.RecipeID != 0);

            using (RecipesEntities db = new RecipesEntities())
            {
                var newRecipe = db.Recipes.Find(recipe.RecipeID);
                Assert.IsNotNull(newRecipe);
                Assert.AreEqual( recipe.RecipeName, newRecipe.RecipeName);
            }
        }

        [TestMethod()]
        public void EditTest()
        {
            Common.SetupDatabase();
            RecipeController target = new RecipeController();
            Recipe recipe;
            const int id = 1;
            string editedName;
            RecipeViewModel viewModel;

            using (RecipesEntities db = new RecipesEntities())
            {
                recipe = db.Recipes.Include(r => r.SubCategory).Single(r => r.RecipeID == id);
                recipe.Category = db.Categories.Single(r => r.CategoryID == recipe.SubCategory.CategoryID);
                var allIngredients = db.Ingredients.ToList();
                var categories = db.Categories.ToList();
                var subCategories = db.SubCategories.Where(sc => sc.CategoryID == recipe.SubCategory.CategoryID).ToList();

                foreach (RecipeIngredient ri in recipe.RecipeIngredients)
                {
                    ri.AllIngredients = allIngredients;
                }

                viewModel = new RecipeViewModel(recipe, categories, subCategories, recipe.Category.CategoryID,
                                            recipe.SubCategoryID);
            }

            editedName = recipe.RecipeName + "Edited";
            viewModel.Recipe.RecipeName = editedName;

            ActionResult actual = target.Edit(viewModel);

            using (RecipesEntities db = new RecipesEntities())
            {
                var editedRecipe = db.Recipes.Find(id);
                Assert.AreEqual(editedRecipe.RecipeName, editedName);
            }
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Common.SetupDatabase();
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeController target = new RecipeController();
            ActionResult actual = target.Create(GetRecipeViewModel(recipe));

            Assert.IsNotNull(recipe);
            int id = recipe.RecipeID;

            actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                var deletedRecipe = db.Recipes.Find(id);
                Assert.IsNull(deletedRecipe);
            }
        }

        [TestMethod()]
        public void EditIngredientsTest()
        {
            Common.SetupDatabase();
            RecipeController target = new RecipeController();
            Recipe recipe;
            RecipeViewModel viewModel;
            int count = 0;
            //List<Ingredient> allIngredients;

            using (RecipesEntities db = new RecipesEntities())
            {
                recipe = db.Recipes.Include(r => r.SubCategory).Single(r => r.RecipeID == 1);
                recipe.Category = db.Categories.Single(r => r.CategoryID == recipe.SubCategory.CategoryID);
                var allIngredients = db.Ingredients.ToList();
                var categories = db.Categories.ToList();
                var subCategories =
                    db.SubCategories.Where(sc => sc.CategoryID == recipe.SubCategory.CategoryID).ToList();

                foreach (RecipeIngredient ri in recipe.RecipeIngredients)
                {
                    ri.AllIngredients = allIngredients;
                }

                viewModel = new RecipeViewModel(recipe, categories, subCategories, recipe.Category.CategoryID,
                                            recipe.SubCategoryID);
                viewModel.Recipe.RecipeIngredients.Add(new RecipeIngredient() { RecipeID = recipe.RecipeID, AllIngredients = db.Ingredients.ToList(), IngredientID = 1, Quantity = 20 });
                count = viewModel.Recipe.RecipeIngredients.Count();
            }

            ActionResult actual = target.Edit(viewModel);

            using (RecipesEntities db = new RecipesEntities())
            {
                var editedRecipe = db.Recipes.Find(1);
                Assert.AreEqual(editedRecipe.RecipeIngredients.Count, count);
            }
        }

        [TestMethod()]
        public void EditCategoryTest()
        {
            Common.SetupDatabase();
            RecipeController target = new RecipeController();
            Recipe recipe;
            RecipeViewModel viewModel;
            int id = 1;

            using (RecipesEntities db = new RecipesEntities())
            {
                recipe = db.Recipes.Include(r => r.SubCategory).Single(r => r.RecipeID == id);
                recipe.Category = db.Categories.Single(r => r.CategoryID == recipe.SubCategory.CategoryID);
                var allIngredients = db.Ingredients.ToList();
                var categories = db.Categories.ToList();
                var subCategories = db.SubCategories.Where(sc => sc.CategoryID == recipe.SubCategory.CategoryID).ToList();

                foreach (RecipeIngredient ri in recipe.RecipeIngredients)
                {
                    ri.AllIngredients = allIngredients;
                }
                viewModel = new RecipeViewModel(recipe, categories, subCategories, recipe.Category.CategoryID,
                                            recipe.SubCategoryID);
            }

            viewModel.Recipe.Category.CategoryID = 5;
            viewModel.Recipe.SubCategoryID = 25;

            ActionResult actual = target.Edit(viewModel);

            using (RecipesEntities db = new RecipesEntities())
            {
                var editedRecipe = db.Recipes.Find(id);
                Assert.AreEqual(editedRecipe.SubCategoryID, 25);
            }
        }

        [TestMethod()]
        public void CanNotCreateWithNoIngredientsTest()
        {
            Common.SetupDatabase();
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeViewModel viewModel = GetRecipeViewModel(recipe);
            viewModel.Recipe.RecipeIngredients = null;

            RecipeController target = new RecipeController();
            ActionResult actual = target.Create(viewModel);

            string s = Common.GetFirstErrorMessage(actual);
            Assert.AreEqual(Constants.Constants.RecipeHasNoIngredients, s);
        }

        [TestMethod()]
        public void CanNotCreateWithNoCategoryTest()
        {
            Common.SetupDatabase();
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeViewModel viewModel = GetRecipeViewModel(recipe);
            viewModel.Recipe.Category.CategoryID = 0;
            viewModel.CategoryID = 0;

            RecipeController target = new RecipeController();
            ActionResult actual = target.Create(viewModel);

            string s = Common.GetFirstErrorMessage(actual);
            Assert.AreEqual(Constants.Constants.RecipeHasNoCategory, s);
        }

        private RecipeViewModel GetRecipeViewModel(Recipe recipe)
        {
            Common.SetupDatabase();

            int categoryID = 5;
            int subcategoryID = 25;
            List<Category> categories = new List<Category>();
            List<SubCategory> subCategories = new List<SubCategory>();

            using (RecipesEntities db = new RecipesEntities())
            {
                categories = db.Categories.ToList();
                subCategories = db.SubCategories.Where(s => s.CategoryID == 5).ToList();
            }

            return new RecipeViewModel(recipe, categories, subCategories, categoryID, subcategoryID);
        }
    }
}
