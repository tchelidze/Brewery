using System.Threading.Tasks;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.BeweryApi.Exceptions;
using Brewery.Infrastructure.BeweryApi.Options;
using Brewery.Infrastructure.BeweryApi.Specifications;
using Brewery.Infrastructure.BeweryApi.Wrappers;
using Microsoft.Extensions.Options;
using Restsharp.Get.AddObjectParameter.Extensions;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi
{
    public class BeweryApiClient : IBeweryApiClient
    {
        readonly BeweryApiOptions _beweryApiOptions;
        readonly IBeweryApiRestClientFactory _beweryApiRestClientFactory;
        readonly IRestRequestWrapper _restRequestWrapper;

        public BeweryApiClient(
            IOptions<BeweryApiOptions> beweryApiOptions,
            IBeweryApiRestClientFactory beweryApiRestClientFactory,
            IRestRequestWrapper restRequestWrapper)
        {
            _beweryApiRestClientFactory = beweryApiRestClientFactory;
            _restRequestWrapper = restRequestWrapper;
            _beweryApiOptions = beweryApiOptions.Value;
        }

        /// <inheritdoc />
        public async Task<Beers.Response> Beers(Beers.Request request)
            => await InvokeBeweryApi<Beers.Request, Beers.Response>(request, "beers");

        /// <summary>
        ///     Invokes Bewery api.
        /// </summary>
        /// <exception cref="BeweryApiRequestFailedException">
        ///     When request fails.
        ///     See  BeweryApiRequestFailedException.IRestResponse for information about failed response
        /// </exception>
        async Task<TResponse> InvokeBeweryApi<TRequest, TResponse>(TRequest request, string resource)
            where TRequest : BaseBeweryApiResponse.Request
            where TResponse : new()
        {
            request.ApiKey = _beweryApiOptions.ApiKeyValue;
            var beweryApiRequest = new RestRequest(resource).AddObjectParameter(request);

            var response = await _restRequestWrapper.ExecuteAsync<TResponse>(_beweryApiRestClientFactory.Create(), beweryApiRequest);

            if (new RestResponseSucceededSpecification().Not().IsSatisfiedBy(response))
            {
                throw new BeweryApiRequestFailedException(response);
            }

            return response.Data;
        }
    }
}