using Restsharp.Get.AddObjectParameter;

namespace Brewery.Infrastructure.BeweryApi.Endpoints.PrameterFormatters
{
    public class BeweryApiBooleanParameterFormatter : IParameterFormatter
    {
        public string Format(object parameterValue)
        {
            var parameterBooleanValue = (bool)parameterValue;
            return parameterBooleanValue ? "Y" : "N";
        }
    }
}