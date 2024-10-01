using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    public record Identities(Identity[] Value)
    {
        public int Count { get; init; }
    }

    public class IdentitiesService(RestClient restClient)
    {
        public async Task<Result<string>> ReadIdentityByEmailAsString(string email)
        {
            var url = $"https://vssps.dev.azure.com/{restClient.OrgName}/" +
                      $"_apis/identities?searchFilter=General&filterValue={email}" +
                      $"&queryMembership=expanded&{ApiVersion}";

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

        public async Task<Result<Identity>> ReadIdentityByEmail(string email)
        {
            var result = await ReadIdentityByEmailAsString(email);

            var identities = JsonConvert.DeserializeObject<Identities>(result.Value);

            if (identities!= null)
            {
                return identities.Count switch
                {
                    1 => Result.CreateSuccess(identities.Value[0]),
                    0 => Result.CreateFail<Identity>("Identity not found."),
                    _ => Result.CreateFail<Identity>("More than one identity found.")
                };
            }
            else
            {
                const string message = $"Can't deserialize {nameof(Identities)} object.";
                return Result.CreateFail<Identity>(message);
            }
        }
    }
}
