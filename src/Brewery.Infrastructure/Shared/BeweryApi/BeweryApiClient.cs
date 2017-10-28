using System.Threading.Tasks;
using Brewery.Infrastructure.Shared.BeweryApi.Endpoints;
using Brewery.Infrastructure.Shared.BeweryApi.Options;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Brewery.Infrastructure.Shared.BeweryApi
{
    public class BeweryApiClient
    {
        readonly BeweryApiOptions _beweryApiOptions;

        public BeweryApiClient(
            IOptions<BeweryApiOptions> beweryApiOptions)
            => _beweryApiOptions = beweryApiOptions.Value;

        RestClient GetBeweryApiClient()
        {
            var client = new RestClient(_beweryApiOptions.ApiBaseUrl);
            var request = new RestRequest("beers")
            {
                Parameters =
                {
                    new Parameter
                    {
                        Name = "key",
                        Value = "ce7f4048bcd9f69c835990f84b0c669b",
                        Type = ParameterType.QueryString
                    }
                }
            };
        }

        public Task<Beers.Response> Beers(Beers.Request request)
        { }
    }
}