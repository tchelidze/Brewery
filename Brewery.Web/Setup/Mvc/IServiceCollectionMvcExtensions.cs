using Brewery.Web.Setup.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Web.Setup.Mvc
{
    internal static class IServiceCollectionMvcExtensions
    {
        internal static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddMvc()
                .ConfigureFluentValidation()
                .AddControllersAsServices();

            return services;
        }
    }
}