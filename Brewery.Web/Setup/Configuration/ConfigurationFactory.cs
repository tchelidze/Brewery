﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace Beelisaurus.Web.Startup.Factories
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