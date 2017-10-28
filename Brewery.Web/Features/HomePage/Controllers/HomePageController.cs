using Brewery.Web.Features.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.HomePage.Controllers
{
    [Area(nameof(HomePage))]
    public class HomePageController : BaseController
    {
        public IActionResult Index() => View();
    }
}