using System;
using Brewery.Infrastructure.BeweryApi.Endpoints;

namespace Brewery.Infrastructure.Bewery.Repository.Exceptions
{
    public class FailedBeweryApiResponseException : Exception
    {
        public FailedBeweryApiResponseException(
            BaseBeweryApiResponse.Response failedResponse)
            => FailedResponse = failedResponse;

        public BaseBeweryApiResponse.Response FailedResponse { get; }
    }
}