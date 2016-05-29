using WeatherTest.Core.Enums;

namespace WeatherTest.Core.Interfaces
{
    public interface IApiSettings
    {
        string Url { get; set; }
        string Name { get; set; }
        string MeasurmentType { get; set; }
    }
}
