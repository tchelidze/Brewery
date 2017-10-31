using Brewery.Infrastructure.BeweryApi.Endpoints;
using System.Threading.Tasks;

namespace Brewery.Infrastructure.BeweryApi
{
    public interface IBeweryApiClient
    {
        /// <inheritdoc cref="IBeweryApiClient.InvokeBeweryApi{TRequest,TResponse}" />
        Task<BeersEndpoint.Response> Beers(BeersEndpoint.Request request);

        /// <inheritdoc cref="IBeweryApiClient.InvokeBeweryApi{TRequest,TResponse}" />
        Task<BeerEndpoint.Response> Beer(BeerEndpoint.Request request);
    }
}