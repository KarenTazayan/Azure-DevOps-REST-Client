using Syncfusion.WinForms.DataGrid;
using System.ComponentModel;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;

namespace AzureDevOpsRESTClient
{
    public partial class UserForm : Form
    {
        private readonly User _user;
        private readonly RestClient _restClient;
        private Identity? _userIdentity;

        public UserForm(User user, RestClient restClient)
        {
            _user = user;
            _restClient = restClient;
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            Text = $@"DisplayName: {_user.DisplayName} MailAddress: {_user.MailAddress}";
            membershipsTabPage.Enter += MembershipsTabPage_Enter;
            IdentityTabPage.Enter += IdentityTabPage_Enter;
            userEntitlementsTabPage.Enter += UserEntitlementsTabPage_Enter;
            accessControlListsTabPage.Enter += AccessControlListsTabPage_Enter;
        }

        private void AccessControlListsTabPage_Enter(object? sender, EventArgs e)
        {
        }

        private async void UserEntitlementsTabPage_Enter(object? sender, EventArgs e)
        {
            var userEntitlements = new UserEntitlements(_restClient);
            var result = await userEntitlements.GetAll(_user.Descriptor);
            userEntitlementsTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
        }

        private async void IdentityTabPage_Enter(object? sender, EventArgs e)
        {
            userTabControl.Enabled = false;
            var identities = new IdentitiesService(_restClient);
            var result = await identities.ReadIdentityByEmailAsString(_user.MailAddress);
            identityTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;

            var identityResult = await identities.ReadIdentityByEmail(_user.MailAddress);
            if (identityResult.IsSuccess)
            {
                _userIdentity = identityResult.Value;
            }
            else
            {
                MessageBox.Show(identityResult.FailMessage);
            }
            userTabControl.Enabled = true;
        }

        private async void MembershipsTabPage_Enter(object? sender, EventArgs e)
        {
            var memberships = new Memberships(_restClient);
            var result = await memberships.GetAllMemberships(_user.Descriptor);
            membershipsTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
        }

        private void userTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void LoadAccessControlListButton_Click(object sender, EventArgs e)
        {
            var securityNamespacesService = new SecurityNamespacesService(_restClient);
            var result = await securityNamespacesService.GetAll();

            if (result.IsSuccess)
            {
                var securityNamespaces = result.Value;
                var list = new BindingList<SecurityNamespace>(securityNamespaces.Value);
                securityNamespacesSfDataGrid.DataSource = list;
                //securityNamespacesDataGridView.Refresh();
            }
            else
            {
                accessControlListTextBox.Text = result.FailMessage;
            }
        }

        private async void securityNamespacesDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            var securityNamespace = (SecurityNamespace)dataGridView.Rows[e.RowIndex].DataBoundItem;
            var accessControlListsService = new AccessControlListsService(_restClient);
            var result = await accessControlListsService.ReadAsString(securityNamespace.NamespaceId, _userIdentity!.Descriptor);

            accessControlListTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
        }

        private void securityNamespacesSfDataGrid_DrawCell(object sender, DrawCellEventArgs e)
        {
            if (securityNamespacesSfDataGrid.ShowRowHeader && e.RowIndex != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    e.DisplayText = e.RowIndex.ToString();
                }

            }
        }

        private async void securityNamespacesSfDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            var securityNamespace = (SecurityNamespace)e.DataRow.RowData;
            var accessControlListsService = new AccessControlListsService(_restClient);
            var result = await accessControlListsService.ReadAsString(securityNamespace.NamespaceId, _userIdentity!.Descriptor);

            accessControlListTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;

            var grid = (SfDataGrid)sender;
            var detailsView = grid.GetDetailsViewGrid(e.DataRow.RowIndex + 1);
            //detailsView.Columns.Add(new GridColumn()
            //{
            //    MappingName = "Test 1",
            //    HeaderText = "Test 1"
            //});
        }

        private void securityNamespacesSfDataGrid_AutoGeneratingRelations(object sender, AutoGeneratingRelationsEventArgs e)
        {
            e.GridViewDefinition.DataGrid.AllowSorting = true;
            e.GridViewDefinition.DataGrid.AllowFiltering = true;
            e.GridViewDefinition.DataGrid.AllowResizingColumns = true;
            e.GridViewDefinition.DataGrid.AllowEditing = false;
        }
    }
}
