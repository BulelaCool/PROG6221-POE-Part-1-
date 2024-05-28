using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_.Classes
{
    namespace RecipeApp
    {
        // Class representing an ingredient
        public class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }
        }

        public enum FoodGroup
        {
            Protein = 1,
            Carbohydrate,
            Fat,
            Vitamins,
            Minerals
        }
    }
}
