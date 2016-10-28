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
        public Random random;
 

        public Day(Player player)
        {
            this.player = player;
            store = new Store(player);
            random = new Random();
            display = new UserInterface();
            weather = new Weather();
            customer = new List<Customer>();
        }
        public void ExecuteDailyRoutine()
        {
            weather.GetTomorrowForecast();
            CreateDailyRecipe();
            ExecuteDailyStoreRoutine();
            weather.GetActualWeather();
            display.DisplayActualWeather(weather);
            GetDailyCustomerAmount();
            ExecuteDailyStandRoutine();
            GetProceedToNextDay();
        }
        private void CreateDailyRecipe()
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
                proceed = AskOptionToRemakeRecipe();
            }            
        }
        private void ExecuteDailyStoreRoutine()
        {
            display.DisplayStoreTemplate(store, player);
            bool proceed = store.BuyAgainOrExit();
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
                proceed = store.BuyAgainOrExit();
            }
            display.ClearScreen();
        }
        private void ExecuteDailyStandRoutine()
        {
            display.DisplayAtStand();
            player.stand.CheckRecipeVsInventory();
            display.DisplayMaxPitchersPerIngredients(player);
            display.DisplayHowManyPitchers();
            player.stand.GetNumberOfPitchersMade();
            display.DisplayHowMuchPerPint();
            player.stand.GetPintPrice();
            player.stand.CalculateNumberOfCustomerSales(customer, weather);
            display.DisplayPintsSold(player);
            player.stand.AddProfitToWallet(store);
            display.DisplayProfit(player);
            player.stand.UpdateInventory();
        }
        private void GetDailyCustomerAmount()
        {
            for (int i = 0; i <= weather.weatherType; i++)
            {
                int customers;
                if (i <= 3)
                {
                    customers = weather.RandomNumberBetween(5, 10);
                    for (int j = 0; j < customers; j++)
                    {
                        customer.Add(new Customer(player, random));
                    }
                }
                else if (i > 3)
                {
                    customers = weather.RandomNumberBetween(30, 35);
                    for (int j = 0; j < customers; j++)
                    {
                        customer.Add(new Customer(player, random));
                    }
                }
            }
            for (int i = 67; i < weather.temperature[1]; i++)
            {
                customer.Add(new Customer(player, random));
            }
        }
        private bool AskOptionToRemakeRecipe()
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
                return AskOptionToRemakeRecipe();
            }
        }
        public void GetProceedToNextDay()
        {
            Console.WriteLine("HIT ENTER TO START NEXT DAY");
            Console.ReadLine();
        }
    }
}
