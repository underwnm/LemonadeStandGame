using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Weather
    {
        int[] weatherType = new int[5]; // "Showers", "Partly Cloudy", "Cloudy", "Mostly Sunny", "Sunny"

        public void GetWeatherForecast()
        {
            int weatherType = GetRandomNumber();
            string temperatue = GetTemperature(weatherType);
            switch (weatherType)
            {
                case 0:
                    DisplayForecast("Showers", temperatue);
                    break;
                case 1:
                    DisplayForecast("Cloudy", temperatue);
                    break;
                case 2:
                    DisplayForecast("Partly Cloudy", temperatue);
                    break;
                case 3:
                    DisplayForecast("Mostly Sunny", temperatue);
                    break;
                case 4:
                    DisplayForecast("Sunny", temperatue);
                    break;
            }
        }
        private void DisplayForecast(string weatherType, string temperature)
        {
            Console.WriteLine("Tomororw's forecast calls for {0} and a High of {1}°", weatherType, temperature);
        }
        private string GetTemperature(int type)
        {
            int temperature = 1;
            switch (type)
            {
                case 0:
                    temperature = RandomNumberBetween(60, 90);
                    break;
                case 1:
                    temperature = RandomNumberBetween(60, 69);
                    break;
                case 2:
                    temperature = RandomNumberBetween(70, 79);
                    break;
                case 3:
                    temperature = RandomNumberBetween(80, 85);
                    break;
                case 4:
                    temperature = RandomNumberBetween(86, 91);
                    break;
            }
            return temperature.ToString();
        }
        public void GetActualWeather()
        {

        }
        public void CalculateChanceOfRain()
        {

        }
        private int GetRandomNumber()
        {
            Random random = new Random();
            int next = random.Next(0, 5);
            return next;
        }
        private int RandomNumberBetween(int minValue, int maxvalue)
        {
            Random random = new Random();
            double multiplier = random.NextDouble();
            int results = Convert.ToInt16(minValue + (multiplier * (maxvalue - minValue)));
            return results;
        }
    }
}
