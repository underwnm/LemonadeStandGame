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
        public Customer(Player player)
        {
            random = new Random();
            this.player = player;
        }
        public bool CheckBuyLemonade()
        {
            if (CheckTastePreference() && CheckPrice())
            {                               
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckPrice()
        {
            double HighPrice = RandomNumberBetween(0, 4);
            if (player.stand.pintPrice < HighPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckTastePreference()
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
                chanceToBuy = .4 + chanceToBuy;
            }
            else
            {
                chanceToBuy = .25 + chanceToBuy;
            }
            tastePreference = RandomNumberBetween(1, 3);
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
        private double RandomNumberBetween(int minValue, int maxvalue)
        {
            Random random = new Random();
            double multiplier = random.NextDouble();
            double number = minValue + (multiplier * (maxvalue - minValue));
            return number;
        }
    }
}
