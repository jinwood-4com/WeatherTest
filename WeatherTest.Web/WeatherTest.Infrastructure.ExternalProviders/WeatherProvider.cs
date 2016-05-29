using System;
using WeatherTest.Core.Interfaces;
using WeatherTest.Core.Objects;
using WeatherTest.Infrastructure.ExternalProviders.Models;

namespace WeatherTest.Infrastructure.ExternalProviders
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly IRestService _restService;

        public WeatherProvider(IRestService restService)
        {
            _restService = restService;
        }

        public WeatherResult GetWeatherResultFromProviderByArea(string location)
        {
            var accuUri = new Uri($"http://localhost:53077/api/Accuweather/{location}");
            var accuResult = _restService.Get(accuUri);

            var bbcUri = new Uri($"http://localhost:53523/api/bbcweather/{location}");
            var bbcResult = _restService.Get(bbcUri);

            return Aggregate(accuResult, bbcResult, location);
        }

        public WeatherResult Aggregate(string imperialJson, string metricJson, string location)
        {
            var accuResult = _restService.Deserialize<AccuResponse>(imperialJson);
            var bbcResult = _restService.Deserialize<BbcResponse>(metricJson);

            accuResult.WindSpeedKph = 8;
            bbcResult.WindSpeedMph = 10;

            var weatherResult = new WeatherResult
            {
                AverageWindSpeedMph = Math.Round((bbcResult.WindSpeedMph + accuResult.WindspeedMph())/2,2),
                AverageTemperatureCelcius = Math.Round((bbcResult.TemperatureCelcius() + accuResult.TemperatureCelsius)/2,2),
                Location = location
            };
            
            return weatherResult;
        }
    }
}
