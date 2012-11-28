using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Controllers
{ 
    public class SubCategoryController : BaseController
    {
        private RecipesEntities db = new RecipesEntities();

        //
        // GET: /SubCategory/
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ViewResult Index()
        {
            var subcategories = db.SubCategories.Include(s => s.Category);
            return View(subcategories.ToList());
        }

        //
        // GET: /SubCategory/Details/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ViewResult Details(int id)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            return View(new SubCategoryViewModel(subcategory, null));
        }

        //
        // GET: /SubCategory/Create
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View(new SubCategoryViewModel(new SubCategory(), db.Categories.ToList()));
        } 

        //
        // POST: /SubCategory/Create
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Create(SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories.Add(subcategory);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", subcategory.CategoryID);
            return View(subcategory);
        }
        
        //
        // GET: /SubCategory/Edit/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Edit(int id)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", subcategory.CategoryID);
            return View(new SubCategoryViewModel(subcategory, db.Categories.ToList()));
        }

        //
        // POST: /SubCategory/Edit/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost]
        public ActionResult Edit(SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", subcategory.CategoryID);
            return View(subcategory);
        }

        //
        // GET: /SubCategory/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        public ActionResult Delete(int id)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            return View(subcategory);
        }

        //
        // POST: /SubCategory/Delete/5
        [MetaKeywords(Constants.Constants.RecipeMetaKeywords)]
        [MetaDescription(Constants.Constants.RecipeMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SubCategory subcategory = db.SubCategories.Find(id);
            db.SubCategories.Remove(subcategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}