using AutoMapper;

namespace Brewery.Web.Features.Shared.Mapping
{
    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile() => CreateMissingTypeMaps = true;
    }
}