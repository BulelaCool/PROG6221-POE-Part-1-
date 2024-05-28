using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_.Classes
{
    // Class to manage multiple recipes
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public int RecipeCount => recipes.Count;

        // Method to add a new recipe
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
        }

        // Method to display all recipes in alphabetical order
        public void DisplayAllRecipes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nRecipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.ResetColor();
        }

        // Method to get a recipe by index
        public Recipe GetRecipe(int index)
        {
            if (index >= 0 && index < recipes.Count)
            {
                return recipes[index];
            }
            return null;
        }
    }
}
