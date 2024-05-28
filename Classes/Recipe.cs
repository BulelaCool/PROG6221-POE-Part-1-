using Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_.Classes.RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_.Classes
{
    // Class representing a recipe
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public delegate void CaloriesExceededHandler(string recipeName);
        public event CaloriesExceededHandler CaloriesExceeded;

        // Method to calculate total calories of a recipe
        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        // Method to check if calories exceed the threshold
        public void CheckCalories()
        {
            if (CalculateTotalCalories() > 300)
            {
                CaloriesExceeded?.Invoke(Name);
            }
        }
    }
}
