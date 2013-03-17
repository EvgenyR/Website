using System.Collections.Generic;

namespace Recipes.Models
{
    public class PostLabel
    {
        public int PostLabelID { get; set; }
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
        public int LabelID { get; set; }
        public virtual Label Label { get; set; }

        public virtual ICollection<PostLabel> PostLabels { get; set; }
    }
}