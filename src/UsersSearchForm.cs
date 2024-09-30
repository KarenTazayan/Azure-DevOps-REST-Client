namespace AzureDevOpsRESTClient
{
    public partial class UsersSearchForm : Form
    {
        private readonly RestClient _restClient;

        private readonly SearchType[] _searchTypes = new[]
        {
            new SearchType {Id = 0, Text = SearchType.Descriptor},
            new SearchType {Id = 1, Text = SearchType.UserEntitlements},
            new SearchType {Id = 2, Text = SearchType.UserPrincipal},
            new SearchType {Id = 3, Text = SearchType.Email}
        };

        public UsersSearchForm(RestClient restClient)
        {
            _restClient = restClient;
            InitializeComponent();
            searchTypesComboBox.DataSource = _searchTypes;
            searchTypesComboBox.DisplayMember = nameof(SearchType.Text);
        }

        private record SearchType
        {
            public const string Descriptor = "Descriptor";
            public const string UserPrincipal = "User Principal";
            public const string Email = "Email";
            public const string UserEntitlements = "UserEntitlements";

            public int Id { get; init; }
            public string Text { get; init; }
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
