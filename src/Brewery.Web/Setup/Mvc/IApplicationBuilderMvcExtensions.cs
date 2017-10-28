using Asp.Net.Core.Screaming;
using Microsoft.AspNetCore.Builder;

namespace Brewery.Web.Setup.Mvc
{
    internal static class IApplicationBuilderMvcExtensions
    {
        internal static IApplicationBuilder UserConfiguredMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes => { routes.MapScreamingRoute(); });
            return app;
        }
    }
}