using System.Web.Mvc;
using AutoMapper;
using WeatherTest.Core.Interfaces;
using WeatherTest.Core.Objects;
using WeatherTest.Mvc.Models;

namespace WeatherTest.Mvc.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        // GET: Weather
        public ActionResult Get(LocationModel model)
        {
            var weatherResult = _weatherService.GetWeatherForArea(model.Location);
            return RedirectToAction("Result", weatherResult);
        }

        public ActionResult Result(WeatherResult weatherResult)
        {
            return View(Mapper.Map<WeatherResultModel>(weatherResult));
        }
    }
}