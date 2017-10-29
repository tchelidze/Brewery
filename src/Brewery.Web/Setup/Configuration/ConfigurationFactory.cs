using System.IO;
using Microsoft.Extensions.Configuration;

namespace Brewery.Web.Setup.Configuration
{
    internal static class ConfigurationFactory
    {
        const string ConfigurationFileBasePath = @"Setup\Configuration";

        internal static IConfigurationRoot CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Path.Combine(ConfigurationFileBasePath, "appsettings.json"), false, true)
#if STAGING
                    .AddJsonFile(Path.Combine(ConfigurationFileBasePath,"appsettings.Staging.json"), false, true)
#endif
#if RELEASE
                    .AddJsonFile(Path.Combine(ConfigurationFileBasePath,"appsettings.Release.json"), false, true)
#endif
#if DEBUG
                    .AddJsonFile(Path.Combine(ConfigurationFileBasePath, "appsettings.Debug.json"), false, true)
#endif
                ;
            return builder.Build();
        }
    }
}