using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Recipes.Models;
using System.Data.Entity;

namespace Recipes.Repository
{
    public class RecipesRepository : IRecipesRepository
    {
        #region IngredientOperations

        public List<Ingredient> GetAllIngredients()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Ingredients.Include(r => r.Measure).Include(r => r.RecipeIngredients).ToList();
            }
        }
        
        public Ingredient GetIngredientById(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Ingredients.Include(r => r.Measure).Single(i => i.IngredientID == id);
            }
        }

        public void AddNewIngredient(Ingredient ingredient)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
            }
        }

        public void EditExistingIngredient(Ingredient ingredient)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingIngredient(Ingredient ingredient)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Ingredients.Remove(ingredient);
                db.SaveChanges();
            }
        }

        #endregion

        #region RecipeOperations

        public Recipe GetRecipeById(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                Recipe recipe = db.Recipes.Include(r => r.SubCategory).Single(r => r.RecipeID == id);
                recipe.Category = GetCategoryById(recipe.SubCategory.CategoryID);
                return recipe;
            }
        }

        public Recipe GetRecipeByIdWithSubCategory(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Recipes.Include(r => r.SubCategory).Include(r => r.RecipeIngredients).Single(r => r.RecipeID == id);
            }
        }

        public List<Recipe> GetAllRecipesWithSubCategory()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Recipes.Include(r => r.SubCategory).ToList();
            }
        }

        public List<Recipe> GetRecipesBySubCategoryId(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Recipes.Where(r => r.SubCategoryID == id).ToList();
            }
        }

        public List<Recipe> GetRecipesWhereSubCategoryIdInList(List<int> ids)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Recipes.Where(r => ids.Contains(r.SubCategoryID)).ToList();
            }
        }

        public void AddNewRecipe(Recipe recipe)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
            }
        }

        public void SetEditedValues(Recipe original, Recipe edited)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(original).CurrentValues.SetValues(edited);
            }
        }

        public void EditExistingRecipe(Recipe original, Recipe edited)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                IEnumerable<int> riToRemove =
                    original.RecipeIngredients.Select(ri => ri.RecipeIngredientID).Distinct().ToList();

                foreach (int rid in riToRemove)
                {
                    RecipeIngredient ri = db.RecipeIngredients.Find(rid);
                    db.RecipeIngredients.Remove(ri);
                }

                foreach (RecipeIngredient ri in edited.RecipeIngredients)
                {
                    ri.RecipeID = edited.RecipeID;
                    db.RecipeIngredients.Add(ri);
                }

                db.SaveChanges();
            }
        }

        public void DeleteExistingRecipe(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                Recipe recipe = GetRecipeById(id);

                List<RecipeIngredient> riToRemove = new List<RecipeIngredient>();

                foreach (var ri in recipe.RecipeIngredients)
                {
                    riToRemove.Add(db.RecipeIngredients.Where(r => r.RecipeID == ri.RecipeID && r.IngredientID == ri.IngredientID).Single());
                }

                foreach (var recipeIngredient in riToRemove)
                {
                    db.RecipeIngredients.Remove(recipeIngredient);
                }

                db.Recipes.Remove(recipe);
                db.SaveChanges();
            }
        }

        #endregion

        #region RecipeIngredientOperations

        public List<RecipeIngredient> GetRecipeIngredientsByIngredientId(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.RecipeIngredients.Where(ri => ri.IngredientID == id).ToList();
            }
        }

        #endregion

        #region CategoryOperations

        public List<Category> GetAllCategories()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Categories.ToList();
            }
        }

        public Category GetCategoryById(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Categories.Include(c => c.Recipes).Single(c => c.CategoryID == id);
            }
        }

        public void AddNewCategory(Category category)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void EditExistingCategory(Category category)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteExistingCategory(Category category)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        #endregion

        #region SubCategoryOperations

        public List<SubCategory> GetSubCategoriesByCategoryId(int id)
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.SubCategories.Where(s => s.CategoryID == id).ToList();
            }
        }

        #endregion

        #region MeasureOperations

        public List<Measure> GetAllMeasures()
        {
            using (RecipesEntities db = new RecipesEntities())
            {
                return db.Measures.ToList();
            }
        }

        #endregion
    }
}