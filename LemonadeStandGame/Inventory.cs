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
            CheckInventory();
        }
        private void DisplayCurrentInventory()
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your supply...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You have {0} cups of sugar", player.sugar);
            Console.WriteLine("You have {0} lemons", player.lemons);
            Console.WriteLine("You have {0} cups of ice", player.ice);
            Console.WriteLine("You have ${0} available in cash", player.money);
            Console.WriteLine("------------------------------------");
        }
        
        private void CheckInventory()
        {
            int product;
            if (player.sugar == 0 || player.lemons == 0 || player.ice == 0)
            {
                product = 0;
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade**", product);                
            }
            else
            {
                
            }
        }
    }
}
