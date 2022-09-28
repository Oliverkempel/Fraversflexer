using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace API_Fun
{
    internal class AmazonRequester
    {

        public RestResponse searchAmazon(string searchTerm, string APIKey)
        {
            var options = new RestClientOptions("https://api.rainforestapi.com/request") {
                MaxTimeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddParameter("api_key" , APIKey);
            request.AddParameter("type", "search");
            request.AddParameter("amazon_domain", "amazon.de");
            request.AddParameter("search_term", searchTerm);
            //request.AddParameter("category_id", catID);
            request.AddParameter("sort_by", "price_low_to_high");
            request.AddParameter("exclude_sponsered", "true");
            request.AddParameter("language", "en_US");
            request.AddParameter("customer_location", "de");
            request.AddParameter("output", "json");
            request.AddParameter("include_html", "false");


            RestResponse yay = new RestResponse();
            yay = client.Execute(request);

            return yay;
        }

    }
}
