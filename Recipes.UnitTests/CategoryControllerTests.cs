using NUnit.Framework;
using Recipes.Controllers;
using System.Web.Mvc;
using Recipes.Models;
using System.Linq;

namespace Recipes.UnitTests
{
    public class CategoryControllerTests
    {
        private const string ShortName = "a";
        private const string ShortDesc = "b";
        private const string LongName = "aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa";
        private const string LongDesc = @"aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa
            aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa";

        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// A new category can be created and successfully searched for
        /// </summary>
        [Test]
        public void CreatesNewRecipeCategory()
        {
            //Arrange
            CategoryController target = new CategoryController();
            Category category = GetNewTestCategory();
            string expectedName = category.CategoryName;
            string actualName = string.Empty;

            //Act
            using (RecipesEntities db = new RecipesEntities())
            {
                ActionResult actual = target.Create(category);
            }
            int id = category.CategoryID;

            using (RecipesEntities db = new RecipesEntities())
            {
                var newCategory = db.Categories.Find(id);
                actualName = newCategory.CategoryName;
            }

            //Assert
            Assert.IsTrue(id != 0);
            Assert.AreEqual(expectedName, actualName);
        }

        /// <summary>
        /// A category can be selected, edited and saved, and changes will be persisted
        /// </summary>
        [Test]
        public void EditsExisitngRecipeCategory()
        {
            //Arrange
            CategoryController target = new CategoryController();
            Category category;
            string actualName;
            string actualDescription;
            string expectedName;
            string expectedDescription;
            int id;
            
            using (RecipesEntities db = new RecipesEntities())
            {
                category = db.Categories.Where(c => c.CategoryName.Contains("Main Dishes")).FirstOrDefault();
                id = category.CategoryID;
                actualName = category.CategoryName + "Edited";
                actualDescription = category.Description + "Edited";
                category.CategoryName = actualName;
                category.Description = actualDescription;
            }

            //Act
            target.Edit(category);

            using (RecipesEntities db = new RecipesEntities())
            {
                var editedCategory = db.Categories.Find(id);
                expectedName = editedCategory.CategoryName;
                expectedDescription = editedCategory.Description;
            }

            //Assert
            Assert.IsNotNull(category);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        /// <summary>
        /// A category can be deleted normally
        /// </summary>
        [Test]
        public void DeletesExistingRecipeCategory()
        {
            //Arrange
            CategoryController target = new CategoryController();

            Category initialCategory = GetNewTestCategory();
            Category deletedCategory = GetNewTestCategory();

            target.Create(initialCategory);
            int id = initialCategory.CategoryID;

            //Act
            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                deletedCategory = db.Categories.Find(id);
            }

            //Assert
            Assert.IsNotNull(initialCategory);
            Assert.IsNull(deletedCategory);
        }

        /// <summary>
        /// Can not delete a category if there are recipes that belong to it
        /// </summary>
        [Test]
        public void CanNotDeleteUsedTest()
        {
            Category category;
            Category deletedCategory = null;
            int id;

            using (RecipesEntities db = new RecipesEntities())
            {
                category = db.Categories.Where(c => c.CategoryName == "Main Dishes").FirstOrDefault();
                id = category.CategoryID;
            }

            CategoryController target = new CategoryController();

            //Act
            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                deletedCategory = db.Categories.Find(id);
            }

            //Assert
            Assert.IsNotNull(category);
            Assert.AreEqual(Common.GetFirstErrorMessage(actual).Substring(0, 10), "Cannot del");
            Assert.IsNotNull(deletedCategory);
        }

        /// <summary>
        /// Verifies that the correct validation error message is returned if the category name is too short
        /// </summary>
        [Test]
        public void VerifiesCatgoryNameTooShort()
        {
            //Arrange
            Category category = GetNewTestCategory();
            category.CategoryName = ShortName;
            CategoryController target = new CategoryController();

            //Act
            ActionResult actual = target.Create(category);

            //Assert
            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryNameTooShort);
        }

        /// <summary>
        /// Verifies that a correct validation error is returned if a category name is too long
        /// </summary>
        [Test]
        public void NameTooLongTest()
        {
            //Arrange
            Category category = GetNewTestCategory();
            category.CategoryName = LongName;
            CategoryController target = new CategoryController();

            //Act
            ActionResult actual = target.Create(category);

            //Assert
            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryNameTooLong);
        }

        /// <summary>
        /// Verifies that a correct validation error is returned if a category description is too short
        /// </summary>
        [Test]
        public void DescriptionTooShortTest()
        {
            //Arrange
            Category category = GetNewTestCategory();
            category.Description = ShortDesc;
            CategoryController target = new CategoryController();

            //Act
            ActionResult actual = target.Create(category);

            //Assert
            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryDescTooShort);
        }

        /// <summary>
        /// Verifies that a correct validation error is returned if a category description is too long
        /// </summary>
        [Test]
        public void DescriptionTooLongTest()
        {
            //Arrange
            Category category = GetNewTestCategory();
            category.Description = LongDesc;
            CategoryController target = new CategoryController();

            //Act
            ActionResult actual = target.Create(category);

            //Assert
            Assert.AreEqual(Common.GetFirstErrorMessage(actual), Constants.Constants.CategoryDescTooLong);
        }

        /// <summary>
        /// Helper method
        /// </summary>
        /// <returns>Test category</returns>
        public static Category GetNewTestCategory()
        {
            return new Category()
            {
                CategoryName = "test",
                Description = "test description"
            };
        }
    }
}
