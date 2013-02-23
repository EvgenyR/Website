using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.SeedData
{
    public static class AddBlogEngineBlogData
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
    }
}