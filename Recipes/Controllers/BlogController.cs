using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recipes.ViewModels;
using Recipes.Models;
using System.Data;
using System.Data.Entity.Validation;
using Recipes.LogHelpers;
using System;
using System.Reflection;

namespace Recipes.Controllers
{
    public class BlogController : BaseController
    {
        readonly RecipesEntities _db = new RecipesEntities();
        private const string InfoLogMessage = "Blog Controller method {0} accessed";
        private const string InfoLogMessageWithParam = InfoLogMessage + " with a parameter {1}={2}";

        private string methodName;
        private static readonly string className = GetClassName();

        private int _postsDisplayed;

        //
        // GET: /Blog/
        /// <summary> 
        /// Displays the Index of a default blog
        /// </summary> 
        /// <returns>Index view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpGet]
        public ActionResult Index()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            _postsDisplayed = 10;
            WriteLog(string.Format(InfoLogMessage, methodName), (int)LogTypeNames.Info);            
            return View(ViewModelFromBlogID(1));
        }

        /// <summary> 
        /// Displays the Index of a specified blog
        /// </summary> 
        /// <param name="id">
        /// Id of the Blog to display
        /// </param>
        /// <returns>Index view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Index(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            _postsDisplayed = 10;
            WriteLog(string.Format(InfoLogMessageWithParam, methodName, "id", id), (int)LogTypeNames.Info);            
            return View(ViewModelFromBlogID(id));
        }

        /// <summary> 
        /// Displays the List of all blogs
        /// </summary> 
        /// <returns>List View</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult List()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            _postsDisplayed = 10;
            WriteLog(string.Format(InfoLogMessage, methodName), (int)LogTypeNames.Info);            
            return View(_db.Blogs.ToList());
        }

        //
        // GET: /Default1/Details/5
        /// <summary> 
        /// Displays the details information about a blog
        /// </summary> 
        /// <param name="id">
        /// Id of the Blog to display information about
        /// </param>
        /// <returns>Details view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Details(int id = 0)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = _db.Blogs.Find(id);
            if (blog == null)
            {
                Logger.WriteEntry(string.Format("Blog with id={0} not found by {1} method.", id, methodName), GetType().FullName, (int)LogTypeNames.Warn);            
                return HttpNotFound();
            }
            blog.Blogger = _db.Bloggers.Where(b => b.BloggerID == blog.BloggerID).FirstOrDefault();

            BlogViewModel viewModel = new BlogViewModel(blog, null, null, null, _postsDisplayed);
            WriteLog(string.Format(InfoLogMessageWithParam, methodName, "id", id), (int)LogTypeNames.Info);            
            return View(viewModel);
        }

        //
        // GET: /Default1/Create
        /// <summary> 
        /// Creates a new blog
        /// </summary> 
        /// <returns>Create view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Create()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = new Blog {Blogger = _db.Bloggers.FirstOrDefault()};
            blog.BloggerID = blog.Blogger.BloggerID;
            BlogViewModel viewModel = new BlogViewModel(blog, new List<Post>(), _db.Blogs.ToList(), _db.Bloggers.ToList(), _postsDisplayed);
            WriteLog(string.Format(InfoLogMessage, methodName), (int)LogTypeNames.Info);            
            return View(viewModel);
         }

        //
        // POST: /Default1/Create
        /// <summary> 
        /// Creates a new blog from a BlogViewModel entity
        /// </summary> 
        /// <param name="viewModel">
        /// ViewModel contains data about Blog, Posts, all blogs, all bloggers and number of posts to display by default
        /// </param>
        /// <returns>Create view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Create(BlogViewModel viewModel)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = viewModel.Blog;
            blog.Blogger = _db.Bloggers.Where(b => b.BloggerID == viewModel.Blog.BloggerID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Blogs.Add(blog);
                    _db.SaveChanges();
                }
                catch (DbEntityValidationException vex)
                {
                    WriteException(vex);
                    foreach (var evError in vex.EntityValidationErrors)
                    {
                        foreach (var vError in evError.ValidationErrors)
                        {
                            WriteLog(String.Format("Model Error found in {0}: " + vError.ErrorMessage, methodName), (int)LogTypeNames.Error);
                            ModelState.AddModelError(string.Empty, vError.ErrorMessage);
                        }
                    }
                }
                catch (DataException dex)
                {
                    WriteException(dex);
                    ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage);
                }

                return RedirectToAction("../Blog/List");
            }
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    WriteLog(String.Format("ModelState Error found in {0}: " + error.ErrorMessage, methodName), (int)LogTypeNames.Error);
                }
            }
            WriteLog(String.Format("Created Blog with id={0} by {1}", blog.BlogID, methodName), (int)LogTypeNames.Info);
            return View(new BlogViewModel(blog, null, _db.Blogs.ToList(), null, _postsDisplayed));
        }

        //
        // GET: /Default1/Edit/5
        /// <summary> 
        /// Edit the blog details
        /// </summary> 
        /// <param name="id">
        /// Id of the blog to edit
        /// </param>
        /// <returns>Details view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Edit(int id = 0)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = _db.Blogs.Find(id);
            blog.Blogger = _db.Bloggers.Single(b => b.BloggerID == blog.BloggerID);
            WriteLog(string.Format(InfoLogMessageWithParam, methodName, "id", id), (int)LogTypeNames.Info);            
            return View(new BlogViewModel(blog, null, null, _db.Bloggers.ToList(), _postsDisplayed));
        }

        //
        // POST: /Default1/Edit/5
        /// <summary> 
        /// Edit the blog details, use ViewModel
        /// </summary> 
        /// <param name="viewModel">
        /// ViewModel contains data about Blog, Posts, all blogs, all bloggers and number of posts to display by default
        /// </param>
        /// <returns>Details view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Edit(BlogViewModel viewModel)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = viewModel.Blog;
            blog.BloggerID = viewModel.Blog.Blogger.BloggerID;
            blog.Blogger = _db.Bloggers.Find(blog.BloggerID);

            if (ModelState.IsValid)
            {
                _db.Entry(blog).State = EntityState.Modified;
                _db.SaveChanges();
                WriteLog(String.Format("Edited Blog with id={0} by {1}", blog.BlogID, methodName), (int)LogTypeNames.Info);
                return RedirectToAction("../Blog/List");
            }
            WriteLog(String.Format("Invalid Model State in {0}", methodName), (int)LogTypeNames.Warn);
            return View(viewModel);
        }

        //
        // GET: /Default1/Delete/5
        /// <summary> 
        /// Delete a blog
        /// </summary> 
        /// <param name="id">
        /// id of the blog to delete
        /// </param>
        /// <returns>Details view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Delete(int id = 0)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = _db.Blogs.Find(id);          
            blog.Blogger = _db.Bloggers.Find(blog.BloggerID);
            WriteLog(string.Format(InfoLogMessage, methodName), (int)LogTypeNames.Info);            
            return View(blog);
        }

        //
        // POST: /Default1/Delete/5
        /// <summary> 
        /// Delete a blog, confirmation
        /// </summary> 
        /// <param name="id">
        /// id of the blog to delete
        /// </param>
        /// <returns>Redirects to blog list</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = _db.Blogs.Find(id);

            //if posts exist, delete posts
            List<Post> posts = _db.Posts.Where(p => p.BlogID == blog.BlogID).ToList();
            if (posts.Count > 0)
            {
                foreach(Post post in posts)
                {
                    _db.Posts.Remove(post);
                }
            }
            //then delete blog

            _db.Blogs.Remove(blog);
            _db.SaveChanges();
            WriteLog(String.Format("Deleted Blog with id={0} by {1}", id, methodName), (int)LogTypeNames.Info);
            return RedirectToAction("../Blog/List");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Update blog details
        /// </summary> 
        /// <param name="id">
        /// id of the blog to update
        /// </param>
        /// <returns>Partial view with updated blog contents</returns>
        public ActionResult Update(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            BlogViewModel model = ViewModelFromBlogID(id);
            return PartialView("_BlogContent", model);
        }

        /// <summary> 
        /// Display one additional post
        /// </summary> 
        /// <param name="id">
        /// id of the blog
        /// </param>
        /// <param name="postsDisplayed">
        /// number of posts to display
        /// </param>
        /// <returns>Partial view with updated blog contents</returns>
        public ActionResult MorePosts(int id, int postsDisplayed)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            BlogViewModel model = ViewModelFromBlogID(id);
            model.PostsDisplayed = postsDisplayed;
            return PartialView("_BlogContent", model);
        }

        /// <summary> 
        /// Display one less post
        /// </summary> 
        /// <param name="id">
        /// id of the blog
        /// </param>
        /// <param name="postsDisplayed">
        /// number of posts to display
        /// </param>
        /// <returns>Partial view with updated blog contents</returns>
        public ActionResult LessPosts(int id, int postsDisplayed)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            BlogViewModel model = ViewModelFromBlogID(id);
            model.PostsDisplayed = postsDisplayed;
            return PartialView("_BlogContent", model);
        }

        /// <summary>
        /// Creates a ViewModel given a blog id
        /// </summary>
        /// <param name="id">Id of a blog</param>
        /// <returns>ViewModel contains data about Blog, Posts, all blogs, all bloggers and number of posts to display by default</returns>
        public BlogViewModel ViewModelFromBlogID(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            Blog blog = _db.Blogs.Where(b => b.BlogID == id).FirstOrDefault();
            List<Post> posts = _db.Posts.Where(p => p.BlogID == id).OrderByDescending(p => p.DateCreated).ToList();
            List<Blog> blogs = _db.Blogs.ToList();
            List<Blogger> bloggers = _db.Bloggers.ToList();

            BlogViewModel model = new BlogViewModel(blog, posts, blogs, bloggers, _postsDisplayed);

            return model;
        }

        private static void WriteLog(string message, int type)
        {
            Logger.WriteEntry(message, className, type);            
        }

        private static void WriteException(Exception ex)
        {
            Logger.WriteEntry(ex);
        }

        private static string GetClassName()
        {
            return new BlogController().GetType().Name;
        }
    }
}
