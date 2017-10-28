using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.Shared.Controllers
{
    public partial class BaseController : Controller
    {
        protected IMapper Mapper { get; set; }
    }
}