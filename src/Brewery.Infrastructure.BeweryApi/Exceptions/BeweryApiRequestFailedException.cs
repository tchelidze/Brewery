using System;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi.Exceptions
{
    public class BeweryApiRequestFailedException : Exception
    {
        public BeweryApiRequestFailedException(
            IRestResponse failedRestResponse)
            => FailedRestResponse = failedRestResponse;

        public IRestResponse FailedRestResponse { get; }
    }
}