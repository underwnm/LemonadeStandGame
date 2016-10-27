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
        public double dailyProfit;
        public int pintsSold;
        public int pitchers;
        public int maxPitchers;

        public Stand(Player player)
        {
            inventory = new Inventory();
            pintsSold = 0;
            grossProfit = 0;
            this.player = player;         
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
                int maxCup = player.stand.inventory.cups.Count() / 8;
                maxPitchers = new int[] { maxLemons, maxSugar, maxIce, maxCup }.Min();
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade and sell {1} pints size cups**", maxPitchers, maxPitchers * 8);
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
                GetNumberOfPitchers(maxPitchers);
            }
            if (userInput > maxPitchers)
            {
                Console.WriteLine("Insufficient Supply");
                GetNumberOfPitchers(maxPitchers);
            }
            return userInput;
        }
        private double GetPintPrice()
        {
            double userInput;
            if (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                GetPintPrice();
            }
            return userInput;
        }
        public void FindNumberOfSales(List<Customer> customer)
        {
            int pints = pitchers * 8;
            for (int i = 0; (i < customer.Count()) && (pints > 0); i++)
            {
                if (customer[i].CheckBuyLemonade())
                {
                    pintsSold++;
                    pints--;
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
                inventory.RemoveCup(8);
            }
        }
        public void AddProfitToWallet(Store store)
        {
            dailyProfit = pintsSold * pintPrice;
            grossProfit = dailyProfit - ((pitchers * player.recipe.ingredients[0]) * (store.cost[0]));
            grossProfit = grossProfit - ((pitchers * player.recipe.ingredients[1]) * (store.cost[1] / 240));
            grossProfit = grossProfit - ((pitchers * player.recipe.ingredients[2]) * (store.cost[2] / 10));
            grossProfit = grossProfit - ((pitchers * 8) * (store.cost[3] / 100));
            player.wallet.money = player.wallet.money + dailyProfit;
        }
    }
}
