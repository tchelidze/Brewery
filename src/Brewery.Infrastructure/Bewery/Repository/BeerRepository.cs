using System.Threading.Tasks;
using AutoMapper;
using Brewery.Domain.Bewery.Repository;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Domain.Shared.Repository.Exceptions;
using Brewery.Infrastructure.Bewery.Repository.Exceptions;
using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.Shared.Repository.Specifications;
using RestSharp;

namespace Brewery.Infrastructure.Bewery.Repository
{
    public class BeerRepository : IBeerRepository
    {
        readonly IBeweryApiClient _beweryApiClient;
        readonly IMapper _mapper;

        public BeerRepository(
            IBeweryApiClient beweryApiClient,
            IMapper mapper)
        {
            _beweryApiClient = beweryApiClient;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<BeerList.Response> List(BeerList.Request request)
        {
            var apiResponse = await _beweryApiClient.Beers(_mapper.Map<Beers.Request>(request));
            if (new BreweryApiFailedSpecification().IsSatisfiedBy(apiResponse))
            {
                throw new UnableToRetrieveDataException(new FailedBeweryApiResponseException(apiResponse));
            }

            var beerListResponse = _mapper.Map<BeerList.Response>(apiResponse);
            return beerListResponse;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => { tcs.SetResult(response); });
            return tcs.Task;
        }
    }
}