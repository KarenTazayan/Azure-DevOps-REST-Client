using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace AzureDevOpsRESTClient
{
    internal class SubjectQuery(RestClient restClient)
    {
        public Result<string> Get(string query)
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/_apis/graph/subjectquery?api-version=7.2-preview.1";
            var httpClient = restClient.GetHttpClient();

            var body = $"{{query: \"{query}\", subjectKind: [\"User\"]}}";

            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

            using var response = httpClient.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var formattedJson = JToken.Parse(json).ToString(Formatting.Indented);
                
                return Result.CreateSuccess(formattedJson);
            }
            else
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }
    }
}
