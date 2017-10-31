using Brewery.Application.Bewery.Services.Abstract;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Web.Features.Shared.Controllers;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Brewery.Web.Features.Bewery.Controllers
{
    [Area(nameof(Bewery))]
    [Route("api/[area]/[controller]")]
    public partial class BeerController : BaseController
    {
        readonly IBeerAppService _beerAppService;

        public BeerController(
            IBeerAppService beerAppService)
            => _beerAppService = beerAppService;

        [HttpGet]
        [Route("/list")]
        public virtual async Task<IActionResult> List(
            [FromQuery] int page,
            [FromQuery] string[] beerIds,
            [FromQuery] string beerName,
            [FromQuery] string order,
            [FromQuery] int? year)
            => (await _beerAppService.ListBeerAsync(new ListBeer.Request
            {
                PageNumber = page,
                BeerIds = beerIds.ToList(),
                BeerName = beerName,
                Order = order,
                Year = year
            }))
                .OnBoth(Json);

        [HttpGet]
        [Route("/details")]
        public virtual async Task<IActionResult> Details(
            [FromQuery] string beerId,
            [FromQuery] bool? withBeweries)
            => (await _beerAppService.BeerDetailsAsync(new BeerDetails.Request
            {
                BeerId = beerId,
                WithBreweries = withBeweries
            }))
                .OnBoth(Json);
    }
}