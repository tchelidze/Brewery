using AutoMapper;
using Brewery.Application.Bewery.Services.Concrete;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Application.Shared.Services.Concrete;
using Brewery.Domain.Bewery.Repository;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Domain.Shared.Repository.Exceptions;
using CSharpFunctionalExtensions;
using Machine.Specifications;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Reflection;

namespace Brewery.Spec.Features.Bewery.AppService
{
    public class when_list_beer_is_invoked_and_repository_throws_UnableToRetrieveDataException
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
        static readonly Mock<ILogger<BaseAppService>> Logger = new Mock<ILogger<BaseAppService>>();
        static Result<ListBeer.Response> _appServiceResponse;
        static BeerAppService _sut;
        static readonly UnableToRetrieveDataException UnableToRetrieveDataException = new UnableToRetrieveDataException(new AmbiguousMatchException());

        Establish context = () =>
        {
            BeerRepositoryMock
                .Setup(it => it.ListAsync(Moq.It.IsAny<BeerList.Request>()))
                .Throws(UnableToRetrieveDataException);

            _sut = new BeerAppService(BeerRepositoryMock.Object);
            typeof(BaseAppService)
                .GetProperty("Mapper", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(_sut, Mapper.Object);

            typeof(BaseAppService)
                .GetProperty("Logger", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(_sut, Logger.Object);
        };

        Because of = () => _appServiceResponse = _sut.ListBeerAsync(ListBeerRequest).Result;

        Machine.Specifications.It should_return_failure_result
            = () => _appServiceResponse.IsFailure.ShouldBeTrue();
    }
}