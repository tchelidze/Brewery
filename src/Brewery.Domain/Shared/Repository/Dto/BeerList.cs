using System.Collections.Generic;
using Brewery.Domain.Bewery.Entities;

namespace Brewery.Domain.Shared.Repository.Dto
{
    public class BeerList
    {
        public class Request
        {
            public int PageNumber { get; protected set; }

            public List<string> BeerIds { get; protected set; }

            public string BeerName { get; protected set; }

            public int? Year { get; protected set; }

            public string Order { get; set; }

            public class Builder
            {
                readonly Request _instance = new Request();

                public Builder Page(int page)
                {
                    _instance.PageNumber = page;
                    return this;
                }

                public Builder OnlyWithOfIds(List<string> beerIds)
                {
                    _instance.BeerIds = beerIds;
                    return this;
                }

                public Builder OfName(string beerName)
                {
                    _instance.BeerName = beerName;
                    return this;
                }

                public Builder VingagedIn(int? year)
                {
                    _instance.Year = year;
                    return this;
                }

                public Builder OrderedBy(string orderBy)
                {
                    _instance.Order = orderBy;
                    return this;
                }

                public Request Build() => _instance;
            }
        }

        public class Response
        {
            public IReadOnlyList<Beer> Beers { get; set; }

            public long NumberOfPages { get; set; }

            public long TotalResults { get; set; }
        }
    }
}