using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recipes.Models;

namespace Recipes.Repository
{
    public interface IRecipesRepository
    {
        #region IngredientOperations

        List<Ingredient> GetAllIngredients();
        Ingredient GetIngredientById(int id);
        void AddNewIngredient(Ingredient ingredient);
        void EditExistingIngredient(Ingredient ingredient);
        void DeleteExistingIngredient(Ingredient ingredient);

        #endregion

        #region CategoryOperations

        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void AddNewCategory(Category category);
        void EditExistingCategory(Category category);
        void DeleteExistingCategory(Category category);

        #endregion

        #region SubCategoryOperations

        List<SubCategory> GetSubCategoriesByCategoryId(int id);

        #endregion

        #region RecipeOperations

        Recipe GetRecipeById(int id);
        Recipe GetRecipeByIdWithSubCategory(int id);
        List<Recipe> GetAllRecipesWithSubCategory();
        List<Recipe> GetRecipesBySubCategoryId(int id);
        List<Recipe> GetRecipesWhereSubCategoryIdInList(List<int> ids);
        void AddNewRecipe(Recipe recipe);
        void SetEditedValues(Recipe original, Recipe edited);
        void EditExistingRecipe(Recipe original, Recipe edited);
        void DeleteExistingRecipe(int id);

        #endregion

        #region RecipeIngredientOperations

        List<RecipeIngredient> GetRecipeIngredientsByIngredientId(int id);

        #endregion

        #region MeasureOperations

        List<Measure> GetAllMeasures();

        #endregion
    }
}