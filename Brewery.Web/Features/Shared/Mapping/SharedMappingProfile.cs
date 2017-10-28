using AutoMapper;

namespace Brewery.Features.Shared.Mapping
{
    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile() => CreateMissingTypeMaps = true;
    }
}