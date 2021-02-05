
namespace WorldHeightmap.Client.Popups
{
    partial class SaveDataForm
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
            this.saveConfirm = new System.Windows.Forms.Button();
            this.includeData = new System.Windows.Forms.CheckBox();
            this.heightmapName = new System.Windows.Forms.TextBox();
            this.heighmapNameLabel = new System.Windows.Forms.Label();
            this.saveElevation = new System.Windows.Forms.CheckBox();
            this.elevationDatasetName = new System.Windows.Forms.TextBox();
            this.elevationDatasetNameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveConfirm
            // 
            this.saveConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveConfirm.Location = new System.Drawing.Point(99, 145);
            this.saveConfirm.Name = "saveConfirm";
            this.saveConfirm.Size = new System.Drawing.Size(236, 32);
            this.saveConfirm.TabIndex = 0;
            this.saveConfirm.Text = "Save";
            this.saveConfirm.UseVisualStyleBackColor = true;
            this.saveConfirm.Click += new System.EventHandler(this.SaveConfirm_Click);
            // 
            // includeData
            // 
            this.includeData.AutoSize = true;
            this.includeData.Location = new System.Drawing.Point(12, 60);
            this.includeData.Name = "includeData";
            this.includeData.Size = new System.Drawing.Size(121, 19);
            this.includeData.TabIndex = 1;
            this.includeData.Text = "Include Extra Data";
            this.includeData.UseVisualStyleBackColor = true;
            // 
            // heightmapName
            // 
            this.heightmapName.Location = new System.Drawing.Point(12, 31);
            this.heightmapName.Name = "heightmapName";
            this.heightmapName.Size = new System.Drawing.Size(323, 23);
            this.heightmapName.TabIndex = 2;
            this.heightmapName.TextChanged += new System.EventHandler(this.HeightmapName_TextChanged);
            // 
            // heighmapNameLabel
            // 
            this.heighmapNameLabel.AutoSize = true;
            this.heighmapNameLabel.Location = new System.Drawing.Point(13, 13);
            this.heighmapNameLabel.Name = "heighmapNameLabel";
            this.heighmapNameLabel.Size = new System.Drawing.Size(102, 15);
            this.heighmapNameLabel.TabIndex = 3;
            this.heighmapNameLabel.Text = "Heightmap Name";
            // 
            // saveElevation
            // 
            this.saveElevation.AutoSize = true;
            this.saveElevation.Location = new System.Drawing.Point(12, 85);
            this.saveElevation.Name = "saveElevation";
            this.saveElevation.Size = new System.Drawing.Size(143, 19);
            this.saveElevation.TabIndex = 4;
            this.saveElevation.Text = "Save Elevation Dataset";
            this.saveElevation.UseVisualStyleBackColor = true;
            this.saveElevation.CheckedChanged += new System.EventHandler(this.SaveElevation_CheckedChanged);
            // 
            // elevationDatasetName
            // 
            this.elevationDatasetName.Enabled = false;
            this.elevationDatasetName.Location = new System.Drawing.Point(154, 110);
            this.elevationDatasetName.Name = "elevationDatasetName";
            this.elevationDatasetName.Size = new System.Drawing.Size(181, 23);
            this.elevationDatasetName.TabIndex = 5;
            // 
            // elevationDatasetNameLabel
            // 
            this.elevationDatasetNameLabel.AutoSize = true;
            this.elevationDatasetNameLabel.Location = new System.Drawing.Point(13, 113);
            this.elevationDatasetNameLabel.Name = "elevationDatasetNameLabel";
            this.elevationDatasetNameLabel.Size = new System.Drawing.Size(135, 15);
            this.elevationDatasetNameLabel.TabIndex = 6;
            this.elevationDatasetNameLabel.Text = "Elevation Dataset Name:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button1.Location = new System.Drawing.Point(12, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SaveDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.elevationDatasetNameLabel);
            this.Controls.Add(this.elevationDatasetName);
            this.Controls.Add(this.saveElevation);
            this.Controls.Add(this.heighmapNameLabel);
            this.Controls.Add(this.heightmapName);
            this.Controls.Add(this.includeData);
            this.Controls.Add(this.saveConfirm);
            this.Name = "SaveDataForm";
            this.Text = "Save Heightmap Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveConfirm;
        private System.Windows.Forms.CheckBox includeData;
        private System.Windows.Forms.TextBox heightmapName;
        private System.Windows.Forms.Label heighmapNameLabel;
        private System.Windows.Forms.CheckBox saveElevation;
        private System.Windows.Forms.TextBox elevationDatasetName;
        private System.Windows.Forms.Label elevationDatasetNameLabel;
        private System.Windows.Forms.Button button1;
    }
}