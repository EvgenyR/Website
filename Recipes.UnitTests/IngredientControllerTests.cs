using System.Linq;
using NUnit.Framework;
using Recipes.Controllers;
using Recipes.Models;
using System.Web.Mvc;

namespace Recipes.UnitTests
{
    public class IngredientControllerTests
    {
        /// <summary>
        ///A test for Details
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [Test]
        public void DetailsTest()
        {
            //Arrange
            IngredientController target = new IngredientController(); // TODO: Initialize to an appropriate value
            int id = 1;
            string expected = "System.Web.Mvc.ViewResult";

            //Act
            string actual = target.Details(id).ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [Test]
        public void IndexTest()
        {
            //Arrange
            IngredientController target = new IngredientController(); // TODO: Initialize to an appropriate value
            string expected = "System.Web.Mvc.ViewResult";

            //Act
            string actual = target.Index().ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies a new ingredient can be created
        /// </summary>
        [Test]
        public void CreatesNewRecipeIngredient()
        {
            //Arrange
            IngredientController target = new IngredientController();
            Ingredient newIngredient = null;
            Ingredient ingredient = GetNewTestIngredient();

            ActionResult actual = target.Create(ingredient);

            using (RecipesEntities db = new RecipesEntities())
            {
                newIngredient = db.Ingredients.Find(ingredient.IngredientID);
            }

            //Assert
            Assert.IsTrue(ingredient.IngredientID != 0);
            Assert.AreEqual(ingredient.IngredientName, newIngredient.IngredientName);
        }

        /// <summary>
        /// Verifies an existing Ingredient can be modified
        /// </summary>
        [Test]
        public void EditsExistingRecipeIngredient()
        {
            //Arrange
            IngredientController target = new IngredientController();

            Ingredient ingredient;
            Ingredient editedIngredient;
            string editedName;
            int id;
            using (RecipesEntities db = new RecipesEntities())
            {
                ingredient = db.Ingredients.Where(i => i.IngredientName.Contains("Ham")).FirstOrDefault();
                id = ingredient.IngredientID;
                editedName = ingredient.IngredientName + "Edited";
                ingredient.IngredientName = editedName;
            }

            //Act
            ActionResult actual = target.Edit(ingredient);

            using (RecipesEntities db = new RecipesEntities())
            {
                editedIngredient = db.Ingredients.Find(id);
            }

            //Assert
            Assert.IsNotNull(ingredient);
            Assert.AreEqual(editedIngredient.IngredientName, editedName);
        }

        /// <summary>
        /// Verifies an Ingredient can be deleted under normal conditions
        /// </summary>
        [Test]
        public void DeletesUnusedRecipeIngredient()
        {
            //Arrange
            IngredientController target = new IngredientController();
            Ingredient deletedIngredient = new Ingredient();
            Ingredient ingredient = GetNewTestIngredient();

            target.Create(ingredient);
            int id = ingredient.IngredientID;

            //Act
            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                deletedIngredient = db.Ingredients.Find(id);
            }

            //Assert
            Assert.IsNotNull(ingredient);
            Assert.IsNull(deletedIngredient);
         }

        /// <summary>
        /// Verifies an ingredient can not be deleted if used in the recipe
        /// </summary>
        [Test]
        public void CanNotDeleteUsedRecipeIngredient()
        {
            //Arrange
            Ingredient ingredient;
            Ingredient deletedIngredient = null;
            int id;

            using (RecipesEntities db = new RecipesEntities())
            {
                ingredient = db.Ingredients.Where(i => i.IngredientName.Contains("Ham")).FirstOrDefault();
                id = ingredient.IngredientID;
            }
            IngredientController target = new IngredientController();

            //Act
            ActionResult actual = target.DeleteConfirmed(id);

            using (RecipesEntities db = new RecipesEntities())
            {
                deletedIngredient = db.Ingredients.Find(id);
            }

            //Assert
            Assert.IsNotNull(ingredient);
            Assert.AreEqual(Common.GetFirstErrorMessage(actual).Substring(0, 10), "Cannot del");
            Assert.IsNotNull(deletedIngredient);
        }

        /// <summary>
        /// Helper method
        /// </summary>
        /// <returns>Test ingredient</returns>
        public static Ingredient GetNewTestIngredient()
        {
            return new Ingredient()
            {
                IngredientName = "test",
                Measure = new Measure { MeasureID = 0 }
            };
        }
    }
}
