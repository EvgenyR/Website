using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Recipes.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int BlogID { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        [MaxLength]
        [DisplayName("Start of Post")]
        public string BriefContent { get; set; }
        [MaxLength]
        [DisplayName("Rest of Post")]
        public string RestOfContent { get; set; }
    }
}