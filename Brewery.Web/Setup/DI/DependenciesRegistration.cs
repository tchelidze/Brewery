using Autofac;
using Beelisaurus.Web.Features.Shared.Controllers;

namespace Brewery.Setup.DI
{
    internal static class DependenciesRegistration
    {
        public static void ConfigureBeweryTypes(this ContainerBuilder builder)
            => builder
                .AddControllers()
                .AddCustomOverrides();

        public static ContainerBuilder AddControllers(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(BaseController).Assembly)
                .AsImplementedInterfaces()
                .AsSelf()
                .PropertiesAutowired(new AccessRightInvariantPropertySelector(true));

            return builder;
        }

        public static ContainerBuilder AddCustomOverrides(this ContainerBuilder builder)
            => builder;
    }
}