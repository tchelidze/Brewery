using System.Collections.Generic;
using System.Threading.Tasks;
using Brewery.Domain.Bewery.Entities;

namespace Brewery.Domain.Bewery.Repository
{
    public interface IBeerRepository
    {
        Task<IReadOnlyList<Beer>> List();
    }
}
