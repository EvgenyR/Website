using System.Collections.Generic;
using System.ComponentModel;

namespace Recipes.Models
{
    public class Blogger
    {
        [DisplayName("Blogger Name")]
        public int BloggerID { get; set; }
        [DisplayName("Blogger Name")]
        public string BloggerName { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}