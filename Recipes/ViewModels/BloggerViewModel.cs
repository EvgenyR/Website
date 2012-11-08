using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recipes.Models;

namespace Recipes.ViewModels
{
    public class BloggerViewModel
    {
        public Blogger Blogger { get; set; }
        public List<Blog> Blogs { get; set; }

        public BloggerViewModel(Blogger blogger, List<Blog> blogs)
        {
            Blogger = blogger;
            Blogs = blogs;
        }

        public BloggerViewModel()
        { 
        
        }
    }
}