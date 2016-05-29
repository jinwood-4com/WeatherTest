using System.Collections.Generic;
using WeatherTest.Core.Objects;

namespace WeatherTest.Core.Interfaces
{
    public interface IWeatherApisConfiguration
    {
        List<IApiSettings> Apis { get; set; }
    }
}
