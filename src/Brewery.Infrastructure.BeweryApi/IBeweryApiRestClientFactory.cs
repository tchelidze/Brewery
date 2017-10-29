using RestSharp;

namespace Brewery.Infrastructure.BeweryApi
{
    public interface IBeweryApiRestClientFactory
    {
        IRestClient Create();
    }
}