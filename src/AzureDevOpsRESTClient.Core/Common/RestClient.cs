using System.Net.Http.Headers;
using System.Text;

namespace AzureDevOpsRESTClient.Common;

public class RestClient(string orgName, string personalAccessToken)
{
  public string OrgName => orgName;

  public HttpClient GetHttpClient()
  {
    var client = new HttpClient();
            
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
      Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalAccessToken}")));

    return client;
  }
}