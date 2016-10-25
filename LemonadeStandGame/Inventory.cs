using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Inventory
    {
        private int sugar;
        private int lemons;
        private int ice;
        private double money;

        public Inventory(int sugar, int lemons, int ice, double money)
        {
            this.sugar = sugar;
            this.lemons = lemons;
            this.ice = ice;
            this.money = money;
        }
        public void DisplayCurrentInventory()
        {
            Console.WriteLine("Let's check your supply...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You have {0} cups of sugar", sugar);
            Console.WriteLine("You have {0} lemons", lemons);
            Console.WriteLine("You have {0} cups of ice", ice);
            Console.WriteLine("You have ${0} available in cash", money);
            Console.WriteLine("------------------------------------");
        }
        
        public void CheckInventory()
        {
            int product;
            if (sugar == 0 || lemons == 0 || ice == 0)
            {
                product = 0;
                Console.WriteLine("With your inventory you can make {0} pitchers of lemonade", product);                
            }
        }
        public void CheckBuy()
        {
            Console.WriteLine("Would you like to purchase supplies?");
            string buy = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            if (buy == "YES")
            {
                Store store = new Store();
            }

        }
    }
}
