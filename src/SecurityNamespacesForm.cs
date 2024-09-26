using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDevOpsRESTClient
{
    public partial class SecurityNamespacesForm : Form
    {
        private readonly RestClient _restClient;

        public SecurityNamespacesForm(RestClient restClient)
        {
            _restClient = restClient;
            InitializeComponent();
        }

        private async void SecurityNamespacesForm_Load(object sender, EventArgs e)
        {
            var securityNamespaces = new SecurityNamespacesService(_restClient!);
            var namespaces = await securityNamespaces.GetAllAsString();

            if (namespaces.IsSuccess)
            {
                securityNamespacesTextBox.Text = namespaces.Value;
            }
            else
            {
                securityNamespacesTextBox.Text = namespaces.FailMessage;
            }
        }
    }
}
