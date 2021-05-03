using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using SearchFight.Common;
using Newtonsoft.Json.Linq;
namespace SearchFight.Services
{
    public class BingEngine : IEngine
    {
        public string name => "Bing";
        public string endpoint => ConfigurationManager.AppSetting["BingEngine:Endpoint"]
            .Replace("{CCID}", ConfigurationManager.AppSetting["BingEngine:CustomConfigID"]);
        private HttpClient _httpClient = new HttpClient() { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", ConfigurationManager.AppSetting["BingEngine:SubscriptionKey"] } } };
        public int searchResultsCount(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException("Input parameter is not valid", nameof(query));
            try
            {
                var response = _httpClient.GetStringAsync(endpoint.Replace("{query}", query)).Result;
                var result = JObject.Parse(response);
                return Convert.ToInt32(result["webPages"]["totalEstimatedMatches"]);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
}