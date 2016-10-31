using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGame
{
    class Weather
    {
        Random random;
        public string[] weather;
        public int[] temperature;
        public int weatherType;

        public Weather()
        {
            random = new Random();
            temperature = new int[2]; 
            weather = new string[2];
        }
        public void GetTomorrowForecast()
        {
            weatherType = GetRandomNumber();
            GetTemperature(weatherType);
            weather[1] = temperature[0].ToString();            
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
                    weather[1] = temperature[1].ToString();
                    break;
                case 1:
                    weather[1] = temperature[1].ToString();
                    break;
                case 2:
                    weather[1] = temperature[1].ToString();
                    break;
                case 3:
                    weather[1] = temperature[1].ToString();
                    break;
                case 4:
                    weather[1] = temperature[1].ToString();
                    break;
            }
        }
        private void GetTemperature(int weatherType)
        {
            switch (weatherType)
            {
                case 0:
                    temperature[0] = RandomNumberBetween(70, 90);
                    temperature[1] = RandomNumberBetween(temperature[0] - 3, temperature[0] + 3);
                    break;
                case 1:
                    temperature[0] = RandomNumberBetween(70, 75);
                    temperature[1] = RandomNumberBetween(temperature[0] - 3, temperature[0] + 3);
                    break;
                case 2:
                    temperature[0] = RandomNumberBetween(75, 80);
                    temperature[1] = RandomNumberBetween(temperature[0] - 3, temperature[0] + 3);
                    break;
                case 3:
                    temperature[0] = RandomNumberBetween(80, 85);
                    temperature[1] = RandomNumberBetween(temperature[0] - 3, temperature[0] + 3);
                    break;
                case 4:
                    temperature[0] = RandomNumberBetween(85, 90);
                    temperature[1] = RandomNumberBetween(temperature[0] - 3, temperature[0] + 3);
                    break;
            }
        }
        private int GetRandomNumber()
        {
            int number = random.Next(0, 5);
            return number;
        }
        private int RandomNumberBetween(int minValue, int maxvalue)
        {
            double multiplier = random.NextDouble();
            int number = Convert.ToInt16(minValue + (multiplier * (maxvalue - minValue)));
            return number;
        }
    }
}
