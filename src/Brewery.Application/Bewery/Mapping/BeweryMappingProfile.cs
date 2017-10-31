using AutoMapper;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Domain.Shared.Repository.Dto;

namespace Brewery.Application.Bewery.Mapping
{
    public class BeweryMappingProfile : Profile
    {
        public BeweryMappingProfile()
        {
            var repositoryBeerListResponseToAppServiceBeerListResponse = CreateMap<BeerList.Response, ListBeer.Response>();
            repositoryBeerListResponseToAppServiceBeerListResponse.ForMember(it => it.TotalNumberOfItems, opts => opts.MapFrom(it => it.TotalResults));
            repositoryBeerListResponseToAppServiceBeerListResponse.ForMember(it => it.BeerItems, opts => opts.MapFrom(it => it.Beers));
        }
    }
}