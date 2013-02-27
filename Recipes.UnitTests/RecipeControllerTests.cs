using System.Collections.Generic;
using System.Linq;
using Recipes.Models;
using Recipes.ViewModels;
using NUnit.Framework;
using Recipes.Controllers;
using System.Web.Mvc;
using System.Data.Entity;

namespace Recipes.UnitTests
{
    public class RecipeControllerTests
    {
        /// <summary>
        /// A new recipe can be created
        /// </summary>
        [Test]
        public void CreatesNewRecipe()
        {
            //Arrange
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeController target = new RecipeController();
            Recipe actualRecipe = null;


            //Act
            ActionResult actual = target.Create(GetRecipeViewModel(recipe));

            using (RecipesEntities db = new RecipesEntities())
            {
                actualRecipe = db.Recipes.Find(recipe.RecipeID);
            }

            //Assert
            Assert.IsTrue(recipe.RecipeID != 0);
            Assert.IsNotNull(actualRecipe);
            Assert.AreEqual(recipe.RecipeName, actualRecipe.RecipeName);
        }

        /// <summary>
        /// An existing recipe can be accessed and modified
        /// </summary>
        [Test]
        public void EditsExistingRecipe()
        {
            //Arrange
            RecipeController target = new RecipeController();
            Recipe recipe;
            Recipe editedRecipe;
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

            //Act
            ActionResult actual = target.Edit(viewModel);

            using (RecipesEntities db = new RecipesEntities())
            {
                editedRecipe = db.Recipes.Find(id);
            }

            //Assert
            Assert.AreEqual(editedRecipe.RecipeName, editedName);
        }

        /// <summary>
        /// An existing recipe can be deleted
        /// </summary>
        [Test]
        public void DeletesExistingRecipe()
        {
            //Arrange
            Recipe recipe = GetNewCorrectTestRecipe();
            Recipe deletedRecipe = GetNewCorrectTestRecipe();
            RecipeController target = new RecipeController();
            ActionResult actual = target.Create(GetRecipeViewModel(recipe));
            int id = recipe.RecipeID;

            //Act
            actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                deletedRecipe = db.Recipes.Find(id);
            }

            //Assert
            Assert.IsNotNull(recipe);
            Assert.IsNull(deletedRecipe);
        }

        /// <summary>
        /// A list of recipe ingredients can be edited
        /// </summary>
        [Test]
        public void EditIngredientsTest()
        {
            RecipeController target = new RecipeController();
            Recipe recipe;
            Recipe editedRecipe;
            RecipeViewModel viewModel;
            int count = 0;

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

            //Act
            ActionResult actual = target.Edit(viewModel);

            using (RecipesEntities db = new RecipesEntities())
            {
                editedRecipe = db.Recipes.Find(1);
            }

            //Assert
            Assert.AreEqual(count, editedRecipe.RecipeIngredients.Count);
        }

        /// <summary>
        /// A recipe category can be modified
        /// </summary>
        [Test]
        public void EditCategoryTest()
        {
            RecipeController target = new RecipeController();
            Recipe recipe;
            Recipe editedRecipe;
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

            //Act
            ActionResult actual = target.Edit(viewModel);

            using (RecipesEntities db = new RecipesEntities())
            {
                editedRecipe = db.Recipes.Find(id);
            }

            //Assert
            Assert.AreEqual(25, editedRecipe.SubCategoryID);
        }

        /// <summary>
        /// A recipe with no ingredients can not be created
        /// </summary>
        [Test]
        public void CanNotCreateWithNoIngredients()
        {
            //Arrange
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeViewModel viewModel = GetRecipeViewModel(recipe);
            viewModel.Recipe.RecipeIngredients = null;

            RecipeController target = new RecipeController();

            //Act
            ActionResult actual = target.Create(viewModel);

            string s = Common.GetFirstErrorMessage(actual);

            //Assert
            Assert.AreEqual(Constants.Constants.RecipeHasNoIngredients, s);
        }


        /// <summary>
        /// A recipe with no category can not be created
        /// </summary>
        [Test]
        public void CanNotCreateWithNoCategoryTest()
        {
            //Arrange
            Recipe recipe = GetNewCorrectTestRecipe();
            RecipeViewModel viewModel = GetRecipeViewModel(recipe);
            viewModel.Recipe.Category.CategoryID = 0;
            viewModel.CategoryID = 0;

            RecipeController target = new RecipeController();

            //Act
            ActionResult actual = target.Create(viewModel);

            string s = Common.GetFirstErrorMessage(actual);

            //Assert
            Assert.AreEqual(Constants.Constants.RecipeHasNoCategory, s);
        }

        /// <summary>
        /// Creates a ViewModel to serve as a template for creating a recipe.
        /// The ViewModel is then modified to simulate test conditions
        /// </summary>
        /// <param name="recipe">Template Recipe</param>
        /// <returns>Correct RecipeViewModel</returns>
        private RecipeViewModel GetRecipeViewModel(Recipe recipe)
        {
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

        /// <summary>
        /// Creates a valid test Recipe
        /// </summary>
        /// <returns>Recipe entity</returns>
        private Recipe GetNewCorrectTestRecipe()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                Ingredient ingredient = db.Ingredients.Where(x => x.IngredientName == "Meat").FirstOrDefault();
                Category category = db.Categories.Where(x => x.CategoryName == "Mains").FirstOrDefault();

                return new Recipe()
                {
                    RecipeName = "test",
                    Category = new Category() { CategoryID = 5 },
                    SubCategoryID = 25,
                    RecipeIngredients = new List<RecipeIngredient>() { new RecipeIngredient() { RecipeID = 0, IngredientID = 1, Quantity = 20 } }
                };
            }
        }
    }
}
