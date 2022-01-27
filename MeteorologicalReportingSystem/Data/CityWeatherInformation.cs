using MeteorologicalReportingSystem.Models;
using System.Collections.Generic;


namespace MeteorologicalReportingSystem.Data
{
    public static class CityWeatherInformation
    {
        public static ICollection<WeatherInfoViewModel> SourceCollection = new List<WeatherInfoViewModel>
        {
            new WeatherInfoViewModel{ City="New York", Temperature = 30, Pressure = 15.2},
            new WeatherInfoViewModel{ City="Toronto", Temperature = 0, Pressure = 12.2},
            new WeatherInfoViewModel{ City="Rome", Temperature = 35, Pressure = 15.6},
            new WeatherInfoViewModel{ City="Berlin", Temperature = 27, Pressure = 14.3},
            new WeatherInfoViewModel{ City="Sofia", Temperature = 26, Pressure = 12.6},
            new WeatherInfoViewModel{ City="Paris", Temperature = 32, Pressure = 13.2},
            new WeatherInfoViewModel{ City="London", Temperature = 18, Pressure = 17.1},
            new WeatherInfoViewModel{ City="Tokyo", Temperature = 32, Pressure = 16.7},
            new WeatherInfoViewModel{ City="Madrid", Temperature = 35, Pressure = 15.8},
            new WeatherInfoViewModel{ City="Dubai", Temperature = 38, Pressure = 15.3}
        };

        public static ICollection<WeatherInfoViewModel> BackupSourceCollection = new List<WeatherInfoViewModel>
        {
            new WeatherInfoViewModel{ City="New York", Temperature = 30, Pressure = 15.2},
            new WeatherInfoViewModel{ City="Toronto", Temperature = 0, Pressure = 12.2},
            new WeatherInfoViewModel{ City="Los Angelis", Temperature = 40, Pressure = 14.6},
            new WeatherInfoViewModel{ City="Chicago", Temperature = 28, Pressure = 13.3},
            new WeatherInfoViewModel{ City="Sydney", Temperature = 39, Pressure = 11.6},
            new WeatherInfoViewModel{ City="Athens", Temperature = 32, Pressure = 13.2},
            new WeatherInfoViewModel{ City="Moscow", Temperature = 5, Pressure = 18.1},
            new WeatherInfoViewModel{ City="Buenos Aires", Temperature = 26, Pressure = 14.7},
            new WeatherInfoViewModel{ City="Hong Kong", Temperature = 31, Pressure = 12.8},
            new WeatherInfoViewModel{ City="Rio De Janeiro", Temperature = 38, Pressure = 15.3}
        };
    }
}
