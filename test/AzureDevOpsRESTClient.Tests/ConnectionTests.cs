namespace AzureDevOpsRESTClient.Tests;

public class ConnectionTests(AzureDevOpsFixture fixture)
{
  [Fact]
  public async Task ClientCanConnectWithValidCredentials()
  {
    var projects = new Projects(fixture.Client);
    var result = await projects.GetAll();
    
    Assert.True(result.IsSuccess);
  }
}