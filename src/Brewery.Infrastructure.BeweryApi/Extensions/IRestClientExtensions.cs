using System.Threading.Tasks;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi.Extensions
{
    public static class IRestClientExtensions
    {
        public static async Task<IRestResponse<TResponse>> ExecuteAsync<TResponse>(this IRestClient client, IRestRequest request)
            where TResponse : new()
        {
            var taskCompletion = new TaskCompletionSource<IRestResponse<TResponse>>();
            var handle = client.ExecuteAsync<TResponse>(request, it => taskCompletion.SetResult(it));
            return await taskCompletion.Task;
        }
    }
}