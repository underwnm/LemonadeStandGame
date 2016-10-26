using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Player
    {
        public string name;
        public double pintPrice;
        public double dailyProfit;
        public Wallet wallet;
        public Recipe recipe;
        public Stand stand;

        public Player(string Name)
        {
            name = Name;
            wallet = new Wallet();
            recipe = new Recipe();
            stand = new Stand();
        }
        public void GetPintPrice()
        {
            Console.WriteLine("Enter the price per pint of lemonade for the day.");
            pintPrice = GetUserInput();
        }
        private double GetUserInput()
        {
            double userInput;
            if (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                GetUserInput();
            }
            return userInput;
        }
    }
}
