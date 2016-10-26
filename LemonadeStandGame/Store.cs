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
        public Player player;
        private Random random;
        public double[] cost;
        public Store (Player player)
        {
            this.player = player;
            random = new Random();
            cost = new double[4];
            GetItemPrices(); //Lemons, Sugar, Ice, Cups
        }
        public bool ExecuteStore()
        {
            SellLemons();
            SellSugar();
            SellIce();
            SellCup();
            return PromptBuyMore();
        }
        public void SellLemons()
        {
            Console.WriteLine("How many lemons do you want to purchase?");
            int amount = GetUserInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[0];
                player.stand.inventory.AddLemon(amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                SellLemons();
            }
        }
        public void SellSugar()
        {
            Console.WriteLine("How many 4 lb bags of sugar do you want to purchase?");
            int amount = GetUserInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[1];
                amount = ConvertSugarToTablespoons(amount);
                player.stand.inventory.AddSugar(amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                SellSugar();
            }
        }
        public void SellIce()
        {
            Console.WriteLine("How many 5 lb bags of ice do you want to purchase?");
            int amount = GetUserInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[2];
                amount = ConvertIceBagToCups(amount);
                player.stand.inventory.AddIce(amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                SellIce();
            }
        }
        public void SellCup()
        {
            Console.WriteLine("How many 100 pint cups do you want to purchase?");
            int amount = GetUserInput();
            if (player.wallet.CheckWallet(amount))
            {
                player.wallet.money = player.wallet.money - amount * cost[3];
                amount = ConvertCupBagToCups(amount);
                player.stand.inventory.AddCup(amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                SellCup();
            }
        }
        public bool PromptBuyMore()
        {
            Console.WriteLine("PRESS ESC TO EXIT STORE...TO BUY AGAIN AND/OR UPDATE YOUR INVENTORY PRESS ANY OTHER KEY");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return false;
            }                
            else
            {
                return true;
            }
        }
        private int ConvertSugarToTablespoons(int amount)
        {
            amount = amount * 240;
            return amount;
        }
        private int ConvertIceBagToCups(int amount)
        {
            amount = amount * 10;
            return amount;
        }
        private int ConvertCupBagToCups(int amount)
        {
            amount = amount * 50;
            return amount;
        }
        private int GetUserInput()
        {
            int userInput;
            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Number");
                GetUserInput();
            }
            return userInput;
        }
        private void GetItemPrices()
        {
            cost[0] = Math.Round(RandomNumberBetween(.5, .6), 2);
            cost[1] = Math.Round(RandomNumberBetween(1.90, 2.10), 2);
            cost[2] = Math.Round(RandomNumberBetween(1.30, 1.50), 2);
            cost[3] = Math.Round(RandomNumberBetween(2, 2.1), 2);
        }
        private double RandomNumberBetween(double minValue, double maxvalue)
        {
            Random random = new Random();
            double next = random.NextDouble();
            return minValue + (next * (maxvalue - minValue));
        }
    }
}
