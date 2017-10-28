using System.Threading.Tasks;
using Brewery.Application.Bewery.Services.Abstract;
using Brewery.Application.Bewery.Services.Dto;
using Brewery.Web.Features.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.Bewery.Controllers
{
    [Area(nameof(Bewery))]
    public partial class BeerController : BaseController
    {
        readonly IBeerAppService _beerAppService;

        public BeerController(
            IBeerAppService beerAppService)
            => _beerAppService = beerAppService;

        public virtual async Task<IActionResult> Index()
        {
            await _beerAppService.ListBeerAsync(new ListBeer.Request());
            return View();
        }
    }
}