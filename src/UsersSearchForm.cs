namespace AzureDevOpsRESTClient
{
    public partial class UsersSearchForm : Form
    {
        private readonly RestClient _restClient;

        private readonly SearchType[] _searchTypes = new[]
        {
            new SearchType (0,SearchType.Descriptor),
            new SearchType (1, SearchType.UserEntitlements),
            new SearchType (2, SearchType.UserPrincipal),
            new SearchType (3, SearchType.Email)
        };

        public UsersSearchForm(RestClient restClient)
        {
            _restClient = restClient;
            InitializeComponent();
            searchTypesComboBox.DataSource = _searchTypes;
            searchTypesComboBox.DisplayMember = nameof(SearchType.Text);
        }

        private record SearchType(int Id, string Text)
        {
            public const string Descriptor = "Descriptor";
            public const string UserPrincipal = "User Principal";
            public const string Email = "Email";
            public const string UserEntitlements = "UserEntitlements";
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTypesComboBox.SelectedValue is SearchType { Text: SearchType.Descriptor })
            {
                var graphUsersService = new GraphUsersService(_restClient);
                var result = await graphUsersService.Get(searchTextBox.Text);

                consoleTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
            }

            if (searchTypesComboBox.SelectedItem is SearchType { Text: SearchType.UserEntitlements })
            {
                var userEntitlementsService = new UserEntitlementsService(_restClient);
                var result = await userEntitlementsService.Search(searchTextBox.Text);
                consoleTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
            }
        }
    }
}
