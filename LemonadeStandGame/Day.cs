using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Day
    {
        Player player;
        Weather weather = new Weather();
        double[] cost = new double[3]; //Sugar, Lemons, Ice

        public Day(Player player)
        {
            this.player = player;
        }
        public void ExecuteDay()
        {
            weather.GetTomorrowForecast();
            CreateRecipe();
            GetItemPrices();
            GoToStore();
            weather.GetActualWeather();
            Console.WriteLine("START NEXT DAY");
            ProceedWithGame();
        }
        private void GetItemPrices()
        {
            Random random = new Random();
            cost[0] = Math.Round(RandomNumberBetween(1.90, 2.10), 2);
            cost[1] = Math.Round(RandomNumberBetween(.5, .6), 2);
            cost[2] = Math.Round(RandomNumberBetween(1.30, 1.50), 2);
        }
        public void GoToStore()
        {
            DisplayToStore();
            ProceedWithGame();
            Store store = new Store(player, cost);
            store.ExecuteStore();
        }
        public void DisplayToStore()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("    LETS GO TO THE STORE FOR YOUR RECIPE INGREDIENTS");
            Console.WriteLine("----------------------------------------------------------");
        }
        public void CreateRecipe()
        {
            Recipe recipe = new Recipe(player);
            recipe.GetRecipe();
        }
        private double RandomNumberBetween(double minValue, double maxvalue)
        {
            Random random = new Random();
            double next = random.NextDouble();
            return minValue + (next * (maxvalue - minValue));
        }
        private void ProceedWithGame()
        {
            Console.WriteLine("");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
