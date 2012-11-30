using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Recipes.Models;
using Recipes.ViewModels;

namespace Recipes.Controllers
{
    public class PostController : BaseController
    {
        private RecipesEntities db = new RecipesEntities();

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
            Blog blog = db.Blogs.Find(id);
            Blogger blogger = db.Bloggers.Where(b => b.BloggerID == blog.BloggerID).FirstOrDefault();
            List<Post> posts = db.Posts.Where(p => p.BlogID == id).ToList();
            //BlogViewModel viewModel = new BlogViewModel(blog, posts, null, blog.BloggerID, null);
            PostViewModel viewModel = new PostViewModel(blog, blogger, null, posts);
            return View(viewModel);
        }

        //
        // GET: /Post/Details/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Details(int id = 0)
        {
            Post post = db.Posts.Find(id);
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
            Post post = db.Posts.Find(id);
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
            Blog blog = db.Blogs.Find(id);
            List<Post> posts = db.Posts.Where(p => p.BlogID == id).ToList();
            Blogger blogger = db.Bloggers.Where(b => b.BloggerID == blog.BloggerID).FirstOrDefault();

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
                db.Posts.Add(viewModel.Post);
                db.SaveChanges();
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
            Post post = db.Posts.Find(id);
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
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
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
            Post post = db.Posts.Find(id);
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

            Post post = db.Posts.Find(id);
            int blogID = post.BlogID;
            db.Posts.Remove(post);
            db.SaveChanges();
            string action = "../Post/Index/" + post.BlogID.ToString();
            return RedirectToAction(action);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}