namespace AzureDevOpsRESTClient
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userTabControl = new TabControl();
            IdentityTabPage = new TabPage();
            identityTextBox = new TextBox();
            membershipsTabPage = new TabPage();
            membershipsTextBox = new TextBox();
            userEntitlementsTabPage = new TabPage();
            userEntitlementsTextBox = new TextBox();
            accessControlListsTabPage = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            securityNamespacesSfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            accessControlListTextBox = new TextBox();
            LoadAccessControlListButton = new Button();
            userTabControl.SuspendLayout();
            IdentityTabPage.SuspendLayout();
            membershipsTabPage.SuspendLayout();
            userEntitlementsTabPage.SuspendLayout();
            accessControlListsTabPage.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)securityNamespacesSfDataGrid).BeginInit();
            SuspendLayout();
            // 
            // userTabControl
            // 
            userTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userTabControl.Controls.Add(IdentityTabPage);
            userTabControl.Controls.Add(membershipsTabPage);
            userTabControl.Controls.Add(userEntitlementsTabPage);
            userTabControl.Controls.Add(accessControlListsTabPage);
            userTabControl.Location = new Point(12, 27);
            userTabControl.Name = "userTabControl";
            userTabControl.SelectedIndex = 0;
            userTabControl.Size = new Size(776, 411);
            userTabControl.SizeMode = TabSizeMode.FillToRight;
            userTabControl.TabIndex = 0;
            userTabControl.SelectedIndexChanged += userTabControl_SelectedIndexChanged;
            // 
            // IdentityTabPage
            // 
            IdentityTabPage.BackColor = Color.Gray;
            IdentityTabPage.Controls.Add(identityTextBox);
            IdentityTabPage.Location = new Point(4, 24);
            IdentityTabPage.Name = "IdentityTabPage";
            IdentityTabPage.Size = new Size(768, 383);
            IdentityTabPage.TabIndex = 2;
            IdentityTabPage.Text = "Identity";
            // 
            // identityTextBox
            // 
            identityTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            identityTextBox.Location = new Point(3, 3);
            identityTextBox.Multiline = true;
            identityTextBox.Name = "identityTextBox";
            identityTextBox.ScrollBars = ScrollBars.Both;
            identityTextBox.Size = new Size(762, 377);
            identityTextBox.TabIndex = 0;
            // 
            // membershipsTabPage
            // 
            membershipsTabPage.BackColor = Color.Gray;
            membershipsTabPage.Controls.Add(membershipsTextBox);
            membershipsTabPage.Location = new Point(4, 24);
            membershipsTabPage.Name = "membershipsTabPage";
            membershipsTabPage.Padding = new Padding(3);
            membershipsTabPage.Size = new Size(768, 383);
            membershipsTabPage.TabIndex = 0;
            membershipsTabPage.Text = "Memberships";
            // 
            // membershipsTextBox
            // 
            membershipsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            membershipsTextBox.Location = new Point(3, 3);
            membershipsTextBox.Multiline = true;
            membershipsTextBox.Name = "membershipsTextBox";
            membershipsTextBox.ScrollBars = ScrollBars.Both;
            membershipsTextBox.Size = new Size(762, 377);
            membershipsTextBox.TabIndex = 0;
            // 
            // userEntitlementsTabPage
            // 
            userEntitlementsTabPage.BackColor = Color.Gray;
            userEntitlementsTabPage.Controls.Add(userEntitlementsTextBox);
            userEntitlementsTabPage.Location = new Point(4, 24);
            userEntitlementsTabPage.Name = "userEntitlementsTabPage";
            userEntitlementsTabPage.Padding = new Padding(3);
            userEntitlementsTabPage.Size = new Size(768, 383);
            userEntitlementsTabPage.TabIndex = 1;
            userEntitlementsTabPage.Text = "User Entitlements";
            // 
            // userEntitlementsTextBox
            // 
            userEntitlementsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userEntitlementsTextBox.Location = new Point(3, 6);
            userEntitlementsTextBox.Multiline = true;
            userEntitlementsTextBox.Name = "userEntitlementsTextBox";
            userEntitlementsTextBox.ScrollBars = ScrollBars.Both;
            userEntitlementsTextBox.Size = new Size(762, 374);
            userEntitlementsTextBox.TabIndex = 0;
            // 
            // accessControlListsTabPage
            // 
            accessControlListsTabPage.BackColor = Color.LightGray;
            accessControlListsTabPage.Controls.Add(tableLayoutPanel1);
            accessControlListsTabPage.Controls.Add(LoadAccessControlListButton);
            accessControlListsTabPage.Location = new Point(4, 24);
            accessControlListsTabPage.Name = "accessControlListsTabPage";
            accessControlListsTabPage.Size = new Size(768, 383);
            accessControlListsTabPage.TabIndex = 3;
            accessControlListsTabPage.Text = "AccessControlLists";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(securityNamespacesSfDataGrid, 0, 0);
            tableLayoutPanel1.Controls.Add(accessControlListTextBox, 0, 1);
            tableLayoutPanel1.Location = new Point(6, 32);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(756, 348);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // securityNamespacesSfDataGrid
            // 
            securityNamespacesSfDataGrid.AccessibleName = "Table";
            securityNamespacesSfDataGrid.AllowEditing = false;
            securityNamespacesSfDataGrid.AllowFiltering = true;
            securityNamespacesSfDataGrid.AutoGenerateRelations = true;
            securityNamespacesSfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            securityNamespacesSfDataGrid.Dock = DockStyle.Fill;
            securityNamespacesSfDataGrid.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            securityNamespacesSfDataGrid.Location = new Point(3, 3);
            securityNamespacesSfDataGrid.Name = "securityNamespacesSfDataGrid";
            securityNamespacesSfDataGrid.ShowBusyIndicator = true;
            securityNamespacesSfDataGrid.ShowRowHeader = true;
            securityNamespacesSfDataGrid.ShowSortNumbers = true;
            securityNamespacesSfDataGrid.Size = new Size(750, 168);
            securityNamespacesSfDataGrid.Style.BorderColor = Color.FromArgb(100, 100, 100);
            securityNamespacesSfDataGrid.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            securityNamespacesSfDataGrid.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            securityNamespacesSfDataGrid.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            securityNamespacesSfDataGrid.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            securityNamespacesSfDataGrid.TabIndex = 2;
            securityNamespacesSfDataGrid.Text = "sfDataGrid1";
            securityNamespacesSfDataGrid.DrawCell += securityNamespacesSfDataGrid_DrawCell;
            securityNamespacesSfDataGrid.CellDoubleClick += securityNamespacesSfDataGrid_CellDoubleClick;
            securityNamespacesSfDataGrid.AutoGeneratingRelations += securityNamespacesSfDataGrid_AutoGeneratingRelations;
            // 
            // accessControlListTextBox
            // 
            accessControlListTextBox.Dock = DockStyle.Fill;
            accessControlListTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            accessControlListTextBox.Location = new Point(3, 177);
            accessControlListTextBox.Multiline = true;
            accessControlListTextBox.Name = "accessControlListTextBox";
            accessControlListTextBox.ScrollBars = ScrollBars.Both;
            accessControlListTextBox.Size = new Size(750, 168);
            accessControlListTextBox.TabIndex = 1;
            // 
            // LoadAccessControlListButton
            // 
            LoadAccessControlListButton.Location = new Point(9, 6);
            LoadAccessControlListButton.Name = "LoadAccessControlListButton";
            LoadAccessControlListButton.Size = new Size(164, 23);
            LoadAccessControlListButton.TabIndex = 0;
            LoadAccessControlListButton.Text = "Load Access Control List";
            LoadAccessControlListButton.UseVisualStyleBackColor = true;
            LoadAccessControlListButton.Click += LoadAccessControlListButton_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(userTabControl);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            userTabControl.ResumeLayout(false);
            IdentityTabPage.ResumeLayout(false);
            IdentityTabPage.PerformLayout();
            membershipsTabPage.ResumeLayout(false);
            membershipsTabPage.PerformLayout();
            userEntitlementsTabPage.ResumeLayout(false);
            userEntitlementsTabPage.PerformLayout();
            accessControlListsTabPage.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)securityNamespacesSfDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl userTabControl;
        private TabPage membershipsTabPage;
        private TabPage userEntitlementsTabPage;
        private TextBox membershipsTextBox;
        private TabPage IdentityTabPage;
        private TextBox identityTextBox;
        private TextBox userEntitlementsTextBox;
        private TabPage accessControlListsTabPage;
        private Button LoadAccessControlListButton;
        private TextBox accessControlListTextBox;
        private Syncfusion.WinForms.DataGrid.SfDataGrid securityNamespacesSfDataGrid;
        private TableLayoutPanel tableLayoutPanel1;
    }
}