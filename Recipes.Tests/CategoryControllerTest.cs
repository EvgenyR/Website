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
        private const string ShortName = "a";
        private const string ShortDesc = "b";
        private const string LongName = "aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa";
        private const string LongDesc = @"aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa
            aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa";


        [TestMethod()]
        public void CreateTest()
        {
            Common.SetupDatabase();
            CategoryController target = new CategoryController();

            Category category = Common.GetNewTestCategory();

            ActionResult actual = target.Create(category);
            int id = category.CategoryID;
            Assert.IsTrue(id != 0);

            using (RecipesEntities db = new RecipesEntities())
            {
                var newCategory = db.Categories.Find(id);
                Assert.AreEqual(category.CategoryName, newCategory.CategoryName);
            }
        }

        [TestMethod()]
        public void EditTest()
        {
            Common.SetupDatabase();
            CategoryController target = new CategoryController();

            Category category;
            string editedName;
            string editedDesc;
            int id;
            using (RecipesEntities db = new RecipesEntities())
            {
                category = db.Categories.Where(c => c.CategoryName == "Main Dishes").FirstOrDefault();
                id = category.CategoryID;

                Assert.IsNotNull(category);

                editedName = category.CategoryName + "Edited";
                editedDesc = category.Description + "Edited";
                category.CategoryName = editedName;
                category.Description = editedDesc;
            }

            ActionResult actual = target.Edit(category);

            using (RecipesEntities db = new RecipesEntities())
            {
                var editedCategory = db.Categories.Find(id);
                Assert.AreEqual(editedCategory.CategoryName, editedName);
                Assert.AreEqual(editedCategory.Description, editedDesc);
            }
        }

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

        [TestMethod()]
        public void NameTooShortTest()
        {
            Common.SetupDatabase();
            Category category = Common.GetNewTestCategory();
            category.CategoryName = ShortName;

            CategoryController target = new CategoryController();
            ActionResult actual = target.Create(category);

            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryNameTooShort);
        }

        [TestMethod()]
        public void NameTooLongTest()
        {
            Common.SetupDatabase();
            Category category = Common.GetNewTestCategory();
            category.CategoryName = LongName;

            CategoryController target = new CategoryController();
            ActionResult actual = target.Create(category);

            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryNameTooLong);
        }

        [TestMethod()]
        public void DescriptionTooShortTest()
        {
            Common.SetupDatabase();
            Category category = Common.GetNewTestCategory();
            category.Description = ShortDesc;

            CategoryController target = new CategoryController();
            ActionResult actual = target.Create(category);

            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryDescTooShort);
        }

        [TestMethod()]
        public void DescriptionTooLongTest()
        {
            Common.SetupDatabase();
            Category category = Common.GetNewTestCategory();
            category.Description = LongDesc;

            CategoryController target = new CategoryController();
            ActionResult actual = target.Create(category);

            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryDescTooLong);
        }
    }
}
