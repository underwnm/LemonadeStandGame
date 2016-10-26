using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Day
    {
        public Player player;
        public Customer customer;
        public Weather weather;
        public Store store;
        public UserInterface display;

        public Day(Player player)
        {
            this.player = player;
            display = new UserInterface();
            weather = new Weather();
            customer = new Customer();
            store = new Store(player);
        }
        public void ExecuteStartDay()
        {
            weather.GetTomorrowForecast();
            display.DisplayTomorrowForecast(weather);
            CreateRecipe();
            GoToStore();
            ShopAtStore();
            display.DisplayAtStand();
            weather.GetActualWeather();
            NumberOfSales();
            ExecuteEndDay();
        }
        public void GoToStore()
        {
            display.DisplayToStore();
            display.ProceedWithGame();
        }
        public void ShopAtStore()
        {
            bool proceed = true;
            while (proceed)
            {
                display.DisplayItemPrices(store);
                display.DisplayCurrentInventory(player);
                display.DisplayRecipe(player);
                CheckRecipeVsInventory();
                proceed = store.ExecuteStore();
                display.ClearScreen();
            }
        }
        public void NumberOfSales()
        {
            for (int i = 0; i < weather.weatherDemand; i++)
            {
                customer.CheckBuyLemonade(player);               
            }
        }
        public void CreateRecipe()
        {
            player.recipe.GetRecipe();
        }
        private void CheckRecipeVsInventory()
        {
            int product;
            if (player.stand.inventory.lemons.Count() <= player.recipe.ingredients[0] || player.stand.inventory.sugar.Count() <= player.recipe.ingredients[1] || player.stand.inventory.ice.Count() <= player.recipe.ingredients[2])
            {
                product = 0;
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade**", product);
                Console.WriteLine("");
            }
            else
            {
                int maxLemons = player.stand.inventory.lemons.Count() / player.recipe.ingredients[0];
                int maxSugar = player.stand.inventory.sugar.Count() / player.recipe.ingredients[1];
                int maxIce = player.stand.inventory.ice.Count() / player.recipe.ingredients[2];
                product = new int[] { maxLemons, maxSugar, maxIce }.Min();
                Console.WriteLine("");
                Console.WriteLine("**With your inventory you can make {0} pitchers of lemonade and sell {1} pints size cups**", product, product * 8);
                Console.WriteLine("");
            }
        }
        private void GetDailyProfit()
        {
            double profit = player.dailyProfit + player.wallet.money;
        }
        private void ExecuteEndDay()
        {
            GetDailyProfit();
            display.DisplayProfit(player);
            Console.WriteLine("START NEXT DAY");
            display.ProceedWithGame();
        }
    }
}
