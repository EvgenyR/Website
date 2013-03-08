using System.Collections.Generic;

namespace Recipes.Models
{
    /// <summary>
    /// A class that stores a Blog entity, including posts and blogger details
    /// </summary>
    public class Blog
    {
        public int BlogID { get; set; }
        public int BloggerID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual Blogger Blogger { get; set; }
        public int test { get; set; }

        public Blog()
        {
            Title = string.Empty;
        }
    }
}