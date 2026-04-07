global using static AzureDevOpsRESTClient.Extensions;

using AzureDevOpsRESTClient.Common;

namespace AzureDevOpsRESTClient;

public partial class UserEntitlementsForm : Form
{
  private readonly RestClient _restClient;

  public UserEntitlementsForm(RestClient restClient)
  {
    _restClient = restClient;
    InitializeComponent();
  }

  // ReSharper disable once AsyncVoidEventHandlerMethod
  private async void addButton_Click(object sender, EventArgs e)
  {
    await HandleEventAsync(AddButtonClickAsync);
  }

  private async Task AddButtonClickAsync()
  {
    addButton.Enabled = false;
    try
    {
      var userEntitlementsService = new UserEntitlementsService(_restClient!);
      var userEntitlementsResult = await userEntitlementsService.Add(inputTextBox.Text);
      outputTextBox.Text = userEntitlementsResult.IsSuccess
        ? userEntitlementsResult.Value
        : userEntitlementsResult.FailMessage;
    }
    finally
    {
      addButton.Enabled = true;
    }
  }
}