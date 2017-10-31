using Brewery.Infrastructure.BeweryApi.Endpoints;
using System.Threading.Tasks;

namespace Brewery.Infrastructure.BeweryApi
{
    public interface IBeweryApiClient
    {
        /// <inheritdoc cref="IBeweryApiClient.InvokeBeweryApi{TRequest,TResponse}" />
        Task<BeersEndpoint.Response> BeersAsync(BeersEndpoint.Request request);

        /// <inheritdoc cref="IBeweryApiClient.InvokeBeweryApi{TRequest,TResponse}" />
        Task<BeerEndpoint.Response> BeerAsync(BeerEndpoint.Request request);
    }
}