using Brewery.Domain.Shared.Repository.Dto.Exceptions;
using Brewery.Domain.Shared.Repository.Dto.Specifications;

namespace Brewery.Domain.Shared.Repository.Dto
{
    public class GetBeer
    {
        public class Request
        {
            public string BeerId { get; protected set; }

            public bool? WithBreweries { get; protected set; }

            public class Builder
            {
                readonly Request _instance = new Request();

                public Builder Id(string beerId)
                {
                    _instance.BeerId = beerId;
                    return this;
                }

                public Builder Beweries(bool? with)
                {
                    _instance.WithBreweries = with;
                    return this;
                }

                ///   <exception cref="InvalidGetBeerRequestException"> When ValiGetBeerRequestSpecification is not satisfied. </exception>
                public Request Build()
                {
                    if (new ValiGetBeerRequestSpecification().Not().IsSatisfiedBy(_instance))
                        throw new InvalidGetBeerRequestException(_instance);
                    return _instance;
                }
            }
        }
    }
}