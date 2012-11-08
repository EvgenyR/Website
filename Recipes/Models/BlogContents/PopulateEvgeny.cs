using System.Collections.Generic;
using System;

namespace Recipes.Models.BlogContents
{
    public static class PopulateEvgeny
    {
        public static void AddPosts(RecipesEntities context)
        {
            List<Post> posts = new List<Post>{
                new Post { BlogID = 1, BriefContent = BlogPosts.content_12082012_b, RestOfContent = BlogPosts.content_12082012_r, DateCreated = new DateTime(2012, 8, 12), PostID = 1, Title = "Securing Access to Windows 7 Folder from Everyone but a Single User" },
                new Post {BlogID = 1, BriefContent = BlogPosts.content_03102012_b, RestOfContent = BlogPosts.content_03102012_r, DateCreated = new DateTime(2012, 10, 3), PostID = 2, Title = "jQuery Show/Hide Toggle"},
                new Post { BlogID = 1, BriefContent = BlogPosts.content_07092012_b, RestOfContent = BlogPosts.content_07092012_r, DateCreated = new DateTime(2012, 9, 7), PostID = 3, Title = "Playing with Google Search Results " },
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();
        }
    }
}