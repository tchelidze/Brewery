using System.Collections.Generic;

namespace Brewery.Infrastructure.Shared.BeweryApi.Options
{
    public class BeweryApiOptions
    {
        public string ApiBaseUrl { get; set; }

        public string ApiKeyValue { get; set; }

        public string ApiKeyName { get; set; }

        public IReadOnlyList<Endpoint> Endpoints { get; set; }

        public class Endpoint
        {
            public string ResourceName { get; set; }
        }
    }
}