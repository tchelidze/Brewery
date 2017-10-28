using System.Threading.Tasks;
using Brewery.Application.Bewery.Services.Dto;
using CSharpFunctionalExtensions;

namespace Brewery.Application.Bewery.Services.Abstract
{
    public interface IBeerAppService
    {
        Task<Result<ListBeer.Response>> ListBeerAsync(ListBeer.Request request);
    }
}