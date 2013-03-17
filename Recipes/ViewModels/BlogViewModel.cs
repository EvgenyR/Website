using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.ViewModels
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public Blog Blog {get;set;}
        public List<Post> Posts{get;set;}
        public List<Blog> Blogs{get;set;}
        public List<Blogger> Bloggers{get;set;}
        public int TotalPosts { get; set; }
        public List<Label> Labels { get; set; }

        public BlogViewModel(Blog blog, List<Post> posts, List<Blog> blogs, List<Blogger> bloggers, int totalPosts)
        {
            Blog = blog;
            Posts = posts;
            Blogs = blogs;
            Bloggers = bloggers;
            TotalPosts = totalPosts;
        }

        public BlogViewModel()
        {

        }
    }
}