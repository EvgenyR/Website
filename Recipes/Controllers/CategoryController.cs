using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using System.Data.Entity.Validation;
using Recipes.ViewModels;

namespace Recipes.Controllers
{ 
    public class CategoryController : BaseController
    {
        private RecipesEntities db = new RecipesEntities();

        //
        // GET: /Category/

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ViewResult Index()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Category/Details/5

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ViewResult Details(int id)
        {
            var category = db.Categories.Single(c => c.CategoryID == id);
            category.Recipes = CategoryRecipes(id);
            return View(new CategoryViewModel(category));
        }

        //
        // GET: /Category/Create

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Category/Create

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Create(Category category)
        {
            ValidateCategory(category);

            if (ModelState.IsValid)
            {
                try
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(DbEntityValidationException vex)
                {
                    foreach (var err in vex.EntityValidationErrors)
                    {
                        foreach (var err2 in err.ValidationErrors)
                        {
                            ModelState.AddModelError(string.Empty, err2.ErrorMessage);
                        }
                    }
                }
                catch (DataException)
                {
                    ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage);
                }
            }

            return View(new CategoryViewModel(category));
        }
        
        //
        // GET: /Category/Edit/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Find(id);
            return View(new CategoryViewModel(category));
        }

        //
        // POST: /Category/Edit/5

        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            ValidateCategory(category);

            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(new CategoryViewModel(category));
        }

        //
        // GET: /Category/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            return View(new CategoryViewModel(category));
        }

        //
        // POST: /Category/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            ValidateCategoryUsage(category);

            if (ModelState.IsValid)
            {
                try
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
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
                catch (DataException)
                {
                    ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage);
                }
                return RedirectToAction("Index");
            }
            else
            {
                category = db.Categories.Find(id);
                ViewData.Model = category;
                return View(new CategoryViewModel(category));
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private List<Recipe> CategoryRecipes(int id)
        {
            return db.Recipes.Where(r => r.SubCategory.CategoryID == id).ToList();
        }

        private void ValidateCategory(Category category)
        {
            if (category.CategoryName == null || category.CategoryName.Length < 3)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.CategoryNameTooShort);
            }
            else if (category.CategoryName.Length > 50)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.CategoryNameTooLong);
            }

            if (category.Description == null || category.Description.Length < 10)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.CategoryDescTooShort);
            }
            else if (category.Description.Length > 100)
            {
                ModelState.AddModelError(string.Empty, Constants.Constants.CategoryDescTooLong);
            }
        }

        private void ValidateCategoryUsage(Category category)
        {
            int count = 0;
            string usage = string.Empty;

            List<SubCategory> subcats = db.SubCategories.Where(s => s.CategoryID == category.CategoryID).ToList();

            if (subcats.Count > 0)
            {
                foreach (var subcat in subcats)
                {
                    if (usage.Length > 0)
                    {
                        usage = usage + ", ";
                    }
                    usage = usage + subcat.SubCategoryName;
                    count++;
                
                }

                if (usage.Length > 0)
                {
                    string msg = "Cannot delete category. It has the following SubCategorie";
                    if (count > 1)
                    {
                        msg = msg + "s";
                    }
                    usage = msg + ": " + usage;
                    ModelState.AddModelError(string.Empty, usage);
                }
            }
            else
            {
                List<int> subcatIDs = subcats.Select(s => s.SubCategoryID).ToList();
                if(subcatIDs.Count > 0)
                {
                    List<Recipe> recipes = db.Recipes.Where(r => subcatIDs.Contains(r.SubCategoryID)).ToList();
                    if(recipes.Count > 0)
                    {
                        foreach (var recipe in recipes)
                        {
                            if (usage.Length > 0)
                            {
                                usage = usage + ", ";
                            }
                            usage = usage + recipe.RecipeName;
                            count++;
                        }
                        if (usage.Length > 0)
                        {
                            string msg = "Cannot delete category. It has the following recipe";
                            if (count > 1)
                            {
                                msg = msg + "s";
                            }
                            usage = msg + ": " + usage;
                            ModelState.AddModelError(string.Empty, usage);
                        }
                    }
                }
            }
        }
    }
}