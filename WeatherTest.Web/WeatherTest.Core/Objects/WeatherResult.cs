namespace WeatherTest.Core.Objects
{
    public class WeatherResult
    {
        public string Location { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public double TemperatureCelcius { get; set; }
        public double WindSpeedMph { get; set; }
        public double WindSpeedKph { get; set; }
    }
}
