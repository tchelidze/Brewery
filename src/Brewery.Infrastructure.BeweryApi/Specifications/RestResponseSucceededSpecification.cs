using System.Net;
using Kodefabrikken.DDD.Specification;
using RestSharp;

namespace Brewery.Infrastructure.BeweryApi.Specifications
{
    public class RestResponseSucceededSpecification : Specification<IRestResponse>
    {
        public RestResponseSucceededSpecification()
            : base(it => it.StatusCode == HttpStatusCode.OK)
        { }
    }
}