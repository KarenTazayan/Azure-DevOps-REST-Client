namespace AzureDevOpsRESTClient
{
    public partial class UserEntitlementsForm : Form
    {
        private readonly RestClient _restClient;

        public UserEntitlementsForm(RestClient restClient)
        {
            _restClient = restClient;
            InitializeComponent();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            var userEntitlementsService = new UserEntitlementsService(_restClient!);
            var userEntitlementsResult = await userEntitlementsService.Add(inputTextBox.Text);
            outputTextBox.Text = userEntitlementsResult.IsSuccess ?
                userEntitlementsResult.Value : userEntitlementsResult.FailMessage;
            addButton.Enabled = true;
        }
    }
}
