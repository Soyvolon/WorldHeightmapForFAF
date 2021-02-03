
namespace WorldHeightmapClient.Popups
{
    partial class EarthEngineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EarthEngineForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearKeyButton = new System.Windows.Forms.Button();
            this.saveApiKey = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.privateKeyCreationLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.apiTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(13, 71);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelButton.Size = new System.Drawing.Size(114, 27);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // clearKeyButton
            // 
            this.clearKeyButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.clearKeyButton.Location = new System.Drawing.Point(242, 71);
            this.clearKeyButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clearKeyButton.Name = "clearKeyButton";
            this.clearKeyButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clearKeyButton.Size = new System.Drawing.Size(114, 27);
            this.clearKeyButton.TabIndex = 16;
            this.clearKeyButton.Text = "Clear Key";
            this.clearKeyButton.UseVisualStyleBackColor = true;
            // 
            // saveApiKey
            // 
            this.saveApiKey.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveApiKey.Location = new System.Drawing.Point(363, 71);
            this.saveApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveApiKey.Name = "saveApiKey";
            this.saveApiKey.Size = new System.Drawing.Size(114, 27);
            this.saveApiKey.TabIndex = 15;
            this.saveApiKey.Text = "Save";
            this.saveApiKey.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(467, 91);
            this.label3.TabIndex = 13;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // privateKeyCreationLink
            // 
            this.privateKeyCreationLink.AutoSize = true;
            this.privateKeyCreationLink.Location = new System.Drawing.Point(158, 55);
            this.privateKeyCreationLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.privateKeyCreationLink.Name = "privateKeyCreationLink";
            this.privateKeyCreationLink.Size = new System.Drawing.Size(62, 15);
            this.privateKeyCreationLink.TabIndex = 12;
            this.privateKeyCreationLink.TabStop = true;
            this.privateKeyCreationLink.Text = "this guide.";
            this.privateKeyCreationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ApiKeyCreationLink_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Don\'t have one? Check out";
            // 
            // apiTextBox
            // 
            this.apiTextBox.Location = new System.Drawing.Point(14, 29);
            this.apiTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.apiTextBox.Name = "apiTextBox";
            this.apiTextBox.Size = new System.Drawing.Size(466, 23);
            this.apiTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter a new Google Earth Engine Private Key:";
            // 
            // EarthEngineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 226);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.clearKeyButton);
            this.Controls.Add(this.saveApiKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.privateKeyCreationLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apiTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EarthEngineForm";
            this.Text = "Earth Engine Priate Key Assignment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearKeyButton;
        private System.Windows.Forms.Button saveApiKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel privateKeyCreationLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apiTextBox;
        private System.Windows.Forms.Label label1;
    }
}