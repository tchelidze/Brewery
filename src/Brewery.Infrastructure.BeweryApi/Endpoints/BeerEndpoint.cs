using Brewery.Infrastructure.BeweryApi.Endpoints.PrameterFormatters;
using Restsharp.Get.AddObjectParameter.Attributes;
using RestSharp;
using RestSharp.Deserializers;

namespace Brewery.Infrastructure.BeweryApi.Endpoints
{
    public class BeerEndpoint
    {
        public class Request : BaseBeweryApiResponse.Request
        {
            [ParameterName("beerId")]
            [ParameterType(ParameterType.UrlSegment)]
            public string BeerId { get; set; }

            [ParameterName("withBreweries")]
            [ParameterType(ParameterType.QueryString)]
            [ParameterFormatter(typeof(BeweryApiBooleanParameterFormatter))]
            public bool? WithBreweries { get; set; }
        }

        public class Response : BaseBeweryApiResponse.Response
        {
            [DeserializeAs(Name = "message")]
            public string Message { get; set; }

            [DeserializeAs(Name = "data")]
            public Shared.Response.Beer Beer { get; set; }
        }
    }
}