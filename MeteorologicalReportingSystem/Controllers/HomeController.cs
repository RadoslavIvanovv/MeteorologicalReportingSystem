using MeteorologicalReportingSystem.Models;
using MeteorologicalReportingSystem.Models.Enums;
using MeteorologicalReportingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeteorologicalReportingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISourceService sourceService;
        private readonly ISourceService backupSourceService;

        public HomeController()
        {
            this.sourceService = new SourceService();
            this.backupSourceService = new BackupSourceService();
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(SecurityKeyViewModel key)
        {
            var sourceKey = this.sourceService.SecurityKey;
            var backupSourceKey = this.backupSourceService.SecurityKey;
            var isSourceOnline = (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12);
            var isBackupSourceOnline = DateTime.Now.Hour >= 12;

            if (key.SecurityKey==sourceKey || key.SecurityKey == backupSourceKey)
            {
                if(key.SecurityKey==sourceKey && isBackupSourceOnline)
                {
                    return BadRequest($"503 - {JSONStatusCode.Offline}");
                }
                else if(key.SecurityKey == backupSourceKey && isSourceOnline)
                {
                    var xmlError = "<response>" +
                   "<success></success>" +
                   $"<error>{XMLStatusCode.Offline}</error>" +
                   "</response>";

                    return this.Content(xmlError, "text/xml");
                }

                return RedirectToAction("Search");
                
            }
            else if (isSourceOnline)
            {
                return BadRequest($"300 - {JSONStatusCode.Unauthorized}");               
            }
            else 
            {
                var xmlError = "<response>" +
                   "<success></success>" +
                   $"<error>{XMLStatusCode.Unautorized}</error>" +
                   "</response>";

                return this.Content(xmlError, "text/xml");
            }          
        }
        public IActionResult Search() => View();


        [HttpPost]
        public IActionResult Search(WeatherInfoViewModel weather)
        {
            this.sourceService.FillSourceCollection();
            this.backupSourceService.FillSourceCollection();

            var isSourceOnline = (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12);

            if (isSourceOnline)
            {
                var currentCity = this.sourceService.GetCurrentCity(weather.City);

                if (currentCity == null)
                {
                    return BadRequest($"500 - {JSONStatusCode.UnexpectedError}");
                }

                return Ok(currentCity);
            }
            else
            {
                var currentCity = this.backupSourceService.GetCurrentCity(weather.City);
                if (currentCity == null)
                {
                    var xmlError = "<response>" +
                    "<success></success>" +
                    $"<error>{XMLStatusCode.UnexpectedError}</error>" +
                    "</response>";

                    return this.Content(xmlError, "text/xml");
                }

                var xml = "<response>" +
                    "<success></success>" +
                    "<error></error>" +
                    "<data>" +
                    $"<temperature>{currentCity.Temperature}</temperature>" +
                    $"<pressure>{currentCity.Pressure}</pressure>" +
                    "</data>" +
                    "</response>";
                
                return this.Content(xml, "text/xml");
            };
        }
    }
}
