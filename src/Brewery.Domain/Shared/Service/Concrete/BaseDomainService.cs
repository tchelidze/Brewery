using AutoMapper;

namespace Brewery.Domain.Shared.Service.Concrete
{
    public class BaseDomainService
    {
        protected IMapper Mapper { get; set; }
    }
}