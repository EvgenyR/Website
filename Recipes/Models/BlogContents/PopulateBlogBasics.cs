using System.Collections.Generic;

namespace Recipes.Models.BlogContents
{
    public static class PopulateBlogBasics
    {
        public static void PopulateBlogs(RecipesEntities context)
        {
            var blogs = new List<Blog> {
                new Blog { BlogID = 1, BloggerID = 1, Title = "Evgeny's Programming Blog" },
                new Blog { BlogID = 2, BloggerID = 1, Title = "Evgeny's Digital Biology Blog" },
            };

            blogs.ForEach(b => context.Blogs.Add(b));
            context.SaveChanges();
        }

        public static void PopulateBloggers(RecipesEntities context)
        {
            var bloggers = new List<Blogger> {
                new Blogger { BloggerID = 1, BloggerName = "Evgeny" },
                new Blogger { BloggerID = 2, BloggerName = "Someone Else" },
            };
            
            bloggers.ForEach(b => context.Bloggers.Add(b));
            context.SaveChanges();
        }
    }
}