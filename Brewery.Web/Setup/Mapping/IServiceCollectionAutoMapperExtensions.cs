using AutoMapper;
using Brewery.Web.Features.Shared.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Web.Setup.Mapping
{
    internal static class IServiceCollectionAutoMapperExtensions
    {
        internal static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(opts => { opts.AddProfiles(typeof(SharedMappingProfile).Assembly); });
            return services;
        }
    }
}