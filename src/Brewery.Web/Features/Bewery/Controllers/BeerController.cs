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
        public virtual async Task<IActionResult> List(
            [FromQuery]int page,
            [FromQuery]string[] beerIds,
            [FromQuery]string beerName,
            [FromQuery]string order,
            [FromQuery]int? year)
            => (await _beerAppService.ListBeerAsync(new ListBeer.Request
            {
                PageNumber = page,
                BeerIds = beerIds.ToList(),
                BeerName = beerName,
                Order = order,
                Year = year
            }))
                .OnBoth(Json);

        //        public virtual async Task<JsonResult> Get()
    }
}