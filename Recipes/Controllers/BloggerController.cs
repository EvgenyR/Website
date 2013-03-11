using System.Data;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using System.Collections.Generic;
using Recipes.ViewModels;
using Recipes.Repository;

namespace Recipes.Controllers
{
    public class BloggerController : BaseController
    {
        //private readonly RecipesEntities db = new RecipesEntities();

        IBlogRepository repository;

        public BloggerController()
            : this(new BlogRepository())
        { }

        public BloggerController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Blogger/
        /// <summary>
        /// Returns a list of bloggers
        /// </summary>
        /// <returns>Index view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Index()
        {
            return View(repository.GetAllBloggers());
        }

        //
        // GET: /Blogger/Details/5
        /// <summary>
        /// Returns details of a blogger
        /// </summary>
        /// <param name="id">blogger id</param>
        /// <returns>Details view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Details(int id = 0)
        {
            Blogger blogger = repository.GetBloggerByID(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }

            List<Blog> blogs = repository.GetBlogsByBloggerId(blogger.BloggerID);
            BloggerViewModel viewModel = new BloggerViewModel(blogger, blogs);

            return View(viewModel);
        }

        //
        // GET: /Blogger/Create
        /// <summary>
        /// Creates a blogger
        /// </summary>
        /// <returns>View</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blogger/Create
        /// <summary>
        /// Creates a blogger in the database
        /// </summary>
        /// <param name="blogger">Blogger object</param>
        /// <returns>Redirects to a list of bloggers</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Create(Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                repository.AddNewBlogger(blogger);
                return RedirectToAction("Index");
            }

            return View(blogger);
        }

        //
        // GET: /Blogger/Edit/5
        /// <summary>
        /// Edits blogger details
        /// </summary>
        /// <param name="id">Id of a blogger</param>
        /// <returns>Edit view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Edit(int id = 0)
        {
            Blogger blogger = repository.GetBloggerByID(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        //
        // POST: /Blogger/Edit/5
        /// <summary>
        /// Edits a blogger
        /// </summary>
        /// <param name="blogger">Edited blogger entiry</param>
        /// <returns>Redirects to Index of bloggers</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Edit(Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                repository.EditExistingBlogger(blogger);
                return RedirectToAction("Index");
            }
            return View(blogger);
        }

        //
        // GET: /Blogger/Delete/5
        /// <summary>
        /// Initiates deletion of a blogger
        /// </summary>
        /// <param name="id">Id of a blogger to delete</param>
        /// <returns>Delete view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Delete(int id = 0)
        {
            Blogger blogger = repository.GetBloggerByID(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        //
        // POST: /Blogger/Delete/5
        /// <summary>
        /// Confirms deletion of a blogger
        /// </summary>
        /// <param name="id">Id of a blogger to delete</param>
        /// <returns>Redirects to blogger index</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteExistingBlogger(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}