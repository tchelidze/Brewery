using Brewery.Infrastructure.BeweryApi.Options;
using Brewery.Web.Setup.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Web.Setup.Configuration
{
    public static class IServiceCollectionConfigurationExtensions
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.ConfigureOption<BeweryApiOptions>(configuration);
            return services;
        }
    }
}