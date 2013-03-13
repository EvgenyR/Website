using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Web.Mvc;
using Recipes.LogHelpers;
using Recipes.Models;
using Recipes.Repository;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogRepository repository;
        private const string InfoLogMessage = "Blog Controller method {0} accessed";
        private const string InfoLogMessageWithParam = InfoLogMessage + " with a parameter {1}={2}";

        private string methodName;
        private static readonly string className = GetClassName();

        private int _postsDisplayed;

        //constructor chaining
        //avoid "no parameterless constructor defined for this object"
        public BlogController()
            : this(new BlogRepository())
        { }

        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Blog/
        /// <summary> 
        /// Displays the Index of a specified blog
        /// </summary> 
        /// <returns>Index view</returns>
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpGet]
        public ActionResult Index(int BlogId = 1, int p = 1)
        {
            methodName = MethodBase.GetCurrentMethod().Name;

            WriteLog(string.Format(InfoLogMessage, methodName), (int)LogTypeNames.Info);

            return View(ViewModelFromBlogID(p, BlogId));
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
            return View(repository.GetAllBlogs());
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
            Blog blog = repository.GetBlogByID(id);
            if (blog == null)
            {
                Logger.WriteEntry(string.Format("Blog with id={0} not found by {1} method.", id, methodName), GetType().FullName, (int)LogTypeNames.Warn);            
                return HttpNotFound();
            }
            blog.Blogger = repository.GetBloggerByID(blog.BloggerID);

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
            Blog blog = new Blog {Blogger = repository.GetFirstBlogger()};
            blog.BloggerID = blog.Blogger.BloggerID;
            BlogViewModel viewModel = new BlogViewModel(blog, new List<Post>(), repository.GetAllBlogs(), repository.GetAllBloggers(), _postsDisplayed);
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
            blog.Blogger = repository.GetBloggerByID(viewModel.Blog.BloggerID);

            if (ModelState.IsValid)
            {
                try
                {
                    repository.AddNewBlog(blog);
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
            return View(new BlogViewModel(blog, null, repository.GetAllBlogs(), null, _postsDisplayed));
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
            Blog blog = repository.GetBlogByID(id);
            blog.Blogger = repository.GetBloggerByID(blog.BloggerID);
            WriteLog(string.Format(InfoLogMessageWithParam, methodName, "id", id), (int)LogTypeNames.Info);            
            return View(new BlogViewModel(blog, null, null, repository.GetAllBloggers(), _postsDisplayed));
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
            blog.Blogger = repository.GetBloggerByID(blog.BloggerID);

            if (ModelState.IsValid)
            {
                repository.EditExistingBlog(blog);
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
            Blog blog = repository.GetBlogByID(id);          
            blog.Blogger = repository.GetBloggerByID(blog.BloggerID);
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
            repository.DeleteExistingBlog(id);
            WriteLog(String.Format("Deleted Blog with id={0} by {1}", id, methodName), (int)LogTypeNames.Info);
            return RedirectToAction("../Blog/List");
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
            BlogViewModel model = ViewModelFromBlogID(0, id);
            return PartialView("_BlogContent", model);
        }

        /// <summary>
        /// Creates a ViewModel given a blog id
        /// </summary>
        /// <param name="id">Id of a blog</param>
        /// <returns>ViewModel contains data about Blog, Posts, all blogs, all bloggers and number of posts to display by default</returns>
        public BlogViewModel ViewModelFromBlogID(int p, int blogId)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            var posts = repository.GetPostPage(p - 1, 10, blogId);
            var totalPosts = repository.TotalPosts(blogId);

            BlogViewModel model = new BlogViewModel
            {
                BlogId = blogId,
                Blog = repository.GetBlogByID(blogId),
                Posts = posts,
                Blogs = repository.GetAllBlogs(),
                Bloggers = repository.GetAllBloggers(),
                TotalPosts = totalPosts
            };

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
            return new BlogController(new BlogRepository()).GetType().Name;
        }
    }
}