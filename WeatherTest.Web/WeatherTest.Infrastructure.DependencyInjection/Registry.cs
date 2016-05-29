using System.Configuration;
using SimpleInjector.Packaging;
using SimpleInjector;
using WeatherTest.Core.Interfaces;
using WeatherTest.Infrastructure.Services;
using WeatherTest.Core.Services;
using WeatherTest.Infrastructure.ExternalProviders;

namespace WeatherTest.Infrastructure.DependencyInjection
{
    public class Registry : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IRestService, RestService>();
            container.Register<IWeatherService, WeatherService>();
            container.Register<IWeatherProvider, WeatherProvider>();

            //container.Register<IMailboxConfiguration>(() => (MailboxConfigurationSettings)(dynamic)ConfigurationManager.GetSection("mailboxConfigurations"));
            container.Register<IWeatherApisConfiguration>(() => (WeatherApiConfigurationSettings)(dynamic)ConfigurationManager.GetSection("weatherApis"));
        }
    }
}
