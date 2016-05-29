namespace WeatherTest.Infrastructure.ExternalProviders.Models
{
    public class AccuResponse
    {
        public string Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public double WindSpeedKph { get; set; }

        public double TemperatureFarenheit()
        {
            return TemperatureCelsius * 9 / 5 + 32;
        }

        public double WindspeedMph()
        {
            return WindSpeedKph/1.609344;
        }
    }
}
