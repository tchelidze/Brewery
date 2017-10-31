using Brewery.Domain.Shared.Entities;

namespace Brewery.Domain.Bewery.Entities
{
    public class Beer : BaseEntity<string>
    {
        public long GlasswareId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreateDate { get; set; }

        public string Abv { get; set; }

        public BeerGlass Glass { get; set; }

        public string IsOrganic { get; set; }

        public BeerLabel Label { get; set; }

        public string StatusDisplay { get; set; }

        public long StyleId { get; set; }

        public string Status { get; set; }

        public BeerStyle Style { get; set; }

        public string UpdateDate { get; set; }
    }
}