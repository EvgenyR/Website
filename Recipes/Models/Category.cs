
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Recipes.Models
{
    //Validation rules: 
    //Category Name has to be 2 to 50 characters long
    //Category Description has to be 10 to 200 characters long
    public class Category
    {
        [ScaffoldColumn(false)]
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Category Description")]
        public string Description { get; set; }

        public virtual List<Recipe> Recipes { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}