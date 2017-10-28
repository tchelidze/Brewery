using AutoMapper;

namespace Brewery.Application.Shared.Services.Concrete
{
    public class BaseAppService
    {
        protected IMapper Mapper { get; set; }
    }
}