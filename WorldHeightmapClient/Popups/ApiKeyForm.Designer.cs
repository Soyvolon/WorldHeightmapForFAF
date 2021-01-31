
namespace WorldHeightmapClient.Popups
{
    partial class ApiKeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApiKeyForm));
            this.label1 = new System.Windows.Forms.Label();
            this.apiTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apiKeyCreationLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.apiBillingInfoLink = new System.Windows.Forms.LinkLabel();
            this.saveApiKey = new System.Windows.Forms.Button();
            this.clearKeyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a new Google Elevation API Key:";
            // 
            // apiTextBox
            // 
            this.apiTextBox.Location = new System.Drawing.Point(15, 35);
            this.apiTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.apiTextBox.Name = "apiTextBox";
            this.apiTextBox.Size = new System.Drawing.Size(466, 23);
            this.apiTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Don\'t have one? Check out";
            // 
            // apiKeyCreationLink
            // 
            this.apiKeyCreationLink.AutoSize = true;
            this.apiKeyCreationLink.Location = new System.Drawing.Point(168, 61);
            this.apiKeyCreationLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.apiKeyCreationLink.Name = "apiKeyCreationLink";
            this.apiKeyCreationLink.Size = new System.Drawing.Size(62, 15);
            this.apiKeyCreationLink.TabIndex = 3;
            this.apiKeyCreationLink.TabStop = true;
            this.apiKeyCreationLink.Text = "this guide.";
            this.apiKeyCreationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ApiKeyCreationLink_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(467, 91);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // apiBillingInfoLink
            // 
            this.apiBillingInfoLink.Location = new System.Drawing.Point(391, 190);
            this.apiBillingInfoLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.apiBillingInfoLink.Name = "apiBillingInfoLink";
            this.apiBillingInfoLink.Size = new System.Drawing.Size(88, 18);
            this.apiBillingInfoLink.TabIndex = 5;
            this.apiBillingInfoLink.TabStop = true;
            this.apiBillingInfoLink.Text = "API Billing Info";
            this.apiBillingInfoLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ApiBillingInfoLink_LinkClicked);
            // 
            // saveApiKey
            // 
            this.saveApiKey.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveApiKey.Location = new System.Drawing.Point(364, 77);
            this.saveApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveApiKey.Name = "saveApiKey";
            this.saveApiKey.Size = new System.Drawing.Size(114, 27);
            this.saveApiKey.TabIndex = 6;
            this.saveApiKey.Text = "Save";
            this.saveApiKey.UseVisualStyleBackColor = true;
            // 
            // clearKeyButton
            // 
            this.clearKeyButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.clearKeyButton.Location = new System.Drawing.Point(243, 77);
            this.clearKeyButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clearKeyButton.Name = "clearKeyButton";
            this.clearKeyButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clearKeyButton.Size = new System.Drawing.Size(114, 27);
            this.clearKeyButton.TabIndex = 7;
            this.clearKeyButton.Text = "Clear Key";
            this.clearKeyButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(14, 77);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelButton.Size = new System.Drawing.Size(114, 27);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ApiKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 219);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.clearKeyButton);
            this.Controls.Add(this.saveApiKey);
            this.Controls.Add(this.apiBillingInfoLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apiKeyCreationLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apiTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ApiKeyForm";
            this.Text = "Google Elevation API Key Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apiTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel apiKeyCreationLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel apiBillingInfoLink;
        private System.Windows.Forms.Button saveApiKey;
        private System.Windows.Forms.Button clearKeyButton;
        private System.Windows.Forms.Button cancelButton;
    }
}