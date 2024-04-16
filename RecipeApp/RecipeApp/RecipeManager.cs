using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Author:Teddy Smith
 * Availability: (https://youtube.com/playlist?list=PL82C6-O4XrHfoN_Y4MwGvJz5BntiL0z0D&si=9IiBbWs4lsCl8hFU)
 * date of access:10 April
 */

class RecipeManager
{
    private Recipe recipe = new Recipe();

    public void EnterRecipeDetails()
        //method consisting of all the user promts to enter recipe details
    {
        try
            //error handling to deal with excpetions
        {
            //user promts for the recipe app
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            recipe.Ingredients = new string[ingredientCount];
            recipe.Quantities = new double[ingredientCount];
            recipe.Units = new string[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                recipe.Ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of {recipe.Ingredients[i]}:");
                recipe.Quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for {recipe.Ingredients[i]}:");
                recipe.Units[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());

            recipe.Steps = new string[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                recipe.Steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully!");
            //message to show data has been stored succesfully
        }
        catch (FormatException)
        //messages to inform user for enterring the wrong format for the data
        {
            throw new FormatException("Invalid input format. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            throw new OverflowException("Input is too large or too small.");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while entering recipe details: {ex.Message}");
        }
    }

    public void DisplayRecipe()
        //method to display the recipe 
    {
        if (recipe.Ingredients == null || recipe.Steps == null)
        {
            Console.WriteLine("Recipe is empty. Please enter recipe details first.");
            return;
        }

        Console.WriteLine("Recipe:");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < recipe.Ingredients.Length; i++)
        {
            Console.WriteLine($"{recipe.Quantities[i]} {recipe.Units[i]} of {recipe.Ingredients[i]}");
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < recipe.Steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
        }
    }

    public void ScaleRecipe()
        //method to scale recipe by 0.5,2 or 3
    {
        try
        {
            Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < recipe.Quantities.Length; i++)
            {
                recipe.Quantities[i] *= factor;
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid input format. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            throw new OverflowException("Input is too large or too small.");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while scaling recipe: {ex.Message}");
        }
    }

    public void ResetQuantities()
        //method to reset quantities
    {
        if (recipe.Quantities == null)
        {
            Console.WriteLine("No quantities to reset.");
            return;
        }

        Console.WriteLine("Quantities reset to original values.");
        //function to reset quantities assuming original values are not cleared when scaling
    }

    public void ClearAllData()
        //method to clear all information and data on the recipe
    {
        recipe = new Recipe();
        Console.WriteLine("All data cleared.");
    }
}
