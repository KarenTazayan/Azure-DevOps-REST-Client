using System.Net.Http.Headers;

namespace AzureDevOpsRESTClient
{
    public class RestClient(string orgName, string personalAccessToken)
    {
        public string OrgName => orgName;

        public HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes($":{personalAccessToken}")));

            return client;
        }
    }
}
