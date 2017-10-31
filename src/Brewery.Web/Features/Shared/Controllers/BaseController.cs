using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.Web.Features.Shared.Controllers
{
    public partial class BaseController : Controller
    {
        protected IMapper Mapper { get; set; }

        protected JsonResult Json<T>(Result<T> operationResult)
            => operationResult.IsFailure
                ? Json(new { success = false, error = operationResult.Error })
                : Json(new { success = true, data = operationResult.Value });
    }
}