using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureDevOpsRESTClient
{
    public class AccessControlListsService(RestClient restClient)
    {
        public async Task<Result<string>> ReadAsString(Guid securityNamespaceId, string descriptor)
        {
            var url =
                $"https://dev.azure.com/{restClient.OrgName}/_apis/accesscontrollists/" +
                $"{securityNamespaceId}?descriptors={descriptor}" +
                $"&recurse=true&includeExtendedInfo=True&api-version=7.2-preview.1";

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
