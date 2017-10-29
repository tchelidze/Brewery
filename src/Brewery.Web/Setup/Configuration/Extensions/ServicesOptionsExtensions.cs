using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Web.Setup.Configuration.Extensions
{
    public static class ServicesOptionsExtensions
    {
        /// <summary>
        ///     Configures option of type TConfig with value retrieved from configuration via name of TConfig type
        /// </summary>
        public static void ConfigureOption<TConfig>(this IServiceCollection services, IConfigurationRoot configuration)
            where TConfig : class
            => services.Configure<TConfig>(configuration.GetSection(typeof(TConfig).Name));
    }
}