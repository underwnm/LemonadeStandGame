using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void GetNumberOfLemons()
        {
            Console.WriteLine("Enter how many lemons...");
            ingredients[0] = GetUserInput();
        }
        public void GetTablespoonsOfSugar()
        {
            Console.WriteLine("Enter how many tablespoons of sugar...");
            ingredients[1] = GetUserInput();
        }
        public void GetCupsOfIce()
        {
            Console.WriteLine("Enter how many cups of ice...");
            ingredients[2] = GetUserInput();
        }
        private int GetUserInput()
        {
            string userInput = Console.ReadLine();
            int userNumber = CheckForValidInput(userInput);
            return userNumber;
        }
        private int CheckForValidInput(string userInput)
        {
            int userNumber = Convert.ToInt16(userInput);
            if (!int.TryParse(userInput, out userNumber))
            {
                Console.WriteLine("*Invalid Number*\nEnter valid number below...");
                return GetUserInput();
            }
            else if (userNumber == 0)
            {
                Console.WriteLine("*Must have at least 1 of each ingredient*\nEnter valid number below...");
                return GetUserInput();
            }
            return userNumber;
        }
    }
}