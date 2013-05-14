using System.Data;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Recipes.Repository;
using Recipes.ViewModels;

using System.Data.Entity;

namespace Recipes.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipesRepository repository;

        //constructor chaining
        //avoid "no parameterless constructor defined for this object"
        public RecipeController()
            : this(new RecipesRepository())
        { }

        public RecipeController(IRecipesRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Recipe/
        /// <summary>
        /// Displays the index of Recipes
        /// </summary>
        /// <returns></returns>
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ViewResult Index()
        {
            var recipes = repository.GetAllRecipesWithSubCategory().OrderBy(r => r.SubCategory.SubCategoryID);
            var recipesList = repository.GetRecipesBySubCategoryId(1);
            var categories = repository.GetAllCategories();
            var subcategories = repository.GetSubCategoriesByCategoryId(1);

            RecipeListViewModel viewModel = new RecipeListViewModel(recipes.ToList(), recipesList, categories, subcategories, 1, 1);

            return View(viewModel);
        }

        //
        // GET: /Recipe/Details/5
        /// <summary>
        /// Displays the Recipe Details view
        /// </summary>
        /// <param name="id">RecipeId in the database</param>
        /// <returns>View, given a valid RecipeViewModel</returns>
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Details(int id)
        {
            var recipe = GetRecipeByID(id);
            return View(new RecipeViewModel(recipe, null, null, 0, 0));
        }

        //
        // GET: /Recipe/Create
        /// <summary>
        /// Displays a Recipe Create view
        /// </summary>
        /// <returns>A filled in Create Recipe view</returns>
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Create()
        {
            Category selectedCategory = repository.GetAllCategories().First();
            Recipe recipe = new Recipe();
            return View(new RecipeViewModel(recipe, repository.GetAllCategories(), repository.GetSubCategoriesByCategoryId(selectedCategory.CategoryID), selectedCategory.CategoryID, 0));
        }

        //
        // POST: /Recipe/Create
        /// <summary>
        /// Submits a Recipe Create view. The ViewModel is validated and, if successful, saved in the database. Otherwise the summary of exceptions is displayed
        /// </summary>
        /// <param name="viewModel">a RecipeViewModel</param>
        /// <returns>Redirects to the Recipe index</returns>
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Create(RecipeViewModel viewModel)
        {
            Recipe recipe = viewModel.Recipe;
            recipe.Category = repository.GetCategoryById(viewModel.CategoryID);
            recipe.SubCategoryID = viewModel.SubCategoryID;

            ValidateRecipeModel(recipe);

            if (ModelState.IsValid)
            {
                try
                {
                    repository.AddNewRecipe(recipe);
                }
                catch (DbEntityValidationException vex)
                {
                    //if the ModelState is valid, DbEntityValidationException can still occur when saving the data. The errors have to be logged and presented to the user.
                    foreach (var err in vex.EntityValidationErrors)
                    {
                        foreach (var innerError in err.ValidationErrors)
                        {
                            ModelState.AddModelError(string.Empty, innerError.ErrorMessage);
                        }
                    }
                }
                catch (DataException)
                {
                    ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage);
                }

                return RedirectToAction("Index");
            }
            
            //Log errors to the database
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    string s = error.ErrorMessage;
                }
            }
            return View(new RecipeViewModel(recipe, repository.GetAllCategories(),
                repository.GetSubCategoriesByCategoryId(recipe.Category.CategoryID), recipe.Category.CategoryID, recipe.SubCategoryID));
        }

        //
        // GET: /Recipe/Edit/5
        /// <summary>
        /// Edits the selected Recipe
        /// </summary>
        /// <param name="id">Recipe Id in the database</param>
        /// <returns>Edited recipe view</returns>
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Edit(int id)
        {
            RecipesEntities db = new RecipesEntities();

            Recipe recipe = db.Recipes.Include(r => r.SubCategory).Single(r => r.RecipeID == id);
            recipe.Category = db.Categories.Single(r => r.CategoryID == recipe.SubCategory.CategoryID);
            var allIngredients = db.Ingredients.ToList();
            var categories = db.Categories.ToList();
            var subCategories = db.SubCategories.Where(sc => sc.CategoryID == recipe.SubCategory.CategoryID).ToList();

            foreach (RecipeIngredient ri in recipe.RecipeIngredients)
            {
                ri.AllIngredients = allIngredients;
            }

            return View(new RecipeViewModel(recipe, categories, subCategories, recipe.Category.CategoryID, recipe.SubCategoryID));

            /*

            Recipe recipe = repository.GetRecipeByIdWithSubCategory(id);
            recipe.Category = repository.GetCategoryById(recipe.SubCategory.CategoryID);
            var categories = repository.GetAllCategories();
            var subCategories = repository.GetSubCategoriesByCategoryId(recipe.SubCategory.CategoryID);
            List<Ingredient> allIngredients = repository.GetAllIngredients();

            List<Ingredient> clone =
                new List<Ingredient>(allIngredients.Count);
            allIngredients.ForEach((item) => clone.Add(new Ingredient(item)));

            foreach (RecipeIngredient ri in recipe.RecipeIngredients)
            {
                //ri.Ingredient = repository.GetIngredientById(ri.IngredientID);
                ri.AllIngredients = clone;
            }

            return View(new RecipeViewModel(recipe, categories, subCategories, recipe.Category.CategoryID, recipe.SubCategoryID));
            */
        }

        /// <summary>
        /// Selects a category
        /// </summary>
        /// <param name="categoryid">category Id</param>
        /// <returns>Json result</returns>
        public ActionResult SelectCategory(int categoryid)
        {
            var subs = repository.GetSubCategoriesByCategoryId(categoryid)
            .Select(x => new SubCategoryViewModel
            {
                SubCategoryID = x.SubCategoryID,
                SubCategoryName = x.SubCategoryName
            });
            return Json(subs, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Updates a partial view of selected recipes
        /// </summary>
        /// <param name="subcatid">SubCategory id</param>
        /// <returns>Partial view</returns>
        public ActionResult UpdateSelected(int subcatid)
        {
            List<Recipe> recipes = repository.GetRecipesBySubCategoryId(subcatid);
            RecipeListViewModel viewModel = new RecipeListViewModel(null, recipes, null, null, 1, 1);
            return PartialView("_SelectedRecipes", viewModel);
        }

        public class SubCategoryViewModel
        {
            public int SubCategoryID { get; set; }
            public string SubCategoryName { get; set; }
        }

        //
        // POST: /Recipe/Edit/5
        /// <summary>
        /// Submits the edited Recipe
        /// </summary>
        /// <param name="model">RecipeViewModel entity</param>
        /// <returns></returns>
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Edit(RecipeViewModel model)
        {
            Recipe recipe = model.Recipe;
            var originalRecipe = GetRecipeByID(recipe.RecipeID);

            ValidateRecipeModel(recipe);

            var currentRecipe = repository.GetRecipeById(recipe.RecipeID);
            repository.SetEditedValues(currentRecipe, recipe);

            if (ModelState.IsValid)
            {
                repository.EditExistingRecipe(originalRecipe, recipe);
                return RedirectToAction("Index");
            }
            
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    string s = error.ErrorMessage;
                }
            }

            return View(model);
        }

        //
        // GET: /Recipe/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Delete(int id)
        {
            Recipe recipe = repository.GetRecipeById(id);
            return View(recipe);
        }

        public ViewResult Add()
        {
            var allIngredients = repository.GetAllIngredients();
            return View("_RIEditor", new RecipeIngredient() { AllIngredients = allIngredients });
        }

        //
        // POST: /Recipe/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteExistingRecipe(id);
            return RedirectToAction("Index");
        }

        private void ValidateRecipeModel(Recipe recipe)
        {
            if (recipe.Category == null || recipe.Category.CategoryID <= 0)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.RecipeHasNoCategory);
                recipe.Category = repository.GetAllCategories().OrderBy(c => c.CategoryID).FirstOrDefault();
            }

            if (recipe.SubCategoryID <= 0)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.RecipeHasNoSubCategory);
            }

            if (recipe.RecipeIngredients == null || recipe.RecipeIngredients.Count() < 1)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.RecipeHasNoIngredients);
            }
        }

        /// <summary>
        /// Returns a recipe entity from the database, populating the calculated fields
        /// </summary>
        /// <param name="id">Recipe database ID</param>
        /// <returns></returns>
        public Recipe GetRecipeByID(int id)
        {
            var recipe = repository.GetRecipeByIdWithSubCategory(id);
            recipe.Category = repository.GetCategoryById(recipe.SubCategory.CategoryID);
            foreach (RecipeIngredient ri in recipe.RecipeIngredients)
            {
                ri.Ingredient = repository.GetIngredientById(ri.IngredientID);

                recipe.TotalFatCalories = recipe.TotalFatCalories + ri.Quantity * ri.Ingredient.FatCaloriesPerMeasure();
                recipe.TotalCarbCalories = recipe.TotalCarbCalories + ri.Quantity * ri.Ingredient.CarbCaloriesPerMeasure();
                recipe.TotalProteinCalories = recipe.TotalProteinCalories +
                                              ri.Quantity * ri.Ingredient.ProteinCaloriesPerMeasure();
            }

            recipe.TotalCalories = recipe.TotalFatCalories + recipe.TotalCarbCalories + recipe.TotalProteinCalories;

            return recipe;
        }
    }
}
