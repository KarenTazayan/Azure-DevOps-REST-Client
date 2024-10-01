using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    internal class Memberships(RestClient restClient)
    {
        public async Task<Result<string>> GetAllMemberships(string subjectDescriptor)
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/" +
                      $"_apis/graph/Memberships/{subjectDescriptor}?{ApiVersion}";

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
