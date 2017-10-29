using System.Collections.Generic;

namespace Brewery.Application.Bewery.Services.Dto
{
    public class ListBeer
    {
        public class Request
        {
            public int PageNumber { get; set; }

            public List<string> BeerIds { get; set; }

            public string BeerName { get; set; }

            public int? Year { get; set; }

            public string Order { get; set; }
        }

        public class Response
        {
            public int TotalNumberOfItems { get; set; }

            public IReadOnlyList<BeerItem> BeerItems { get; set; }

            public class BeerItem
            {
                public string Id { get; set; }

                public string Description { get; set; }

                public BeerItemCategory Category { get; set; }

                public class BeerItemCategory
                {
                    public long Id { get; set; }

                    public string CreateDate { get; set; }

                    public string Name { get; set; }
                }
            }
        }
    }
}