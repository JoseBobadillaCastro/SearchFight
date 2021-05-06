using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using SearchFight.Common;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
namespace SearchFight.Services
{
    public class GoogleEngine : IEngine
    {
        public string name => "Google";
        public string endpoint => ConfigurationManager.AppSetting["GoogleEngine:Endpoint"]
            .Replace("{APIKey}", ConfigurationManager.AppSetting["GoogleEngine:APIKey"])
            .Replace("{CseID}", ConfigurationManager.AppSetting["GoogleEngine:CustomSearchEngineID"]);
        private HttpClient _httpClient = new HttpClient();
        public async Task<int> searchResultsCount(string query) 
        {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException("Input parameter is not valid", nameof(query));
            try 
            {
                var response = await _httpClient.GetAsync(endpoint.Replace("{query}",query));
                var result = JObject.Parse(await response.Content.ReadAsStringAsync());
                return Convert.ToInt32(result["queries"]["request"][0]["totalResults"]);
            }
            catch (Exception ex) 
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
}