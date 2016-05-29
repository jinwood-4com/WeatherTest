using System.ComponentModel.DataAnnotations;

namespace WeatherTest.Core.Objects
{
    public class WeatherResult
    {
        public string Location { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double AverageTemperatureCelcius { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double AverageWindSpeedMph { get; set; }
    }
}
