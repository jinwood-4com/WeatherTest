namespace WeatherTest.Infrastructure.ExternalProviders.Models
{
    public class BbcResponse
    {
        public string Location { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public double WindSpeedMph { get; set; }
    }
}
