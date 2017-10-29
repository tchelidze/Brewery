using Autofac.Builder;

namespace Brewery.Web.Setup.DI.Extensions
{
    public static class IRegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> PropertiesAutowiredWithAccessRightInvariantPropertySelector<TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder,
            bool allowCircularDependencies = false)
            => registrationBuilder
                .PropertiesAutowired(new AccessRightInvariantPropertySelector(true), allowCircularDependencies);
    }
}