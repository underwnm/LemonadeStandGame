using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Customer
    {
        Random random;
        public Customer()
        {
            random = new Random();
        }
        public bool CheckBuyLemonade(Player player)
        {
            if (CheckTastePreference(player) && CheckPrice(player))
            {
                player.dailyProfit = player.dailyProfit + player.pintPrice;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckPrice(Player player)
        {
            double HighPrice = RandomNumberBetween(0, 4);
            if (player.pintPrice < HighPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckTastePreference(Player player)
        {
            double chanceToBuy;
            double tastePreference = RandomNumberBetween(2, 8);
            if (player.recipe.ingredients[0] >= tastePreference)
            {
                chanceToBuy = .4;
            }
            else
            {
                chanceToBuy = .25;
            }
            tastePreference = RandomNumberBetween(25, 45);
            if (player.recipe.ingredients[1] >= tastePreference)
            {
                chanceToBuy = .4;
            }
            else
            {
                chanceToBuy = .25;
            }
            tastePreference = RandomNumberBetween(1, 3);
            if (player.recipe.ingredients[2] >= tastePreference)
            {
                chanceToBuy = .4;
            }
            else
            {
                chanceToBuy = .25;
            }
            if (chanceToBuy >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        private double RandomNumberBetween(int minValue, int maxvalue)
        {
            Random random = new Random();
            double multiplier = random.NextDouble();
            double number = Convert.ToInt16(minValue + (multiplier * (maxvalue - minValue)));
            return number;
        }
    }
}
