using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Store
    {
        private double sugarCost;
        private double lemonCost;
        private double iceCost;
        private double money;
        public void DisplayStoreItems(int sugar, int lemons, int ice, double money)
        {
            Console.WriteLine("WELCOME TO THE STORE");
            Console.WriteLine("Let's buy some supplies...");
            Console.WriteLine("Right now, you have:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You have {0} cups of sugar", sugar);
            Console.WriteLine("You have {0} lemons", lemons);
            Console.WriteLine("You have {0} cups of ice", ice);
            Console.WriteLine("You have ${0} available in cash", money);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("The prices today at the store are...");
            Console.WriteLine("4 lb bag of sugar costs {0}", sugarCost);
            Console.WriteLine("1 lb bag of lemons costs {0}", lemonCost);
            Console.WriteLine("5 lb bag of ice costs {0}", iceCost);
        }
        public void GetItemPrices()
        {
            Random random = new Random();
            sugarCost = Math.Round(RandomNumberBetween(1.90, 2.10), 2);
            lemonCost = Math.Round(RandomNumberBetween(2.20, 2.40), 2);
            iceCost = Math.Round(RandomNumberBetween(1.30, 1.50), 2);
            DisplayStoreItems(5, 3, 3, 10.00);
        }
        public double RandomNumberBetween(double minValue, double maxvalue)
        {
            Random random = new Random();
            double next = random.NextDouble();
            return minValue + (next * (maxvalue-minValue));
        }
    }
}
