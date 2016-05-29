namespace WeatherTest.Core.Objects
{
    public class ImperialResponse
    {
        public string Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public double WindSpeedKph { get; set; }

        public double TemperatureFahrenheit()
        {
            return TemperatureCelsius * 9 / 5 + 32;
        }

        public double WindspeedMph()
        {
            return WindSpeedKph/1.609344;
        }
    }
}
