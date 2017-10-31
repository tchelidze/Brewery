using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.BeweryApi.Options;
using Brewery.Infrastructure.BeweryApi.Wrappers;
using Machine.Specifications;
using Microsoft.Extensions.Options;
using Moq;
using RestSharp;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using It = Machine.Specifications.It;

namespace Brewery.Spec.Features.Bewery.Integration
{
    [Subject(typeof(BeweryApiClient))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_retrieving_list_of_beers_from_bewery_api_and_request_succeedes
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

        static readonly Mock<IRestResponse<BeersEndpoint.Response>> SucceededRestResponse =
            new Mock<IRestResponse<BeersEndpoint.Response>>();

        static readonly BeersEndpoint.Response SucceededRestResponseData = new BeersEndpoint.Response
        {
            TotalResults = 12,
            CurrentPage = 2,
            NumberOfPages = 32
        };

        static BeweryApiClient _sut;
        static BeersEndpoint.Response _beersResponse;

        Because of = () => { _beersResponse = _sut.BeersAsync(new BeersEndpoint.Request()).Result; };

        Establish context = () =>
        {
            BeweryApiOptionsMock.SetupGet(it => it.Value).Returns(BeweryApiOptions);
            SucceededRestResponse.SetupGet(it => it.StatusCode).Returns(HttpStatusCode.OK);
            SucceededRestResponse.SetupGet(it => it.Data).Returns(SucceededRestResponseData);

            RestRequestWrapper
                .Setup(it => it.ExecuteAsync<BeersEndpoint.Response>(Moq.It.IsAny<IRestClient>(),
                    Moq.It.IsAny<IRestRequest>()))
                .Returns(Task.FromResult(SucceededRestResponse.Object));
            _sut = new BeweryApiClient(BeweryApiOptionsMock.Object, BeweryApiRestClientFactoryMock.Object,
                RestRequestWrapper.Object);
        };

        It should_return_data_returned_from_the_api = () => _beersResponse.ShouldBe(SucceededRestResponseData);
    }
}