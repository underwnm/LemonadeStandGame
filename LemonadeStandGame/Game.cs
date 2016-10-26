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
        int currentDay = 0;
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
                day = new Day(player);
                day.ExecuteDay();
                currentDay++;
            }
        }
        private void ExecuteGameWelcome()
        {
            display.DisplayMenuMessage();
            display.AddSpace();
            display.DisplayMenuNewGame();
            GetUserInput();
            display.AddSpace();
            display.DisplayMenuNumberOfPeople();
            GetUserInput();
            display.ClearScreen();
            display.DisplayMenuInstructions();
            display.AddSpace();
            display.DisplayContinueOrExit();
            GetUserInput();
            display.ClearScreen();
        }
        private string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
        private void GetPlayerName()
        {
            Console.WriteLine("Enter the owner of the lemonade stand");
            player.name = Console.ReadLine().ToUpper();
            Console.Clear();
        }
    }
}
