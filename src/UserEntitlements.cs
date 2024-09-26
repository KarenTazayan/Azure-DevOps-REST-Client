using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureDevOpsRESTClient
{
    internal class UserEntitlements(RestClient restClient)
    {
        public async Task<Result<string>> GetAll(string userId)
        {
            var url = $"https://vsaex.dev.azure.com/{restClient.OrgName}/_apis/userentitlements/{userId}" +
                      "?api-version=7.2-preview.4";

            var httpClient = restClient.GetHttpClient();
            using var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return Result.CreateSuccess(JToken.Parse(json).ToString(Formatting.Indented));
            }
            else
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }
    }
}
