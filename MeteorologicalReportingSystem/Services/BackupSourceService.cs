using MeteorologicalReportingSystem.Models;
using System.Collections.Generic;
using System.Linq;

using static MeteorologicalReportingSystem.Data.CityWeatherInformation;

namespace MeteorologicalReportingSystem.Services
{
    public class BackupSourceService : ISourceService
    {
        private ICollection<WeatherInfoViewModel> CityWeatherInfo;

        public BackupSourceService()
        {
            CityWeatherInfo = new List<WeatherInfoViewModel>();
        }

        public string SecurityKey { get { return "mySecretBackupSourceKey"; } }

        public void FillSourceCollection()
        {
            List<WeatherInfoViewModel> CityInfo = (List<WeatherInfoViewModel>)BackupSourceCollection;

            foreach (var city in CityInfo)
            {
                CityWeatherInfo.Add(city);
            }
        }

        public WeatherInfoViewModel GetCurrentCity(string name)
        {
            var currentCity = CityWeatherInfo.Where(c => c.City == name).FirstOrDefault();

            return currentCity;
        }
    }
}
