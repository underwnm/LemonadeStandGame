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
        public static int round = 1;
        public static int numberOfRounds = 8;
        public Game()
        {
            display = new UserInterface();
        }
        public void ExecuteStartOfGame()
        {
            display.DisplayWelcomeTemplate();
            GetPlayerName();
            while (round < numberOfRounds)
            {
                display.DisplayDay(round);
                Day day = new Day(player);
                day.ExecuteDailyRoutine();
                round++;
            }
            display.DisplayEndOfGame(player);
        }
        private string GetInput()
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
