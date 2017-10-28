﻿using Brewery.Web.Features.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.Bewery.Controllers
{
    [Area(nameof(Bewery))]
    public class BeerController : BaseController
    {
        public IActionResult Index() => View();
    }
}