using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.ViewModels
{
    public class BlogViewModel
    {
        public Blog Blog {get;set;}
        public List<Post> Posts{get;set;}
        public List<Blog> Blogs{get;set;}
        public List<Blogger> Bloggers{get;set;}
        public int PostsDisplayed { get; set; }

        public BlogViewModel(Blog blog, List<Post> posts, List<Blog> blogs, List<Blogger> bloggers, int postsDisplayed)
        {
            Blog = blog;
            Posts = posts;
            Blogs = blogs;
            Bloggers = bloggers;
            PostsDisplayed = postsDisplayed;
        }

        public BlogViewModel()
        {

        }
    }
}