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

        private void readIdentitiesButton_Click(object sender, EventArgs e)
        {
            var users = new Users(_restClient!);
            var identities = users.ReadIdentities(userFilterTextBox.Text);
            consoleTextBox.Text = identities;
        }

        private void readUserByFilterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userFilterTextBox.Text))
            {
                MessageBox.Show(@"Please provide the filter value.");
                return;
            }

            var subjectQuery = new SubjectQuery(_restClient!);
            var identities = subjectQuery.Get(userFilterTextBox.Text);

            if (!identities.IsSuccess)
            {
                MessageBox.Show(identities.FailMessage);
            }

            consoleTextBox.Text = identities.Value;

            var usersResponse = JsonConvert.DeserializeObject<UsersResponse>(identities.Value);
            usersDataGridView.DataSource = usersResponse!.Users;
        }

        private void usersDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            var user = (User)dataGridView.Rows[e.RowIndex].DataBoundItem;
            var userForm = new UserForm(user, _restClient!);
            userForm.Show();
        }

        private void securityNamespacesButton_Click(object sender, EventArgs e)
        {
            var form = new SecurityNamespacesForm(_restClient!);
            form.Show();
        }
    }
}
