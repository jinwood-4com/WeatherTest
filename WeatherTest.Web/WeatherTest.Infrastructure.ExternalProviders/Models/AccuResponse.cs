namespace WeatherTest.Infrastructure.ExternalProviders.Models
{
    public class AccuResponse
    {
        public string Location { get; set; }
        public string TemperatureCelsius { get; set; }
        public string WindSpeedKph { get; set; }
    }
}
