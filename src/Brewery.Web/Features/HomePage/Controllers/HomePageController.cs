using Brewery.Web.Features.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.HomePage.Controllers
{
    [Area(nameof(HomePage))]
    public partial class HomePageController : BaseController
    {
        public virtual IActionResult Index() => View();
    }
}