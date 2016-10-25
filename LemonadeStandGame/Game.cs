using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Game
    {
        UserInterface output = new UserInterface();

        public void ExecuteStartOfGame()
        {
            output.DisplayMenuMessage();
            output.AddSpace();
            output.DisplayMenuNewGame();
            GetUserInput();
            output.AddSpace();
            output.DisplayMenuNumberOfPeople();
            GetUserInput();
            output.ClearScreen();
            output.DisplayMenuInstructions();
            output.AddSpace();
            output.DisplayContinueOrExit();
            GetUserInput();
            output.ClearScreen();
        }
        public string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
