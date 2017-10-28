using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Beelisaurus.Web.Features.Shared.Controllers
{
    public partial class BaseController : Controller
    {
        protected IMapper Mapper { get; set; }
    }
}