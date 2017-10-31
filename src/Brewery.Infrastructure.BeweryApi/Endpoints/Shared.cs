using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Brewery.Infrastructure.BeweryApi.Endpoints
{
    public class Shared
    {
        public class Response
        {
            public class Beer
            {
                [DeserializeAs(Name = "id")]
                public string Id { get; set; }

                [DeserializeAs(Name = "glasswareId")]
                public long? GlasswareId { get; set; }

                [DeserializeAs(Name = "servingTemperature")]
                public string ServingTemperature { get; set; }

                [DeserializeAs(Name = "breweries")]
                public List<Brewery> Breweries { get; set; }

                [DeserializeAs(Name = "available")]
                public Available Available { get; set; }

                [DeserializeAs(Name = "abv")]
                public string Abv { get; set; }

                [DeserializeAs(Name = "availableId")]
                public long? AvailableId { get; set; }

                [DeserializeAs(Name = "description")]
                public string Description { get; set; }

                [DeserializeAs(Name = "createDate")]
                public string CreateDate { get; set; }

                [DeserializeAs(Name = "glass")]
                public Category Glass { get; set; }

                [DeserializeAs(Name = "labels")]
                public Labels Labels { get; set; }

                [DeserializeAs(Name = "ibu")]
                public string Ibu { get; set; }

                [DeserializeAs(Name = "isOrganic")]
                public string IsOrganic { get; set; }

                [DeserializeAs(Name = "nameDisplay")]
                public string NameDisplay { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }

                [DeserializeAs(Name = "originalGravity")]
                public string OriginalGravity { get; set; }

                [DeserializeAs(Name = "status")]
                public string Status { get; set; }

                [DeserializeAs(Name = "srm")]
                public Srm Srm { get; set; }

                [DeserializeAs(Name = "servingTemperatureDisplay")]
                public string ServingTemperatureDisplay { get; set; }

                [DeserializeAs(Name = "srmId")]
                public long? SrmId { get; set; }

                [DeserializeAs(Name = "style")]
                public Style Style { get; set; }

                [DeserializeAs(Name = "statusDisplay")]
                public string StatusDisplay { get; set; }

                [DeserializeAs(Name = "styleId")]
                public long StyleId { get; set; }

                [DeserializeAs(Name = "updateDate")]
                public string UpdateDate { get; set; }
            }

            public class Brewery
            {
                [DeserializeAs(Name = "isOrganic")]
                public string IsOrganic { get; set; }

                [DeserializeAs(Name = "established")]
                public string Established { get; set; }

                [DeserializeAs(Name = "createDate")]
                public string CreateDate { get; set; }

                [DeserializeAs(Name = "brandClassification")]
                public string BrandClassification { get; set; }

                [DeserializeAs(Name = "description")]
                public string Description { get; set; }

                [DeserializeAs(Name = "images")]
                public Images Images { get; set; }

                [DeserializeAs(Name = "id")]
                public string Id { get; set; }

                [DeserializeAs(Name = "isMassOwned")]
                public string IsMassOwned { get; set; }

                [DeserializeAs(Name = "nameShortDisplay")]
                public string NameShortDisplay { get; set; }

                [DeserializeAs(Name = "mailingListUrl")]
                public string MailingListUrl { get; set; }

                [DeserializeAs(Name = "locations")]
                public List<Location> Locations { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }

                [DeserializeAs(Name = "statusDisplay")]
                public string StatusDisplay { get; set; }

                [DeserializeAs(Name = "status")]
                public string Status { get; set; }

                [DeserializeAs(Name = "updateDate")]
                public string UpdateDate { get; set; }

                [DeserializeAs(Name = "website")]
                public string Website { get; set; }
            }

            public class Images
            {
                [DeserializeAs(Name = "large")]
                public string Large { get; set; }

                [DeserializeAs(Name = "squareLarge")]
                public string SquareLarge { get; set; }

                [DeserializeAs(Name = "icon")]
                public string Icon { get; set; }

                [DeserializeAs(Name = "medium")]
                public string Medium { get; set; }

                [DeserializeAs(Name = "squareMedium")]
                public string SquareMedium { get; set; }
            }

            public class Location
            {
                [DeserializeAs(Name = "inPlanning")]
                public string InPlanning { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }

                [DeserializeAs(Name = "extendedAddress")]
                public string ExtendedAddress { get; set; }

                [DeserializeAs(Name = "countryIsoCode")]
                public string CountryIsoCode { get; set; }

                [DeserializeAs(Name = "country")]
                public Country Country { get; set; }

                [DeserializeAs(Name = "createDate")]
                public string CreateDate { get; set; }

                [DeserializeAs(Name = "hoursOfOperation")]
                public string HoursOfOperation { get; set; }

                [DeserializeAs(Name = "forwardingId")]
                public string ForwardingId { get; set; }

                [DeserializeAs(Name = "id")]
                public string Id { get; set; }

                [DeserializeAs(Name = "locality")]
                public string Locality { get; set; }

                [DeserializeAs(Name = "isPrimary")]
                public string IsPrimary { get; set; }

                [DeserializeAs(Name = "isClosed")]
                public string IsClosed { get; set; }

                [DeserializeAs(Name = "latitude")]
                public double Latitude { get; set; }

                [DeserializeAs(Name = "locationTypeDisplay")]
                public string LocationTypeDisplay { get; set; }

                [DeserializeAs(Name = "locationType")]
                public string LocationType { get; set; }

                [DeserializeAs(Name = "longitude")]
                public double Longitude { get; set; }

                [DeserializeAs(Name = "region")]
                public string Region { get; set; }

                [DeserializeAs(Name = "phone")]
                public string Phone { get; set; }

                [DeserializeAs(Name = "openToPublic")]
                public string OpenToPublic { get; set; }

                [DeserializeAs(Name = "postalCode")]
                public string PostalCode { get; set; }

                [DeserializeAs(Name = "statusDisplay")]
                public string StatusDisplay { get; set; }

                [DeserializeAs(Name = "updateDate")]
                public string UpdateDate { get; set; }

                [DeserializeAs(Name = "status")]
                public string Status { get; set; }

                [DeserializeAs(Name = "streetAddress")]
                public string StreetAddress { get; set; }

                [DeserializeAs(Name = "website")]
                public string Website { get; set; }

                [DeserializeAs(Name = "yearOpened")]
                public string YearOpened { get; set; }
            }

            public class Country
            {
                [DeserializeAs(Name = "displayName")]
                public string DisplayName { get; set; }

                [DeserializeAs(Name = "isoThree")]
                public string IsoThree { get; set; }

                [DeserializeAs(Name = "createDate")]
                public string CreateDate { get; set; }

                [DeserializeAs(Name = "isoCode")]
                public string IsoCode { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }

                [DeserializeAs(Name = "numberCode")]
                public long NumberCode { get; set; }
            }

            public class Available
            {
                [DeserializeAs(Name = "id")]
                public long Id { get; set; }

                [DeserializeAs(Name = "description")]
                public string Description { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }
            }

            public class Category
            {
                [DeserializeAs(Name = "id")]
                public long Id { get; set; }

                [DeserializeAs(Name = "createDate")]
                public string CreateDate { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }
            }

            public class Labels
            {
                [DeserializeAs(Name = "large")]
                public string Large { get; set; }

                [DeserializeAs(Name = "icon")]
                public string Icon { get; set; }

                [DeserializeAs(Name = "medium")]
                public string Medium { get; set; }
            }

            public class Srm
            {
                [DeserializeAs(Name = "id")]
                public long Id { get; set; }

                [DeserializeAs(Name = "hex")]
                public string Hex { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }
            }

            public class Style
            {
                [DeserializeAs(Name = "fgMin")]
                public string FgMin { get; set; }

                [DeserializeAs(Name = "categoryId")]
                public long CategoryId { get; set; }

                [DeserializeAs(Name = "abvMin")]
                public string AbvMin { get; set; }

                [DeserializeAs(Name = "abvMax")]
                public string AbvMax { get; set; }

                [DeserializeAs(Name = "category")]
                public Category Category { get; set; }

                [DeserializeAs(Name = "description")]
                public string Description { get; set; }

                [DeserializeAs(Name = "createDate")]
                public string CreateDate { get; set; }

                [DeserializeAs(Name = "fgMax")]
                public string FgMax { get; set; }

                [DeserializeAs(Name = "name")]
                public string Name { get; set; }

                [DeserializeAs(Name = "ibuMin")]
                public string IbuMin { get; set; }

                [DeserializeAs(Name = "ibuMax")]
                public string IbuMax { get; set; }

                [DeserializeAs(Name = "id")]
                public long Id { get; set; }

                [DeserializeAs(Name = "shortName")]
                public string ShortName { get; set; }

                [DeserializeAs(Name = "srmMin")]
                public string SrmMin { get; set; }

                [DeserializeAs(Name = "ogMin")]
                public string OgMin { get; set; }

                [DeserializeAs(Name = "srmMax")]
                public string SrmMax { get; set; }

                [DeserializeAs(Name = "updateDate")]
                public string UpdateDate { get; set; }
            }
        }
    }
}
