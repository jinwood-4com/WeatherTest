using System;
using System.Collections.Generic;
using WeatherTest.Core.Interfaces;
using WeatherTest.Core.Objects;

namespace WeatherTest.Infrastructure
{
    public class WeatherApiConfigurationSettings : IWeatherApisConfiguration
    {
        public List<IApiSettings> Apis { get; set; }
    }
}
