using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;

namespace API_Fun
{
    internal class MapsRequesters
    {

        public RestResponse searchLocations(string searchQuery)
        {
            var options = new RestClientOptions("https://maps.googleapis.com/maps/api/place/textsearch/json")
            {
                MaxTimeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddQueryParameter("query", searchQuery);
            request.AddQueryParameter("key", "AIzaSyB_2grOxYz8m3tfMlKo96br6amGmAC6aBE");

            var response = client.Execute(request);

            return response;
        }

    }
}
