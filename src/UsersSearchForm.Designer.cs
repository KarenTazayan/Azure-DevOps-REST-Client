namespace AzureDevOpsRESTClient
{
    partial class UsersSearchForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            consoleTextBox = new TextBox();
            searchButton = new Button();
            searchTextBox = new TextBox();
            searchTypesComboBox = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(consoleTextBox, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 116);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(776, 322);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // consoleTextBox
            // 
            consoleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleTextBox.Location = new Point(3, 3);
            consoleTextBox.Multiline = true;
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ScrollBars = ScrollBars.Both;
            consoleTextBox.Size = new Size(770, 235);
            consoleTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(12, 87);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(137, 23);
            searchButton.TabIndex = 0;
            searchButton.Text = "Search User By...";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(321, 87);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(322, 23);
            searchTextBox.TabIndex = 2;
            // 
            // searchTypesComboBox
            // 
            searchTypesComboBox.FormattingEnabled = true;
            searchTypesComboBox.Location = new Point(155, 87);
            searchTypesComboBox.Name = "searchTypesComboBox";
            searchTypesComboBox.Size = new Size(160, 23);
            searchTypesComboBox.TabIndex = 3;
            // 
            // UsersSearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(searchTypesComboBox);
            Controls.Add(searchTextBox);
            Controls.Add(searchButton);
            Controls.Add(tableLayoutPanel1);
            Name = "UsersSearchForm";
            Text = "UsersSearchForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button searchButton;
        private TextBox searchTextBox;
        private TextBox consoleTextBox;
        private ComboBox searchTypesComboBox;
    }
}