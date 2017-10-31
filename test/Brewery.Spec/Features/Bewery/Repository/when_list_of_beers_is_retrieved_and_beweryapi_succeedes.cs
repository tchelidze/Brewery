using AutoMapper;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Domain.Shared.Repository.Exceptions;
using Brewery.Infrastructure.Bewery.Repository;
using Brewery.Infrastructure.Bewery.Repository.Exceptions;
using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Machine.Specifications;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using It = Machine.Specifications.It;

// ReSharper disable InconsistentNaming

namespace Brewery.Spec.Features.Bewery.Repository
{
    [Subject(typeof(BeerRepository))]
    public class when_list_of_beers_is_retrieved_and_beweryapi_fails
    {
        static readonly Mock<IBeweryApiClient> _beweryApiClientMock = new Mock<IBeweryApiClient>();
        static readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        static BeerRepository _sut;
        static Exception _thrownException;

        static BeersEndpoint.Response failedApiResponse = new BeersEndpoint.Response { Status = "fail" };

        Establish context = () =>
        {
            _beweryApiClientMock
                .Setup(it => it.BeersAsync(Moq.It.IsAny<BeersEndpoint.Request>()))
                .Returns(Task.FromResult(failedApiResponse));
            _sut = new BeerRepository(_beweryApiClientMock.Object, _mapperMock.Object);
        };

        Because of = () =>
        {
            try
            {
                _sut.ListAsync(new BeerList.Request()).Wait();
            }
            catch (Exception ex)
            {
                _thrownException = ex.InnerException;
            }
        };

        It should_throw_UnableToRetrieveDataException_exception
            = () => _thrownException.ShouldBeOfType(typeof(UnableToRetrieveDataException));

        It thrown_UnableToRetrieveDataException_should_have_FailedBeweryApiResponseException_inner_exceptin
            = () => _thrownException.InnerException.ShouldBeOfType(typeof(FailedBeweryApiResponseException));

        It thrown_UnableToRetrieveDataException_shoulds_inner_FailedBeweryApiResponseException_exception_should_have_failed_api_response
            = () => ((FailedBeweryApiResponseException)_thrownException.InnerException).FailedResponse.ShouldBe(failedApiResponse);
    }
}