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
        private Player player;
        bool exit = true;
        double[] cost;
        public Store (Player player, double[] cost)
        {
            this.player = player;
            this.cost = cost;        
        }
        public void ExecuteStore()
        {
            DisplayItemPrices();
            Thread.Sleep(500);
            DisplayInventory();
            Thread.Sleep(500);
            DisplayRecipe();
            Thread.Sleep(500);
            BuyItems();
        }
        private void DisplayItemPrices()
        {
            Console.WriteLine("WELCOME TO {0}'S FAVORITE STORE", player.name);
            Console.WriteLine("");
            Console.WriteLine("These are today's prices");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("4 lb bag of sugar costs {0}", cost[0]);
            Console.WriteLine("1 lb bag of lemons costs {0}", cost[1]);
            Console.WriteLine("4 lb bag of ice costs {0}", cost[2]);
            Console.WriteLine("------------------------------------");
        }
        private void DisplayInventory()
        {
            Inventory inventory = new Inventory(player);
            inventory.ExecuteInventory();
        }
        private void DisplayRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your recipe...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("{0} cups of sugar", player.recipe[0]);
            Console.WriteLine("{0} lemons", player.recipe[1]);
            Console.WriteLine("{0} cups of ice", player.recipe[2]);
            Console.WriteLine("------------------------------------");
        }
        private void BuyItems()
        {
            DisplayBuyChoices();
            int buy = Convert.ToInt16(GetUserInput());
            switch (buy)
            {
                case 1:
                    while (exit)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("How many bags of sugar do you want?");
                        int buySugar = Convert.ToInt16(GetUserInput());
                        if (player.money >= buySugar * cost[0])
                        {
                            player.money = Math.Round((player.money - (buySugar * cost[0])), 2);
                            player.ingredients[0] = buySugar*15 + player.ingredients[0];
                            Console.WriteLine("");
                            Console.WriteLine("You just purchased {0}, 4 lb bags of sugar, and now have {1} cups of sugar in your supply", buySugar, player.ingredients[0]);
                            Console.WriteLine("You have ${0} cash left", player.money);
                            Console.WriteLine("");
                            Console.WriteLine("Would you like to buy anything else? Yes or No?");
                            string buyMore = GetUserInput();
                            if (buyMore == "YES")
                            {
                                Console.Clear();
                                ExecuteStore();
                            }
                            else
                            {
                                Console.Clear();
                                exit = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Not enough money...Press key to continue...");
                            Console.ReadLine();
                        }
                    }
                    break;
                case 2:
                    while (exit)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("How many bags of lemons do you want?");
                        int buyLemons = Convert.ToInt16(GetUserInput());
                        if (player.money >= buyLemons * cost[1])
                        {
                            player.money = Math.Round((player.money - (buyLemons * cost[1])), 2);
                            player.ingredients[1] = buyLemons*15 + player.ingredients[1];
                            Console.WriteLine("");
                            Console.WriteLine("You just purchased {0}, 1 lb bags of lemons, and have {1} lemons in your supply", buyLemons, player.ingredients[1]);
                            Console.WriteLine("You have ${0} cash left", player.money);
                            Console.WriteLine("");
                            Console.WriteLine("Would you like to buy anything else? Yes or No?");
                            string buyMore = GetUserInput();
                            if (buyMore == "YES")
                            {
                                Console.Clear();
                                ExecuteStore();
                            }
                            else
                            {
                                exit = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Not enough money");
                            Console.ReadLine();
                        }
                    }
                    break;
                case 3:
                    while (exit)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("How many bags of ice do you want?");
                        int buyIce = Convert.ToInt16(GetUserInput());
                        if (player.money >= buyIce * cost[2])
                        {
                            player.money = Math.Round((player.money - (buyIce * cost[2])), 2);
                            player.ingredients[2] = buyIce*15 + player.ingredients[2];
                            Console.WriteLine("");
                            Console.WriteLine("You just purchased {0}, 4 lb bags of ice, and have {1} cups of ice in your supply", buyIce, player.ingredients[2]);
                            Console.WriteLine("You have ${0} cash left", player.money);
                            Console.WriteLine("");
                            Console.WriteLine("Would you like to buy anything else? Yes or No?");
                            string buyMore = GetUserInput();
                            if (buyMore == "YES")
                            {
                                Console.Clear();
                                ExecuteStore();
                            }
                            else
                            {
                                exit = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Not enough money");
                            Console.ReadLine();
                        }
                    }
                    break;
                case 4:
                    exit = false;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("INVALID INPUT TRY AGAIN");
                    Console.ReadKey();
                    Console.Clear();
                    ExecuteStore();
                    break;
            }
        }
        private void DisplayBuyChoices()
        {
            Console.WriteLine("");
            Console.WriteLine("Select which product you want to purchase...");
            Console.WriteLine("1. 4 lb bag of sugar (15 cups per bag)");
            Console.WriteLine("2. 2 lb bag of lemons (15 lemons per bag)");
            Console.WriteLine("3. 4 lb bag of ice (15 cups per bag)");
            Console.WriteLine("4. Buy Nothing");
        }
        private string GetUserInput()
        {
            string userInput = Console.ReadLine().ToUpper();
            return userInput;
        }
    }
}
