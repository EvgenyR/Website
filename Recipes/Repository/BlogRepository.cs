using System.Collections.Generic;
using System.Data;
using System.Linq;
using Recipes.Models;

namespace Recipes.Repository
{
    public class BlogRepository : IBlogRepository
    {
        #region BlogOperations

        public Blog GetBlogByID(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Blogs.Find(id);
            }
        }

        public List<Blog> GetAllBlogs()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Blogs.ToList();
            }
        }

        public List<Blog> GetBlogsByBloggerId(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Blogs.Where(b => b.BloggerID == id).ToList();
            }        
        }

        public void AddNewBlog(Blog blog)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        public void EditExistingBlog(Blog blog)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingBlog(int id)
        {
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
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Bloggers.Single(b => b.BloggerID == id);
            }
        }

        public Blogger GetFirstBlogger()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Bloggers.FirstOrDefault();
            }               
        }

        public List<Blogger> GetAllBloggers()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Bloggers.ToList();
            }
        }

        public void AddNewBlogger(Blogger blogger)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Bloggers.Add(blogger);
                db.SaveChanges();
            }
        }

        public void EditExistingBlogger(Blogger blogger)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(blogger).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingBlogger(int id)
        {
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
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Posts.Where(p => p.BlogID == id).ToList();
            }
        }

        public Post GetPostByID(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Posts.Find(id);
            }
        }

        public void AddNewPost(Post post)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public void EditExistingPost(Post post)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingPost(Post post)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }

        public List<Post> GetPostPage(int pageNo, int pageSize, int blogId)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return GetPostsByBlogID(blogId).OrderByDescending(p => p.DateCreated).Skip(pageNo * pageSize).Take(pageSize).ToList();
            }
        }

        public int TotalPosts(int blogId)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return GetPostsByBlogID(blogId).Count();
            }
        }

        #endregion
    }
}