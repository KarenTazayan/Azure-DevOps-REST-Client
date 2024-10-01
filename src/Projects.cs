using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    internal class Projects(RestClient restClient)
    {
        public async Task<Result<string>> GetAll()
        {
            var url = $"https://dev.azure.com/{restClient.OrgName}/_apis/projects?{ApiVersion}";

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
