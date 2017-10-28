using System.Collections.Generic;
using System.Threading.Tasks;
using Brewery.Domain.Bewery.Entities;
using Brewery.Domain.Bewery.Repository;
using RestSharp;

namespace Brewery.Infrastructure.Bewery.Repository
{
    public class BeerRepository : IBeerRepository
    {
        public async Task<IReadOnlyList<Beer>> List()
        {
            var client = new RestClient("http://api.brewerydb.com/v2/");
            var request = new RestRequest("beers")
            {
                Parameters =
                {
                    new Parameter
                    {
                        Name = "key",
                        Value = "ce7f4048bcd9f69c835990f84b0c669b",
                        Type = ParameterType.QueryString
                    }
                }
            };
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            return null;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}