using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Day
    {
        List<Customer> customer;
        public Player player;
        public Weather weather;
        public Store store;
        public UserInterface display;

        public Day(Player player)
        {
            this.player = player;
            display = new UserInterface();
            weather = new Weather();
            store = new Store(player);
            customer = new List<Customer>();
        }
        public void ExecuteStartDay()
        {
            weather.GetTomorrowForecast();
            display.DisplayTomorrowForecast(weather);
            player.recipe.GetRecipe();
            ProceedToStore();
            ShopAtStore();
            weather.GetActualWeather();
            display.DisplayActualWeather(weather);
            DetermineCustomerDemand();
            ProceedToStand();
            ExecuteEndDay();
        }
        private void ProceedToStore()
        {
            display.DisplayToStore();
            display.ProceedWithGame();
        }
        private void ShopAtStore()
        {
            bool proceed = true;
            while (proceed)
            {
                display.DisplayItemPrices(store);
                display.DisplayCurrentInventory(player);
                display.DisplayRecipe(player);
                player.stand.CheckRecipeVsInventory();
                proceed = store.ExecuteStore();
                display.ClearScreen();
            }
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
            Console.WriteLine("START NEXT DAY");
            display.ProceedWithGame();
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
            for (int i = 67; i < weather.temperature[1]; i++)
            {
                customer.Add(new Customer(player));
            }
        }
    }
}
