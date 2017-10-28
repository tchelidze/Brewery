using Brewery.Web.Features.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.Bewery.Controllers
{
    [Area(nameof(Bewery))]
    public partial class BeerController : BaseController
    {
        public virtual IActionResult Index() => View();
    }
}