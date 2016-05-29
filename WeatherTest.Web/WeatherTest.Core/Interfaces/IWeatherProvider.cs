using System.Collections.Generic;
using WeatherTest.Core.Objects;

namespace WeatherTest.Core.Interfaces
{
    public interface IWeatherProvider
    {
        WeatherResult GetWeatherResultFromProviderByArea(string location);
        WeatherResult Aggregate(string imperialJson, string metricJson, string location);
    }
}
