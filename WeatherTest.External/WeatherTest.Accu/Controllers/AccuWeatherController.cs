using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherTest.Accu.Models;

namespace WeatherTest.Accu.Controllers
{
    [RoutePrefix("api/accuweather")]
    public class AccuWeatherController : ApiController
    {
        private System.Random _rng = new Random();

        [HttpGet]
        [Route("{location}")]
        public WeatherResult GetWeather(string location)
        {
            return new WeatherResult
            {
                Location = location,
                TemperatureCelsius = _rng.Next(0, 38),
                WindSpeedKph = _rng.Next(0, 32)
            };
        }
    }
}
