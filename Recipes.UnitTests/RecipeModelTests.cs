using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Recipes.Models;
using System.ComponentModel.DataAnnotations;

namespace Recipes.UnitTests
{
    public class RecipeModelTests
    {
        private readonly string ShortName = "a";

        private readonly string LongName = @"aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa
                aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa aaaaaaaaaa";

        /// <summary>
        /// Verifies that attempt to create a Recipe returns correct validation error
        /// if recipe name is too short
        /// </summary>
        [Test]
        public void RecipeNameTooShortTest()
        {
            //Arrange
            Recipe recipe = new Recipe()
            {
                RecipeName = ShortName
            };

            var validationContext = new ValidationContext(recipe, null, null);
            var validationResults = new List<ValidationResult>();

            //Act
            Validator.TryValidateObject(recipe, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            //Assert
            Assert.AreEqual(error, Constants.Constants.RecipeNameTooShort);
        }

        /// <summary>
        /// Verifies that attempt to create a Recipe returns correct validation error
        /// if recipe name is too long
        /// </summary>
        [Test]
        public void RecipeNameTooLongTest()
        {
            //Arrange
            Recipe recipe = new Recipe()
            {
                RecipeName = LongName
            };

            var validationContext = new ValidationContext(recipe, null, null);
            var validationResults = new List<ValidationResult>();
            
            //Act
            Validator.TryValidateObject(recipe, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            //Assert
            Assert.AreEqual(error, Constants.Constants.RecipeNameTooLong);
        }
    }
}
