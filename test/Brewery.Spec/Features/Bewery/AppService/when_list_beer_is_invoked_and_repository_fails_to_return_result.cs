using AutoMapper;
using Brewery.Application.Bewery.Services.Concrete;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Application.Shared.Services.Concrete;
using Brewery.Domain.Bewery.Repository;
using Brewery.Domain.Shared.Repository.Dto;
using CSharpFunctionalExtensions;
using Machine.Specifications;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Reflection;

namespace Brewery.Spec.Features.Bewery.AppService
{
    public class when_list_beer_is_invoked_and_repository_returns_result_successfully
    {
        static readonly ListBeer.Request ListBeerRequest = new ListBeer.Request
        {
            Order = "name",
            Year = 1995,
            BeerIds = new List<string>
            {
                "ada",
                "adts"
            },
            BeerName = "88",
            PageNumber = 21
        };

        static readonly Mock<IBeerRepository> BeerRepositoryMock = new Mock<IBeerRepository>();
        static readonly Mock<IMapper> Mapper = new Mock<IMapper>();
        static Result<ListBeer.Response> appServiceResponse;
        static BeerAppService _sut;
        static readonly ListBeer.Response MappedResult = new ListBeer.Response
        {
            TotalNumberOfItems = 21
        };

        Establish context = () =>
        {
            _sut = new BeerAppService(BeerRepositoryMock.Object);
            Mapper
                .Setup(it => it.Map<ListBeer.Response>(Moq.It.IsAny<BeerList.Response>()))
                .Returns(MappedResult);

            typeof(BaseAppService)
                .GetProperty("Mapper", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(_sut, Mapper.Object);
        };

        Because of = () => appServiceResponse = _sut.ListBeerAsync(ListBeerRequest).Result;

        Machine.Specifications.It should_return_success_result
            = () => appServiceResponse.IsSuccess.ShouldBeTrue();

        Machine.Specifications.It should_return_correct_data
            = () => appServiceResponse.Value.ShouldBe(MappedResult);
    }
}