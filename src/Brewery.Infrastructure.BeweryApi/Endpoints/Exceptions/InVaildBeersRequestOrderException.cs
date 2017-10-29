using System;

namespace Brewery.Infrastructure.BeweryApi.Endpoints.Exceptions
{
    public class InVaildBeersRequestOrderException : Exception
    {
        public InVaildBeersRequestOrderException(
            string inVaildBeersRequestOrder) 
            => InVaildBeersRequestOrder = inVaildBeersRequestOrder;

        public string InVaildBeersRequestOrder { get; }
    }
}