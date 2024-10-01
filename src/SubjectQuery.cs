using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    internal class SubjectQuery(RestClient restClient)
    {
        public async Task<Result<string>> Get(string query)
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/_apis/graph/subjectquery?{ApiVersion}";
            var httpClient = restClient.GetHttpClient();

            var body = $"{{query: \"{query}\", subjectKind: [\"User\"]}}";

            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var formattedJson = JToken.Parse(json).ToString(Formatting.Indented);
                
                return Result.CreateSuccess(formattedJson);
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }
    }
}
