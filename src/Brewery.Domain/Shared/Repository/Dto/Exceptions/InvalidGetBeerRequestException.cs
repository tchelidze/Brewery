using System;

namespace Brewery.Domain.Shared.Repository.Dto.Exceptions
{
    public class InvalidGetBeerRequestException : Exception
    {
        public InvalidGetBeerRequestException(
            GetBeer.Request invalidRequest)
            => InvalidRequest = invalidRequest;

        public GetBeer.Request InvalidRequest { get; }
    }
}