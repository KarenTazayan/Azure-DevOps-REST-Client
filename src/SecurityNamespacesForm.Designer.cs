namespace AzureDevOpsRESTClient
{
    partial class SecurityNamespacesForm
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
            securityNamespacesTextBox = new TextBox();
            SuspendLayout();
            // 
            // securityNamespacesTextBox
            // 
            securityNamespacesTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            securityNamespacesTextBox.Location = new Point(5, 12);
            securityNamespacesTextBox.Multiline = true;
            securityNamespacesTextBox.Name = "securityNamespacesTextBox";
            securityNamespacesTextBox.ScrollBars = ScrollBars.Both;
            securityNamespacesTextBox.Size = new Size(789, 426);
            securityNamespacesTextBox.TabIndex = 0;
            // 
            // SecurityNamespacesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(securityNamespacesTextBox);
            Name = "SecurityNamespacesForm";
            Text = "SecurityNamespacesForm";
            Load += SecurityNamespacesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox securityNamespacesTextBox;
    }
}