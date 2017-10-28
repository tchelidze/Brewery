using AutoMapper;
using Brewery.Features.Shared.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Setup.IServiceCollectionExtensions
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