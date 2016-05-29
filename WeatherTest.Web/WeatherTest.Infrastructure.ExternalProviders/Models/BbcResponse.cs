namespace WeatherTest.Infrastructure.ExternalProviders.Models
{
    public class BbcResponse
    {
        public string Location { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public double WindSpeedMph { get; set; }

        public double WindSpeedKph()
        {
            return WindSpeedMph*1.60;
        }

        public double TemperatureCelcius()
        {
            return (TemperatureFahrenheit - 32) *5 / 9;
        }
    }
    
}
