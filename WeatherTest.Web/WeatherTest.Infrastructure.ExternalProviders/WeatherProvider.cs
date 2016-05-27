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
            var accuResult = _restService.Deserialize<AccuResponse>(_restService.Get(accuUri));

            var bbcUri = new Uri("http://localhost:53077/api/weather/{area}");
            var bbcResult = _restService.Deserialize<BbcResponse>(_restService.Get(bbcUri));

            var result = new WeatherResult
            {
                Location = area,
                TemperatureCelcius = double.Parse(accuResult.TemperatureCelsius),
                TemperatureFahrenheit = double.Parse(bbcResult.TemperatureFahrenheit),
                WindSpeedKph = double.Parse(accuResult.WindSpeedKph),
                WindSpeedMph = double.Parse(bbcResult.WindSpeedMph)
            };

            return result;
        }
    }
}
