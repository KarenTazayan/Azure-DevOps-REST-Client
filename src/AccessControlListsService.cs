using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    public class AccessControlListsService(RestClient restClient)
    {
        public async Task<Result<string>> ReadAsString(Guid securityNamespaceId, string descriptor)
        {
            var url =
                $"https://dev.azure.com/{restClient.OrgName}/_apis/accesscontrollists/" +
                $"{securityNamespaceId}?descriptors={descriptor}" +
                $"&recurse=true&includeExtendedInfo=True&{ApiVersion}";

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
