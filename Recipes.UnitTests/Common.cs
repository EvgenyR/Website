using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Recipes.UnitTests
{
    internal class Common
    {
        /// <summary>
        /// Returns a validation error message if a validation error occurred, and an empty string otherwise
        /// </summary>
        /// <param name="results">validation results</param>
        /// <returns>error message</returns>
        public static string GetValidationError(List<ValidationResult> results)
        {
            foreach (var result in results)
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    return result.ErrorMessage;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Used when an error is expected to occur
        /// </summary>
        /// <param name="result"></param>
        /// <returns>First error message</returns>
        public static string GetFirstErrorMessage(ActionResult result)
        {
            ViewResult vr = (ViewResult)result;

            foreach (ModelState error in vr.ViewData.ModelState.Values)
            {
                foreach (var innerError in error.Errors)
                {
                    if (!string.IsNullOrEmpty(innerError.ErrorMessage))
                    {
                        return innerError.ErrorMessage;
                    }
                }
            }
            return string.Empty;
        }

    }
}
