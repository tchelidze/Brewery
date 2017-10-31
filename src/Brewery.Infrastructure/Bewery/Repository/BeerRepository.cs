using AutoMapper;
using Brewery.Domain.Bewery.Entities;
using Brewery.Domain.Bewery.Repository;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Domain.Shared.Repository.Exceptions;
using Brewery.Infrastructure.Bewery.Repository.Exceptions;
using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.Shared.Repository;
using Brewery.Infrastructure.Shared.Repository.Specifications;
using RestSharp;
using System.Threading.Tasks;

namespace Brewery.Infrastructure.Bewery.Repository
{
    public class BeerRepository : BaseRepository, IBeerRepository
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
            var listBeersApiResponse = await _beweryApiClient.Beers(_mapper.Map<BeersEndpoint.Request>(request));
            if (new BreweryApiFailedSpecification().IsSatisfiedBy(listBeersApiResponse))
                throw new UnableToRetrieveDataException(new FailedBeweryApiResponseException(listBeersApiResponse));

            var beerListResponse = _mapper.Map<BeerList.Response>(listBeersApiResponse);
            return beerListResponse;
        }

        public async Task<Beer> Get(GetBeer.Request request)
        {
            var beersApiResponse = await _beweryApiClient.Beer(_mapper.Map<BeerEndpoint.Request>(request));
            if (new BreweryApiFailedSpecification().IsSatisfiedBy(beersApiResponse))
                throw new UnableToRetrieveDataException(new FailedBeweryApiResponseException(beersApiResponse));
            var beer = _mapper.Map<Beer>(beersApiResponse.Beer);
            return beer;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => { tcs.SetResult(response); });
            return tcs.Task;
        }
    }
}