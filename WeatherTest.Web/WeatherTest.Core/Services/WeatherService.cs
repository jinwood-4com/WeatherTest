using WeatherTest.Core.Interfaces;
using WeatherTest.Core.Objects;

namespace WeatherTest.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherProvider _weatherProvider;

        public WeatherService(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        public WeatherResult GetWeatherForArea(string area)
        {
            return _weatherProvider.GetWeatherResultFromProviderByArea(area);
        }
    }
}
