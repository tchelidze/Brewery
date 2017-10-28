using Brewery.Web.Features.Shared.Controllers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Brewery.Web.Setup.Validation
{
    internal static class IServiceCollectionValidationExtensions
    {
        internal static IMvcBuilder ConfigureFluentValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(it =>
                {
                    it.RegisterValidatorsFromAssemblyContaining<BaseController>();
                    it.LocalizationEnabled = true;
                });

            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            return builder;
        }
    }
}