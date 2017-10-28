using Brewery.Domain.Shared.Entities;

namespace Brewery.Domain.Bewery.Entities
{
    public class BeerStyle : BaseEntity<long>
    {
        public string FgMin { get; set; }

        public long CategoryId { get; set; }

        public string AbvMin { get; set; }

        public string AbvMax { get; set; }

        public BeerStyleCategory Category { get; set; }

        public string Description { get; set; }

        public string CreateDate { get; set; }

        public string FgMax { get; set; }

        public string Name { get; set; }

        public string IbuMin { get; set; }

        public string IbuMax { get; set; }

        public string SrmMax { get; set; }

        public string OgMin { get; set; }

        public string SrmMin { get; set; }
    }
}