using Newtonsoft.Json;

namespace AzureDevOpsRESTClient
{
    public partial class Main : Form
    {
        private RestClient? _restClient;

        public Main()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(orgNameTextBox.Text) || string.IsNullOrWhiteSpace(patTextBox.Text))
            {
                MessageBox.Show(@"Organisation name and PAT are required.");
                return;
            }

            _restClient = new RestClient(orgNameTextBox.Text, patTextBox.Text);
            var projects = new Projects(_restClient!);
            var result = await projects.GetAll();
            if (result.IsSuccess)
            {
                loginButton.Enabled = false;
                usersGroupBox.Enabled = true;
                consoleTextBox.Text = result.Value;
            }
            else
            {
                MessageBox.Show(@"Failed to connect");
            }
        }

        private async void readIdentitiesButton_Click(object sender, EventArgs e)
        {
            var users = new GraphUsersService(_restClient!);
            var identities = await users.ReadIdentities();
            consoleTextBox.Text = identities;
        }

        private async void readUserByFilterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userFilterTextBox.Text))
            {
                MessageBox.Show(@"Please provide the filter value.");
                return;
            }

            var subjectQuery = new SubjectQuery(_restClient!);
            var identities = await subjectQuery.Get(userFilterTextBox.Text);

            if (!identities.IsSuccess)
            {
                MessageBox.Show(identities.FailMessage);
            }
            else
            {
                consoleTextBox.Text = identities.Value;
                var usersResponse = JsonConvert.DeserializeObject<UsersResponse>(identities.Value);
                usersDataGridView.DataSource = usersResponse!.Users;
            }
        }

        private void usersDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            var user = (User)dataGridView.Rows[e.RowIndex].DataBoundItem;
            var userForm = new UserForm(user, _restClient!, userServicePrincipalCheckBox.CheckState == CheckState.Checked);
            userForm.Show();
        }

        private void securityNamespacesButton_Click(object sender, EventArgs e)
        {
            var form = new SecurityNamespacesForm(_restClient!);
            form.Show();
        }

        private void createNewUserWithOriginIdButton_Click(object sender, EventArgs e)
        {
            var userEntitlementsForm = new UserEntitlementsForm(_restClient!);
            userEntitlementsForm.Show();
        }

        private void advancedSearchButton_Click(object sender, EventArgs e)
        {
            var usersSearchForm = new UsersSearchForm(_restClient!);
            usersSearchForm.Show();
        }
    }
}
