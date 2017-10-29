using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Brewery.Application.Shared.Services.Concrete
{
    public class BaseAppService
    {
        protected IMapper Mapper { get; set; }

        protected ILogger<BaseAppService> Logger { get; set; }
    }
}