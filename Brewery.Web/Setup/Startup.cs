using Asp.Net.Core.Screaming;
using AspNetCore.IServiceCollection.AddIUrlHelper;
using Autofac;
using Beelisaurus.Web.Startup.Factories;
using Brewery.Setup.DI;
using Brewery.Setup.IServiceCollectionExtensions;
using Brewery.Setup.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Setup
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
            => Configuration = ConfigurationFactory.CreateConfiguration();

        public IConfigurationRoot Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder) => builder.ConfigureBeweryTypes();

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddScreaming()
                .AddSession()
                .ConfigureMvc()
                .AddAutoMapperProfiles()
                .AddUrlHelper();

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
            => app
#if DEBUG || STAGING
                .UseDeveloperExceptionPage()
                .UseDatabaseErrorPage()
                .UseBrowserLink()
#endif
#if RELEASE
                .UseStatusCodePagesWithRedirects("/Home/Code/{0}")
#endif
                .UseStaticFiles()
                .UseSession()
                .UserConfiguredMvc();
    }
}