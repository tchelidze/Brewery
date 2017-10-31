using Microsoft.AspNetCore.Builder;

namespace Brewery.Web.Setup.Api
{
    public static class IApplicationBuilderApiExtensions
    {
        public static IApplicationBuilder UseConfiguredSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bewery API V1"); });
            return app;
        }
    }
}