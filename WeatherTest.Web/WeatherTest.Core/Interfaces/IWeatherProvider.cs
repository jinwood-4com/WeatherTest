using System.Collections.Generic;
using WeatherTest.Core.Objects;

namespace WeatherTest.Core.Interfaces
{
    public interface IWeatherProvider
    {
        WeatherResult GetWeatherResultFromProviderByArea(string location);
        WeatherResult Aggregate(List<ImperialResponse> imperialResponses, List<MetricResponse> metricResponses,
            string location);
    }
}
