using System.Reflection;
using SimpleInjector;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleInjector.Integration.Web.Mvc;
using WeatherTest.Infrastructure.DependencyInjection;

namespace WeatherTest.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureSimpleInjector();
            AutoMapperConfig.Bootstrap();
        }

        private static void ConfigureSimpleInjector()
        {
            var container = new Container();

            new Registry().RegisterServices(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
