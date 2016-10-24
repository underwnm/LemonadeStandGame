using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Weather
    {
        private string name;
        public Weather Sunny = new Weather("Sunny");

        private Weather(string name)
        {
            this.name = name; 
        }
        public void GetWeatherForecast()
        {

        }
        public void GetActualWeather()
        {

        }
    }
}
