using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Store
    {
        public double[] cost;
        public int tablespoonsOfSugarPerBag = 240;
        public int cupsOfIcePerBag = 10;
        public int cupsPerBag = 100;
        public Player player;
        private Random random;
        public Store (Player player)
        {
            this.player = player;
            random = new Random();
            cost = new double[4];
        }
        public void SetItemCosts()
        {
            cost[0] = Math.Round(RandomNumberBetween(.5, .6), 2);
            cost[1] = Math.Round(RandomNumberBetween(1.90, 2.10), 2);
            cost[2] = Math.Round(RandomNumberBetween(1.30, 1.50), 2);
            cost[3] = Math.Round(RandomNumberBetween(2, 2.1), 2);
        }
        public void SellLemons()
        {
            Console.WriteLine("How many lemons do you want to purchase?");
            int amount = GetInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[0];
                player.stand.inventory.AddLemon(amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                Console.ReadKey();
                SellLemons();
            }
        }
        public void SellSugar()
        {
            Console.WriteLine("How many bags of sugar do you want to purchase? (each bag has {0} Tbsp)", tablespoonsOfSugarPerBag);
            int amount = GetInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[1];
                player.stand.inventory.AddSugar(amount*tablespoonsOfSugarPerBag);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                Console.ReadKey();
                SellSugar();
            }
        }
        public void SellIce()
        {
            Console.WriteLine("How many bags of ice do you want to purchase? (each bag has {0} cups)", cupsOfIcePerBag);
            int amount = GetInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[2];
                player.stand.inventory.AddIce(amount*cupsOfIcePerBag);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                Console.ReadKey();
                SellIce();
            }
        }
        public void SellCup()
        {
            Console.WriteLine("How many bags of pint sized cups do you want to purchase? (each bag has {0} cups)", cupsPerBag);
            int amount = GetInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[3];
                player.stand.inventory.AddCup(amount * cupsPerBag);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                SellCup();
            }
        }
        public bool PromptBuyMore()
        {
            Console.WriteLine("PRESS ESC TO EXIT STORE...PRESS ENTER TO BUY");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return false;
            }                
            else if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid Key..\nPlease make choice");
                return PromptBuyMore();
            }
        }
        private int GetInput()
        {
            int userInput;
            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                return GetInput();
            }
            return userInput;
        }
        private double RandomNumberBetween(double minValue, double maxvalue)
        {
            double next = random.NextDouble();
            return minValue + (next * (maxvalue - minValue));
        }
    }
}
