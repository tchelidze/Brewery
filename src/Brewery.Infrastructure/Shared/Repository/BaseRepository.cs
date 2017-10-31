using AutoMapper;

namespace Brewery.Infrastructure.Shared.Repository
{
    public class BaseRepository
    {
        protected IMapper Mapper { get; set; }
    }
}