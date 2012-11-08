using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using System.Data;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class IngredientController : BaseController
    {
        RecipesEntities db = new RecipesEntities();
        //
        // GET: /Ingredient/
        public ActionResult Index()
        {
            var ingredients = db.Ingredients.ToList();
            return View(ingredients);
        }

        //
        // GET: /Ingredient/Details/5

        public ActionResult Details(int id)
        {
            var ingredient = db.Ingredients.Single(i => i.IngredientID == id);
            ingredient.RecipeIngredients = db.RecipeIngredients.Where(ri => ri.IngredientID == ingredient.IngredientID).ToList();
            return View(new IngredientViewModel(ingredient, db.Measures.ToList()));
        }

        //
        // GET: /Ingredient/Create

        public ActionResult Create()
        {
            return View(new IngredientViewModel(new Ingredient(), db.Measures.ToList()));
        } 

        //
        // POST: /Ingredient/Create

        [HttpPost]
        public ActionResult Create(Ingredient ingredient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Ingredients.Add(ingredient);
                    db.SaveChanges();
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
            catch(DataException ex)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage );
            }
            return View(new IngredientViewModel(ingredient, db.Measures.ToList()));
        }
        
        //
        // GET: /Ingredient/Edit/5
 
        public ActionResult Edit(int id)
        {
            Ingredient ingredient = db.Ingredients.Single(i => i.IngredientID == id);
            return View(new IngredientViewModel(ingredient, db.Measures.ToList()));
        }

        //
        // POST: /Ingredient/Edit/5

        [HttpPost]
        public ActionResult Edit(Ingredient ingredient)
        {

            if(ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(new IngredientViewModel(ingredient, db.Measures.ToList()));
            }
        }

        //
        // GET: /Ingredient/Delete/5
 
        public ActionResult Delete(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            return View(new IngredientViewModel(ingredient, db.Measures.ToList()));
        }

        //
        // POST: /Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            ValidateIngredientUsage(ingredient);

            if(ModelState.IsValid)
            {
                db.Ingredients.Remove(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ingredient = db.Ingredients.Find(id);
                ViewData.Model = ingredient;
                return View(new IngredientViewModel(ingredient, db.Measures.ToList()));
            }
        }

        private void ValidateIngredientUsage(Ingredient ingredient)
        {
            int count = 0;
            string usage = string.Empty;

            List<RecipeIngredient> riList = db.RecipeIngredients.Where(ri => ri.IngredientID == ingredient.IngredientID).ToList();

            if(riList.Count > 0)
            { 
                foreach(var ri in riList)
                {
                    Recipe recipe = db.Recipes.Find(ri.RecipeID);
                    if (usage.Length > 0)
                        {
                            usage = usage + ", ";
                        }
                        usage = usage + recipe.RecipeName;
                        count++;
                }

                if (usage.Length > 0)
                {
                    string msg = "Cannot delete ingredient. It is used in the following recipe";
                    if (count > 1)
                    {
                        msg = msg + "s";
                    }
                    usage = msg + ": " + usage;
                }

                ModelState.AddModelError(string.Empty, usage);
            }
        }
    }
}
