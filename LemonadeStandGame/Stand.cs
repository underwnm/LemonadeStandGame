using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Stand
    {
        public Inventory inventory;
        public Player player;
        public double pintPrice;
        public double grossProfit;
        public double dailyIncome;
        public int pitchers;
        public int pintsPerPitcher;
        public int pintsSold;
        public int maxPitchers;

        public Stand(Player player)
        {
            this.player = player;
            inventory = new Inventory();
            grossProfit = 0;
            pintsPerPitcher = 10;      
        }
        public void CheckRecipeVsInventory()
        {
            if (inventory.lemons.Count() <= player.recipe.ingredients[0] || inventory.sugar.Count() <= player.recipe.ingredients[1] || inventory.ice.Count() <= player.recipe.ingredients[2])
            {
                maxPitchers = 0;
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade**", maxPitchers);
                Console.WriteLine("");
            }
            else
            {
                int maxLemons = player.stand.inventory.lemons.Count() / player.recipe.ingredients[0];
                int maxSugar = player.stand.inventory.sugar.Count() / player.recipe.ingredients[1];
                int maxIce = player.stand.inventory.ice.Count() / player.recipe.ingredients[2];
                int maxCup = player.stand.inventory.cups.Count() / pintsPerPitcher;
                maxPitchers = new int[] { maxLemons, maxSugar, maxIce, maxCup }.Min();
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade and sell {1} pints size cups**", maxPitchers, maxPitchers * pintsPerPitcher);
                Console.WriteLine("");
            }
        }
        public void SetNumberOfPitchers()
        {
            pitchers = GetNumberOfPitchers(maxPitchers);
        }
        public void SetPintPrice()
        {
            pintPrice = GetPintPrice();
        }
        private int GetNumberOfPitchers(int maxPitchers)
        {
            int userInput;
            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                return GetNumberOfPitchers(maxPitchers);
            }
            if (userInput > maxPitchers)
            {
                Console.WriteLine("Insufficient Supply");
                return GetNumberOfPitchers(maxPitchers);
            }
            return userInput;
        }
        private double GetPintPrice()
        {
            double userInput;
            if (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                return GetPintPrice();
            }
            return userInput;
        }
        public void FindNumberOfSales(List<Customer> customer)
        {
            pintsSold = 0;
            int pintsMade = pitchers * pintsPerPitcher;
            for (int i = 0; (i < customer.Count()) && (pintsMade > 0); i++)
            {
                if (customer[i].CheckBuyLemonade())
                {
                    pintsSold++;
                    pintsMade--;
                }
            }
        }
        public void UpdateInventory()
        {
            for (int i = 0; i < pitchers; i++)
            {
                inventory.RemoveLemon(player.recipe.ingredients[0]);
                inventory.RemoveSugar(player.recipe.ingredients[1]);
                inventory.RemoveIce(player.recipe.ingredients[2]);
                inventory.RemoveCup(pintsPerPitcher);
            }
        }
        public void AddProfitToWallet(Store store)
        {
            dailyIncome = pintsSold * pintPrice;
            grossProfit = dailyIncome - ((pitchers * player.recipe.ingredients[0]) * (store.cost[0]));
            grossProfit = grossProfit - ((pitchers * player.recipe.ingredients[1]) * (store.cost[1] / 240));
            grossProfit = grossProfit - ((pitchers * player.recipe.ingredients[2]) * (store.cost[2] / 10));
            grossProfit = grossProfit - ((pitchers * pintsPerPitcher) * (store.cost[3] / 100));
            player.wallet.money = player.wallet.money + dailyIncome;
        }
    }
}
