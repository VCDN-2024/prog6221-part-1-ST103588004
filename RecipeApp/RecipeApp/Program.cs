using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Author:Teddy Smith
 * Availability: (https://youtube.com/playlist?list=PL82C6-O4XrHfoN_Y4MwGvJz5BntiL0z0D&si=9IiBbWs4lsCl8hFU)
 * date of access:10 April
 */

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display the current recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                //dsiplaying options for user

                int userOption = GetUserInput();
                try
                {
                    switch (userOption)
                    {
                        case 1:
                            recipeManager.EnterRecipeDetails();
                            break;
                        case 2:
                            recipeManager.DisplayRecipe();
                            break;
                        case 3:
                            recipeManager.ScaleRecipe();
                            break;
                        case 4:
                            recipeManager.ResetQuantities();
                            break;
                        case 5:
                            recipeManager.ClearAllData();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
        //Use case case options for recipe app
        static int GetUserInput()
        {
            int userOption;
            while (!int.TryParse(Console.ReadLine(), out userOption) || userOption < 1 || userOption > 6)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            }
            return userOption;
        }
    }
}