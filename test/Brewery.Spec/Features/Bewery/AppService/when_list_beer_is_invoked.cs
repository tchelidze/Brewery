using AutoMapper;
using Brewery.Application.Bewery.Services.Concrete;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Application.Shared.Services.Concrete;
using Brewery.Domain.Bewery.Repository;
using Brewery.Domain.Shared.Repository.Dto;
using Machine.Specifications;
using Moq;
using System.Collections.Generic;
using System.Reflection;

namespace Brewery.Spec.Features.Bewery.AppService
{
    public class when_list_beer_is_invoked
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
        static BeerAppService _sut;

        Establish context = () =>
        {
            _sut = new BeerAppService(BeerRepositoryMock.Object);
            Mapper
                .Setup(it => it.Map<ListBeer.Response>(Moq.It.IsAny<BeerList.Response>()))
                .Returns(new ListBeer.Response());

            typeof(BaseAppService)
                .GetProperty("Mapper", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(_sut, Mapper.Object);
        };

        Because of = () => _sut.ListBeerAsync(ListBeerRequest).Wait();


        Machine.Specifications.It should_pass_correct_Order_to_repository =
            () => BeerRepositoryMock.Verify(it => it.ListAsync(Moq.It.Is<BeerList.Request>(ti => ti.Order == ListBeerRequest.Order)));

        Machine.Specifications.It should_pass_correct_Year_to_repository =
            () => BeerRepositoryMock.Verify(it => it.ListAsync(Moq.It.Is<BeerList.Request>(ti => ti.Year == ListBeerRequest.Year)));

        Machine.Specifications.It should_pass_correct_BeerIds_to_repository =
            () => BeerRepositoryMock.Verify(it => it.ListAsync(Moq.It.Is<BeerList.Request>(ti => ti.BeerIds == ListBeerRequest.BeerIds)));

        Machine.Specifications.It should_pass_correct_BeerName_to_repository =
            () => BeerRepositoryMock.Verify(it => it.ListAsync(Moq.It.Is<BeerList.Request>(ti => ti.BeerName == ListBeerRequest.BeerName)));

        Machine.Specifications.It should_pass_correct_PageNumber_to_repository =
            () => BeerRepositoryMock.Verify(it => it.ListAsync(Moq.It.Is<BeerList.Request>(ti => ti.PageNumber == ListBeerRequest.PageNumber)));
    }
}