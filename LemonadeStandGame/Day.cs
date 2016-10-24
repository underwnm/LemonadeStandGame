using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Day
    {
        public int number;
        public Weather weather;
        public RandomEvent randomEvent;
        public int lemonadeCost;

        public Day(int number, Weather weather, RandomEvent randomEvent)
        {
            this.number = number;
            this.weather = weather;
            this.randomEvent = randomEvent;
        }
    }
}
