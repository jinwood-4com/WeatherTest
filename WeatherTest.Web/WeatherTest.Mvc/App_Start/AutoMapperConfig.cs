using AutoMapper;
using WeatherTest.Core.Objects;
using WeatherTest.Mvc.Models;

namespace WeatherTest.Mvc
{
    public class AutoMapperConfig
    {
        public static void Bootstrap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<WeatherResultModel, WeatherResult>();
                cfg.CreateMap<WeatherResult, WeatherResultModel>();
            });
        }
    }
}