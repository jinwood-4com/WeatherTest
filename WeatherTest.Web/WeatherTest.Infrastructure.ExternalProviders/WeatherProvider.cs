using System;
using System.Collections.Generic;
using WeatherTest.Core.Enums;
using WeatherTest.Core.Helpers;
using WeatherTest.Core.Interfaces;
using WeatherTest.Core.Objects;

namespace WeatherTest.Infrastructure.ExternalProviders
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly IRestService _restService;
        private readonly IWeatherApisConfiguration _weatherApis;

        public WeatherProvider(IRestService restService, IWeatherApisConfiguration weatherApis)
        {
            _restService = restService;
            _weatherApis = weatherApis;
        }

        public WeatherResult GetWeatherResultFromProviderByArea(string location)
        {
            var imperialResults = new List<ImperialResponse>();
            var metricResults = new List<MetricResponse>();
            foreach (var api in _weatherApis.Apis)
            {
                var uri = new Uri(api.Url);
                var jsonResponse = _restService.Get(uri);

                if (jsonResponse == string.Empty)
                    continue;

                if (EnumHelper<MeasurmentType>.Parse(api.MeasurmentType) == MeasurmentType.Imperial)
                {
                    imperialResults.Add(_restService.Deserialize<ImperialResponse>(jsonResponse));
                }
                else
                {
                    metricResults.Add(_restService.Deserialize<MetricResponse>(jsonResponse));
                }
            }

            return Aggregate(imperialResults, metricResults, location);
        }

        public WeatherResult Aggregate(List<ImperialResponse> imperialResponses, List<MetricResponse> metricResponses,
            string location)
        {
            metricResponses.AddRange(ConverToMetric(imperialResponses));
            var totalCount = metricResponses.Count;

            var totalTemp = 0.0d;
            var totalWind = 0.0d;
            
            foreach (var response in metricResponses)
            {
                totalTemp += response.TemperatureFahrenheit;
                totalWind += response.WindSpeedMph;
            }
            var weatherResult = new WeatherResult();
            weatherResult.AverageTemperatureCelcius = Math.Round(totalTemp/totalCount, 2);
            weatherResult.AverageWindSpeedMph = Math.Round(totalWind/totalCount, 2);
            weatherResult.Location = location;

            return weatherResult;
        }

        private List<MetricResponse> ConverToMetric(List<ImperialResponse> imperialResponses)
        {
            var metricResponses = new List<MetricResponse>();
            foreach (var response in imperialResponses)
            {
                metricResponses.Add(new MetricResponse
                {
                    WindSpeedMph = response.WindspeedMph(),
                    TemperatureFahrenheit = response.TemperatureFahrenheit(),
                    Location = response.Location
                });
            }

            return metricResponses;
        } 
    }
}
