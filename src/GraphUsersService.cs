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

    internal class GraphUsersService(RestClient restClient)
    {
        public string ReadIdentities()
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/_apis/graph/users?api-version=7.2-preview.1";

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

        public async Task<Result<string>> Get(string userDescriptor)
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}" +
                      $"/_apis/graph/users/{userDescriptor}?api-version=7.1-preview.1";

            var httpClient = restClient.GetHttpClient();
            using var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Result.CreateSuccess(JToken.Parse(json).ToString(Formatting.Indented));
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }
    }
}
