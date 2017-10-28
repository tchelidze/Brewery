using Brewery.Domain.Shared.Entities;

namespace Brewery.Domain.Bewery.Entities
{
    public class BeerGlass : BaseEntity<long>
    {
        public string CreateDate { get; set; }

        public string Name { get; set; }
    }
}