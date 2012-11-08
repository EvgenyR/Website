using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Recipes.Models
{
    public class SubCategory
    {
        [ScaffoldColumn(false)]
        [DisplayName("SubCategory")]
        public int SubCategoryID { get; set; }
        [DisplayName("Sub Category")]
        public string SubCategoryName { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
    }
}