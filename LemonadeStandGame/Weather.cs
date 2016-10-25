using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Weather
    {
        //int[] weatherType = new int[5]; // "Showers", "Partly Cloudy", "Cloudy", "Mostly Sunny", "Sunny"
        double[] weatherDemand = new double[5];
        int weatherType;
        string weather;
        int forecastTemperature;
        int actualTemperature;

        public void GetTomorrowForecast()
        {
            weatherType = GetRandomNumber();
            GetTemperature(weatherType);
            switch (weatherType)
            {
                case 0:
                    weather = "Showers";
                    DisplayTomorrowForecast(weather, forecastTemperature);
                    break;
                case 1:
                    weather = "Cloudy";
                    DisplayTomorrowForecast(weather, forecastTemperature);
                    break;
                case 2:
                    weather = "Partly Cloudy";
                    DisplayTomorrowForecast(weather, forecastTemperature);
                    break;
                case 3:
                    weather = "Mostly Sunny";
                    DisplayTomorrowForecast(weather, forecastTemperature);
                    break;
                case 4:
                    weather = "Sunny";
                    DisplayTomorrowForecast(weather, forecastTemperature);
                    break;
            }
        }
        private void DisplayTomorrowForecast(string weatherType, int temperature)
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(" Tomororw's forecast calls for {0} and a High of {1}°", weatherType, temperature);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");
        }
        public void GetActualWeather()
        {
            switch (weatherType)
            {
                case 0:
                    weatherDemand[0] = .0;
                    DisplayActualWeather(weather, actualTemperature);
                    break;
                case 1:
                    weatherDemand[1] = .25;
                    DisplayActualWeather(weather, actualTemperature);
                    break;
                case 2:
                    weatherDemand[2] = .5;
                    DisplayActualWeather(weather, actualTemperature);
                    break;
                case 3:
                    weatherDemand[3] = .75;
                    DisplayActualWeather(weather, actualTemperature);
                    break;
                case 4:
                    weatherDemand[4] = 1;
                    DisplayActualWeather(weather, actualTemperature);
                    break;
            }
        }
        private void DisplayActualWeather(string actualWeather, int actualTemperature)
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("     Today is {0} and a High of {1}°", actualWeather, actualTemperature);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");
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
