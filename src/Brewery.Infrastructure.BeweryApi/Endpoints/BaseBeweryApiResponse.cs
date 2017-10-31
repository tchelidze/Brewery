using Restsharp.Get.AddObjectParameter.Attributes;
using RestSharp.Deserializers;

namespace Brewery.Infrastructure.BeweryApi.Endpoints
{
    public class BaseBeweryApiResponse
    {
        public class Request
        {
            [IncludeParameter]
            [ParameterName("key")]
            internal string ApiKey { get; set; }
        }

        public class Response
        {
            [DeserializeAs(Name = "status")]
            public string Status { get; set; }
        }
    }
}