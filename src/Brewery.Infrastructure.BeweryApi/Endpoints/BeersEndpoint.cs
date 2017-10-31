using Brewery.Infrastructure.BeweryApi.Endpoints.Exceptions;
using Brewery.Infrastructure.BeweryApi.Endpoints.PrameterFormatters;
using Brewery.Infrastructure.BeweryApi.Endpoints.Specifications;
using Restsharp.Get.AddObjectParameter.Attributes;
using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;
using System.Linq;

namespace Brewery.Infrastructure.BeweryApi.Endpoints
{
    public class BeersEndpoint
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
            [ParameterFormatter(typeof(BeweryApiCollectionParameterFormatter))]
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
            public List<Shared.Response.Beer> Beers { get; set; }

            [DeserializeAs(Name = "currentPage")]
            public long CurrentPage { get; set; }

            [DeserializeAs(Name = "numberOfPages")]
            public long NumberOfPages { get; set; }

            [DeserializeAs(Name = "totalResults")]
            public long TotalResults { get; set; }

            [DeserializeAs(Name = "errorMessage")]
            public string ErrorMessage { get; set; }
        }
    }
}