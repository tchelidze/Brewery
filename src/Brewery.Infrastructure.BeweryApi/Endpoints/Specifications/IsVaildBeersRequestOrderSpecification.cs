using System.Collections.Generic;
using System.Linq;
using Brewery.CrossEdge;
using Kodefabrikken.DDD.Specification;

namespace Brewery.Infrastructure.BeweryApi.Endpoints.Specifications
{
    public class IsVaildBeersRequestOrderSpecification : Specification<string>
    {
        public static IReadOnlyList<string> VaildBeersRequestOrders = new List<string>
        {
            "name",
            "description",
            "abv",
            "ibu",
            "glasswareId",
            "srmId",
            "availableId",
            "styleId",
            "isOrganic",
            "status",
            "createDate",
            "updateDate",
            "random"
        };

        public IsVaildBeersRequestOrderSpecification()
            : base(it => it.IsNullOrEmpty() || VaildBeersRequestOrders.Contains(it))
        { }
    }
}