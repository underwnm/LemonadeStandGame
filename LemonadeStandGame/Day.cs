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
        public Customer customers;
        public Weather weather;
        public Store store;

        public Day(Player player)
        {
            this.player = player;
        }
        public void ExecuteDay()
        {
            weather.GetTomorrowForecast();
            CreateRecipe();
            GoToStore();
            weather.GetActualWeather();
            Console.WriteLine("START NEXT DAY");
            ProceedWithGame();
        }
        public void GoToStore()
        {
            DisplayToStore();
            ProceedWithGame();
            Store store = new Store(player);
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
            Recipe recipe = new Recipe();
            recipe.GetRecipe();
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
