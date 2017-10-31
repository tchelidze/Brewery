using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Brewery.Web.Setup.Api
{
    public static class IServiceCollectionApiExtensions
    {
        public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Version = "v1", Title = "Bewery API" }); });
            return services;
        }
    }
}