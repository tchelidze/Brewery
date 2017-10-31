using Restsharp.Get.AddObjectParameter;
using System.Collections;
using System.Linq;

namespace Brewery.Infrastructure.BeweryApi.Endpoints.PrameterFormatters
{
    /// <summary>
    ///     Applied to any collection (child of IEnumerable) generates string of comma seperated collection items.
    /// </summary>
    public class BeweryApiCollectionParameterFormatter : IParameterFormatter
    {
        public string Format(object parameterValue)
        {
            if (parameterValue == null) return null;
            var collection = parameterValue as IEnumerable;
            return string.Join(",", collection.OfType<object>().Select(it => it.ToString()));
        }
    }
}