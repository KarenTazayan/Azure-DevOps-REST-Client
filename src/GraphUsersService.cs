using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    internal record UsersResponse([property: JsonProperty("value")] User[] Users)
    {
        public int Count { get; init; }
    }

    internal class GraphUsersService(RestClient restClient)
    {
        public async Task<string> ReadIdentities()
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/_apis/graph/users?{ApiVersion}";

            var httpClient = restClient.GetHttpClient();
            using var response =  await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync(); 
                return JToken.Parse(json).ToString(Formatting.Indented);
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return $"Failed to connect: {response.ReasonPhrase}";
            }
        }

        public async Task<Result<string>> Get(string userDescriptor)
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}" +
                      $"/_apis/graph/users/{userDescriptor}?{ApiVersion}";

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
