using System.Collections.Generic;
using System.Linq;
using Brewery.Infrastructure.BeweryApi.Endpoints.Exceptions;
using Brewery.Infrastructure.BeweryApi.Endpoints.PrameterFormatters;
using Brewery.Infrastructure.BeweryApi.Endpoints.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using RestSharp;
using RestSharp.Deserializers;

namespace Brewery.Infrastructure.BeweryApi.Endpoints
{
    public class Beers
    {
        public class Request : BaseBeweryApiResponse.Request
        {
            List<string> _beerIds;
            string _order;

            /// <summary>
            ///     Page Number`
            /// </summary>
            [ParameterName("p")]
            [ParameterType(ParameterType.QueryString)]
            public int? PageNumber { get; set; }

            /// <summary>
            ///     ID's of the beers to return, comma separated. Max 10.
            /// </summary>
            [ParameterName("ids")]
            [ParameterType(ParameterType.QueryString)]
            public List<string> BeerIds
            {
                get => _beerIds;
                set => _beerIds = value?.Any() == true ? value : null;
            }

            /// <summary>
            ///     Name of a beer.
            /// </summary>
            [ParameterName("name")]
            [ParameterType(ParameterType.QueryString)]
            public string BeerName { get; set; }

            /// <summary>
            ///     ID for glassware
            /// </summary>
            [ParameterName("glasswareId")]
            [ParameterType(ParameterType.QueryString)]
            public long? GlasswareId { get; set; }

            /// <summary>
            ///     ID for SRM
            /// </summary>
            [ParameterName("srmId")]
            [ParameterType(ParameterType.QueryString)]
            public string SrmId { get; set; }

            /// <summary>
            ///     ID for availability
            /// </summary>
            [ParameterName("availableId")]
            [ParameterType(ParameterType.QueryString)]
            public string AvailableId { get; set; }

            /// <summary>
            ///     ID for style
            /// </summary>
            [ParameterName("styleId")]
            [ParameterType(ParameterType.QueryString)]
            public long? StyleId { get; set; }

            /// <summary>
            ///     Whether the beer is certified organic or not. Values : 'Y' || 'N'
            /// </summary>
            [ParameterName("isOrganic")]
            [ParameterType(ParameterType.QueryString)]
            [ParameterFormatter(typeof(BeweryApiBooleanParameterFormatter))]
            public bool? IsOrganic { get; set; }

            /// <summary>
            ///     Whether or not the beer has a label.  Values : 'Y' || 'N'
            /// </summary>
            [ParameterName("hasLabels")]
            [ParameterType(ParameterType.QueryString)]
            [ParameterFormatter(typeof(BeweryApiBooleanParameterFormatter))]
            public bool? HasLabels { get; set; }

            /// <summary>
            ///     Year vintage of the beer. Format YYYY
            /// </summary>
            [ParameterName("year")]
            [ParameterType(ParameterType.QueryString)]
            public int? Year { get; set; }

            /// <summary>
            ///     How the results should be ordered
            ///     Possible values :
            ///     name
            ///     description
            ///     abv
            ///     ibu
            ///     glasswareId
            ///     srmId
            ///     availableId
            ///     styleId
            ///     isOrganic
            ///     status
            ///     createDate
            ///     updateDate
            ///     random
            /// </summary>
            [ParameterName("order")]
            [ParameterType(ParameterType.QueryString)]
            public string Order
            {
                get => _order;
                set
                {
                    if (new IsVaildBeersRequestOrderSpecification().Not().IsSatisfiedBy(value))
                    {
                        throw new InVaildBeersRequestOrderException(value);
                    }

                    _order = value;
                }
            }

            /// <summary>
            ///     How the results should be sorted.
            ///     Possible value
            ///     ASC
            ///     DESC
            /// </summary>
            [ParameterName("sort")]
            [ParameterType(ParameterType.QueryString)]
            public string SortOrder { get; set; }

            /// <summary>
            ///     If the order parameter is set to random, this option specifies how many random beers to return. It has a max value
            ///     of 10
            /// </summary>
            [ParameterName("randomCount")]
            [ParameterType(ParameterType.QueryString)]
            public int? NumberOfRandomlyReturnedBeers { get; set; }

            /// <summary>
            ///     Get beer results with brewery information included.
            /// </summary>
            [ParameterName("withBreweries")]
            [ParameterType(ParameterType.QueryString)]
            [ParameterFormatter(typeof(BeweryApiBooleanParameterFormatter))]
            public bool? WithBreweries { get; set; }
        }

        public class Response : BaseBeweryApiResponse.Response
        {
            [DeserializeAs(Name = "data")]
            public List<Beer> Beers { get; set; }

            [DeserializeAs(Name = "currentPage")]
            public long CurrentPage { get; set; }

            [DeserializeAs(Name = "numberOfPages")]
            public long NumberOfPages { get; set; }

            [DeserializeAs(Name = "totalResults")]
            public long TotalResults { get; set; }
        }

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