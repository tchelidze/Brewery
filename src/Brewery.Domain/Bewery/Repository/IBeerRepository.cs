using System.Threading.Tasks;
using Brewery.Domain.Bewery.Entities;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Domain.Shared.Repository.Exceptions;

namespace Brewery.Domain.Bewery.Repository
{
    public interface IBeerRepository
    {
        /// <exception cref="UnableToRetrieveDataException">
        ///     When data retrievation fails for unknown reasons.
        ///     See inner exception for details
        /// </exception>
        Task<BeerList.Response> ListAsync(BeerList.Request request);

        Task<Beer> GetAsync(GetBeer.Request request);
    }
}