using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Recipes.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public DateTime DateCreated { get; set; }
        public string BloggerUrl { get; set; }
        [MaxLength]
        [DisplayName("Start of Post")]
        public string BriefContent { get; set; }
        [MaxLength]
        [DisplayName("Rest of Post")]
        public string RestOfContent { get; set; }

        public virtual ICollection<PostLabel> PostLabels { get; set; }
    }
}