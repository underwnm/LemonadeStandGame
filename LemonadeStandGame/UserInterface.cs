using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class UserInterface
    {
        public Player player;
        public Day day;

        public void DisplayMenuMessage()
        {
            Console.WriteLine("WELCOME TO LEMONADE STAND! THIS IS A GAME TO SEE WHO CAN GET THE HIGHEST SCORE!\n");
            Thread.Sleep(500);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("\tIN THIS GAME YOU WILL BE IN CHARGE OF RUNNING YOUR OWN LEMONADE");
            Console.WriteLine("\tSTAND. YOU CAN COMPETE WITH ANY AMOUNT OF PEOPLE THAT YOU WANT.");
            Console.WriteLine("\tTHE GOAL IS TO MAKE THE HIGHEST PROFIT. SALES WILL BE AFFECTED BY");
            Console.WriteLine("\tYOUR RECIPE, THE WEATHER, AND THE PER GLASS PRICE OF YOUR RECIPE.");
            Thread.Sleep(500);
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public void DisplayMenuNewGame()
        {
            Console.WriteLine("ARE YOU READY TO START A NEW GAME? (YES OR NO)");
            Console.WriteLine("TYPE YOUR ANSWER AND HIT ENTER");
        }
        public void DisplayMenuNumberOfPeople()
        {
            Console.WriteLine("HOW MANY PEOPLE WILL BE PLAYING?");
            Console.WriteLine("TYPE YOUR ANSWER AND HIT ENTER");
        }
        public void DisplayMenuInstructions()
        {
            Console.WriteLine("TO MANAGE YOUR LEMONADE STAND, YOU WILL NEED TO MAKE THESE DECISIONS EVERY DAY.\n");
            Console.WriteLine("\t\t1. THE AMOUNT OF SUGAR, ICE, AND LEMONS");
            Console.WriteLine("\t\t2. WHAT PRICE TO SELL EACH GLASS FOR\n");
            Console.WriteLine("\tYOU WILL BEGIN WITH A TOTAL OF $20.00 CASH. YOU THEN");
            Console.WriteLine("\tCREATE A RECIPE WITH SUGAR, LEMONS, AND ICE. YOUR TOTAL COST");
            Console.WriteLine("\tTO MAKE LEMONADE WILL DEPEND ON YOUR RECIPE. YOUR EXPENSES");
            Console.WriteLine("\tARE THE SUM OF THE INGREDIANT COSTS IN YOUR RECIPE.");
        }
        public void DisplayDay(int day)
        {
            Console.WriteLine("On Day {0}", day);
        }
        public void DisplayDayPlayerLemonadeStand(string playerName)
        {
            Console.WriteLine("{0}'S LEMONADE STAND", playerName);
        }
        public void DisplayDayPlayerAssets(int dollars, int cents)
        {
            Console.WriteLine("ASSETS ${0}.{0}", dollars, cents);
        }
        public void DisplayContinueOrExit()
        {
            Console.WriteLine("PRESS A KEY TO CONTINUE, ESC TO END. . .");
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
        public void AddSpace()
        {
            Console.WriteLine();
        }

        private void DisplayCurrentInventory()
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your supply...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("You have {0} lemons", player.stand.inventory.lemons.Count());
            Console.WriteLine("You have {0} tablespoons of sugar", player.stand.inventory.sugar.Count());
            Console.WriteLine("You have {0} cups of ice", player.stand.inventory.ice.Count());
            Console.WriteLine("You have {0} pint sized cups", player.stand.inventory.cups.Count());
            Console.WriteLine("You have ${0} available in cash", player.wallet.cash);
            Console.WriteLine("------------------------------------");
        }
        private void DisplayItemPrices()
        {
            Console.WriteLine("WELCOME TO {0}'S FAVORITE STORE", player.name);
            Console.WriteLine("");
            Console.WriteLine("These are today's prices");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1 lemon costs {0}", day.store.cost[0]);
            Console.WriteLine("4 lb bag of sugar costs {0}", day.store.cost[1]);
            Console.WriteLine("5 lb bag of ice costs {0}", day.store.cost[2]);
            Console.WriteLine("50 pack of pint sized plastic cups costs {0}", day.store.cost[3]);
            Console.WriteLine("------------------------------------");
        }
        private void DisplayRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your recipe...");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("{0} lemons", player.recipe.ingredients[0]);
            Console.WriteLine("{0} tablespoon of sugar", player.recipe.ingredients[1]);
            Console.WriteLine("{0} cups of ice", player.recipe.ingredients[2]);
            Console.WriteLine("------------------------------------");
        }
        private void DisplayBuyChoices()
        {
            Console.WriteLine("");
            Console.WriteLine("Select which product you want to purchase...");
            Console.WriteLine("1. Lemons");
            Console.WriteLine("2. 4 lb bag of sugar (240 tablespoons per bag)");
            Console.WriteLine("3. 5 lb bag of ice (10 cups per bag)");
            Console.WriteLine("4. Buy Nothing");
        }
    }
}
