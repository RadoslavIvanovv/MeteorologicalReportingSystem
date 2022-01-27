using MeteorologicalReportingSystem.Models;

namespace MeteorologicalReportingSystem.Services
{
    public interface ISourceService
    {
        string SecurityKey { get; }
        WeatherInfoViewModel GetCurrentCity(string name);
        void FillSourceCollection();
    }
}
