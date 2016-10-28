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
        public double[] costOfGoods;
        public int tablespoonsOfSugarPerBag = 240;
        public int cupsOfIcePerBag = 100;
        public int cupsPerBag = 100;
        public Player player;
        private Random random;
        public Store (Player player)
        {
            this.player = player;
            random = new Random();
            costOfGoods = new double[4];
        }
        public void SetItemCosts()
        {
            costOfGoods[0] = Math.Round(RandomNumberBetween(.50, .75), 2);
            costOfGoods[1] = Math.Round(RandomNumberBetween(2.00, 2.40), 2);
            costOfGoods[2] = Math.Round(RandomNumberBetween(2.50, 3.00), 2);
            costOfGoods[3] = Math.Round(RandomNumberBetween(5.00, 5.50), 2);
        }
        public void SellLemons()
        {
            Console.WriteLine("How many lemons do you want to purchase?");
            int amount = GetUserInput();
            double ingredientCost = amount * costOfGoods[0];
            if (player.wallet.CheckWalletForEnoughMoney(ingredientCost))
            {
                player.wallet.cashInWallet = Math.Round(player.wallet.cashInWallet - ingredientCost, 2);
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
            int amount = GetUserInput();
            double ingredientCost = amount * costOfGoods[1];
            if (player.wallet.CheckWalletForEnoughMoney(ingredientCost))
            {
                player.wallet.cashInWallet = Math.Round(player.wallet.cashInWallet - ingredientCost, 2);
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
            int amount = GetUserInput();
            double ingredientCost = amount * costOfGoods[2];
            if (player.wallet.CheckWalletForEnoughMoney(ingredientCost))
            {
                player.wallet.cashInWallet = Math.Round(player.wallet.cashInWallet - ingredientCost, 2);
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
            int amount = GetUserInput();
            double ingredientCost = amount * costOfGoods[3];
            if (player.wallet.CheckWalletForEnoughMoney(ingredientCost))
            {
                player.wallet.cashInWallet = Math.Round(player.wallet.cashInWallet - ingredientCost, 2);
                player.stand.inventory.AddCup(amount * cupsPerBag);
            }
            else
            {
                Console.WriteLine("Insufficient funds in your wallet");
                SellCup();
            }
        }
        public bool BuyAgainOrExit()
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
                Console.WriteLine("Invalid Key...\nPlease make choice");
                return BuyAgainOrExit();
            }
        }
        private int GetUserInput()
        {
            string userInput = Console.ReadLine();
            int userNumber = CheckForValidInput(userInput);
            return userNumber;
        }
        private int CheckForValidInput(string userInput)
        {
            int userNumber = Convert.ToInt16(userInput);
            if (!int.TryParse(userInput, out userNumber))
            {
                Console.WriteLine("*Invalid Number*\nEnter valid number below...");
                return GetUserInput();
            }
            return userNumber;
        }
        private double RandomNumberBetween(double minValue, double maxvalue)
        {
            double next = random.NextDouble();
            return minValue + (next * (maxvalue - minValue));
        }
    }
}
