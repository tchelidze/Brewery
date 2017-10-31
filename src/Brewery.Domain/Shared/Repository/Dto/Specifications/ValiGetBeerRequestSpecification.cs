using Brewery.CrossEdge;
using Kodefabrikken.DDD.Specification;

namespace Brewery.Domain.Shared.Repository.Dto.Specifications
{
    public class ValiGetBeerRequestSpecification : Specification<GetBeer.Request>
    {
        public ValiGetBeerRequestSpecification()
            : base(it => it.BeerId.IsNotNullOrEmpty())
        {
        }
    }
}