using Serilog;
using static Brewery.Web.Setup.Configuration.ConfigurationFactory;

namespace Brewery.Web.Setup.Logging
{
    public static class SerilogLoggerFactory
    {
        public static ILogger CreateLogger()
        {
            var configuration = CreateConfiguration();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
}