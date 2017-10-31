using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.BeweryApi.Options;
using Brewery.Infrastructure.BeweryApi.Wrappers;
using Machine.Specifications;
using Microsoft.Extensions.Options;
using Moq;
using RestSharp;
using It = Machine.Specifications.It;

namespace Brewery.Spec.Features.BeweryIntegration
{
    [Subject(typeof(BeweryApiClient))]
    public class WhenRetrievingListOfBeersFromBeweryApiAndRequestSucceedes
    {
        static readonly BeweryApiOptions BeweryApiOptions = new BeweryApiOptions
        {
            ApiBaseUrl = "somebaseurl",
            ApiKeyValue = "some api key"
        };

        static readonly Mock<IOptions<BeweryApiOptions>> BeweryApiOptionsMock = new Mock<IOptions<BeweryApiOptions>>();
        static readonly Mock<IBeweryApiRestClientFactory> BeweryApiRestClientFactoryMock = new Mock<IBeweryApiRestClientFactory>();
        static readonly Mock<IRestRequestWrapper> RestRequestWrapper = new Mock<IRestRequestWrapper>();
        static BeweryApiClient _sut;

        Because _context = () => { _sut.Beers(new BeersEndpoint.Request()).Wait(); };

        Establish _establish = () =>
        {
            BeweryApiOptionsMock.SetupGet(it => it.Value).Returns(BeweryApiOptions);
            var succeededRestResponse = new Mock<IRestResponse<BeersEndpoint.Response>>();
            succeededRestResponse.SetupGet(it => it.StatusCode).Returns(HttpStatusCode.OK);

            RestRequestWrapper
                .Setup(it => it.ExecuteAsync<BeersEndpoint.Response>(Moq.It.IsAny<IRestClient>(), Moq.It.IsAny<IRestRequest>()))
                .Returns(Task.FromResult(succeededRestResponse.Object));
            _sut = new BeweryApiClient(BeweryApiOptionsMock.Object, BeweryApiRestClientFactoryMock.Object, RestRequestWrapper.Object);
        };

        It shouldPassCorrectApiKeyToRequest = () => { RestRequestWrapper.Verify(it => it.ExecuteAsync<BeersEndpoint.Response>(Moq.It.IsAny<IRestClient>(), Moq.It.Is<IRestRequest>(ti => (string)ti.Parameters.First(tti => tti.Name == "key").Value == BeweryApiOptions.ApiKeyValue))); };
    }
}