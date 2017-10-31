using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.BeweryApi.Options;
using Brewery.Infrastructure.BeweryApi.Wrappers;
using Machine.Specifications;
using Microsoft.Extensions.Options;
using Moq;
using RestSharp;
// ReSharper disable once RedundantUsingDirective
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using It = Machine.Specifications.It;
// ReSharper disable InconsistentNaming

namespace Brewery.Spec.Features.Bewery.Integration
{
    [Subject(typeof(BeweryApiClient))]
    public class when_retrieving_list_of_beers_from_bewery_api
    {
        static readonly BeweryApiOptions BeweryApiOptions = new BeweryApiOptions
        {
            ApiBaseUrl = "somebaseurl",
            ApiKeyValue = "some api key"
        };

        static readonly Mock<IOptions<BeweryApiOptions>> BeweryApiOptionsMock = new Mock<IOptions<BeweryApiOptions>>();

        static readonly Mock<IBeweryApiRestClientFactory> BeweryApiRestClientFactoryMock =
            new Mock<IBeweryApiRestClientFactory>();

        static readonly Mock<IRestRequestWrapper> RestRequestWrapper = new Mock<IRestRequestWrapper>();

        static readonly Mock<IRestResponse<BeersEndpoint.Response>> RestResponse = new Mock<IRestResponse<BeersEndpoint.Response>>();

        static BeweryApiClient _sut;

        Because of = () => { _sut.BeersAsync(new BeersEndpoint.Request()).Wait(); };

        Establish context = () =>
        {
            BeweryApiOptionsMock.SetupGet(it => it.Value).Returns(BeweryApiOptions);
            RestResponse.SetupGet(it => it.StatusCode).Returns(HttpStatusCode.OK);
            RestRequestWrapper
                .Setup(it => it.ExecuteAsync<BeersEndpoint.Response>(Moq.It.IsAny<IRestClient>(),
                    Moq.It.IsAny<IRestRequest>()))
                .Returns(Task.FromResult(RestResponse.Object));

            _sut = new BeweryApiClient(BeweryApiOptionsMock.Object, BeweryApiRestClientFactoryMock.Object,
                RestRequestWrapper.Object);
        };

        It should_pass_correct_api_key_to_request = () =>
        {
            RestRequestWrapper.Verify(
                it => it.ExecuteAsync<BeersEndpoint.Response>(
                    Moq.It.IsAny<IRestClient>(),
                    Moq.It.Is<IRestRequest>(ti => (string)ti.Parameters.First(tti => tti.Name == "key").Value == BeweryApiOptions.ApiKeyValue)),
                Times.Exactly(1));
        };
    }
}