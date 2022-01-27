using MeteorologicalReportingSystem.Models;
using System.Collections.Generic;
using System.Linq;

using static MeteorologicalReportingSystem.Data.CityWeatherInformation;


namespace MeteorologicalReportingSystem.Services
{
    public class SourceService:ISourceService
    {
        private ICollection<WeatherInfoViewModel> CityWeatherInfo;
        public SourceService()
        {
            CityWeatherInfo = new List<WeatherInfoViewModel>();
        }

        public string SecurityKey { get { return "mySecretSourceKey"; } }

        public void FillSourceCollection()
        {
            List<WeatherInfoViewModel> CityInfo = (List<WeatherInfoViewModel>)SourceCollection;

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
