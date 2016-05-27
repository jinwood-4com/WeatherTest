using System;
using System.Collections.Generic;

namespace WeatherTest.Core.Interfaces
{
    public interface IRestService
    {
        string Get(Uri uri);
        T Deserialize<T>(string json);
        List<T> DeserializeList<T>(string json);
    }
}
