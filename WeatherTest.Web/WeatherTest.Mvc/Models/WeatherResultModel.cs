namespace WeatherTest.Mvc.Models
{
    public class WeatherResultModel
    {
        public string Location { get; set; }
        public decimal AverageTemperatureCelcius { get; set; }
        public decimal AverageWindSpeedMph { get; set; }
    }
}