using System;

namespace WeatherTest.Core.Interfaces
{
    public interface IRestService
    {
        string Get(Uri uri);
        T Deserialize<T>(string json);
    }
}
