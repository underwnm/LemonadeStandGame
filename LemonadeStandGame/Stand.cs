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
        public double totalNetProfit;
        public double pintPriceToday;
        public double dailyGrossProfit;
        public double dailyIncome;
        public int pintsPerPitcher;
        public int numberOfPitchersMade;
        public int maxPitchersPerIngredients;
        public int pintsSoldToCustomers;

        public Stand(Player player)
        {
            this.player = player;
            inventory = new Inventory();
            pintsPerPitcher = 10;      
        }
        public void CheckRecipeVsInventory()
        {
            if (inventory.lemons.Count() < player.recipe.ingredients[0] || inventory.sugar.Count() < player.recipe.ingredients[1] || inventory.ice.Count() < player.recipe.ingredients[2])
            {
                maxPitchersPerIngredients = 0;
            }
            else
            {
                int maxLemons = player.stand.inventory.lemons.Count() / player.recipe.ingredients[0];
                int maxSugar = player.stand.inventory.sugar.Count() / player.recipe.ingredients[1];
                int maxIce = player.stand.inventory.ice.Count() / player.recipe.ingredients[2];
                int maxCup = player.stand.inventory.cups.Count() / pintsPerPitcher;
                maxPitchersPerIngredients = new int[] { maxLemons, maxSugar, maxIce, maxCup }.Min();
            }
        }
        public void GetNumberOfPitchersMade()
        {
            string userInput = Console.ReadLine();
            numberOfPitchersMade = CheckForValidPitcherInput(userInput);
        }
        private int CheckForValidPitcherInput(string userInput)
        {
            int userAmount;
            if (!int.TryParse(userInput, out userAmount))
            {
                Console.WriteLine("Invalid Number");
                GetNumberOfPitchersMade();
            }
            else if (userAmount > maxPitchersPerIngredients)
            {
                Console.WriteLine("Insufficient Supply");
                GetNumberOfPitchersMade();
            }
            return userAmount;
        }
        public void GetPintPrice()
        {
            string userInput = Console.ReadLine();
            pintPriceToday = CheckForValidPintPrice(userInput);
        }
        private double CheckForValidPintPrice(string userInput)
        {
            double userPrice;
            if (!double.TryParse(userInput, out userPrice))
            {
                Console.WriteLine("Invalid Number");
                GetPintPrice();
            }
            return userPrice;
        }
        public void CalculateNumberOfCustomerSales(List<Customer> customer, Weather weather)
        {
            pintsSoldToCustomers = 0;
            int pintsMade = GetTotalPintsMade();
            for (int i = 0; (i < customer.Count()) && (pintsMade > 0); i++)
            {
                if (customer[i].CheckBuyLemonade(weather))
                {
                    pintsSoldToCustomers++;
                    pintsMade--;
                }
            }
        }
        public void UpdateInventory()
        {
            for (int i = 0; i < numberOfPitchersMade; i++)
            {
                inventory.RemoveLemon(player.recipe.ingredients[0]);
                inventory.RemoveSugar(player.recipe.ingredients[1]);
                inventory.RemoveIce(player.recipe.ingredients[2]);
                inventory.RemoveCup(pintsPerPitcher);
            }
        }
        public void AddProfitToWallet(Store store)
        {
            dailyIncome = pintsSoldToCustomers * pintPriceToday;
            dailyGrossProfit = dailyIncome - ((numberOfPitchersMade * player.recipe.ingredients[0]) * (store.costOfGoods[0]));
            dailyGrossProfit = dailyGrossProfit - ((numberOfPitchersMade * player.recipe.ingredients[1]) * (store.costOfGoods[1] / store.tablespoonsOfSugarPerBag));
            dailyGrossProfit = dailyGrossProfit - ((numberOfPitchersMade * player.recipe.ingredients[2]) * (store.costOfGoods[2] / store.cupsOfIcePerBag));
            dailyGrossProfit = dailyGrossProfit - ((numberOfPitchersMade * pintsPerPitcher) * (store.costOfGoods[3] / store.cupsPerBag));
            player.wallet.money = player.wallet.money + dailyIncome;
            totalNetProfit = player.wallet.money - player.wallet.startingInvestmentMoney;
        }
        public int GetTotalPintsMade()
        {
            int totalPintsMade = pintsPerPitcher * numberOfPitchersMade;
            return totalPintsMade;
        }
    }
}
