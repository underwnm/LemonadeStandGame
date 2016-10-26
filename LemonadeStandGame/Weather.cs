using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Weather
    {
        public string[] weather = new string[2];
        public int weatherDemand;
        public int weatherType;
        public int forecastTemperature;
        public int actualTemperature;

        public void GetTomorrowForecast()
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
        }
        public void GetActualWeather()
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
        }
        public int GetWeatherDemand()
        {
            for (int i = 0; i <= weatherType; i++)
            {
                if (i <= 3)
                {
                    int number = RandomNumberBetween(5, 10);
                    weatherDemand = number + weatherDemand;
                }
                else if (i > 3)
                {
                    int number = RandomNumberBetween(20, 30);
                    weatherDemand = number + weatherDemand;
                }
            }
            for (int i = 67; i < actualTemperature; i++)
            {
                weatherDemand++;
            }
            return weatherDemand;
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
    }
}
