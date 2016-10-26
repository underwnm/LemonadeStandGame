using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Weather
    {
        string[] weather = new string[2];
        public int weatherDemand;
        public int weatherType;
        public int forecastTemperature;
        public int actualTemperature;

        public string[] GetTomorrowForecast()
        {
            weatherType = GetRandomNumber();
            GetTemperature(weatherType);
            weather[1] = forecastTemperature.ToString();            
            switch (weatherType)
            {
                case 0:
                    weather[0] = "Showers";
                    break;
                case 1:
                    weather[0] = "Cloudy";
                    break;
                case 2:
                    weather[0] = "Partly Cloudy";
                    break;
                case 3:
                    weather[0] = "Mostly Sunny";
                    break;
                case 4:
                    weather[0] = "Sunny";
                    break;
            }
            return weather;
        }
        public string[] GetActualWeather()
        {
            switch (weatherType)
            {
                case 0:
                    weatherDemand = 5;
                    weather[1] = actualTemperature.ToString();
                    break;
                case 1:
                    weatherDemand = 10;
                    weather[1] = actualTemperature.ToString();
                    break;
                case 2:
                    weatherDemand = 15;
                    weather[1] = actualTemperature.ToString();
                    break;
                case 3:
                    weatherDemand = 30;
                    weather[1] = actualTemperature.ToString();
                    break;
                case 4:
                    weatherDemand = 50;
                    weather[1] = actualTemperature.ToString();
                    break;
            }
            return weather;
        }
        private void GetTemperature(int weatherType)
        {
            switch (weatherType)
            {
                case 0:
                    forecastTemperature = RandomNumberBetween(70, 90);
                    actualTemperature = RandomNumberBetween(forecastTemperature - 3, forecastTemperature + 3);
                    break;
                case 1:
                    forecastTemperature = RandomNumberBetween(70, 75);
                    actualTemperature = RandomNumberBetween(forecastTemperature - 3, forecastTemperature + 3);
                    break;
                case 2:
                    forecastTemperature = RandomNumberBetween(75, 80);
                    actualTemperature = RandomNumberBetween(forecastTemperature - 3, forecastTemperature + 3);
                    break;
                case 3:
                    forecastTemperature = RandomNumberBetween(80, 85);
                    actualTemperature = RandomNumberBetween(forecastTemperature - 3, forecastTemperature + 3);
                    break;
                case 4:
                    forecastTemperature = RandomNumberBetween(85, 90);
                    actualTemperature = RandomNumberBetween(forecastTemperature - 3, forecastTemperature + 3);
                    break;
            }
        }
        private int GetRandomNumber()
        {
            Random random = new Random();
            int number = random.Next(0, 5);
            return number;
        }
        private int RandomNumberBetween(int minValue, int maxvalue)
        {
            Random random = new Random();
            double multiplier = random.NextDouble();
            int temperatue = Convert.ToInt16(minValue + (multiplier * (maxvalue - minValue)));
            return temperatue;
        }
        public void GetWeatherDemand()
        {
            for (int i = 67; i < actualTemperature; i++)
            {
                weatherDemand++;
            }
        }
    }
}
