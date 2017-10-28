using System.Collections.Generic;
using Restsharp.Get.AddObjectParameter.Attributes;

namespace Brewery.Infrastructure.Shared.BeweryApi.Endpoints
{
    public class Beers
    {
        public class Request
        {
            /// <summary>
            ///     Page Number`
            /// </summary>
            [ParameterName("p")]
            public int PageNumber { get; set; }

            /// <summary>
            ///     ID's of the beers to return, comma separated. Max 10.
            /// </summary>
            [ParameterName("ids")]
            public List<string> BeerIds { get; set; }

            /// <summary>
            ///     Name of a beer.
            /// </summary>
            [ParameterName("name")]
            public string BeerName { get; set; }

            /// <summary>
            ///     ID for glassware
            /// </summary>
            [ParameterName("glasswareId")]
            public long GlasswareId { get; set; }

            /// <summary>
            ///     ID for SRM
            /// </summary>
            [ParameterName("srmId")]
            public string SrmId { get; set; }

            /// <summary>
            ///     ID for availability
            /// </summary>
            [ParameterName("availableId")]
            public string AvailableId { get; set; }

            /// <summary>
            ///     ID for style
            /// </summary>
            [ParameterName("styleId")]
            public long StyleId { get; set; }

            /// <summary>
            ///     Whether the beer is certified organic or not. Values : 'Y' || 'N'
            /// </summary>
            [ParameterName("isOrganic")]
            public char IsOrganic { get; set; }

            /// <summary>
            ///     Whether or not the beer has a label.  Values : 'Y' || 'N'
            /// </summary>
            [ParameterName("hasLabels")]
            public char HasLabels { get; set; }

            /// <summary>
            ///     Year vintage of the beer. Format YYYY
            /// </summary>
            [ParameterName("year")]
            public int Year { get; set; }

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
            public string Order { get; set; }

            /// <summary>
            ///     How the results should be sorted.
            ///     Possible value
            ///     ASC
            ///     DESC
            /// </summary>
            [ParameterName("sort")]
            public string SortOrder { get; set; }

            /// <summary>
            ///     If the order parameter is set to random, this option specifies how many random beers to return. It has a max value
            ///     of 10
            /// </summary>
            [ParameterName("randomCount")]
            public int NumberOfRandomlyReturnedBeers { get; set; }

            /// <summary>
            ///     Get beer results with brewery information included.
            /// </summary>
            [ParameterName("randomCount")]
            public char WithBreweries { get; set; }
        }

        public class Response
        {
            
        }
    }
}