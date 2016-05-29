﻿using System.Collections.Generic;
using WeatherTest.Core.Objects;

namespace WeatherTest.Core.Interfaces
{
    public interface IWeatherProvider
    {
        WeatherResult GetWeatherResultFromProviderByArea(string area);
        WeatherResult Aggregate(string imperialJson, string metricJson);
    }
}