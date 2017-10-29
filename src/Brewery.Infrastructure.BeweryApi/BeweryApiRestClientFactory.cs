using Brewery.Infrastructure.BeweryApi.Options;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi
{
    public class BeweryApiRestClientFactory : IBeweryApiRestClientFactory
    {
        readonly BeweryApiOptions _beweryApiOptions;
        public BeweryApiRestClientFactory(
            IOptions<BeweryApiOptions> beweryApiOptions)
            => _beweryApiOptions = beweryApiOptions.Value;

        public IRestClient Create()
        {
            var client = new RestClient(_beweryApiOptions.ApiBaseUrl);
            return client;
        }
    }
}