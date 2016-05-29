using System;
using System.Web.Http;
using WeatherTest.Bbc.Models;

namespace WeatherTest.Bbc.Controllers
{
    [RoutePrefix("api/bbcweather")]
    public class BbcWeatherController : ApiController
    {
        private System.Random _rng = new Random();

        [HttpGet]
        [Route("{location}")]
        public WeatherResult GetWeather(string location)
        {
            return new WeatherResult
            {
                Location = location,
                TemperatureFahrenheit = _rng.Next(32, 100),
                WindSpeedMph = _rng.Next(0, 20)
            };
        }
    }
}
