using Newtonsoft.Json;

namespace AzureDevOpsRESTClient
{
    internal class UsersService(RestClient restClient)
    {
        public async Task<Result<User>> CreateNew(string originId)
        {
            if(string.IsNullOrWhiteSpace(originId)) return Result.CreateFail<User>("OriginId is required.");

            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/_apis/graph/users?api-version=7.1-preview.1";
            var httpClient = restClient.GetHttpClient();

            // 'aad' for Azure Active Directory, or 'vsts' for local users
            var body = $"{{originId: \"{originId}\", origin: [\"aad\"]}}";

            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var json =  await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(json);

                return user == null ? 
                    Result.CreateFail<User>("Failed to deserialize User object.") : 
                    Result.CreateSuccess(user);
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<User>($"Failed to connect: {response.ReasonPhrase}");
            }
        }
    }
}
