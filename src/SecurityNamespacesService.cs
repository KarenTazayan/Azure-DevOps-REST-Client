using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureDevOpsRESTClient
{
    public record SecurityNamespaces
    {
        public int Count { get; init; }

        public SecurityNamespace[] Value { get; init; }
    }

    internal class SecurityNamespacesService(RestClient restClient)
    {
        public async Task<Result<string>> GetAllAsString()
        {
            var url = $"https://dev.azure.com/{restClient.OrgName}/_apis/securitynamespaces?api-version=7.2-preview.1";

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

        public async Task<Result<SecurityNamespaces>> GetAll()
        {
            var result = await GetAllAsString();
            if (result.IsSuccess)
            {
                var securityNamespaces = JsonConvert.DeserializeObject<SecurityNamespaces>(result.Value);

                if (securityNamespaces != null)
                {
                    return Result.CreateSuccess(securityNamespaces);
                }
                else
                {
                    const string message = $"Can't deserialize {nameof(securityNamespaces)} object.";
                    return Result.CreateFail<SecurityNamespaces>(message);
                }
            }
            else
            {
                return Result.CreateFail<SecurityNamespaces>(result.FailMessage);
            }
        }
    }
}
