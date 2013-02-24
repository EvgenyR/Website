using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Controllers;
using Recipes.Models;
using System.Web.Mvc;
using System.Linq;

namespace Recipes.Tests
{
    /// <summary>
    ///This is a test class for CategoryControllerTest and is intended
    ///to contain all CategoryControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CategoryControllerTest
    {
        [TestMethod()]
        public void DeleteTest()
        {
            Common.SetupDatabase();
            CategoryController target = new CategoryController();

            Category category = Common.GetNewTestCategory();

            target.Create(category);
            int id = category.CategoryID;

            Assert.IsNotNull(category);

            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                var deletedCategory = db.Categories.Find(id);
                Assert.IsNull(deletedCategory);
            }
        }

        [TestMethod()]
        public void CanNotDeleteUsedTest()
        {
            Common.SetupDatabase();
            Category category;
            int id;

            using (RecipesEntities db = new RecipesEntities())
            {
                category = db.Categories.Where(c => c.CategoryName == "Main Dishes").FirstOrDefault();
                id = category.CategoryID;

                Assert.IsNotNull(category);
            }
            CategoryController target = new CategoryController();

            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                var deletedCategory = db.Categories.Find(id);
                Assert.AreEqual(Common.GetFirstErrorMessage(actual).Substring(0, 10), "Cannot del");
                Assert.IsNotNull(deletedCategory);
            }
        }
    }
}
