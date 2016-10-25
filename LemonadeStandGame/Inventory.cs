using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Inventory
    {
        Player player;

        public Inventory(Player player)
        {
            this.player = player;
        }
        public void ExecuteInventory()
        {
            DisplayCurrentInventory();
            CheckRecipeVsInventory();
        }
        private void DisplayCurrentInventory()
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your supply...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You have {0} cups of sugar", player.ingredients[0]);
            Console.WriteLine("You have {0} lemons", player.ingredients[1]);
            Console.WriteLine("You have {0} cups of ice", player.ingredients[2]);
            Console.WriteLine("You have ${0} available in cash", player.money);
            Console.WriteLine("------------------------------------");
        }
        
        private void CheckRecipeVsInventory()
        {
            int product;
            if (player.ingredients[0] < player.recipe[0] || player.ingredients[1] < player.recipe[1] || player.ingredients[2] < player.recipe[2])
            {
                product = 0;
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade**", product);                
            }
            else
            {
                int maxSugar = player.ingredients[0] / player.recipe[0];
                int maxLemons = player.ingredients[1] / player.recipe[1];
                int maxIce = player.ingredients[2] / player.recipe[2];
                product = new int[] { maxSugar, maxLemons, maxIce }.Min();
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade**", product);
            }
        }
    }
}
