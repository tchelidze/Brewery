using System.Threading.Tasks;
using Brewery.Infrastructure.BeweryApi.Endpoints;

namespace Brewery.Infrastructure.BeweryApi
{
    public interface IBeweryApiClient
    {
        /// <inheritdoc cref="IBeweryApiClient.InvokeBeweryApi{TRequest,TResponse}" />
        Task<Beers.Response> Beers(Beers.Request request);
    }
}