using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Day
    {
        public List<Customer> customer;
        public Player player;
        public Weather weather;
        public Store store;
        public UserInterface display;

        public Day(Player player, Store store)
        {
            this.player = player;
            this.store = store;
            display = new UserInterface();
            weather = new Weather();
            customer = new List<Customer>();
        }
        public void ExecuteStartDay()
        {
            weather.GetTomorrowForecast();
            CreatePlayerRecipe();
            ShopAtStore();
            weather.GetActualWeather();
            display.DisplayActualWeather(weather);
            DetermineCustomerDemand();
            ProceedToStand();
            ExecuteEndDay();
        }
        private void CreatePlayerRecipe()
        {
            bool proceed = true;
            while (proceed)
            {
                display.DisplayRecipeTemplate(weather);
                player.recipe.GetNumberOfLemons();
                display.DisplayRecipeTemplate(weather);
                player.recipe.GetTablespoonsOfSugar();
                display.DisplayRecipeTemplate(weather);
                player.recipe.GetCupsOfIce();
                display.DisplayRecipeTemplate(weather);
                display.DisplayRecipe(player);
                proceed = PromptProceed();
            }            
        }
        private void ShopAtStore()
        {
            display.DisplayStoreTemplate(store, player);
            bool proceed = store.PromptBuyMore();
            while (proceed)
            {
                display.DisplayStoreTemplate(store, player);
                store.SellLemons();
                display.DisplayStoreTemplate(store, player);
                store.SellSugar();
                display.DisplayStoreTemplate(store, player);
                store.SellIce();
                display.DisplayStoreTemplate(store, player);
                store.SellCup();
                display.DisplayStoreTemplate(store, player);
                proceed = store.PromptBuyMore();
            }
            display.ClearScreen();
        }
        private void ProceedToStand()
        {
            display.DisplayAtStand();
            player.stand.CheckRecipeVsInventory();
            display.DisplayHowManyPitchers();
            player.stand.SetNumberOfPitchers();
            display.DisplayHowMuchPerPint();
            player.stand.SetPintPrice();
            player.stand.FindNumberOfSales(customer);
            display.DisplayPintsSold(player);
            player.stand.AddProfitToWallet(store);
            display.DisplayProfit(player);
            player.stand.UpdateInventory();
        }
        private void ExecuteEndDay()
        {
            Console.WriteLine("HIT ENTER TO START NEXT DAY");
            Console.ReadLine();
        }
        public void DetermineCustomerDemand()
        {
            for (int i = 0; i <= weather.weatherType; i++)
            {
                int customers;
                if (i <= 3)
                {
                    customers = weather.RandomNumberBetween(5, 10);
                    for (int j = 0; j < customers; j++)
                    {
                        customer.Add(new Customer(player));
                    }
                }
                else if (i > 3)
                {
                    customers = weather.RandomNumberBetween(20, 30);
                    for (int j = 0; j < customers; j++)
                    {
                        customer.Add(new Customer(player));
                    }
                }
            }
            for (int i = 67; i < weather.temperature[1] && weather.weatherType != 0; i++)
            {
                customer.Add(new Customer(player));
            }
        }
        public bool PromptProceed()
        {
            Console.WriteLine("PRESS ESC TO REMAKE RECIPE...PRESS ENTER TO CONTINUE TO STORE");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return false;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid Key..\nPlease make choice");
                return PromptProceed();
            }
        }
    }
}
