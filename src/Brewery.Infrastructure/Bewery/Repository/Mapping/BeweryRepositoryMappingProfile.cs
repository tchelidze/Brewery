using AutoMapper;
using Brewery.Domain.Shared.Repository.Dto;
using Brewery.Infrastructure.BeweryApi.Endpoints;

namespace Brewery.Infrastructure.Bewery.Repository.Mapping
{
    public class BeweryRepositoryMappingProfile : Profile
    {
        public BeweryRepositoryMappingProfile()
        {
            var beerListRequestToBeersRequest = CreateMap<BeerList.Request, Beers.Request>();
            beerListRequestToBeersRequest.ForMember(it => it.BeerIds, opts => opts.MapFrom(it => it.BeerIds == null ? null : it.BeerIds.ToArray()));
        }
    }
}