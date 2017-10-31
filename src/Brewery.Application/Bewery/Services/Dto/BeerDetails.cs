namespace Brewery.Application.Bewery.Services.Dto
{
    public class BeerDetails
    {
        public class Request
        {
            public string BeerId { get; set; }

            public bool? WithBreweries { get; set; }
        }

        public class Response
        {
            public string Id { get; set; }

            public string Description { get; set; }

            public string Name { get; set; }

            public int Year { get; set; }
        }
    }
}