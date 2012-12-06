using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public Blog Blog { get; set; }
        public Blogger Blogger { get; set; }
        public List<Post> Posts { get; set; }

        public PostViewModel(Blog blog, Blogger blogger, Post post, List<Post> posts)
        {
            Post = post;
            Blogger = blogger;
            Blog = blog;
            Posts = posts;
        }

        public PostViewModel()
        {

        }
    }
}