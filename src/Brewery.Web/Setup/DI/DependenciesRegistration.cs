using Autofac;
using Brewery.Application.Shared.Services.Concrete;
using Brewery.Domain.Shared.Service.Concrete;
using Brewery.Infrastructure.Bewery.Repository;
using Brewery.Web.Features.Shared.Controllers;

namespace Brewery.Web.Setup.DI
{
    internal static class DependenciesRegistration
    {
        public static void ConfigureBeweryTypes(this ContainerBuilder builder)
            => builder
                .AddDomainServices()
                .AddAppServices()
                .AddInfrastructureServices()
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

        public static ContainerBuilder AddDomainServices(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(BaseDomainService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(new AccessRightInvariantPropertySelector(true));

            return builder;
        }

        public static ContainerBuilder AddAppServices(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(BaseAppService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(new AccessRightInvariantPropertySelector(true));

            return builder;
        }

        public static ContainerBuilder AddInfrastructureServices(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(BeerRepository).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(new AccessRightInvariantPropertySelector(true));

            return builder;
        }

        public static ContainerBuilder AddCustomOverrides(this ContainerBuilder builder)
            => builder;
    }
}