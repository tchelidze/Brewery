using System.Threading.Tasks;
using Brewery.Application.Bewery.Services.Abstract;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Application.Shared.Services.Concrete;
using Brewery.Domain.Bewery.Repository;
using CSharpFunctionalExtensions;

namespace Brewery.Application.Bewery.Services.Concrete
{
    public class BeerAppService : BaseAppService, IBeerAppService
    {
        readonly IBeerRepository _beerRepository;

        public BeerAppService(
            IBeerRepository beerRepository)
            => _beerRepository = beerRepository;

        public Task<Result<ListBeer.Response>> ListBeerAsync(ListBeer.Request request)
        {
            var a = _beerRepository.List();
            return null;
        }
    }
}