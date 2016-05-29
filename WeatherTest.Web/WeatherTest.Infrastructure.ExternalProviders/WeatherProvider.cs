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

        public WeatherResult GetWeatherResultFromProviderByArea(string area)
        {
            var accuUri = new Uri($"http://localhost:53077/api/weather/{area}");
            var accuResult = _restService.Get(accuUri);

            var bbcUri = new Uri("http://localhost:53077/api/weather/{area}");
            var bbcResult = _restService.Get(bbcUri);

            return Aggregate(accuResult, bbcResult);
        }

        public WeatherResult Aggregate(string imperialJson, string metricJson)
        {
            var accuResult = _restService.Deserialize<AccuResponse>(imperialJson);
            var bbcResult = _restService.Deserialize<BbcResponse>(metricJson);

            var weatherResult = new WeatherResult
            {
                AverageWindSpeedMph = bbcResult.WindSpeedMph + accuResult.WindspeedMph()/2,
                AverageTemperatureCelcius = bbcResult.TemperatureFahrenheit + accuResult.WindspeedMph()/2
            };
            
            return weatherResult;
        }
    }
}
