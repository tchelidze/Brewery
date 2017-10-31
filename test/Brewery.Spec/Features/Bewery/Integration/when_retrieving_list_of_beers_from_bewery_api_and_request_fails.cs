using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Brewery.Infrastructure.BeweryApi.Exceptions;
using Brewery.Infrastructure.BeweryApi.Options;
using Brewery.Infrastructure.BeweryApi.Wrappers;
using Machine.Specifications;
using Microsoft.Extensions.Options;
using Moq;
using RestSharp;
using Shouldly;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using It = Machine.Specifications.It;

namespace Brewery.Spec.Features.Bewery.Integration
{
    [Subject(typeof(BeweryApiClient))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class when_retrieving_list_of_beers_from_bewery_api_and_request_fails
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

        static readonly Mock<IRestResponse<BeersEndpoint.Response>> FailedRestResponse = new Mock<IRestResponse<BeersEndpoint.Response>>();

        static BeweryApiClient _sut;
        static Exception _thrownException;

        Because of = () =>
        {
            try
            {
                var result = _sut.BeersAsync(new BeersEndpoint.Request()).Result;
            }
            catch (Exception ex)
            {
                _thrownException = ex.InnerException;
            }
        };

        Establish context = () =>
        {
            BeweryApiOptionsMock.SetupGet(it => it.Value).Returns(BeweryApiOptions);
            FailedRestResponse.SetupGet(it => it.StatusCode).Returns(HttpStatusCode.NotFound);

            RestRequestWrapper
                .Setup(it => it.ExecuteAsync<BeersEndpoint.Response>(Moq.It.IsAny<IRestClient>(),
                    Moq.It.IsAny<IRestRequest>()))
                .Returns(Task.FromResult(FailedRestResponse.Object));
            _sut = new BeweryApiClient(BeweryApiOptionsMock.Object, BeweryApiRestClientFactoryMock.Object,
                RestRequestWrapper.Object);
        };

        It should_throw_BeweryApiRequestFailedException = () => _thrownException.ShouldBeOfType(typeof(BeweryApiRequestFailedException));

        It thrown_BeweryApiRequestFailedException_should_contain_correct_response =
            () => ((BeweryApiRequestFailedException)_thrownException).FailedRestResponse.ShouldBe(FailedRestResponse.Object);
    }
}