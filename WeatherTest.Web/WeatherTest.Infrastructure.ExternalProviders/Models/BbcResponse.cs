namespace WeatherTest.Infrastructure.ExternalProviders.Models
{
    public class BbcResponse
    {
        public string Location { get; set; }
        public string TemperatureFahrenheit { get; set; }
        public string WindSpeedMph { get; set; }
    }
}
