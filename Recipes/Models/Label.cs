using System.Collections.Generic;

namespace Recipes.Models
{
    public class Label
    {
        public int LabelID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PostLabel> PostLabels { get; set; }
    }
}