using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Player
    {
        public string name;
        public double money = 20.00;
        public int[] ingredients = new int[3]; //Sugar, Lemons, Ice
        public int[] recipe = new int[3]; //#Sugar, #Lemons, #Ice
        public void GetPlayerName()
        {
            Console.WriteLine("Enter the owner of the lemonade stand");
            name = Console.ReadLine().ToUpper();
            Console.Clear();
        }
    }
}
