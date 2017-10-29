using Asp.Net.Core.Screaming;
using AspNetCore.IServiceCollection.AddIUrlHelper;
using Autofac;
using Brewery.Web.Setup.Configuration;
using Brewery.Web.Setup.DI;
using Brewery.Web.Setup.Mapping;
using Brewery.Web.Setup.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Web.Setup
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
                .ConfigureOptions(Configuration)
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