using System.IO;
using Microsoft.Extensions.Configuration;

namespace Brewery.Web.Setup.Configuration
{
    internal static class ConfigurationFactory
    {
        internal static IConfigurationRoot CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
#if STAGING
                    .AddJsonFile("appsettings.Staging.json", false, true)
#endif
#if RELEASE
                    .AddJsonFile("appsettings.Release.json", false, true)
#endif
#if DEBUG
                    .AddJsonFile("appsettings.Debug.json", false, true)
#endif
                ;
            return builder.Build();
        }
    }
}