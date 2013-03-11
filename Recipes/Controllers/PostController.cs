using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.Repository;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class PostController : BaseController
    {
        IBlogRepository repository;

        public PostController()
            : this(new BlogRepository())
        { }

        public PostController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Post/

        //public ActionResult Index()
        //{
        //    return View(db.Posts.ToList());
        //}
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Index(int id)
        {
            List<Post> posts = repository.GetPostsByBlogID(id);
            Blog blog = repository.GetBlogByID(id);
            Blogger blogger = repository.GetBloggerByID(blog.BloggerID);
            PostViewModel viewModel = new PostViewModel(blog, blogger, null, posts);
            return View(viewModel);
        }

        //
        // GET: /Post/Details/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Details(int id = 0)
        {
            Post post = repository.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
            //return RedirectToAction("Details", new {id = id, })
        }

        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Display(int id = 0)
        {
            Post post = repository.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
            //return RedirectToAction("Details", new {id = id, })
        }

        //
        // GET: /Post/Create
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Create(int id)
        {
            Blog blog = repository.GetBlogByID(id);
            List<Post> posts = repository.GetPostsByBlogID(id);
            Blogger blogger = repository.GetBloggerByID(blog.BloggerID);

            Post newPost = new Post();
            newPost.BlogID = blog.BlogID;
            newPost.DateCreated = DateTime.Now;
 
            PostViewModel viewModel = new PostViewModel(blog, blogger, newPost, posts);
            return View(viewModel);
        }

        //
        // POST: /Post/Create
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Create(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                repository.AddNewPost(viewModel.Post);
                string action = "../Post/Index/" + viewModel.Post.BlogID.ToString();
                return RedirectToAction(action);
            }

            return View(viewModel);
        }

        //
        // GET: /Post/Edit/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Edit(int id = 0)
        {
            Post post = repository.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Edit/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                repository.EditExistingPost(post);
                string action = "../Post/Index/" + post.BlogID.ToString();
                return RedirectToAction(action);
            }
            return View(post);
        }

        //
        // GET: /Post/Delete/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Delete(int id = 0)
        {
            Post post = repository.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Delete/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            Post post = repository.GetPostByID(id);
            int blogID = post.BlogID;
            repository.DeleteExistingPost(post);
            string action = "../Post/Index/" + post.BlogID.ToString();
            return RedirectToAction(action);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}