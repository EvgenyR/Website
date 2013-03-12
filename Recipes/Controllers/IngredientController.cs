using System.Web.Mvc;
using Recipes.Models;
using System.Data;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using Recipes.Repository;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class IngredientController : BaseController
    {
        private readonly IRecipesRepository repository;

        //constructor chaining
        //avoid "no parameterless constructor defined for this object"
        public IngredientController()
            : this(new RecipesRepository())
        { }

        public IngredientController(IRecipesRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Ingredient/
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Index()
        {
            var ingredients = repository.GetAllIngredients();
            return View(ingredients);
        }

        //
        // GET: /Ingredient/Details/5

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Details(int id)
        {
            var ingredient = repository.GetIngredientById(id);
            ingredient.RecipeIngredients = repository.GetRecipeIngredientsByIngredientId(ingredient.IngredientID);
            return View(new IngredientViewModel(ingredient, repository.GetAllMeasures()));
        }

        //
        // GET: /Ingredient/Create

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Create()
        {
            return View(new IngredientViewModel(new Ingredient(), repository.GetAllMeasures()));
        } 

        //
        // POST: /Ingredient/Create
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Create(Ingredient ingredient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.AddNewIngredient(ingredient);
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        ModelState.AddModelError(string.Empty, err2.ErrorMessage);
                    }
                }
            }
            catch(DataException e)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage );
            }
            return View(new IngredientViewModel(ingredient, repository.GetAllMeasures()));
        }
        
        //
        // GET: /Ingredient/Edit/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Edit(int id)
        {
            Ingredient ingredient = repository.GetIngredientById(id);
            return View(new IngredientViewModel(ingredient, repository.GetAllMeasures()));
        }

        //
        // POST: /Ingredient/Edit/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Edit(Ingredient ingredient)
        {
            if(ModelState.IsValid)
            {
                repository.EditExistingIngredient(ingredient);
                return RedirectToAction("Index");
            }
            
            return View(new IngredientViewModel(ingredient, repository.GetAllMeasures()));
        }

        //
        // GET: /Ingredient/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Delete(int id)
        {
            Ingredient ingredient = repository.GetIngredientById(id);
            return View(new IngredientViewModel(ingredient, repository.GetAllMeasures()));
        }

        //
        // POST: /Ingredient/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = repository.GetIngredientById(id);
            ValidateIngredientUsage(ingredient);

            if(ModelState.IsValid)
            {
                repository.DeleteExistingIngredient(ingredient);
                return RedirectToAction("Index");
            }
            
            ingredient = repository.GetIngredientById(id);
            ViewData.Model = ingredient;
            return View(new IngredientViewModel(ingredient, repository.GetAllMeasures()));
        }

        private void ValidateIngredientUsage(Ingredient ingredient)
        {
            int count = 0;
            string usage = string.Empty;

            List<RecipeIngredient> riList = repository.GetRecipeIngredientsByIngredientId(ingredient.IngredientID);

            if(riList.Count > 0)
            { 
                foreach(var ri in riList)
                {
                    Recipe recipe = repository.GetRecipeById(ri.RecipeID);
                    if (usage.Length > 0)
                        {
                            usage = usage + ", ";
                        }
                        usage = usage + recipe.RecipeName;
                        count++;
                }

                if (usage.Length > 0)
                {
                    string msg = count > 1 ? Constants.Constants.CanNotDeleteIngredientWithRecipes
                                                   : Constants.Constants.CanNotDeleteIngredientWithRecipe;
                    
                    usage = msg + usage;
                }

                ModelState.AddModelError(string.Empty, usage);
            }
        }
    }
}
