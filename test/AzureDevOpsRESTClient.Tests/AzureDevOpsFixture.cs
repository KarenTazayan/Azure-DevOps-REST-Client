using AzureDevOpsRESTClient.Common;
using AzureDevOpsRESTClient.Tests;
using Microsoft.Extensions.Configuration;

[assembly: AssemblyFixture(typeof(AzureDevOpsFixture))]

namespace AzureDevOpsRESTClient.Tests;

public sealed class AzureDevOpsFixture
{
  public RestClient Client { get; private set; }
  
  private IConfiguration Configuration { get; }

  public AzureDevOpsFixture()
  {
    Configuration = new ConfigurationBuilder()
      .AddUserSecrets<AzureDevOpsFixture>(optional: true)
      .Build();

    var orgName = Configuration["AzureDevOpsOrganisationName"];

    if (string.IsNullOrWhiteSpace(orgName))
    {
      orgName = Environment.GetEnvironmentVariable("AZURE_DEV_OPS_ORGANISATION_NAME");
      if (string.IsNullOrWhiteSpace(orgName))
      {
        throw new InvalidOperationException("AzureDevOpsOrganisationName cannot be empty or whitespace.");
      }
    }

    var pat = Configuration["AzureDevOpsPersonalAccessToken"];

    if (string.IsNullOrWhiteSpace(pat))
    {
      pat = Environment.GetEnvironmentVariable("AZURE_DEV_OPS_PERSONAL_ACCESS_TOKEN");
      if (string.IsNullOrWhiteSpace(pat))
      {
        throw new InvalidOperationException("AzureDevOpsPersonalAccessToken cannot be empty or whitespace.");
      }
    }

    Client = new RestClient(orgName, pat);
  }
}

