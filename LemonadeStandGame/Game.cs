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
        Store store;
        Day day;
        int currentDay = 1;
        public Game()
        {
            display = new UserInterface();
        }
        public void ExecuteStartOfGame()
        {
            display.DisplayWelcomeTemplate();
            GetPlayerName();
            while (currentDay < 8)
            {
                display.DisplayDay(currentDay);
                CreateStorePrices();
                day = new Day(player, store);
                day.ExecuteStartDay();
                currentDay++;
            }
            display.DisplayEndOfGame(player);
        }
        private void CreateStorePrices()
        {
            store = new Store(player);
            store.SetItemCosts();
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
