using AutoMapper;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Infrastructure.Bewery.Repository;
using Brewery.Infrastructure.BeweryApi;
using Brewery.Infrastructure.BeweryApi.Endpoints;
using Machine.Specifications;
using Moq;
using Shouldly;
using System.Threading.Tasks;
using It = Moq.It;

// ReSharper disable InconsistentNaming

namespace Brewery.Spec.Features.Bewery.Repository
{
    [Subject(typeof(BeerRepository))]
    public class when_list_of_beers_is_retrieved_and_beweryapi_succeedes
    {
        static readonly Mock<IBeweryApiClient> _beweryApiClientMock = new Mock<IBeweryApiClient>();
        static readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        static BeerRepository _sut;

        static BeerList.Response _mappedResponse = new BeerList.Response
        {
            TotalResults = 21
        };
        static BeerList.Response ListResponseReturnedFromRepository;

        static BeersEndpoint.Response succeededApiResponse = new BeersEndpoint.Response
        {
            Status = "success"
        };

        Establish context = () =>
        {
            _beweryApiClientMock
                .Setup(it => it.BeersAsync(It.IsAny<BeersEndpoint.Request>()))
                .Returns(Task.FromResult(succeededApiResponse));

            _mapperMock
                .Setup(it => it.Map<BeerList.Response>(succeededApiResponse))
                .Returns(_mappedResponse);

            _sut = new BeerRepository(_beweryApiClientMock.Object, _mapperMock.Object);
        };

        Because of = () =>
        {
            ListResponseReturnedFromRepository = _sut.ListAsync(new BeerList.Request()).Result;
        };

        Machine.Specifications.It should_return_correct_result
            = () => ListResponseReturnedFromRepository.ShouldBe(_mappedResponse);
    }
}