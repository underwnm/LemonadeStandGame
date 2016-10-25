using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Day
    {
        public int dayNumber;
        public Weather weather;
        public RandomEvent randomEvent;
        //public int lemonadeCost;

        public void CheckSupply()
        {
            Console.WriteLine("Let's check you supply...");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");
        }
    }
}
