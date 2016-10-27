using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Game
    {
        UserInterface display;
        Player player;
        Day day;
        int currentDay = 1;
        public Game()
        {
            display = new UserInterface();
        }
        public void ExecuteStartOfGame()
        {
            ExecuteGameWelcome();
            GetPlayerName();

            while (currentDay < 8)
            {
                display.DisplayDay(currentDay);
                day = new Day(player);
                day.ExecuteStartDay();
                currentDay++;
            }
        }
        private void ExecuteGameWelcome()
        {
            display.DisplayMenuMessage();
            display.AddSpace();
            display.DisplayMenuInstructions();
            display.AddSpace();
            display.DisplayContinueOrExit();
            GetUserInput();
            display.ClearScreen();
            //display.DisplayMenuNumberOfPeople();
            //GetUserInput();
        }
        private string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
        private void GetPlayerName()
        {
            Console.WriteLine("Enter the owner of the lemonade stand");
            string name = Console.ReadLine().ToUpper();
            player = new Player(name);
            Console.Clear();
        }
    }
}
