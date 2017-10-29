using Brewery.Infrastructure.BeweryApi.Endpoints;
using Kodefabrikken.DDD.Specification;

namespace Brewery.Infrastructure.Shared.Repository.Specifications
{
    public class BreweryApiFailedSpecification : Specification<BaseBeweryApiResponse.Response>
    {
        public BreweryApiFailedSpecification()
            : base(it => it.Status != "success")
        { }
    }
}