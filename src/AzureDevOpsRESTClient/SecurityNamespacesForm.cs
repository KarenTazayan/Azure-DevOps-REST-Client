global using static AzureDevOpsRESTClient.Extensions;

using AzureDevOpsRESTClient.Common;

namespace AzureDevOpsRESTClient;

public partial class SecurityNamespacesForm : Form
{
  private readonly RestClient _restClient;

  public SecurityNamespacesForm(RestClient restClient)
  {
    _restClient = restClient;
    InitializeComponent();
  }

  // ReSharper disable once AsyncVoidEventHandlerMethod
  private async void SecurityNamespacesForm_Load(object sender, EventArgs e)
  {
    await HandleEventAsync(SecurityNamespacesFormLoadAsync);
  }

  private async Task SecurityNamespacesFormLoadAsync()
  {
    var securityNamespaces = new SecurityNamespacesService(_restClient!);
    var namespaces = await securityNamespaces.GetAllAsString();

    securityNamespacesTextBox.Text = namespaces.IsSuccess ? namespaces.Value : namespaces.FailMessage;
  }
}