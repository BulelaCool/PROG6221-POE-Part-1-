using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_
{
    internal class Recipe
    {
        // Arrays to store ingredients and steps
        private string[] ingredients;
        private string[] steps;

        // Constructor to initialize arrays
        public Recipe()
        {
            ingredients = new string[0];
            steps = new string[0];
        }

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            // Initialize ingredients array with user-defined size
            ingredients = new string[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter quantity for {name}: ");
                string quantity = Console.ReadLine();
                Console.Write($"Enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();
                ingredients[i] = $"{quantity} {unit} of {name}";
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Initialize steps array with user-defined size
            steps = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1} description: ");
                steps[i] = Console.ReadLine();
            }
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:\n");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            // Loop through ingredients and scale quantities
            for (int i = 0; i < ingredients.Length; i++)
            {
                string[] parts = ingredients[i].Split(' ');
                double quantity = double.Parse(parts[0]) * factor;
                ingredients[i] = $"{quantity} {parts[1]} of {string.Join(' ', parts, 2, parts.Length - 2)}";
            }
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            // This could be implemented to reset quantities to original values
            // For simplicity, this method is left unimplemented
        }

        // Method to clear recipe data
        public void ClearRecipe()
        {
            // Reset ingredients and steps arrays to empty arrays
            ingredients = new string[0];
            steps = new string[0];
        }
    }
}

