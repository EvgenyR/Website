using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recipes.ViewModels;
using Recipes.Models;
using System.Data;
using System.Data.Entity.Validation;

namespace Recipes.Controllers
{
    public class BlogController : BaseController
    {
        RecipesEntities db = new RecipesEntities();

        private int iPostsDisplayed;

        //
        // GET: /Blog/
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpGet]
        public ActionResult Index()
        {
            iPostsDisplayed = 3;
            return View(ViewModelFromBlogID(1));
        }

        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Index(int id)
        {
            iPostsDisplayed = 3;
            return View(ViewModelFromBlogID(id));
        }

        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult List()
        {
            iPostsDisplayed = 3;
            return View(db.Blogs.ToList());
        }

        //
        // GET: /Default1/Details/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Details(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            blog.Blogger = db.Bloggers.Where(b => b.BloggerID == blog.BloggerID).FirstOrDefault();

            BlogViewModel viewModel = new BlogViewModel(blog, null, null, null, iPostsDisplayed);

            return View(viewModel);
        }

        //
        // GET: /Default1/Create
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Create()
        {
            Blog blog = new Blog();
            blog.Blogger = db.Bloggers.FirstOrDefault();
            blog.BloggerID = blog.Blogger.BloggerID;
            BlogViewModel viewModel = new BlogViewModel(blog, new List<Post>(), db.Blogs.ToList(), db.Bloggers.ToList(), iPostsDisplayed);
            return View(viewModel);
         }

        //
        // POST: /Default1/Create
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Create(BlogViewModel viewModel)
        {
            Blog blog = viewModel.Blog;
            blog.Blogger = db.Bloggers.Where(b => b.BloggerID == viewModel.Blog.BloggerID).FirstOrDefault();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Blogs.Add(blog);
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
                catch (DataException ex)
                {
                    ModelState.AddModelError(string.Empty, Constants.Constants.DataExceptionMessage);
                }

                return RedirectToAction("../Blog/List");
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        string s = error.ErrorMessage;
                    }
                }
            }
            return View(new BlogViewModel(blog, null, db.Blogs.ToList(), null, iPostsDisplayed));
        }

        //
        // GET: /Default1/Edit/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Edit(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            blog.Blogger = db.Bloggers.Single(b => b.BloggerID == blog.BloggerID);
            return View(new BlogViewModel(blog, null, null, db.Bloggers.ToList(), iPostsDisplayed));
        }

        //
        // POST: /Default1/Edit/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost]
        public ActionResult Edit(BlogViewModel model)
        {
            Blog blog = model.Blog;
            blog.BloggerID = model.Blog.Blogger.BloggerID;
            blog.Blogger = db.Bloggers.Find(blog.BloggerID);

            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Blog/List");
            }
            return View(model);
        }

        //
        // GET: /Default1/Delete/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        public ActionResult Delete(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);          
            blog.Blogger = db.Bloggers.Find(blog.BloggerID);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Default1/Delete/5
        [MetaKeywords(Constants.Constants.BlogMetaKeywords)]
        [MetaDescription(Constants.Constants.BlogMetaDescription)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);

            //if posts exist, delete posts
            List<Post> posts = db.Posts.Where(p => p.BlogID == blog.BlogID).ToList();
            if (posts != null && posts.Count > 0)
            {
                foreach(Post post in posts)
                {
                    db.Posts.Remove(post);
                }
            }
            //then delete blog

            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("../Blog/List");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Update(int id)
        {
            BlogViewModel model = ViewModelFromBlogID(id);
            return PartialView("_BlogContent", model);
        }

        public ActionResult MorePosts(int id, int postsDisplayed)
        {
            BlogViewModel model = ViewModelFromBlogID(id);
            model.PostsDisplayed = postsDisplayed;
            return PartialView("_BlogContent", model);
        }

        public ActionResult LessPosts(int id, int postsDisplayed)
        {
            BlogViewModel model = ViewModelFromBlogID(id);
            model.PostsDisplayed = postsDisplayed;
            return PartialView("_BlogContent", model);
        }

        public BlogViewModel ViewModelFromBlogID(int id)
        {
            Blog blog = db.Blogs.Where(b => b.BlogID == id).FirstOrDefault();
            List<Post> posts = db.Posts.Where(p => p.BlogID == id).OrderByDescending(p => p.DateCreated).ToList();
            List<Blog> blogs = db.Blogs.ToList();
            List<Blogger> bloggers = db.Bloggers.ToList();

            BlogViewModel model = new BlogViewModel(blog, posts, blogs, bloggers, iPostsDisplayed);

            return model;
        }

    }
}
