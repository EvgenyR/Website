using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Models;
using System.ComponentModel.DataAnnotations;
using Recipes.Controllers;

namespace Recipes.Tests
{
    /// <summary>
    ///This is a test class for IngredientModelTest and is intended
    ///to contain all IngredientModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IngredientModelTest
    {
        private const string ShortName = "t";
        private const string LongName = "tttttttttt tttttttttt tttttttttt tttttttttt tttttttttt";

        [TestMethod()]
        public void ValidateNameIsTooShort()
        {
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = ShortName
            };

            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(ingredient, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            Assert.AreEqual(error, Constants.Constants.IngredientNameTooShort);
        }

        [TestMethod()]
        public void ValidateNameIsTooLong()
        {
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = LongName
            };

            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(ingredient, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            Assert.AreEqual(error, Constants.Constants.IngredientNameTooLong);
        }
    }
}
