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
        List<string> type = new List<string>() { "Rainy", "Cold", "Cloudy", "Sunny", "Hot"};

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
        public void CalculateChanceOfRain()
        {

        }
    }
}
