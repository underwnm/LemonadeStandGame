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

        public void ExecuteGame()
        {
            output.DisplayMenuMessage();
            output.DisplayMenuNewGame();
            Console.ReadLine();
            output.DisplayMenuNumberOfPeople();
            Console.ReadLine();
            output.ClearScreen();
            output.DisplayMenuInstructions();
            output.DisplayContinueOrExit();
            Console.ReadLine();
            output.ClearScreen();
        }
    }
}
