using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureDevOpsRESTClient
{
    internal class UserProfiles(RestClient restClient)
    {
        public Result<string> Get(string userId)
        {
            var url = $"https://app.vssps.visualstudio.com/_apis/profile/profiles/{userId}?api-version=7.2-preview.3";

            var httpClient = restClient.GetHttpClient();
            using var response =  httpClient.GetAsync(url).Result;
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
