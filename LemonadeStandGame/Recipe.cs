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
            Console.WriteLine("Create your recipe for tomorrow");
            Console.WriteLine("Enter how many cups of sugar...");
            player.recipe[0] = GetUserInput();
            Console.WriteLine("Enter how many lemons...");
            player.recipe[1] = GetUserInput();
            Console.WriteLine("Enter how many cups of ice");
            player.recipe[2] = GetUserInput();
            Console.Clear();
        }
        private int GetUserInput()
        {
            int userInput = Convert.ToInt16(Console.ReadLine().ToUpper());
            return userInput;
        }
    }
}
