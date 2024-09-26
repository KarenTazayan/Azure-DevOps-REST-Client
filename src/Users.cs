using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace AzureDevOpsRESTClient
{
    internal record UsersResponse
    {
        public int Count { get; init; }

        [JsonProperty("value")]
        public User[] Users { get; init; }
    }

    internal class Users(RestClient restClient)
    {
        public string ReadIdentities(string filter = "")
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/_apis/graph/users?api-version=7.2-preview.1";

            if (!string.IsNullOrWhiteSpace(filter))
            {
                url = url + $"$filter=mailAddress eq '{filter}'";
            }

            var httpClient = restClient.GetHttpClient();
            using var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result; 
                return JToken.Parse(json).ToString(Formatting.Indented);
            }
            else
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                return $"Failed to connect: {response.ReasonPhrase}";
            }
        }
    }
}
