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
        Player player;
        public Customer(Player player, Random random)
        {
            this.random = random;
            this.player = player;
        }
        public bool CheckBuyLemonade(Weather weather)
        {
            if (CheckPrice(weather) && CheckTastePreference())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckPrice(Weather weather)
        {
            if (weather.weatherType <= 2)
            {
                double HighPrice = RandomNumberBetween(0, 2);
                if (player.stand.pintPriceToday < HighPrice)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (weather.weatherType > 2)
            {
                double HighPrice = RandomNumberBetween(1, 2);
                if (player.stand.pintPriceToday < HighPrice)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CheckTastePreference()
        {
            double chanceToBuy;
            double tastePreference = RandomNumberBetween(1, 8);
            if (player.recipe.ingredients[0] >= tastePreference)
            {
                chanceToBuy = .4;
            }
            else
            {
                chanceToBuy = .25;
            }
            tastePreference = RandomNumberBetween(1, 45);
            if (player.recipe.ingredients[1] >= tastePreference)
            {
                chanceToBuy = .4 + chanceToBuy;
            }
            else
            {
                chanceToBuy = .25 + chanceToBuy;
            }
            tastePreference = RandomNumberBetween(1, 5);
            if (player.recipe.ingredients[2] >= tastePreference)
            {
                chanceToBuy = .4 + chanceToBuy;
            }
            else
            {
                chanceToBuy = .25 + chanceToBuy;
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
        private double RandomNumberBetween(int minValue, int maxValue)
        {
            double multiplier = random.NextDouble();
            double number = minValue + (multiplier * (maxValue - minValue));
            return number;
        }
    }
}
