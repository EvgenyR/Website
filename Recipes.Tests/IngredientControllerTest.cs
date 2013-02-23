using Recipes.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Recipes.Models;
using System.Linq;

namespace Recipes.Tests
{
    /// <summary>
    ///This is a test class for IngredientControllerTest and is intended
    ///to contain all IngredientControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IngredientControllerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Details
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void DetailsTest()
        {
            IngredientController target = new IngredientController(); // TODO: Initialize to an appropriate value
            int id = 1;
            string expected = "System.Web.Mvc.ViewResult";
            string actual;
            actual = target.Details(id).ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void IndexTest()
        {
            IngredientController target = new IngredientController(); // TODO: Initialize to an appropriate value
            string expected = "System.Web.Mvc.ViewResult";
            string actual = target.Index().ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Common.SetupDatabase();
            IngredientController target = new IngredientController();

            Ingredient ingredient = new Ingredient()
            {
                IngredientName = "test"
            };

            ActionResult actual = target.Create(ingredient);
            Assert.IsTrue(ingredient.IngredientID != 0);

            using (RecipesEntities db = new RecipesEntities())
            {
                var newIngredient = db.Ingredients.Find(ingredient.IngredientID);
                Assert.AreEqual(ingredient.IngredientName, newIngredient.IngredientName);
            }
        }

        [TestMethod()]
        public void CanEdit()
        {
            Common.SetupDatabase();

            IngredientController target = new IngredientController();

            Ingredient ingredient;
            string editedName;
            int id;
            using(RecipesEntities db = new RecipesEntities())
            {
                ingredient = db.Ingredients.Where(i => i.IngredientName == "Meat").FirstOrDefault();
                id = ingredient.IngredientID;

                Assert.IsNotNull(ingredient);

                editedName = ingredient.IngredientName + "Edited";
                ingredient.IngredientName = editedName;
            }

            ActionResult actual = target.Edit(ingredient);

            using (RecipesEntities db = new RecipesEntities())
            {
                var editedIngredient = db.Ingredients.Find(id);
                Assert.AreEqual(editedIngredient.IngredientName, editedName);
            }
        }

        [TestMethod()]
        public void CanDeleteUnusedIngredient()
        {
            Common.SetupDatabase();
            IngredientController target = new IngredientController();

            Ingredient ingredient = new Ingredient()
            {
                IngredientName = "test"
            };

            target.Create(ingredient);
            int id = ingredient.IngredientID;

            Assert.IsNotNull(ingredient);

            ActionResult actual = target.DeleteConfirmed(id);

            using(RecipesEntities db = new RecipesEntities())
            {
                var deletedIngredient = db.Ingredients.Find(id);
                Assert.IsNull(deletedIngredient);
            }
        }

        [TestMethod()]
        public void CanNotDeleteUsedIngredient()
        {
            Common.SetupDatabase();
            Ingredient ingredient;
            int id;

            using (RecipesEntities db = new RecipesEntities())
            {
                ingredient = db.Ingredients.Where(i => i.IngredientName == "Meat").FirstOrDefault();
                id = ingredient.IngredientID;

                Assert.IsNotNull(ingredient);
            }
            IngredientController target = new IngredientController();

            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                var deletedIngredient = db.Ingredients.Find(id);
                Assert.AreEqual(Common.GetFirstErrorMessage(actual).Substring(0, 10), "Cannot del");
                Assert.IsNotNull(deletedIngredient);
            }
        }
    }
}
