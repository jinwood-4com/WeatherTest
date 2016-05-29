using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherTest.Mvc.Models
{
    public class WeatherResultModel
    {
        public string Location { get; set; }
        public string AverageTemperatureFahrenheit { get; set; }
        public string AverageTemperatureCelcius { get; set; }
        public string AverageWindSpeedMph { get; set; }
        public string AverageWindSpeedKph { get; set; }
    }
}