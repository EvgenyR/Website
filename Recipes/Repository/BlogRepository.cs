using System.Collections.Generic;
using System.Data;
using System.Linq;
using Recipes.Models;
using System.Data.Entity;
using Recipes.LogHelpers;
using System.Reflection;

namespace Recipes.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private string methodName;

        #region BlogOperations

        public Blog GetBlogByID(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                Logger.WriteEntry(string.Format("Blog with id={0} returned by method {1}.", id, methodName), GetType().FullName, (int)LogTypeNames.Info);
                return db.Blogs.Find(id);
            }
        }

        public List<Blog> GetAllBlogs()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Blogs.ToList();
            }
        }

        public List<Blog> GetBlogsByBloggerId(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Blogs.Where(b => b.BloggerID == id).ToList();
            }        
        }

        public void AddNewBlog(Blog blog)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        public void EditExistingBlog(Blog blog)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingBlog(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                Blog blog = GetBlogByID(id);

                //if posts exist, delete posts
                List<Post> posts = GetPostsByBlogID(blog.BlogID);
                if (posts.Count > 0)
                {
                    foreach (Post post in posts)
                    {
                        db.Posts.Remove(post);
                    }
                }
                //then delete blog
                db.Blogs.Remove(blog);
                db.SaveChanges();
            }
        }

        #endregion

        #region BloggerOperations

        public Blogger GetBloggerByID(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Bloggers.Single(b => b.BloggerID == id);
            }
        }

        public Blogger GetFirstBlogger()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Bloggers.FirstOrDefault();
            }               
        }

        public List<Blogger> GetAllBloggers()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Bloggers.ToList();
            }
        }

        public void AddNewBlogger(Blogger blogger)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Bloggers.Add(blogger);
                db.SaveChanges();
            }
        }

        public void EditExistingBlogger(Blogger blogger)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(blogger).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingBlogger(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                Blogger blogger = GetBloggerByID(id);

                //first check if the blogger has blogs
                List<Blog> blogs = GetBlogsByBloggerId(blogger.BloggerID);

                //if there are blogs, for each blog start with deleting posts
                if (blogs.Count > 0)
                {
                    foreach (Blog blog in blogs)
                    {
                        List<Post> posts = GetPostsByBlogID(blog.BlogID);
                        if (posts.Count > 0)
                        {
                            foreach (Post post in posts)
                            {
                                db.Posts.Remove(post);
                            }
                        }
                        //then, delete all blogs which are now empty
                        db.Blogs.Remove(blog);
                    }
                }
                //finally, delete the blogger
                db.Bloggers.Remove(blogger);
                db.SaveChanges();
            }
        }

        #endregion

        #region PostOperations

        public List<Post> GetPostsByBlogID(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            List<Post> posts;
            using (RecipesEntities db = new RecipesEntities())
            {
                posts = db.Posts.Where(p => p.BlogID == id).Include(p => p.PostLabels).ToList();
                foreach (Post post in posts)
                {
                    foreach (PostLabel pl in post.PostLabels)
                    {
                        pl.Label.Name = db.Labels.Single(p => p.LabelID == pl.LabelID).Name;
                    }
                }
                return posts;
            }
        }

        public Post GetPostByID(int id)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                Post post = db.Posts.Single(p => p.PostID == id);
                post.PostLabels = db.PostLabels.Where(p => p.PostID == post.PostID).ToList();
                foreach (var postLabel in post.PostLabels)
                {
                    postLabel.Label = db.Labels.Single(l => l.LabelID == postLabel.LabelID);
                }
                return post;
            }
        }

        public void AddNewPost(Post post)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public void EditExistingPost(Post post)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingPost(Post post)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }

        public List<Post> GetPostPage(int pageNo, int pageSize, int blogId)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return GetPostsByBlogID(blogId)
                    .OrderByDescending(p => p.DateCreated)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize).ToList();
            }
        }

        public int TotalPosts(int blogId)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return GetPostsByBlogID(blogId).Count();
            }
        }

        public List<Post> GetPostPageForLabel(int pageNo, int pageSize, int blogId, string label)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                Label lbl = db.Labels.Single(l => l.Name == label);
                List<int> postIds = db.PostLabels
                    .Where(pl => pl.LabelID == lbl.LabelID)
                    .Select(p => p.PostID).ToList();

                return GetPostsByBlogID(blogId)
                    .Where(p => postIds.Contains(p.PostID))
                    .OrderByDescending(p => p.DateCreated)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize).ToList();            
            }
        }

        public int TotalPostsForLabel(int blogId, string label)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                Label lbl = db.Labels.Single(l => l.Name == label);
                List<int> postIds = db.PostLabels
                    .Where(pl => pl.LabelID == lbl.LabelID)
                    .Select(p => p.PostID).ToList();

                return GetPostsByBlogID(blogId)
                    .Where(p => postIds.Contains(p.PostID)).Count();
            }
        }

        #endregion

        #region LabelOperations

        public List<Label> GetAllLabels()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Labels.Include(p => p.PostLabels).ToList();
            }
        }

        public List<Label> GetLabelsByBlogId(int blogId)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                List<Post> posts = GetPostsByBlogID(blogId);

                List<int> postIds = db.Posts.Where(p => p.BlogID == blogId).Select(p => p.PostID).ToList();

                List<int> postLabelIds = db.PostLabels.Where(p => postIds.Contains(p.PostID)).Select(p => p.LabelID).Distinct().ToList();

                return db.Labels.Where(p => postLabelIds.Contains(p.LabelID)).Include(p => p.PostLabels).ToList();
            }
        }

        #endregion

        #region PostLabelOperations

        public List<PostLabel> GetAllPostLabels()
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.PostLabels.ToList();
            }
        }

        #endregion
    }
}