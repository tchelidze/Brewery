using System.Threading.Tasks;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi.Wrappers
{
    public interface IRestRequestWrapper
    {
        Task<IRestResponse<TResponse>> ExecuteAsync<TResponse>(IRestClient client, IRestRequest request)
            where TResponse : new();
    }
}