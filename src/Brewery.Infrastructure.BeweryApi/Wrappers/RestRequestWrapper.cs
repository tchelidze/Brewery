using System.Threading.Tasks;
using Brewery.Infrastructure.BeweryApi.Extensions;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi.Wrappers
{
    public class RestRequestWrapper : IRestRequestWrapper
    {
        public async Task<IRestResponse<TResponse>> ExecuteAsync<TResponse>(IRestClient client, IRestRequest request)
            where TResponse : new()
            => await client.ExecuteAsync<TResponse>(request);
    }
}