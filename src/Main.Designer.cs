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
            securityNamespacesButton = new Button();
            usersDataGridView = new DataGridView();
            usersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(361, 60);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(112, 23);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // patTextBox
            // 
            patTextBox.Location = new Point(140, 25);
            patTextBox.Name = "patTextBox";
            patTextBox.Size = new Size(215, 23);
            patTextBox.TabIndex = 1;
            patTextBox.Text = "PAT";
            // 
            // orgNameTextBox
            // 
            orgNameTextBox.Location = new Point(140, 60);
            orgNameTextBox.Name = "orgNameTextBox";
            orgNameTextBox.Size = new Size(215, 23);
            orgNameTextBox.TabIndex = 2;
            orgNameTextBox.Text = "{organization}";
            // 
            // patLabel
            // 
            patLabel.AutoSize = true;
            patLabel.Location = new Point(108, 28);
            patLabel.Name = "patLabel";
            patLabel.Size = new Size(26, 15);
            patLabel.TabIndex = 3;
            patLabel.Text = "PAT";
            // 
            // orgNamelabel
            // 
            orgNamelabel.AutoSize = true;
            orgNamelabel.Location = new Point(24, 63);
            orgNamelabel.Name = "orgNamelabel";
            orgNamelabel.Size = new Size(110, 15);
            orgNamelabel.TabIndex = 4;
            orgNamelabel.Text = "Organization Name";
            // 
            // consoleTextBox
            // 
            consoleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleTextBox.Location = new Point(6, 64);
            consoleTextBox.Multiline = true;
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ScrollBars = ScrollBars.Both;
            consoleTextBox.Size = new Size(1016, 279);
            consoleTextBox.TabIndex = 5;
            // 
            // readIdentitiesButton
            // 
            readIdentitiesButton.Location = new Point(912, 34);
            readIdentitiesButton.Name = "readIdentitiesButton";
            readIdentitiesButton.Size = new Size(110, 23);
            readIdentitiesButton.TabIndex = 6;
            readIdentitiesButton.Text = "Read All Users";
            readIdentitiesButton.UseVisualStyleBackColor = true;
            readIdentitiesButton.Click += readIdentitiesButton_Click;
            // 
            // userFilterTextBox
            // 
            userFilterTextBox.Location = new Point(133, 35);
            userFilterTextBox.Name = "userFilterTextBox";
            userFilterTextBox.PlaceholderText = "User Filter";
            userFilterTextBox.Size = new Size(270, 23);
            userFilterTextBox.TabIndex = 7;
            // 
            // readUserByFilterButton
            // 
            readUserByFilterButton.Location = new Point(6, 35);
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
            usersGroupBox.Controls.Add(securityNamespacesButton);
            usersGroupBox.Controls.Add(usersDataGridView);
            usersGroupBox.Controls.Add(consoleTextBox);
            usersGroupBox.Controls.Add(readUserByFilterButton);
            usersGroupBox.Controls.Add(readIdentitiesButton);
            usersGroupBox.Controls.Add(userFilterTextBox);
            usersGroupBox.Enabled = false;
            usersGroupBox.Location = new Point(12, 106);
            usersGroupBox.Name = "usersGroupBox";
            usersGroupBox.Size = new Size(1028, 473);
            usersGroupBox.TabIndex = 9;
            usersGroupBox.TabStop = false;
            usersGroupBox.Text = "Users";
            // 
            // securityNamespacesButton
            // 
            securityNamespacesButton.Location = new Point(756, 34);
            securityNamespacesButton.Name = "securityNamespacesButton";
            securityNamespacesButton.Size = new Size(150, 23);
            securityNamespacesButton.TabIndex = 10;
            securityNamespacesButton.Text = "Security Namespaces";
            securityNamespacesButton.UseVisualStyleBackColor = true;
            securityNamespacesButton.Click += securityNamespacesButton_Click;
            // 
            // usersDataGridView
            // 
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Dock = DockStyle.Bottom;
            usersDataGridView.Location = new Point(3, 349);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.Size = new Size(1022, 121);
            usersDataGridView.TabIndex = 9;
            usersDataGridView.RowHeaderMouseDoubleClick += usersDataGridView_RowHeaderMouseDoubleClick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 591);
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
    }
}
