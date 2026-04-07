using AzureDevOpsRESTClient.Common;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System.ComponentModel;

namespace AzureDevOpsRESTClient;

public partial class UserForm : Form
{
  private readonly User _user;
  private readonly RestClient _restClient;
  private readonly bool _useUserServicePrincipal;
  private Identity? _userIdentity;

  public UserForm(User user, RestClient restClient, bool useUserServicePrincipal)
  {
    _user = user;
    _restClient = restClient;
    _useUserServicePrincipal = useUserServicePrincipal;
    InitializeComponent();
  }

  private void UserForm_Load(object sender, EventArgs e)
  {
    Text = $@"DisplayName: {_user.DisplayName} MailAddress: {_user.MailAddress}";
    membershipsTabPage.Enter += MembershipsTabPage_Enter;
    IdentityTabPage.Enter += IdentityTabPage_Enter;
    userEntitlementsTabPage.Enter += UserEntitlementsTabPage_Enter;
  }

  // ReSharper disable once AsyncVoidEventHandlerMethod
  private async void UserEntitlementsTabPage_Enter(object? sender, EventArgs e)
  {
    await HandleEventAsync(UserEntitlementsTabPageEnterAsync);
  }

  // ReSharper disable once AsyncVoidEventHandlerMethod
  private async void IdentityTabPage_Enter(object? sender, EventArgs e)
  {
      await HandleEventAsync(IdentityTabPageEnterAsync);
  }

  // ReSharper disable once AsyncVoidEventHandlerMethod
  private async void MembershipsTabPage_Enter(object? sender, EventArgs e)
  {
    await HandleEventAsync(MembershipsTabPageEnterAsync);
  }


  // ReSharper disable once AsyncVoidEventHandlerMethod
  private async void LoadAccessControlListButton_Click(object sender, EventArgs e)
  {
    await HandleEventAsync(LoadAccessControlListButtonClickAsync);
  }

  private async void securityNamespacesDataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
  {
    try
    {
      await SecurityNamespacesDataGridViewRowHeaderMouseDoubleClickAsync(sender, e);
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, @"Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
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
    try
    {
      await SecurityNamespacesSfDataGridCellDoubleClickAsync(sender, e);
    }
    catch (Exception ex)
    {
      MessageBox.Show(ex.Message, @"Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  private async Task UserEntitlementsTabPageEnterAsync()
  {
    var userEntitlements = new UserEntitlementsService(_restClient);
    var result = await userEntitlements.GetAll(_user.Descriptor);
    userEntitlementsTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
  }

  private async Task IdentityTabPageEnterAsync()
  {
    userTabControl.Enabled = false;
    try
    {
      var identities = new IdentitiesService(_restClient);
      var searchEmail = _useUserServicePrincipal ? _user.PrincipalName : _user.MailAddress;

      var result = await identities.ReadIdentityByEmailAsString(searchEmail);
      identityTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;

      var identityResult = await identities.ReadIdentityByEmail(searchEmail);
      if (identityResult.IsSuccess)
      {
        _userIdentity = identityResult.Value;
      }
      else
      {
        MessageBox.Show(identityResult.FailMessage);
      }
    }
    finally
    {
      userTabControl.Enabled = true;
    }
  }

  private async Task MembershipsTabPageEnterAsync()
  {
    var memberships = new Memberships(_restClient);
    var result = await memberships.GetAllMemberships(_user.Descriptor);
    membershipsTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
  }

  private async Task LoadAccessControlListButtonClickAsync()
  {
    var securityNamespacesService = new SecurityNamespacesService(_restClient);
    var result = await securityNamespacesService.GetAll();

    if (result.IsSuccess)
    {
      SecurityNamespaces securityNamespaces = result.Value;
      var list = new BindingList<SecurityNamespace>(securityNamespaces.Value);
      securityNamespacesSfDataGrid.DataSource = list;
      //securityNamespacesDataGridView.Refresh();
    }
    else
    {
      accessControlListTextBox.Text = result.FailMessage;
    }
  }

  private async Task SecurityNamespacesDataGridViewRowHeaderMouseDoubleClickAsync(object sender, DataGridViewCellMouseEventArgs e)
  {
    var dataGridView = (DataGridView)sender;
    var securityNamespace = (SecurityNamespace)dataGridView.Rows[e.RowIndex].DataBoundItem;
    var accessControlListsService = new AccessControlListsService(_restClient);
    var result = await accessControlListsService.ReadAsString(securityNamespace.NamespaceId, _userIdentity!.Descriptor);

    accessControlListTextBox.Text = result.IsSuccess ? result.Value : result.FailMessage;
  }

  private async Task SecurityNamespacesSfDataGridCellDoubleClickAsync(object sender, CellClickEventArgs e)
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