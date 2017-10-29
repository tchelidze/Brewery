using System.Threading.Tasks;
using Brewery.Application.Bewery.Services.Abstract;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Application.Shared.Services.Concrete;
using Brewery.Domain.Bewery.Repository;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Domain.Shared.Repository.Exceptions;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;

namespace Brewery.Application.Bewery.Services.Concrete
{
    public class BeerAppService : BaseAppService, IBeerAppService
    {
        readonly IBeerRepository _beerRepository;

        public BeerAppService(
            IBeerRepository beerRepository)
            => _beerRepository = beerRepository;

        public async Task<Result<ListBeer.Response>> ListBeerAsync(ListBeer.Request request)
        {
            try
            {
                var beerList = await _beerRepository.List(
                    new BeerList.Request.Builder()
                        .Page(request.PageNumber)
                        .OnlyWithOfIds(request.BeerIds)
                        .OfName(request.BeerName)
                        .VingagedIn(request.Year)
                        .OrderedBy(request.Order)
                        .Build());

                return Result.Ok(Mapper.Map<ListBeer.Response>(beerList));
            }
            catch (UnableToRetrieveDataException ex)
            {
                Logger.LogCritical(string.Empty, ex);
                return Result.Fail<ListBeer.Response>("Unable to retrieve list of beers");
            }
        }
    }
}