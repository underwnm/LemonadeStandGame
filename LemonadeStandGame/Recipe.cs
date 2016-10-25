using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Recipe
    {
        Player player;
        public Recipe(Player player)
        {
            this.player = player;
        }
        public void GetRecipe()
        {
            Console.WriteLine("Create a recipe for tomorrow");
            Console.WriteLine("Each recipe creates a 1 gallon pitcher\n This will create 8 pints to sell to potential customers");
            Console.WriteLine("");
            Console.WriteLine("Enter how many tablespoons of sugar...");
            player.recipe[0] = GetUserInput();
            Console.WriteLine("Enter how many lemons...");
            player.recipe[1] = GetUserInput();
            Console.WriteLine("Enter how many cups of ice...");
            player.recipe[2] = GetUserInput();
        }
        private int GetUserInput()
        {
            int userInput = Convert.ToInt16(Console.ReadLine().ToUpper());
            return userInput;
        }
    }
}
