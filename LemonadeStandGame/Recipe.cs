using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Recipe
    {
        public int[] ingredients; 
        public Recipe()
        {
            ingredients = new int[4]; //#Lemons, #Sugar, #Ice, #Cups
        }
        public void GetRecipe()
        {
            Console.WriteLine("Create a recipe for tomorrow");
            Console.WriteLine("Each recipe creates a 1 gallon pitcher\nThis will create 8 pints to sell to potential customers");
            Console.WriteLine("");
            Console.WriteLine("Enter how many tablespoons of sugar...");
            ingredients[0] = GetUserInput();
            Console.WriteLine("Enter how many lemons...");
            ingredients[1] = GetUserInput();
            Console.WriteLine("Enter how many cups of ice...");
            ingredients[2] = GetUserInput();
            Console.WriteLine("Enter how many pint cups you want...");
            ingredients[3] = GetUserInput();
        }
        private int GetUserInput()
        {
            int userInput;
            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                GetUserInput();
            }
            return userInput;
        }
    }
}
