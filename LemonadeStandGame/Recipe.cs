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
            ingredients = new int[3]; //#Lemons, #Sugar, #Ice,
        }
        public void GetRecipe()
        {
            Console.WriteLine("Create a recipe for tomorrow");
            Console.WriteLine("Each recipe creates a 1 gallon pitcher\nThis will create 8 pints to sell to potential customers");
            Console.WriteLine("");
            Console.WriteLine("Enter how many lemons...");
            ingredients[0] = GetUserInput();
            Console.WriteLine("Enter how many tablespoons of sugar...");
            ingredients[1] = GetUserInput();
            Console.WriteLine("Enter how many cups of ice...");
            ingredients[2] = GetUserInput();
        }
        private int GetUserInput()
        {
            int userInput;
            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                GetUserInput();
            }
            if (userInput == 0)
            {
                Console.WriteLine("Must at least have 1 of each ingredient");
                GetUserInput();
            }
            return userInput;
        }
    }
}
