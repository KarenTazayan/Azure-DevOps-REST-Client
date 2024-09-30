namespace AzureDevOpsRESTClient
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginButton = new Button();
            patTextBox = new TextBox();
            orgNameTextBox = new TextBox();
            patLabel = new Label();
            orgNamelabel = new Label();
            consoleTextBox = new TextBox();
            readIdentitiesButton = new Button();
            userFilterTextBox = new TextBox();
            readUserByFilterButton = new Button();
            usersGroupBox = new GroupBox();
            advancedSearchButton = new Button();
            userServicePrincipalCheckBox = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            usersDataGridView = new DataGridView();
            securityNamespacesButton = new Button();
            createNewUserWithOriginIdButton = new Button();
            usersGroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(602, 17);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(181, 23);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // patTextBox
            // 
            patTextBox.Location = new Point(381, 17);
            patTextBox.Name = "patTextBox";
            patTextBox.PasswordChar = '*';
            patTextBox.Size = new Size(215, 23);
            patTextBox.TabIndex = 1;
            patTextBox.Text = "PAT";
            // 
            // orgNameTextBox
            // 
            orgNameTextBox.Location = new Point(128, 17);
            orgNameTextBox.Name = "orgNameTextBox";
            orgNameTextBox.Size = new Size(215, 23);
            orgNameTextBox.TabIndex = 2;
            orgNameTextBox.Text = "{organization}";
            // 
            // patLabel
            // 
            patLabel.AutoSize = true;
            patLabel.Location = new Point(349, 20);
            patLabel.Name = "patLabel";
            patLabel.Size = new Size(26, 15);
            patLabel.TabIndex = 3;
            patLabel.Text = "PAT";
            // 
            // orgNamelabel
            // 
            orgNamelabel.AutoSize = true;
            orgNamelabel.Location = new Point(12, 20);
            orgNamelabel.Name = "orgNamelabel";
            orgNamelabel.Size = new Size(110, 15);
            orgNamelabel.TabIndex = 4;
            orgNamelabel.Text = "Organization Name";
            // 
            // consoleTextBox
            // 
            consoleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleTextBox.Location = new Point(3, 3);
            consoleTextBox.Multiline = true;
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ScrollBars = ScrollBars.Both;
            consoleTextBox.Size = new Size(1081, 189);
            consoleTextBox.TabIndex = 5;
            // 
            // readIdentitiesButton
            // 
            readIdentitiesButton.Location = new Point(3, 263);
            readIdentitiesButton.Name = "readIdentitiesButton";
            readIdentitiesButton.Size = new Size(206, 23);
            readIdentitiesButton.TabIndex = 6;
            readIdentitiesButton.Text = "Read All Users";
            readIdentitiesButton.UseVisualStyleBackColor = true;
            readIdentitiesButton.Click += readIdentitiesButton_Click;
            // 
            // userFilterTextBox
            // 
            userFilterTextBox.Location = new Point(133, 22);
            userFilterTextBox.Name = "userFilterTextBox";
            userFilterTextBox.PlaceholderText = "User Filter";
            userFilterTextBox.Size = new Size(270, 23);
            userFilterTextBox.TabIndex = 7;
            // 
            // readUserByFilterButton
            // 
            readUserByFilterButton.Location = new Point(6, 22);
            readUserByFilterButton.Name = "readUserByFilterButton";
            readUserByFilterButton.Size = new Size(121, 23);
            readUserByFilterButton.TabIndex = 8;
            readUserByFilterButton.Text = "Read User By Filter";
            readUserByFilterButton.UseVisualStyleBackColor = true;
            readUserByFilterButton.Click += readUserByFilterButton_Click;
            // 
            // usersGroupBox
            // 
            usersGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usersGroupBox.AutoSize = true;
            usersGroupBox.Controls.Add(advancedSearchButton);
            usersGroupBox.Controls.Add(userServicePrincipalCheckBox);
            usersGroupBox.Controls.Add(tableLayoutPanel1);
            usersGroupBox.Controls.Add(createNewUserWithOriginIdButton);
            usersGroupBox.Controls.Add(readUserByFilterButton);
            usersGroupBox.Controls.Add(userFilterTextBox);
            usersGroupBox.Enabled = false;
            usersGroupBox.Location = new Point(12, 74);
            usersGroupBox.Name = "usersGroupBox";
            usersGroupBox.Size = new Size(1101, 411);
            usersGroupBox.TabIndex = 9;
            usersGroupBox.TabStop = false;
            usersGroupBox.Text = "Users";
            // 
            // advancedSearchButton
            // 
            advancedSearchButton.BackColor = Color.Transparent;
            advancedSearchButton.Location = new Point(6, 51);
            advancedSearchButton.Name = "advancedSearchButton";
            advancedSearchButton.Size = new Size(121, 23);
            advancedSearchButton.TabIndex = 15;
            advancedSearchButton.Text = "Advanced Search";
            advancedSearchButton.UseVisualStyleBackColor = false;
            advancedSearchButton.Click += advancedSearchButton_Click;
            // 
            // userServicePrincipalCheckBox
            // 
            userServicePrincipalCheckBox.AutoSize = true;
            userServicePrincipalCheckBox.Location = new Point(409, 25);
            userServicePrincipalCheckBox.Name = "userServicePrincipalCheckBox";
            userServicePrincipalCheckBox.Size = new Size(160, 19);
            userServicePrincipalCheckBox.TabIndex = 14;
            userServicePrincipalCheckBox.Text = "Use User Service Principal";
            userServicePrincipalCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(usersDataGridView, 0, 1);
            tableLayoutPanel1.Controls.Add(securityNamespacesButton, 0, 3);
            tableLayoutPanel1.Controls.Add(readIdentitiesButton, 0, 2);
            tableLayoutPanel1.Controls.Add(consoleTextBox, 0, 0);
            tableLayoutPanel1.Location = new Point(6, 80);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(1087, 320);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // usersDataGridView
            // 
            usersDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Location = new Point(3, 198);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.Size = new Size(1081, 59);
            usersDataGridView.TabIndex = 9;
            usersDataGridView.RowHeaderMouseDoubleClick += usersDataGridView_RowHeaderMouseDoubleClick;
            // 
            // securityNamespacesButton
            // 
            securityNamespacesButton.Location = new Point(3, 293);
            securityNamespacesButton.Name = "securityNamespacesButton";
            securityNamespacesButton.Size = new Size(206, 23);
            securityNamespacesButton.TabIndex = 10;
            securityNamespacesButton.Text = "Security Namespaces";
            securityNamespacesButton.UseVisualStyleBackColor = true;
            securityNamespacesButton.Click += securityNamespacesButton_Click;
            // 
            // createNewUserWithOriginIdButton
            // 
            createNewUserWithOriginIdButton.BackColor = Color.Transparent;
            createNewUserWithOriginIdButton.Location = new Point(920, 23);
            createNewUserWithOriginIdButton.Name = "createNewUserWithOriginIdButton";
            createNewUserWithOriginIdButton.Size = new Size(172, 23);
            createNewUserWithOriginIdButton.TabIndex = 12;
            createNewUserWithOriginIdButton.Text = "Create New User";
            createNewUserWithOriginIdButton.UseVisualStyleBackColor = false;
            createNewUserWithOriginIdButton.Click += createNewUserWithOriginIdButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 497);
            Controls.Add(usersGroupBox);
            Controls.Add(orgNamelabel);
            Controls.Add(patLabel);
            Controls.Add(orgNameTextBox);
            Controls.Add(patTextBox);
            Controls.Add(loginButton);
            Name = "Main";
            Text = "AzureDevOpsRESTClient";
            usersGroupBox.ResumeLayout(false);
            usersGroupBox.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private TextBox patTextBox;
        private TextBox orgNameTextBox;
        private Label patLabel;
        private Label orgNamelabel;
        private TextBox consoleTextBox;
        private Button readIdentitiesButton;
        private TextBox userFilterTextBox;
        private Button readUserByFilterButton;
        private GroupBox usersGroupBox;
        private DataGridView usersDataGridView;
        private Button securityNamespacesButton;
        private Button createNewUserWithOriginIdButton;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox userServicePrincipalCheckBox;
        private Button advancedSearchButton;
    }
}
