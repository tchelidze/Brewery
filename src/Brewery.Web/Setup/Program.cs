using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using static Serilog.Log;
using static Brewery.Web.Setup.Logging.SerilogLoggerFactory;

namespace Brewery.Web.Setup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger = CreateLogger();

            try
            {
                Information("Starting web host");

                var host = new WebHostBuilder()
                    .UseKestrel()
                    .ConfigureServices(it => it.AddAutofac())
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseSerilog()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                CloseAndFlush();
            }
        }
    }
}