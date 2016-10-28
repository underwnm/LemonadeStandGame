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
            dailyGrossProfit = 0;
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
        public int GetNumberOfPitchersMade()
        {
            string userInput = Console.ReadLine();
            int userNumber = CheckForValidPitcherInput(userInput);
            return userNumber;
        }
        private int CheckForValidPitcherInput(string userInput)
        {
            int userNumber = Convert.ToInt16(userInput);
            if (!int.TryParse(userInput, out userNumber))
            {
                Console.WriteLine("Invalid Number");
                return GetNumberOfPitchersMade();
            }
            else if (userNumber > maxPitchersPerIngredients)
            {
                Console.WriteLine("Insufficient Supply");
                return GetNumberOfPitchersMade();
            }
            return numberOfPitchersMade = userNumber;
        }
        public double GetPintPrice()
        {
            string userInput = Console.ReadLine();
            double userNumber = CheckForValidPintPrice(userInput);
            return userNumber;
        }
        private double CheckForValidPintPrice(string userInput)
        {
            double userNumber = Convert.ToDouble(userInput);
            if (!double.TryParse(Console.ReadLine(), out userNumber))
            {
                Console.WriteLine("Invalid Number");
                return GetPintPrice();
            }
            return pintPriceToday = userNumber;
        }
        public void CalculateNumberOfCustomerSales(List<Customer> customer, Weather weather)
        {
            pintsSoldToCustomers = 0;
            int pintsMade = numberOfPitchersMade * pintsPerPitcher;
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
            player.wallet.cashInWallet = player.wallet.cashInWallet + dailyIncome;
            totalNetProfit = player.wallet.cashInWallet - player.wallet.startingInvestmentMoney;
        }
        public int GetTotalPintsMade()
        {
            int totalPintsMade = pintsPerPitcher * numberOfPitchersMade;
            return totalPintsMade;
        }
    }
}
