using Microsoft.AspNetCore.Builder;

namespace Brewery.Setup.Mvc
{
    internal static class IApplicationBuilderMvcExtensions
    {
        internal static IApplicationBuilder UserConfiguredMvc(this IApplicationBuilder app)
        {
            app.UseMvc();
            return app;
        }
    }
}