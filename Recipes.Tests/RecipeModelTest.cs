using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Models;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Tests
{
    /// <summary>
    ///This is a test class for RecipeModelTest and is intended
    ///to contain all RecipeModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecipeModelTest
    {
        private string ShortName = "a";

        private string LongName = @"aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa
                aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa";

        [TestMethod()]
        public void RecipeNameTooShortTest()
        {
            Recipe recipe = new Recipe()
            {
                RecipeName = ShortName
            };

            var validationContext = new ValidationContext(recipe, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(recipe, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            Assert.AreEqual(error, Constants.Constants.RecipeNameTooShort);
        }

        [TestMethod()]
        public void RecipeNameTooLongTest()
        {
            Recipe recipe = new Recipe()
            {
                RecipeName = LongName
            };

            var validationContext = new ValidationContext(recipe, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(recipe, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            Assert.AreEqual(error, Constants.Constants.RecipeNameTooLong);
        }
    }
}
