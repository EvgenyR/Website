using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Recipes.Models.Recipes
{
    public static class AddRecipes
    {
        public static void Execute(RecipesEntities context)
        {
            try
            {
                //apple breakfast lasagna

                var ingredient1 = new Ingredient { IngredientID = 1, IngredientName = "Ham", MeasureID = 1, Carb = 1.9M, Protein = 16.3M, Fat = 20.7M };
                var ingredient2 = new Ingredient { IngredientID = 2, IngredientName = "Sour Cream", MeasureID = 2, Carb = 6.6M, Protein = 2.4M, Fat = 19.5M };
                var ingredient3 = new Ingredient { IngredientID = 3, IngredientName = "Brown Sugar", MeasureID = 2, Carb = 97.3M };
                var ingredient4 = new Ingredient { IngredientID = 4, IngredientName = "Cheese", MeasureID = 1, Carb = 2.3M, Protein = 21.4M, Fat = 28.7M };
                var ingredient5 = new Ingredient { IngredientID = 5, IngredientName = "Apple Pie Filling", MeasureID = 2, Carb = 37, Protein = 2.6M, Fat = 11.8M };
                var ingredient6 = new Ingredient { IngredientID = 6, IngredientName = "Granola", MeasureID = 2, Carb = 53, Protein = 14.7M, Fat = 24.6M };
                var ingredient7 = new Ingredient { IngredientID = 7, IngredientName = "Frozen French Toast Slices", MeasureID = 3, Carb = 88, Protein = 4, Fat = 3.2M, GramsPerItem = 50 };

                var ingredients = new List<Ingredient> { ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6, ingredient7 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 1,
                    RecipeName = "Apple Breakfast Lasagna",
                    SubCategoryID = 1,
                    Description = @"In small bowl, combine sugar and sour cream; cover and refrigerate. Place 6 slices French toast in bottom of greased 9 x 13 pan. Layer ham, 2 cups of cheese and remaining 6 slices of French toast in baking pan. Spread pie filling over top; sprinkle granola over apples. Bake in preheated 350F oven for 25 minutes. Top with remaining 1/2 cup cheddar cheese; bake another 5 minutes until cheese is melted and casserole is hot. Serve with sour cream mixture."
                });
                context.SaveChanges();

                var ri0_1 = new RecipeIngredient { RecipeIngredientID = 1, IngredientID = 1, RecipeID = 1, Quantity = 200 };
                var ri0_2 = new RecipeIngredient { RecipeIngredientID = 2, IngredientID = 2, RecipeID = 1, Quantity = 1 };
                var ri0_3 = new RecipeIngredient { RecipeIngredientID = 3, IngredientID = 3, RecipeID = 1, Quantity = 0.3M };
                var ri0_4 = new RecipeIngredient { RecipeIngredientID = 4, IngredientID = 4, RecipeID = 1, Quantity = 200 };
                var ri0_5 = new RecipeIngredient { RecipeIngredientID = 5, IngredientID = 5, RecipeID = 1, Quantity = 1 };
                var ri0_6 = new RecipeIngredient { RecipeIngredientID = 6, IngredientID = 6, RecipeID = 1, Quantity = 1 };
                var ri0_7 = new RecipeIngredient { RecipeIngredientID = 7, IngredientID = 7, RecipeID = 1, Quantity = 12 };

                var recipeIngredients = new List<RecipeIngredient> { ri0_1, ri0_2, ri0_3, ri0_4, ri0_5, ri0_6, ri0_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                // super french toast

                var ingredient8 = new Ingredient { IngredientID = 8, IngredientName = "Orange Juice", MeasureID = 2, Carb = 10.4M, Protein = 0.7M, Fat = 0.2M };
                var ingredient9 = new Ingredient { IngredientID = 9, IngredientName = "Cornflakes", MeasureID = 2, Carb = 85, Protein = 6, Fat = 1.3M };
                var ingredient10 = new Ingredient { IngredientID = 10, IngredientName = "Wheat Germ", MeasureID = 2, Carb = 51.8M, Protein = 23.1M, Fat = 9.7M };
                var ingredient11 = new Ingredient { IngredientID = 11, IngredientName = "Pecans", MeasureID = 2, Carb = 13.9M, Protein = 9.2M, Fat = 72 };
                var ingredient12 = new Ingredient { IngredientID = 12, IngredientName = "Eggs", MeasureID = 3, Carb = 4.9M, Protein = 47.3M, Fat = 41, GramsPerItem = 60 };
                var ingredient13 = new Ingredient { IngredientID = 13, IngredientName = "Salt", MeasureID = 4 };
                var ingredient14 = new Ingredient { IngredientID = 14, IngredientName = "Margarine", MeasureID = 4, Carb = 0.9M, Protein = 0.9M, Fat = 80.5M };
                var ingredient15 = new Ingredient { IngredientID = 15, IngredientName = "Bread", MeasureID = 5, Carb = 43.3M, Protein = 5.2M, Fat = 1.5M, GramsPerItem = 50 };

                ingredients = new List<Ingredient> { ingredient8, ingredient9, ingredient10, ingredient11, ingredient12, ingredient13, ingredient14, ingredient15 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 2,
                    RecipeName = "Super French Toast",
                    SubCategoryID = 1,
                    Description = @"Beat the eggs, orange juice, and salt in a flat bowl with a fork or whisk until blended.  Mix the cornflakes, wheat germ, and nuts in a pie pan or cake pan. Heat the margarine in a large skillet.  Dip bread slices into egg mixture and then into cornflake mixture, coating both sides. Place in skillet as many pieces as will fit comfortably in 1 layer (2 or 3 batches may be needed). Cook until brown on both sides, turning slices carefully with wide spatula. Keep finished toast warm if cooking more batches."
                });
                context.SaveChanges();
                
                var ri1_1 = new RecipeIngredient { RecipeIngredientID = 8, IngredientID = 8, RecipeID = 2, Quantity = 0.25M };
                var ri1_2 = new RecipeIngredient { RecipeIngredientID = 9, IngredientID = 9, RecipeID = 2, Quantity = 0.5M };
                var ri1_3 = new RecipeIngredient { RecipeIngredientID = 10, IngredientID = 10, RecipeID = 2, Quantity = 0.25M };
                var ri1_4 = new RecipeIngredient { RecipeIngredientID = 11, IngredientID = 11, RecipeID = 2, Quantity = 0.25M };
                var ri1_5 = new RecipeIngredient { RecipeIngredientID = 12, IngredientID = 12, RecipeID = 2, Quantity = 2 };
                var ri1_6 = new RecipeIngredient { RecipeIngredientID = 13, IngredientID = 13, RecipeID = 2, Quantity = 0.25M };
                var ri1_7 = new RecipeIngredient { RecipeIngredientID = 14, IngredientID = 14, RecipeID = 2, Quantity = 3 };
                var ri1_8 = new RecipeIngredient { RecipeIngredientID = 15, IngredientID = 15, RecipeID = 2, Quantity = 8 };

                recipeIngredients = new List<RecipeIngredient> { ri1_1, ri1_2, ri1_3, ri1_4, ri1_5, ri1_6, ri1_7, ri1_8 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //ruben burgers

                var ingredient16 = new Ingredient { IngredientID = 16, IngredientName = "Ground Beef", MeasureID = 1, Carb = 1.9M, Protein = 16.3M, Fat = 20.7M };
                var ingredient17 = new Ingredient { IngredientID = 17, IngredientName = "Conrned Beef", MeasureID = 1, Protein = 22.9M, Fat = 6.1M };
                var ingredient18 = new Ingredient { IngredientID = 18, IngredientName = "Chopped Onions", MeasureID = 2, Carb = 8.6M, Protein = 1.2M, Fat = 0.2M };
                var ingredient19 = new Ingredient { IngredientID = 19, IngredientName = "Garlic Salt", MeasureID = 4 };
                var ingredient20 = new Ingredient { IngredientID = 20, IngredientName = "Pepper", MeasureID = 4 };
                var ingredient21 = new Ingredient { IngredientID = 21, IngredientName = "Sauerkraut", MeasureID = 1, Carb = 4.3M, Protein = 0.9M, Fat = 0.1M };

                ingredients = new List<Ingredient> { ingredient16, ingredient17, ingredient18, ingredient19, ingredient20, ingredient21 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 3,
                    RecipeName = "Ruben Burgers",
                    SubCategoryID = 2,
                    Description = @"Mix all the ingredients together except the sauerkraut and cheese.  Shape mixture into 5 patties, each about 3/4-inch thick. Set oven control to broil or 550 degrees F. Broil the patties 4 inches from the heat, turning once, to the desired doneness, about 10 to 15 minutes. Top each patty with sauerkraut and a cheese slice. Broil until the cheese is melted and a light brown in color. Nice served on toasted rye or pumpernickel buns or bread."
                });
                context.SaveChanges();

                var ri2_1 = new RecipeIngredient { RecipeIngredientID = 16, IngredientID = 16, RecipeID = 3, Quantity = 500 };
                var ri2_2 = new RecipeIngredient { RecipeIngredientID = 17, IngredientID = 17, RecipeID = 3, Quantity = 100 };
                var ri2_3 = new RecipeIngredient { RecipeIngredientID = 18, IngredientID = 1, RecipeID = 3, Quantity = 100 };
                var ri2_4 = new RecipeIngredient { RecipeIngredientID = 19, IngredientID = 18, RecipeID = 3, Quantity = 0.25M };
                var ri2_5 = new RecipeIngredient { RecipeIngredientID = 20, IngredientID = 13, RecipeID = 3, Quantity = 0.25M };
                var ri2_6 = new RecipeIngredient { RecipeIngredientID = 21, IngredientID = 19, RecipeID = 3, Quantity = 0.125M };
                var ri2_7 = new RecipeIngredient { RecipeIngredientID = 22, IngredientID = 20, RecipeID = 3, Quantity = 0.125M };
                var ri2_8 = new RecipeIngredient { RecipeIngredientID = 23, IngredientID = 21, RecipeID = 3, Quantity = 200 };
                var ri2_9 = new RecipeIngredient { RecipeIngredientID = 24, IngredientID = 4, RecipeID = 3, Quantity = 100 };

                recipeIngredients = new List<RecipeIngredient> { ri2_1, ri2_2, ri2_3, ri2_4, ri2_5, ri2_6, ri2_7, ri2_8, ri2_9 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                // zesty burgers

                var ingredient22 = new Ingredient { IngredientID = 22, IngredientName = "Bread Crumbs", MeasureID = 2, Carb = 72.5M, Protein = 12.5M, Fat = 5.4M };
                var ingredient23 = new Ingredient { IngredientID = 23, IngredientName = "Water", MeasureID = 2 };
                var ingredient24 = new Ingredient { IngredientID = 24, IngredientName = "Beef Stock", MeasureID = 2, Carb = 7.4M, Protein = 2.5M, Fat = 3.2M };
                var ingredient25 = new Ingredient { IngredientID = 25, IngredientName = "Lemon Juice", MeasureID = 2, Carb = 8.6M, Protein = 0.4M };
                var ingredient26 = new Ingredient { IngredientID = 26, IngredientName = "Sage", MeasureID = 4, Carb = 1.2M, Protein = 0.2M, Fat = 0.3M };
                var ingredient27 = new Ingredient { IngredientID = 27, IngredientName = "Ginger", MeasureID = 4, Carb = 15.1M, Protein = 1.7M, Fat = 0.7M };
                var ingredient28 = new Ingredient { IngredientID = 28, IngredientName = "Pepper Sauce", MeasureID = 4, Carb = 7.4M, Protein = 3.8M, Fat = 6.7M };

                ingredients = new List<Ingredient> { ingredient22, ingredient23, ingredient24, ingredient25, ingredient26, ingredient27, ingredient28 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 4,
                    RecipeName = "Zesty Burgers",
                    SubCategoryID = 2,
                    Description = @"Mix all ingredients together.  Shape mixture into 4 patties, each about 3/4-inch thick.  Broil or grill patties 4-inches from the heat, turning once, to the desired doneness, about 10 to 15 minutes."
                });
                context.SaveChanges();

                var ri3_1 = new RecipeIngredient { RecipeIngredientID = 25, IngredientID = 16, RecipeID = 4, Quantity = 500 };
                var ri3_2 = new RecipeIngredient { RecipeIngredientID = 26, IngredientID = 22, RecipeID = 4, Quantity = 0.3M };
                var ri3_3 = new RecipeIngredient { RecipeIngredientID = 27, IngredientID = 23, RecipeID = 4, Quantity = 0.3M };
                var ri3_4 = new RecipeIngredient { RecipeIngredientID = 28, IngredientID = 24, RecipeID = 4, Quantity = 0.1M };
                var ri3_5 = new RecipeIngredient { RecipeIngredientID = 29, IngredientID = 25, RecipeID = 4, Quantity = 0.1M };
                var ri3_6 = new RecipeIngredient { RecipeIngredientID = 30, IngredientID = 13, RecipeID = 4, Quantity = 1 };
                var ri3_7 = new RecipeIngredient { RecipeIngredientID = 31, IngredientID = 26, RecipeID = 4, Quantity = 0.5M };
                var ri3_8 = new RecipeIngredient { RecipeIngredientID = 32, IngredientID = 27, RecipeID = 4, Quantity = 0.5M };
                var ri3_9 = new RecipeIngredient { RecipeIngredientID = 33, IngredientID = 20, RecipeID = 4, Quantity = 0.25M };
                var ri3_10 = new RecipeIngredient { RecipeIngredientID = 34, IngredientID = 28, RecipeID = 4, Quantity = 0.1M };

                recipeIngredients = new List<RecipeIngredient> { ri3_1, ri3_2, ri3_3, ri3_4, ri3_5, ri3_6, ri3_7, ri3_8, ri3_9, ri3_10 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //chili soup

                var ingredient29 = new Ingredient { IngredientID = 29, IngredientName = "Chili", MeasureID = 1, Carb = 9.2M, Protein = 2, Fat = 0.2M };
                var ingredient30 = new Ingredient { IngredientID = 30, IngredientName = "Corn Chips", MeasureID = 1, Carb = 68.1M, Protein = 2.3M, Fat = 24.9M };

                context.Ingredients.Add(ingredient29);
                context.Ingredients.Add(ingredient30);
                context.Recipes.Add(new Recipe
                {
                    RecipeID = 4,
                    RecipeName = "Chili Soup",
                    SubCategoryID = 3,
                    Description = @"Simply layer the chili, then chips, then cheese. (Usually good for two layers :)  Heat in oven at 350 or 375 until cheese is melted and chili is warm.  Serve with additional corn chips if desired. (Since so many ppl seem to be confirmed SAD and/or m**t eaters, I often add one box/package prepared Heartline Meatless Meats to the chili before layering.  It has fooled everyone to date with no complaints :)"
                });
                context.SaveChanges();

                var ri4_1 = new RecipeIngredient { RecipeIngredientID = 35, IngredientID = 29, RecipeID = 5, Quantity = 800 };
                var ri4_2 = new RecipeIngredient { RecipeIngredientID = 36, IngredientID = 4, RecipeID = 5, Quantity = 450 };
                var ri4_3 = new RecipeIngredient { RecipeIngredientID = 37, IngredientID = 30, RecipeID = 5, Quantity = 300 };

                context.RecipeIngredients.Add(ri4_1);
                context.RecipeIngredients.Add(ri4_2);
                context.RecipeIngredients.Add(ri4_3);
                context.SaveChanges();

                //whole wheat bagels

                var ingredient31 = new Ingredient { IngredientID = 31, IngredientName = "Honey", MeasureID = 4, Carb = 82M };
                var ingredient32 = new Ingredient { IngredientID = 32, IngredientName = "Whole wheat flour", MeasureID = 2, Carb = 72.6M, Protein = 13.7M, Fat = 1.9M };
                var ingredient33 = new Ingredient { IngredientID = 33, IngredientName = "Yeast", MeasureID = 5, Carb = 18.1M, Fat = 1.9M, Protein = 8.4M };
                var ingredient34 = new Ingredient { IngredientID = 34, IngredientName = "Sesame seeds", MeasureID = 4, Carb = 23.5M, Fat = 49.7M, Protein = 17.7M };

                ingredients = new List<Ingredient> { ingredient31, ingredient32, ingredient33, ingredient34 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 5,
                    RecipeName = "Whole Wheat Bagels",
                    SubCategoryID = 11,
                    Description = @"<p>Dissolve yeast in warm water in a large bowl; let stand 5 minutes.  Add honey, stirring well.  Stir in 2 cups whole wheat flour and 1-1/2 teaspoons salt; mix well.  Gradually stir in enough all-purpose flour to make a soft dough. Turn dough out onto a heavily floured surface (dough will be sticky), and knead until smooth and elastic (8 to 10 minutes). Place dough in a well-greased bowl, turning to grease top. Cover dough, and let rise in a warm place (85 degrees), free from drafts, 1-1/2 hours or until doubled in bulk.</p> <p>Punch dough down, and divide dough into 12 equal pieces. Roll each into a smooth ball.  Cut with 1-inch cutter or punch a hole in the center of each ball with a floured finger.  Gently pull dough away from center to make a 1- to 1-1/2-inch hole.  Place shaped bagels on lightly greased baking sheets.  Cover and let rise 15 minutes.  Broil bagels 5 inches from heat 2 minutes on each side or until lightly browned. Bring water and 1 teaspoon salt to a boil in a large Dutch oven.  Reduce heat, and simmer bagels 3 minutes on each side. Place bagels on lightly greased baking sheets.  Sprinkle with sesame seeds; lightly press seeds into bagels.  Bake at 425 degrees for 20 to 25 minutes or until golden brown.</p>"
                });
                context.SaveChanges();

                var ri5_1 = new RecipeIngredient { RecipeIngredientID = 38, IngredientID = 23, RecipeID = 6, Quantity = 2 };
                var ri5_2 = new RecipeIngredient { RecipeIngredientID = 39, IngredientID = 31, RecipeID = 6, Quantity = 2 };
                var ri5_3 = new RecipeIngredient { RecipeIngredientID = 40, IngredientID = 32, RecipeID = 6, Quantity = 5 };
                var ri5_4 = new RecipeIngredient { RecipeIngredientID = 41, IngredientID = 33, RecipeID = 6, Quantity = 2 };
                var ri5_5 = new RecipeIngredient { RecipeIngredientID = 42, IngredientID = 13, RecipeID = 6, Quantity = 1.5M };
                var ri5_6 = new RecipeIngredient { RecipeIngredientID = 43, IngredientID = 34, RecipeID = 6, Quantity = 1 };

                recipeIngredients = new List<RecipeIngredient> { ri5_1, ri5_2, ri5_3, ri5_4, ri5_5, ri5_6 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Drop Biscuits

                var ingredient35 = new Ingredient {IngredientID = 35, IngredientName = "Milk", MeasureID = 2, Carb = 4.7M, Fat = 3.3M, Protein = 3.3M};
                var ingredient36 = new Ingredient {IngredientID = 36, IngredientName = "Baking Powder", MeasureID = 4, Carb = 46.9M, Fat = 0.1M, Protein = 0.4M};
                var ingredient37 = new Ingredient {IngredientID = 37, IngredientName = "Shortening", MeasureID = 2, Fat = 100M};

                ingredients = new List<Ingredient> { ingredient35, ingredient36, ingredient37 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 6,
                    RecipeName = "Drop Biscuits",
                    SubCategoryID = 12,
                    Description = @"Combine flour, baking powder, and salt; cut in shortening with a pastry blender until mixture resembles coarse meal. Add milk, stirring until dry ingredients are moistened. Drop dough by heaping tablespoonfuls onto a lightly greased baking sheet. Bake at 425 degrees for 12 minutes or until lightly browned."
                });
                context.SaveChanges();

                var ri6_1 = new RecipeIngredient {RecipeIngredientID = 44, IngredientID = 32, RecipeID = 7, Quantity = 2};
                var ri6_2 = new RecipeIngredient {RecipeIngredientID = 45, IngredientID = 13, RecipeID = 7, Quantity = 1.5M};
                var ri6_3 = new RecipeIngredient {RecipeIngredientID = 46, IngredientID = 35, RecipeID = 7, Quantity = 1};
                var ri6_4 = new RecipeIngredient {RecipeIngredientID = 47, IngredientID = 36, RecipeID = 7, Quantity = 1};
                var ri6_5 = new RecipeIngredient {RecipeIngredientID = 48, IngredientID = 37, RecipeID = 7, Quantity = 0.3M};

                recipeIngredients = new List<RecipeIngredient> { ri6_1, ri6_2, ri6_3, ri6_4, ri6_5 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Peasant bread

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 7,
                                            RecipeName = "Peasant Bread",
                                            SubCategoryID = 13,
                                            Description = @"A very moist, chewy bread with a light, crispy crust.  Similar to the English Muffin loaf but more moist.  Wonderful for grilled cheese sandwiches."
                                        });

                context.SaveChanges();

                var ri7_1 = new RecipeIngredient {RecipeIngredientID = 49, IngredientID = 23, RecipeID = 8, Quantity = 1.5M};
                var ri7_2 = new RecipeIngredient {RecipeIngredientID = 50, IngredientID = 3, RecipeID = 8, Quantity = 0.1M};
                var ri7_3 = new RecipeIngredient {RecipeIngredientID = 51, IngredientID = 13, RecipeID = 8, Quantity = 1.5M};
                var ri7_4 = new RecipeIngredient {RecipeIngredientID = 52, IngredientID = 32, RecipeID = 8, Quantity = 3};
                var ri7_5 = new RecipeIngredient {RecipeIngredientID = 53, IngredientID = 33, RecipeID = 8, Quantity = 1};

                recipeIngredients = new List<RecipeIngredient> { ri7_1, ri7_2, ri7_3, ri7_4, ri7_5 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Apple bran muffings

                var ingredient38 = new Ingredient {IngredientID = 38, IngredientName = "Butter", MeasureID = 2, Fat = 81.1M, Carb = 0.1M, Protein = 0.9M};
                var ingredient39 = new Ingredient {IngredientID = 39, IngredientName = "Bran", MeasureID = 2, Carb = 66.2M, Protein = 17.3M, Fat = 7M};
                var ingredient40 = new Ingredient {IngredientID = 40, IngredientName = "Apples", MeasureID = 3, Carb = 15.3M, Fat = 0.2M, Protein = 0.4M};
                var ingredient41 = new Ingredient {IngredientID = 41, IngredientName = "Cloves", MeasureID = 4, Carb = 61.2M, Protein = 6M, Fat = 20.1M};
                var ingredient42 = new Ingredient {IngredientID = 42, IngredientName = "Maple Syrup", MeasureID = 2, Carb = 29.6M, Protein = 0.1M, Fat = 0.1M};
                var ingredient43 = new Ingredient {IngredientID = 43, IngredientName = "Nutmeg", MeasureID = 4, Carb = 49.3M, Protein = 5.8M, Fat = 36.3M};
                var ingredient44 = new Ingredient {IngredientID = 44, IngredientName = "Raisins", MeasureID = 2, Carb = 78.5M, Protein = 2.5M, Fat = 0.5M};

                ingredients = new List<Ingredient> { ingredient38, ingredient39, ingredient40, ingredient41, ingredient42, ingredient43, ingredient44 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 8,
                                            RecipeName = "Apple Bran Muffins",
                                            SubCategoryID = 14,
                                            Description = @"Combine bran, flour, baking powder, nutmeg and cloves; set aside.  Cream together milk, eggs, maple syrup, and butter; fold in flour mixture.  Stir in apples and raisins.  Pour into oiled muffin tins, and bake at 350 degrees until tops split, 15 to 25 minutes."
                                        });
                context.SaveChanges();

                var ri8_1 = new RecipeIngredient {RecipeIngredientID = 54, IngredientID = 32, RecipeID = 9, Quantity = 1};
                var ri8_2 = new RecipeIngredient {RecipeIngredientID = 55, IngredientID = 36, RecipeID = 9, Quantity = 1.25M};
                var ri8_3 = new RecipeIngredient {RecipeIngredientID = 56, IngredientID = 35, RecipeID = 9, Quantity = 0.3M};
                var ri8_4 = new RecipeIngredient {RecipeIngredientID = 57, IngredientID = 12, RecipeID = 9, Quantity = 2};
                var ri8_5 = new RecipeIngredient {RecipeIngredientID = 58, IngredientID = 38, RecipeID = 9, Quantity = 0.25M};
                var ri8_6 = new RecipeIngredient {RecipeIngredientID = 59, IngredientID = 39, RecipeID = 9, Quantity = 1.25M};
                var ri8_7 = new RecipeIngredient {RecipeIngredientID = 60, IngredientID = 40, RecipeID = 9, Quantity = 1};
                var ri8_8 = new RecipeIngredient {RecipeIngredientID = 61, IngredientID = 41, RecipeID = 9, Quantity = 0.25M};
                var ri8_9 = new RecipeIngredient {RecipeIngredientID = 62, IngredientID = 42, RecipeID = 9, Quantity = 0.75M};
                var ri8_10 = new RecipeIngredient {RecipeIngredientID = 63, IngredientID = 43, RecipeID = 9, Quantity = 0.75M};
                var ri8_11 = new RecipeIngredient {RecipeIngredientID = 64, IngredientID = 44, RecipeID = 9, Quantity = 1};

                recipeIngredients = new List<RecipeIngredient> { ri8_1, ri8_2, ri8_3, ri8_4, ri8_5, ri8_6, ri8_7, ri8_8, ri8_9, ri8_10, ri8_11 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Baked Doughnuts

                var ingredient45 = new Ingredient { IngredientID = 45, IngredientName = "Cinnamon", MeasureID = 4, Carb = 79.8M, Protein = 3.9M, Fat = 3.2M };
                context.Ingredients.Add(ingredient45);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 9,
                                            RecipeName = "Baked Doughnuts",
                                            SubCategoryID = 15,
                                            Description = @"<p>1. Sprinkle the yeast over the warm water in a small bowl and let it dissolve for 5 minutes. Put the milk and shortening in a saucepan and heat until the shortening is melted. Cool to lukewarm.</p><p>2. Pour the yeast mixture into a large mixing bowl and add the milk mix. Stif in the 1/4 cup sugar, salt, nutmeg, eggs and 2 cups flour. Beat briskly until well blended. Add the remaining 2 1/2 cups flour and beat until smooth. Cover the bowl and let double in bulk, about 1 hour.</p><p>3. Dust a board generously with flour and turn the dough mass onto it. This dough is soft and needs enough flour on the board to prevent sticking, but is easy to handle. Pat the dough into a round about 1/2 inch thick. Use a 3 inch doughnut cutter and cut out the doughnuts, placing them (and the doughnut holes) on greased baking sheets, 1 inch apart. These don't spread much; they rise. Preheat oven to 450F. Let the doughnuts rest and rise for 20 minutes uncovered. Bake about 10 minutes or a little longer, until they have a touch of golden brown. Remove from the oven. Have ready the melted butter and a brush. On a sheet of wax paper, spread the cinnamon sugar. Brush each doughnut and doughnut hole with butter and roll in the cinnamon sugar. Serve hot.</p>"
                                        });
                context.SaveChanges();

                var ri9_1 = new RecipeIngredient {RecipeIngredientID = 65, IngredientID = 13, RecipeID = 10, Quantity = 2};
                var ri9_2 = new RecipeIngredient {RecipeIngredientID = 66, IngredientID = 33, RecipeID = 10, Quantity = 2};
                var ri9_3 = new RecipeIngredient {RecipeIngredientID = 67, IngredientID = 23, RecipeID = 10, Quantity = 0.3M};
                var ri9_4 = new RecipeIngredient {RecipeIngredientID = 68, IngredientID = 35, RecipeID = 10, Quantity = 1.5M};
                var ri9_5 = new RecipeIngredient {RecipeIngredientID = 69, IngredientID = 37, RecipeID = 10, Quantity = 0.3M};
                var ri9_6 = new RecipeIngredient {RecipeIngredientID = 70, IngredientID = 3, RecipeID = 10, Quantity = 0.25M};
                var ri9_7 = new RecipeIngredient {RecipeIngredientID = 71, IngredientID = 43, RecipeID = 10, Quantity = 2};
                var ri9_8 = new RecipeIngredient {RecipeIngredientID = 72, IngredientID = 12, RecipeID = 10, Quantity = 2};
                var ri9_9 = new RecipeIngredient {RecipeIngredientID = 73, IngredientID = 32, RecipeID = 10, Quantity = 4.5M};
                var ri9_10 = new RecipeIngredient {RecipeIngredientID = 74, IngredientID = 38, RecipeID = 10, Quantity = 0.5M};
                var ri9_11 = new RecipeIngredient {RecipeIngredientID = 75, IngredientID = 45, RecipeID = 10, Quantity = 1};

                recipeIngredients = new List<RecipeIngredient> { ri9_1, ri9_2, ri9_3, ri9_4, ri9_5, ri9_6, ri9_7, ri9_8, ri9_9, ri9_10, ri9_11 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Oven Roasted Potatoes

                var ingredient46 = new Ingredient {IngredientID = 46, IngredientName = "Potatoes", MeasureID = 1, Carb = 12.4M, Protein = 2.6M, Fat = 0.1M};
                context.Ingredients.Add(ingredient46);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 10,
                                            RecipeName = "Oven Roasted Potatoes",
                                            SubCategoryID = 4,
                                            Description = @"Preheat oven to 450 degrees.  In large plastic bag or bowl add all ingredients,  close bag and shake, or toss in bowl, until potatoes are evenly coated.  Empty potatoes into shallow baking or roasting pan; discard bag,  bake stirring occasionally, 40 minutes or until potatoes are tender and golden brown.  Garnish, if desired with chopped fresh parsley"
                                        });

                context.SaveChanges();

                var ri10_1 = new RecipeIngredient {RecipeIngredientID = 76, IngredientID = 18, RecipeID = 11, Quantity = 1};
                var ri10_2 = new RecipeIngredient {RecipeIngredientID = 77, IngredientID = 46, RecipeID = 11, Quantity = 1000};
                var ri10_3 = new RecipeIngredient {RecipeIngredientID = 78, IngredientID = 24, RecipeID = 11, Quantity = 0.3M};

                recipeIngredients = new List<RecipeIngredient> { ri10_1, ri10_2, ri10_3 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Red and Green Tomato Pie

                var ingredient47 = new Ingredient { IngredientID = 47, IngredientName = "Garlic", MeasureID = 4, Carb = 33.1M, Fat = 0.5M, Protein = 6.4M };
                var ingredient48 = new Ingredient { IngredientID = 48, IngredientName = "Mayonnaise", MeasureID = 2, Carb = 23.9M, Fat = 22.4M, Protein = 0.9M };
                var ingredient49 = new Ingredient { IngredientID = 49, IngredientName = "Pastry", MeasureID = 2, Carb = 37.2M, Fat = 21.9M, Protein = 8M };
                var ingredient50 = new Ingredient { IngredientID = 50, IngredientName = "Tomatoes", MeasureID = 3, Carb = 5.1M, Fat = 0.2M, Protein = 1.2M };
                var ingredient51 = new Ingredient { IngredientID = 51, IngredientName = "Shredded Cheese", MeasureID = 2, Carb = 2.3M, Protein = 21.4M, Fat = 28.7M };

                ingredients = new List<Ingredient> { ingredient47, ingredient48, ingredient49, ingredient50, ingredient51 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 11,
                                            RecipeName = "Red and Green Tomato Pie",
                                            SubCategoryID = 5,
                                            Description = @"Line deep 9″ pie pan with the pastry; crimp edges, and brush with evaporated milk. Bake in a very hot oven, 450°, 5 minutes. Fill shell with tomatoes, and sprinkle with salt and pepper. Mix remaining ingredients and spread on tomatoes. Bake in moderate oven, 350°, for 40 minutes, or until tomatoes are done."
                                        });
                context.SaveChanges();

                var ri11_1 = new RecipeIngredient {RecipeIngredientID = 79, IngredientID = 13, RecipeID = 12, Quantity = 1.5M};
                var ri11_2 = new RecipeIngredient {RecipeIngredientID = 80, IngredientID = 20, RecipeID = 12, Quantity = 0.125M};
                var ri11_3 = new RecipeIngredient {RecipeIngredientID = 81, IngredientID = 47, RecipeID = 12, Quantity = 1};
                var ri11_4 = new RecipeIngredient {RecipeIngredientID = 82, IngredientID = 48, RecipeID = 12, Quantity = 0.3M};
                var ri11_5 = new RecipeIngredient {RecipeIngredientID = 83, IngredientID = 49, RecipeID = 12, Quantity = 9};
                var ri11_6 = new RecipeIngredient {RecipeIngredientID = 84, IngredientID = 50, RecipeID = 12, Quantity = 5};
                var ri11_7 = new RecipeIngredient {RecipeIngredientID = 85, IngredientID = 51, RecipeID = 12, Quantity = 0.3M};

                recipeIngredients = new List<RecipeIngredient> { ri11_1, ri11_2, ri11_3, ri11_4, ri11_5, ri11_6, ri11_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Cherry Nut Easter Egg

                var ingredient52 = new Ingredient {IngredientID = 52, IngredientName = "Chocolate", MeasureID = 1, Carb = 22.1M, Protein = 3.0M, Fat = 1.1M};
                var ingredient53 = new Ingredient {IngredientID = 53, IngredientName = "Cherries", MeasureID = 1, Carb = 16.5M, Protein = 1.2M, Fat = 1};
                var ingredient54 = new Ingredient {IngredientID = 54, IngredientName = "Pudding", MeasureID = 1, Carb = 91.2M, Protein = 2.7M, Fat = 0.1M};

                ingredients = new List<Ingredient> { ingredient52, ingredient53, ingredient54 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 12,
                                            RecipeName = "Cherry Nut Easter Egg",
                                            SubCategoryID = 21,
                                            Description = @"<p>Preparation : Cut cherries in half, and drain well on paper towels. Cook milk, butter and pudding in a medium saucepan on low heat until well blended and thick. Remove from stove and add cherries, nuts and enough sugar to make a thick consistency.  Form the mixture into 8 to 10 egg shapes with hands coated in butter. Place on wax paper covered cookie sheet.  Chill several hours until firm. Melt chocolate being careful not to scorch it.  Frost egg with melted chocolate.  Decorate with butter cream icing.</p>"
                                        });
                context.SaveChanges();

                var ri12_1 = new RecipeIngredient {RecipeIngredientID = 86, IngredientID = 35, RecipeID = 13, Quantity = 0.5M};
                var ri12_2 = new RecipeIngredient {RecipeIngredientID = 87, IngredientID = 38, RecipeID = 13, Quantity = 0.5M};
                var ri12_3 = new RecipeIngredient {RecipeIngredientID = 88, IngredientID = 11, RecipeID = 13, Quantity = 1};
                var ri12_4 = new RecipeIngredient {RecipeIngredientID = 89, IngredientID = 3, RecipeID = 13, Quantity = 2};
                var ri12_5 = new RecipeIngredient {RecipeIngredientID = 90, IngredientID = 52, RecipeID = 13, Quantity = 400};
                var ri12_6 = new RecipeIngredient {RecipeIngredientID = 91, IngredientID = 53, RecipeID = 13, Quantity = 400};
                var ri12_7 = new RecipeIngredient {RecipeIngredientID = 92, IngredientID = 54, RecipeID = 13, Quantity = 150};

                recipeIngredients = new List<RecipeIngredient> { ri12_1, ri12_2, ri12_3, ri12_4, ri12_5, ri12_6, ri12_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Cat Litter Casserole

                var ingredient55 = new Ingredient{IngredientID = 55, IngredientName = "Rice", MeasureID = 2, Carb = 74.9M, Protein = 14.7M, Fat = 1.1M};
                var ingredient56 = new Ingredient{IngredientID = 56, IngredientName = "Biscuits", MeasureID = 1, Carb = 63.3M, Protein = 8, Fat = 15.4M};
                context.Ingredients.Add(ingredient55);
                context.Ingredients.Add(ingredient56);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 13,
                                            RecipeName = "Cat Litter Casserole",
                                            SubCategoryID = 22,
                                            Description = @"<p>To make dumps: With an adult’s help, preheat the oven to 350F. Using clean hans, mix together the dump ingredients in a large bowl. Mold pieces of this mixture into various size/shape dumps. Place so they don't touch each other in an ungreased baking pan. Use two if they don''t all fit. With an adult’s help, bake the dumps for about 20 minutes or until they are all brown, firm and slightly crusty. While the meat cooks, put all four litter ingredients into a large   saucepan. Then, with an adult’s help, heat on high until the water   comes to a boil. Stir, turn heat to low and cover the pan. Simmer   without lifting the cover for fourteen minutes. With an adult’s help, remove the saucepan from the stove and   carefully (to avoid having your face melted away by the steam), lift   off the cover. Break apart, or “fluff” the rice with a fork and set pan aside. When dumps are done, carefully transfer them onto paper towels to   drain.      Spoon the rice and dumps into the now empty baking pan, leaving some   dumps partially uncovered, the way Kitty does when he/she is in a   hurry. Serves 8-10 litterbox lovers. Use ppper scooper to serve.</p>"
                                        });
                context.SaveChanges();

                var ri13_1 = new RecipeIngredient {RecipeIngredientID = 93, IngredientID = 51, RecipeID = 14, Quantity = 1};
                var ri13_2 = new RecipeIngredient {RecipeIngredientID = 94, IngredientID = 1, RecipeID = 14, Quantity = 400};
                var ri13_3 = new RecipeIngredient {RecipeIngredientID = 95, IngredientID = 55, RecipeID = 14, Quantity = 2};
                var ri13_4 = new RecipeIngredient {RecipeIngredientID = 96, IngredientID = 56, RecipeID = 14, Quantity = 100};
                var ri13_5 = new RecipeIngredient {RecipeIngredientID = 97, IngredientID = 23, RecipeID = 14, Quantity = 3.75M};
                var ri13_6 = new RecipeIngredient {RecipeIngredientID = 98, IngredientID = 13, RecipeID = 14, Quantity = 2};
                var ri13_7 = new RecipeIngredient {RecipeIngredientID = 99, IngredientID = 38, RecipeID = 14, Quantity = 1};

                recipeIngredients = new List<RecipeIngredient> { ri13_1, ri13_2, ri13_3, ri13_4, ri13_5, ri13_6, ri13_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Cornucopia

                context.Recipes.Add(new Recipe
                                        {RecipeID = 14, RecipeName = "Cornucopia", SubCategoryID = 23, Description = @"<ol><li>Preheat oven to 350 degrees F.  Lightly spray a cookie sheet, at least 17“x 14”, with non-stick cooking spray.</li><li>Tear off a 30“x 18″ sheet of heavy duty aluminum foil.  Fold in 1/2 to 18'x 15'.  Roll diagonally to form a hollow cone, about 18' long with a diameter of 5″ at the widest end (Cornucopia opening). Fasten end with clear tape.  Stuff cone with crumpled regular foil until form is rigid. Bend tail of cone up then down at end.  Spray outside of cone with non-stick cooking spray.  Place on cookie sheet.</li><li>Open and unroll first  can of breadstick dough on work surface. Seperate breadsticks.  Begin by wraping one breadstick around tip of cone. Brush end of next breadstick with Glaze and press to attach to end of first breadstick.  Continue spiral-wrapping cone, slightly overlapping dough until there are 3 breadsticks left.</li><li>Pinch one end of the 3 breadsticks together, then braid.  Brush bread around opening of Cornucopia with Glaze.  Gently press on braid.  Brush entire Cornucopia with Glaze.</li><li>Bake 45 minutes in preheated oven or until bread is a rich brown. (If parts start to darken too much, cover them with poeces of foil.)</li><li>Remove from oven and let cool completely on cookie sheet on a wire rack.  Carefully remove foil when cool. (If freezing, leave foil in bread for support. Remove when thawed.)</li> <li>Fill Cornucopia with the assorted raw vegetables directly on table and let them spill out of opening</li></ol>"});

                var ri14_1 = new RecipeIngredient {RecipeIngredientID = 100, IngredientID = 49, RecipeID = 15, Quantity = 3};
                var ri14_2 = new RecipeIngredient {RecipeIngredientID = 101, IngredientID = 12, RecipeID = 15, Quantity = 1};
                var ri14_3 = new RecipeIngredient {RecipeIngredientID = 102, IngredientID = 23, RecipeID = 15, Quantity = 1};

                recipeIngredients = new List<RecipeIngredient> { ri14_1, ri14_2, ri14_3 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Holiday Eggnog

                var ingredient57 = new Ingredient { IngredientID = 57, IngredientName = "Beer", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient58 = new Ingredient {IngredientID = 58, IngredientName = "Bourbon", MeasureID = 2, Carb = 0.1M};
                context.Ingredients.Add(ingredient57);
                context.Ingredients.Add(ingredient58);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 15,
                                            RecipeName = "Holiday Eggnog",
                                            SubCategoryID = 24,
                                            Description = @"<p>Beat egg yolks with 1/4 cup sugar until very thick. Gradually stir in milk, beer, and brandy. Beat egg whites until foamy. Gradually beat in 1/4 cup sugar, continuing beating until stiff peaks form. Fold whites into yolk-beer mixture. Chill. Just before serving, fold in whipped cream. Serve in small punch cups, sprinkled with nutmeg. Makes 6 cups, or 12 half-cup servings.<p>"
                                        });
                context.SaveChanges();

                var ri15_1 = new RecipeIngredient { RecipeIngredientID = 103, IngredientID = 57, RecipeID = 16, Quantity = 1};
                var ri15_2 = new RecipeIngredient { RecipeIngredientID = 104, IngredientID = 58, RecipeID = 16, Quantity = 0.25M };
                var ri15_3 = new RecipeIngredient { RecipeIngredientID = 105, IngredientID = 12, RecipeID = 16, Quantity = 3 };
                var ri15_4 = new RecipeIngredient { RecipeIngredientID = 106, IngredientID = 3, RecipeID = 16, Quantity = 0.5M};
                var ri15_5 = new RecipeIngredient { RecipeIngredientID = 107, IngredientID = 35, RecipeID = 16, Quantity = 2 };
                var ri15_6 = new RecipeIngredient { RecipeIngredientID = 108, IngredientID = 2, RecipeID = 16, Quantity = 1 };
                var ri15_7 = new RecipeIngredient { RecipeIngredientID = 109, IngredientID = 43, RecipeID = 16, Quantity = 1};

                recipeIngredients = new List<RecipeIngredient> { ri15_1, ri15_2, ri15_3, ri15_4, ri15_5, ri15_6, ri15_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Valentine Sugar Cookies

                var ingredient59 = new Ingredient { IngredientID = 57, IngredientName = "Vanilla extract", MeasureID = 4, Carb = 12.6M, Protein = 0.1M, Fat = 0.1M};
                context.Ingredients.Add(ingredient59);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 16,
                                            RecipeName = "Valentine Sugar Cookies",
                                            SubCategoryID = 25,
                                            Description = @"<p>In a mixing bowl, cream butter and sugar. Add egg and extracts. Stir in flour; mix well. Chill for several hours. On a lightly floured surface, roll dough to 1/4 inch thickness; cut with a 2 1/2 or 3 inch heart shaped cookie cutter. Place on ungreased baking sheets; sprinkle with red sugar, if desired. Bake at 375F for 8 to 10 minutes or until lightly browned.</p>"
                                        });
                context.SaveChanges();

                var ri16_1 = new RecipeIngredient { RecipeIngredientID = 110, IngredientID = 59, RecipeID = 17, Quantity = 1 };
                var ri16_2 = new RecipeIngredient { RecipeIngredientID = 111, IngredientID = 38, RecipeID = 17, Quantity = 1 };
                var ri16_3 = new RecipeIngredient { RecipeIngredientID = 112, IngredientID = 3, RecipeID = 17, Quantity = 1.5M };
                var ri16_4 = new RecipeIngredient { RecipeIngredientID = 113, IngredientID = 12, RecipeID = 17, Quantity = 1 };
                var ri16_5 = new RecipeIngredient { RecipeIngredientID = 114, IngredientID = 32, RecipeID = 17, Quantity = 2.5M };

                recipeIngredients = new List<RecipeIngredient> { ri16_1, ri16_2, ri16_3, ri16_4, ri16_5 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Speedy Chili

                var ingredient60 = new Ingredient { IngredientID = 60, IngredientName = "Tomato Sauce", MeasureID = 1, Carb = 52, Protein = 15, Fat = 5 };
                var ingredient61 = new Ingredient { IngredientID = 61, IngredientName = "Chili", MeasureID = 4, Carb = 9.5M, Protein = 2, Fat = 0.2M };
                context.Ingredients.Add(ingredient60);
                context.Ingredients.Add(ingredient61);

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 17,
                    RecipeName = "Speedy Chili",
                    SubCategoryID = 6,
                    Description = @"<p>Combine first 3 ingredients in a Dutch oven; cook until beef is browned, stirring to crumble.  Drain off drippings.  Add remaining ingredients; cover, reduce heat, and simmer 30 minutes, stirring occasionally.</p>"
                });
                context.SaveChanges();

                var ri17_1 = new RecipeIngredient { RecipeIngredientID = 115, IngredientID = 16, RecipeID = 18, Quantity = 450 };
                var ri17_2 = new RecipeIngredient { RecipeIngredientID = 116, IngredientID = 18, RecipeID = 18, Quantity = 1 };
                var ri17_3 = new RecipeIngredient { RecipeIngredientID = 117, IngredientID = 19, RecipeID = 18, Quantity = 1 };
                var ri17_4 = new RecipeIngredient { RecipeIngredientID = 118, IngredientID = 60, RecipeID = 18, Quantity = 200 };
                var ri17_5 = new RecipeIngredient { RecipeIngredientID = 119, IngredientID = 13, RecipeID = 18, Quantity = 0.25M };
                var ri17_6 = new RecipeIngredient { RecipeIngredientID = 120, IngredientID = 20, RecipeID = 18, Quantity = 0.125M };
                var ri17_7 = new RecipeIngredient { RecipeIngredientID = 121, IngredientID = 61, RecipeID = 18, Quantity = 3 };
                var ri17_8 = new RecipeIngredient { RecipeIngredientID = 122, IngredientID = 23, RecipeID = 18, Quantity = 1 };

                recipeIngredients = new List<RecipeIngredient> { ri17_1, ri17_2, ri17_3, ri17_4, ri17_5, ri17_6, ri17_7, ri17_8 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Cold Strawberry Soup

                var ingredient62 = new Ingredient { IngredientID = 62, IngredientName = "Wine", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient63 = new Ingredient { IngredientID = 63, IngredientName = "Fruit juice", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient64 = new Ingredient { IngredientID = 64, IngredientName = "Strawberries", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                ingredients = new List<Ingredient> { ingredient62, ingredient63, ingredient64 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 18,
                    RecipeName = "Cold Strawberry Soup",
                    SubCategoryID = 7,
                    Description = @"<p>Combine pineapple juice, powdered sugar and strawberries in container of electric blender. Blend until smooth. Add burgundy and sour cream, process an additional 2 minutes. Cover and chill several hours. Garnish with whipped cream, sliced strawberris and mint leaves.</p>"
                });
                context.SaveChanges();

                var ri18_1 = new RecipeIngredient { RecipeIngredientID = 123, IngredientID = 63, RecipeID = 19, Quantity = 2 };
                var ri18_2 = new RecipeIngredient { RecipeIngredientID = 124, IngredientID = 3, RecipeID = 19, Quantity = 0.3M };
                var ri18_3 = new RecipeIngredient { RecipeIngredientID = 125, IngredientID = 64, RecipeID = 19, Quantity = 2 };
                var ri18_4 = new RecipeIngredient { RecipeIngredientID = 126, IngredientID = 62, RecipeID = 19, Quantity = 0.5M };
                var ri18_5 = new RecipeIngredient { RecipeIngredientID = 127, IngredientID = 2, RecipeID = 19, Quantity = 0.5M };

                recipeIngredients = new List<RecipeIngredient> { ri18_1, ri18_2, ri18_3, ri18_4, ri18_5 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Vegetarian Stock

                var ingredient65 = new Ingredient { IngredientID = 65, IngredientName = "Celery", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient66 = new Ingredient { IngredientID = 66, IngredientName = "Parsley", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient67 = new Ingredient { IngredientID = 67, IngredientName = "Bay Leaf", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                ingredients = new List<Ingredient> { ingredient65, ingredient66, ingredient67 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 19,
                    RecipeName = "Vegetarian Stock",
                    SubCategoryID = 10,
                    Description = @"<p>I rarely peel potatoes, but when I do, I save the peels for this delicious stock.  Keep vegetable trimmings in a plastic bag in the freezer until you have enough for stock.</p><ol><li>Slice cloves of garlic, Chop onions and slice celery.</li><li>Place all of ghe ingredients in a large stock pot.</li><li>Bring to a boil.  Remove any foam that may come to the top.</li><li>Reduce heat, cover and simmer for 1 1/2 to 2 hours.</li><li>Strain the stock, cool, cover and refrigerate or freeze</li></ol>"
                });
                context.SaveChanges();

                var ri19_1 = new RecipeIngredient { RecipeIngredientID = 128, IngredientID = 46, RecipeID = 20, Quantity = 600 };
                var ri19_2 = new RecipeIngredient { RecipeIngredientID = 129, IngredientID = 23, RecipeID = 20, Quantity = 12 };
                var ri19_3 = new RecipeIngredient { RecipeIngredientID = 130, IngredientID = 47, RecipeID = 20, Quantity = 2 };
                var ri19_4 = new RecipeIngredient { RecipeIngredientID = 131, IngredientID = 18, RecipeID = 20, Quantity = 2 };
                var ri19_5 = new RecipeIngredient { RecipeIngredientID = 132, IngredientID = 65, RecipeID = 20, Quantity = 1 };
                var ri19_6 = new RecipeIngredient { RecipeIngredientID = 133, IngredientID = 66, RecipeID = 20, Quantity = 3 };
                var ri19_7 = new RecipeIngredient { RecipeIngredientID = 134, IngredientID = 67, RecipeID = 20, Quantity = 1 };

                recipeIngredients = new List<RecipeIngredient> { ri19_1, ri19_2, ri19_3, ri19_4, ri19_5, ri19_6, ri19_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Turkey Stock

                var ingredient68 = new Ingredient { IngredientID = 68, IngredientName = "Rosemary", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient69 = new Ingredient { IngredientID = 69, IngredientName = "Thyme", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient70 = new Ingredient { IngredientID = 70, IngredientName = "Turkey", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient71 = new Ingredient { IngredientID = 71, IngredientName = "Basil", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                ingredients = new List<Ingredient> { ingredient68, ingredient69, ingredient70, ingredient71 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 20,
                                            RecipeName = "Turkey Stock",
                                            SubCategoryID = 9,
                                            Description = @"<p>Combine giblets, neck, and wing tips with water in a large saucepan; add remaining ingredients. Bring to boil, then lower heat and simmer for about 15 minutes, or until liver is tender. Remove liver and continue to simmer mixture for about 1 hour, or until remaining giblets are tender. Strain mixture; remove and chop giblets and liver for gravy. Reserve stock.</p>"
                                        });
                context.SaveChanges();

                var ri20_1 = new RecipeIngredient { RecipeIngredientID = 135, IngredientID = 70, RecipeID = 21, Quantity = 500 };
                var ri20_2 = new RecipeIngredient { RecipeIngredientID = 136, IngredientID = 23, RecipeID = 21, Quantity = 3 };
                var ri20_3 = new RecipeIngredient { RecipeIngredientID = 137, IngredientID = 18, RecipeID = 21, Quantity = 0.5M };
                var ri20_4 = new RecipeIngredient { RecipeIngredientID = 138, IngredientID = 47, RecipeID = 21, Quantity = 0.5M };
                var ri20_5 = new RecipeIngredient { RecipeIngredientID = 139, IngredientID = 64, RecipeID = 21, Quantity = 0.5M };
                var ri20_6 = new RecipeIngredient { RecipeIngredientID = 140, IngredientID = 71, RecipeID = 21, Quantity = 0.125M };
                var ri20_7 = new RecipeIngredient { RecipeIngredientID = 141, IngredientID = 68, RecipeID = 21, Quantity = 0.125M };
                var ri20_8 = new RecipeIngredient { RecipeIngredientID = 142, IngredientID = 69, RecipeID = 21, Quantity = 0.125M };
                var ri20_9 = new RecipeIngredient { RecipeIngredientID = 143, IngredientID = 13, RecipeID = 21, Quantity = 0.125M };

                recipeIngredients = new List<RecipeIngredient> { ri20_1, ri20_2, ri20_3, ri20_4, ri20_5, ri20_6, ri20_7, ri20_8, ri20_9 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Lamb Stew

                var ingredient72 = new Ingredient { IngredientID = 72, IngredientName = "Lamb", MeasureID = 1, Carb = 1.3M, Protein = 0.2M };
                var ingredient73 = new Ingredient { IngredientID = 73, IngredientName = "Paprika", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                var ingredient74 = new Ingredient { IngredientID = 74, IngredientName = "Beans", MeasureID = 2, Carb = 1.3M, Protein = 0.2M };
                ingredients = new List<Ingredient> { ingredient72, ingredient73, ingredient74 };
                ingredients.ForEach(i => context.Ingredients.Add(i));

                context.Recipes.Add(new Recipe { RecipeID = 21, RecipeName = "Lamb Stew", SubCategoryID = 8, Description = @"<ul><li>Remove as much fat as possible from meat.  Wash thoroughly.  Braise meat in a large kettle.  Add 1/2 cup water, add onion and green pepper and braise until onion and green pepper are transparent.  Braise until meat sizzles, but is not burned.  Add 2 tablespoons paprika, blend thoroughly.</li><li>Add can of tomato sauce and peeled tomatoes and boil water to cover mixture. Let simmer 2 hours.  Add green beans cut into 1 inch pieces and allow to simmer another 1/2 hour.</li><li>Serve with rice.</li></ul>" });
                context.SaveChanges();

                var ri21_1 = new RecipeIngredient { RecipeIngredientID = 144, IngredientID = 72, RecipeID = 22, Quantity = 1200 };
                var ri21_2 = new RecipeIngredient { RecipeIngredientID = 145, IngredientID = 18, RecipeID = 22, Quantity = 0.125M };
                var ri21_3 = new RecipeIngredient { RecipeIngredientID = 146, IngredientID = 20, RecipeID = 22, Quantity = 1 };
                var ri21_4 = new RecipeIngredient { RecipeIngredientID = 147, IngredientID = 73, RecipeID = 22, Quantity = 2 };
                var ri21_5 = new RecipeIngredient { RecipeIngredientID = 148, IngredientID = 74, RecipeID = 22, Quantity = 2 };
                var ri21_6 = new RecipeIngredient { RecipeIngredientID = 149, IngredientID = 60, RecipeID = 22, Quantity = 1 };
                var ri21_7 = new RecipeIngredient { RecipeIngredientID = 150, IngredientID = 50, RecipeID = 22, Quantity = 1 };

                recipeIngredients = new List<RecipeIngredient> { ri21_1, ri21_2, ri21_3, ri21_4, ri21_5, ri21_6, ri21_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Blond Brownies

                var ingredient75 = new Ingredient { IngredientID = 75, IngredientName = "Baking Soda", MeasureID = 4 };
                context.Ingredients.Add(ingredient75);

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 22,
                    RecipeName = "Blond Brownies",
                    SubCategoryID = 16,
                    Description = @"<p>Stir together melted margarine and sugars. Add eggs and mix well. Stir in sifted flour, baking powder and soda. Stir in chips (and nuts.) Spread in greased 13x9-inch baking pan. Bake 350 degrees for 30 minutes.</p><p>Do not overbake these; they will get dry and crunchy instead of soft & moist.</p>"
                });
                context.SaveChanges();

                var ri22_1 = new RecipeIngredient { RecipeIngredientID = 151, IngredientID = 38, RecipeID = 23, Quantity = 1 };
                var ri22_2 = new RecipeIngredient { RecipeIngredientID = 152, IngredientID = 3, RecipeID = 23, Quantity = 2 };
                var ri22_3 = new RecipeIngredient { RecipeIngredientID = 153, IngredientID = 12, RecipeID = 23, Quantity = 2 };
                var ri22_4 = new RecipeIngredient { RecipeIngredientID = 154, IngredientID = 32, RecipeID = 23, Quantity = 2 };
                var ri22_5 = new RecipeIngredient { RecipeIngredientID = 155, IngredientID = 36, RecipeID = 23, Quantity = 1 };
                var ri22_6 = new RecipeIngredient { RecipeIngredientID = 156, IngredientID = 75, RecipeID = 23, Quantity = 0.25M };
                var ri22_7 = new RecipeIngredient { RecipeIngredientID = 157, IngredientID = 52, RecipeID = 23, Quantity = 50 };
                var ri22_8 = new RecipeIngredient { RecipeIngredientID = 158, IngredientID = 11, RecipeID = 23, Quantity = 0.5M };

                recipeIngredients = new List<RecipeIngredient> { ri22_1, ri22_2, ri22_3, ri22_4, ri22_5, ri22_6, ri22_7, ri22_8 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Cream Filling 

                var ingredient76 = new Ingredient { IngredientID = 76, IngredientName = "Whipping Cream", MeasureID = 2, Carb = 4.3M, Protein = 3, Fat = 11.5M };
                context.Ingredients.Add(ingredient76);

                context.Recipes.Add(new Recipe
                {
                    RecipeID = 23,
                    RecipeName = "Cream Filling",
                    SubCategoryID = 17,
                    Description = @"<p>Beat whipping cream with sugar and vanilla. Whip until stiff; do not overbeat. DO NOT OVER EAT!</p>"
                });
                context.SaveChanges();

                var ri23_1 = new RecipeIngredient { RecipeIngredientID = 159, IngredientID = 76, RecipeID = 24, Quantity = 2 };
                var ri23_2 = new RecipeIngredient { RecipeIngredientID = 160, IngredientID = 3, RecipeID = 24, Quantity = 0.1M };
                var ri23_3 = new RecipeIngredient { RecipeIngredientID = 161, IngredientID = 59, RecipeID = 24, Quantity = 1 };

                recipeIngredients = new List<RecipeIngredient> { ri23_1, ri23_2, ri23_3 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Gery's Cheesecake

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 24,
                                            RecipeName = "Gery's Cheesecake",
                                            SubCategoryID = 18,
                                            Description = @"<p>Filling:  Combine cheese and sugar and mix thoroughly.</p><p>Add eggs one at a time, beating after each addition.</p><p>Beat in salt and vanilla. Turn into prepared graham cracker crust. Bake 1 hour in preheated 325 oven.</p><p>Topping: Combine sour cream, sugar and vanilla. Spread over top of cream cheese mixture.  Return to oven for 5 minutes. Remove and place to chill.</p><p>Serve plain or with berries.  Makes one deep-dish pie. I have doubled this and placed in a 11 x 8. Works beautifully. (Prepare crust by using boxed crushed graham cracker crumbs mixed with butter and press into dish)</p>"
                                        });
                context.SaveChanges();

                var ri24_1 = new RecipeIngredient { RecipeIngredientID = 162, IngredientID = 4, RecipeID = 25, Quantity = 1 };
                var ri24_2 = new RecipeIngredient { RecipeIngredientID = 163, IngredientID = 3, RecipeID = 25, Quantity = 1.5M };
                var ri24_3 = new RecipeIngredient { RecipeIngredientID = 164, IngredientID = 12, RecipeID = 25, Quantity = 5 };
                var ri24_4 = new RecipeIngredient { RecipeIngredientID = 165, IngredientID = 13, RecipeID = 25, Quantity = 0.25M };
                var ri24_5 = new RecipeIngredient { RecipeIngredientID = 166, IngredientID = 59, RecipeID = 25, Quantity = 2.5M };
                var ri24_6 = new RecipeIngredient { RecipeIngredientID = 167, IngredientID = 2, RecipeID = 25, Quantity = 1 };
                var ri24_7 = new RecipeIngredient { RecipeIngredientID = 168, IngredientID = 64, RecipeID = 25, Quantity = 1 };

                recipeIngredients = new List<RecipeIngredient> { ri24_1, ri24_2, ri24_3, ri24_4, ri24_5, ri24_6, ri24_7 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Icy Yogurt Pops

                var ingredient77 = new Ingredient { IngredientID = 77, IngredientName = "Yogurt", MeasureID = 2, Carb = 24.2M, Protein = 4, Fat = 5.6M };
                context.Ingredients.Add(ingredient77);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 25,
                                            RecipeName = "Icy Yogurt Pops",
                                            SubCategoryID = 19,
                                            Description = @"<p>You can use pureed fresh fruit or frozen fruits instead juice. In a 4 cup glass measure, combine yogurt, fruit juice concentrate and milk. Pour into pop molds or use small paper cups and insert a wooden stick in the centre of each. Freeze until firm, about 2 - 3 hours. To serve, peel off paper cups.</p>"
                                        });
                context.SaveChanges();

                var ri25_1 = new RecipeIngredient { RecipeIngredientID = 169, IngredientID = 77, RecipeID = 26, Quantity = 1 };
                var ri25_2 = new RecipeIngredient { RecipeIngredientID = 170, IngredientID = 63, RecipeID = 26, Quantity = 0.75M };
                var ri25_3 = new RecipeIngredient { RecipeIngredientID = 171, IngredientID = 35, RecipeID = 26, Quantity = 0.75M };

                recipeIngredients = new List<RecipeIngredient> { ri25_1, ri25_2, ri25_3 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();

                //Lemon Mousse

                var ingredient78 = new Ingredient { IngredientID = 78, IngredientName = "Gelatin", MeasureID = 4, Protein = 24 };
                var ingredient79 = new Ingredient { IngredientID = 79, IngredientName = "Lemon Rind", MeasureID = 3, Carb = 16.5M, Protein = 1.5M, Fat = 0.3M };
                context.Ingredients.Add(ingredient78);
                context.Ingredients.Add(ingredient79);

                context.Recipes.Add(new Recipe
                                        {
                                            RecipeID = 26,
                                            RecipeName = "Lemon Mousse",
                                            SubCategoryID = 20,
                                            Description = @"<p>Sprinkle gelatin over cold water and soften. Set in a bowl of hot water and mix till dissolved. Beat egg yolks in a medium bowl until blended. Gradually add half the sugar and continue beating until ribbon forms, about 3 to 5 minutes. Beat in lemon juice and zest, then the gelatin.</p><p>Refrigerator for 10 minutes, stirring every two minutes or until mixture mounds slightly when dropped from a spoon.</p><p>Whip cream until stiff. Whip egg whites wntil soft peaks form, then add remaining sugar a tablespoon at a time. Continue beating until stiff but not dry.</p><p>Gently fold egg-yolk mixture into shites until no streaks are left then fold in whipped cream.</p><p>Spoon into serving bowl or individual desset dishes.</p><p>Refrigerate 3 hours. Garnish with mint and lemon slices.</p>"
                                        });
                context.SaveChanges();

                var ri26_1 = new RecipeIngredient { RecipeIngredientID = 172, IngredientID = 78, RecipeID = 27, Quantity = 1 };
                var ri26_2 = new RecipeIngredient { RecipeIngredientID = 173, IngredientID = 12, RecipeID = 27, Quantity = 4 };
                var ri26_3 = new RecipeIngredient { RecipeIngredientID = 174, IngredientID = 2, RecipeID = 27, Quantity = 0.75M };
                var ri26_4 = new RecipeIngredient { RecipeIngredientID = 175, IngredientID = 63, RecipeID = 27, Quantity = 0.5M };
                var ri26_5 = new RecipeIngredient { RecipeIngredientID = 176, IngredientID = 79, RecipeID = 27, Quantity = 1 };
                var ri26_6 = new RecipeIngredient { RecipeIngredientID = 177, IngredientID = 76, RecipeID = 27, Quantity = 0.75M };

                recipeIngredients = new List<RecipeIngredient> { ri26_1, ri26_2, ri26_3, ri26_4, ri26_5, ri26_6 };
                recipeIngredients.ForEach(ri => context.RecipeIngredients.Add(ri));
                context.SaveChanges();
            }
            catch (DbEntityValidationException vex)
            {
                foreach (var err in vex.EntityValidationErrors)
                {
                    foreach (var err2 in err.ValidationErrors)
                    {
                        string msg = err2.ErrorMessage;
                    }
                }
            }
        }
    }
}