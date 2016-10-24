using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class UserInterface
    {
        public void DisplayMenuMessage()
        {
            Console.WriteLine("HI! \tWELCOME TO LEMONADE STAND! IN THIS GAME");
            Console.WriteLine("YOU WILL BE IN CHARGE OF RUNNG YOUR OWN LEMONADE");
            Console.WriteLine("STAND. YOU CAN COMPETE WITH ANY AMOUNT OF PEOPLE");
            Console.WriteLine("THAT YOU WANT. THE GOAL IS TO MAKE THE HIGHEST");
            Console.WriteLine("PROFIT. SALES WILL BE AFFECTED BY YOUR RECIPE,");
            Console.WriteLine("WEATHER, AND PRICE.");
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
            Console.WriteLine("TO MANAGE YOUR LEMONADE STAND, YOU WILL NEED TO");
            Console.WriteLine("THESE DECISIONS EVERY DAY.");
            Console.WriteLine("1. THE AMOUNT OF SUGAR, ICE, AND LEMONS IN YOUR RECIPE");
            Console.WriteLine("2. WHAT PRICE TO SELL EACH GLASS FOR");
            Console.WriteLine("YOU WILL BEGIN WITH $20.00 CASH. THEN CREATE A RECIPE");
            Console.WriteLine("WITH SUGAR, ICE, AND LEMONS (WATER IF FREE).");
            Console.WriteLine("YOUR COST TO MAKE LEMONADE WILL DEPEND ON YOUR RECIPE.");
            Console.WriteLine("YOUR EXPENSES ARE THE SUM OF THE COST OF THE INGREDIANTS");
            Console.WriteLine("USED IN MAKING YOUR RECIPE.");
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
    }
}
