using WeatherTest.Core.Objects;

namespace WeatherTest.Core.Interfaces
{
    public interface IWeatherService
    {
        WeatherResult GetWeatherForArea(string area);
    }
}
