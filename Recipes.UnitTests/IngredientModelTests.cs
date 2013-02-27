using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Recipes.Models;
using System.ComponentModel.DataAnnotations;

namespace Recipes.UnitTests
{
    public class IngredientModelTests
    {
        private const string ShortName = "t";
        private const string LongName = "tttttttttt tttttttttt tttttttttt tttttttttt tttttttttt";

        [Test]
        public void ValidateNameIsTooShort()
        {
            //Arrange
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = ShortName
            };

            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResults = new List<ValidationResult>();

            //Act
            Validator.TryValidateObject(ingredient, validationContext, validationResults);

            string error = Common.GetValidationError(validationResults);

            //Assert
            Assert.AreEqual(error, Constants.Constants.IngredientNameTooShort);
        }

        [Test]
        public void ValidateNameIsTooLong()
        {
            //Arrange
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = LongName
            };

            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResults = new List<ValidationResult>();

            //Act
            Validator.TryValidateObject(ingredient, validationContext, validationResults);
            string error = Common.GetValidationError(validationResults);

            //Assert
            Assert.AreEqual(error, Constants.Constants.IngredientNameTooLong);
        }
    }
}
