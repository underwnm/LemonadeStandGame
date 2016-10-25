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
        double[] cost = new double[3];

        public Day(Player player)
        {
            this.player = player;
        }
        public void ExecuteDay()
        {
            GetItemPrices();
            GoToStore();
        }
        private void GetItemPrices()
        {
            Random random = new Random();
            cost[0] = Math.Round(RandomNumberBetween(1.90, 2.10), 2);
            cost[1] = Math.Round(RandomNumberBetween(2.20, 2.40), 2);
            cost[2] = Math.Round(RandomNumberBetween(1.30, 1.50), 2);
        }
        public void CreateRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.ExecuteMakeRecipe();
        }
        public void GoToStore()
        {
            Store store = new Store(player, cost);
            store.ExecuteStore();
        }
        private double RandomNumberBetween(double minValue, double maxvalue)
        {
            Random random = new Random();
            double next = random.NextDouble();
            return minValue + (next * (maxvalue - minValue));
        }
    }
}
