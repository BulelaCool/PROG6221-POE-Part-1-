// See https://aka.ms/new-console-template for more information
// Bulela Denzel Mhlana
// ST10198391
// Group 1

//Refernces List:
// 1) https://www.youtube.com/watch?v=EsM8qnl1tkw
// 2) https://www.youtube.com/watch?v=8bOoiftm5wM
// 3) https://stackoverflow.com/questions/58964183/methods-to-clear-array-and-then-fill-it-ends-up-in-an-empty-array
// 4) https://www.youtube.com/watch?v=uHwJLtOQy4g
// 5) https://www.youtube.com/watch?v=8bOoiftm5wM
// 6) https://wellsb.com/csharp/beginners/create-menu-csharp-console-application#:~:text=Building%20the%20Console%20Menu,will%20call%20the%20appropriate%20method.
// 7) https://stackoverflow.com/questions/76828905/how-can-i-define-a-string-format-for-a-double-that-displays-the-value-as-if-it-w
// 8) https://github.com/github/VisualStudio/blob/master/docs/using/publishing-an-existing-project-to-github.md

using Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_.Classes.RecipeApp;
using Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_.Classes;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nSelect an option:\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Display All Recipes");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear All Recipes");
                Console.WriteLine("7. Exit\n");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    DisplayError("Invalid Input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails(recipeManager);
                        break;
                    case 2:
                        DisplayRecipe(recipeManager);
                        break;
                    case 3:
                        recipeManager.DisplayAllRecipes();
                        break;
                    case 4:
                        ScaleRecipe(recipeManager);
                        break;
                    case 5:
                        ResetQuantities(recipeManager);
                        break;
                    case 6:
                        ClearRecipes(ref recipeManager);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        DisplayError("Invalid Choice. Please try again.");
                        break;
                }
            }
        }

        static void EnterRecipeDetails(RecipeManager recipeManager)
        {
            Recipe recipe = new Recipe();

            Console.Write("\nEnter the Recipe Name: ");
            recipe.Name = Console.ReadLine();

            int numIngredients;
            while (true)
            {
                Console.Write("\nEnter the Number of Ingredients: ");
                if (int.TryParse(Console.ReadLine(), out numIngredients) && numIngredients > 0)
                    break;

                DisplayError("Invalid Input. Please enter a Positive Integer.");
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();

                Console.Write($"\nEnter Ingredient {i + 1} Name: ");
                ingredient.Name = Console.ReadLine();

                while (true)
                {
                    Console.Write($"\nEnter Quantity for {ingredient.Name}: ");
                    if (double.TryParse(Console.ReadLine(), out double quantity) && quantity > 0)
                    {
                        ingredient.Quantity = quantity;
                        break;
                    }

                    DisplayError("Invalid Input. Please Enter a Positive Number.");
                }

                Console.Write($"\nEnter Unit of Measurement for {ingredient.Name}: ");
                ingredient.Unit = Console.ReadLine();

                while (true)
                {
                    Console.Write($"\nEnter Calories for {ingredient.Name}: ");
                    if (int.TryParse(Console.ReadLine(), out int calories) && calories >= 0)
                    {
                        ingredient.Calories = calories;
                        break;
                    }

                    DisplayError("Invalid Input. Please Enter a Non-negative Integer.");
                }

                while (true)
                {
                    Console.WriteLine($"\nEnter Food Group for {ingredient.Name} (Choose a number):");
                    Console.WriteLine("1. Protein");
                    Console.WriteLine("2. Carbohydrate");
                    Console.WriteLine("3. Fat");
                    Console.WriteLine("4. Vitamins");
                    Console.WriteLine("5. Minerals\n");
                    if (int.TryParse(Console.ReadLine(), out int foodGroupChoice) && foodGroupChoice >= 1 && foodGroupChoice <= 5)
                    {
                        ingredient.FoodGroup = ((FoodGroup)foodGroupChoice).ToString();
                        break;
                    }

                    DisplayError("Invalid Input. Please Select a Valid Food Group.");
                }

                recipe.Ingredients.Add(ingredient);
            }

            int numSteps;
            while (true)
            {
                Console.Write("\nEnter the Number of Steps: ");
                if (int.TryParse(Console.ReadLine(), out numSteps) && numSteps > 0)
                    break;

                DisplayError("Invalid Input. Please Enter a Positive Integer.");
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nEnter Step {i + 1} Description: ");
                recipe.Steps.Add(Console.ReadLine());
            }

            recipe.CaloriesExceeded += (recipeName) =>
            {
                DisplayWarning($"\nWarning: The Total Calories of the Recipe '{recipeName}' Exceed 300!");
                Console.WriteLine("A balanced diet typically contains:");
                Console.WriteLine("- Less than 300 calories per meal for weight maintenance");
                Console.WriteLine("- Less than 500 calories per meal for weight gain");
            };

            recipe.CheckCalories();
            recipeManager.AddRecipe(recipe);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe Added Successfully!");
            Console.ResetColor();
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        static void DisplayRecipe(RecipeManager recipeManager)
        {
            recipeManager.DisplayAllRecipes();
            Console.Write("\nEnter the Number of the Recipe to Display: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > recipeManager.RecipeCount)
            {
                DisplayError("Invalid Recipe Number.");
                return;
            }
            index--;

            Recipe recipe = recipeManager.GetRecipe(index);
            if (recipe != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nRecipe: {recipe.Name}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIngredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup} group)");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nSteps:");
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nTotal Calories: {recipe.CalculateTotalCalories()}");
                Console.ResetColor();
            }
            else
            {
                DisplayError("Invalid Recipe Number.");
            }
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }

        static void ScaleRecipe(RecipeManager recipeManager)
        {
            recipeManager.DisplayAllRecipes();
            Console.Write("\nEnter the Number of the Recipe to Scale: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > recipeManager.RecipeCount)
            {
                DisplayError("Invalid Recipe Number.");
                return;
            }
            index--;

            Recipe recipe = recipeManager.GetRecipe(index);
            if (recipe != null)
            {
                double factor;
                while (true)
                {
                    Console.Write("\nEnter Scaling Factor (0.5, 2, or 3): ");
                    if (double.TryParse(Console.ReadLine(), out factor) && (factor == 0.5 || factor == 2 || factor == 3))
                        break;

                    DisplayError("Invalid Input. Please Enter 0.5, 2, or 3.");
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= factor;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRecipe Scaled Successfully.");
                Console.ResetColor();
            }
            else
            {
                DisplayError("Invalid Recipe Number.");
            }
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }

        static void ResetQuantities(RecipeManager recipeManager)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nReset Quantities Feature is not Implemented.");
            Console.ResetColor();
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }

        static void ClearRecipes(ref RecipeManager recipeManager)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nClearing Recipes...");
            recipeManager = new RecipeManager();
            Console.WriteLine("All Recipes Have Been Cleared.");
            Console.ResetColor();
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadLine();
        }

        static void DisplayWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
