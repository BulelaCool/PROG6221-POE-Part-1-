// See https://aka.ms/new-console-template for more information
using Bulela_Mhlana___ST10198391___PROG6221__POE_Part_1_;

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        while (true)
        {
            // Display menu options
            Console.WriteLine("\nMenu Options:\n");
            Console.WriteLine("1. Enter Recipe Details");
            Console.WriteLine("2. Display Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Exit\n");

            // Read user choice
            int choice = int.Parse(Console.ReadLine());

            // Perform action based on user choice
            switch (choice)
            {
                case 1:
                    recipe.EnterRecipeDetails();
                    break;
                case 2:
                    recipe.DisplayRecipe();
                    break;
                case 3:
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(factor);
                    break;
                case 4:
                    recipe.ResetQuantities();
                    break;
                case 5:
                    recipe.ClearRecipe();
                    break;
                case 6:
                    Environment.Exit(0); // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

