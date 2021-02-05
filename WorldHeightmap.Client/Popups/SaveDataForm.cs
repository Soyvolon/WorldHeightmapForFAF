using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;

using WorldHeightmap.Core.Models;
using WorldHeightmap.Core.Services;

namespace WorldHeightmap.Client.Popups
{
    public partial class SaveDataForm : Form
    {
        public string Folder { get; private set; }
        public bool SaveDataset { get; private set; }
        public bool SaveExtraData { get; private set; }
        public string HeightmapName { get; private set; }
        public string ElevationDatasetName { get; private set; }
        public bool Aborted { get; private set; } = true;

        private readonly GeneratorResult result;
        private readonly string EDNStarter;

        public SaveDataForm(GeneratorResultCacheService cahce)
        {
            result = cahce.GetResult();
            InitializeComponent();

            EDNStarter = $"_{result.RawElevationData.GetLength(0)}_{result.RawElevationData.GetLength(1)}";
            elevationDatasetName.Text = EDNStarter;
            heightmapName.Text = "heightmap";
        }

        private void SaveConfirm_Click(object sender, EventArgs e)
        {
            if(CommonFileDialog.IsPlatformSupported)
            {
                var diag = new CommonOpenFileDialog();
                diag.IsFolderPicker = true;
                diag.DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                diag.Multiselect = false;
                //diag.Filters.Add(new CommonFileDialogFilter("Data Files", "*.raw;*.bmp;*.txt;*.whcd"));
                var res = diag.ShowDialog();

                if (res == CommonFileDialogResult.Cancel)
                {
                    Aborted = true;
                    return;
                }

                Folder = diag.FileName;
            }
            else
            {
                var diag = new FolderBrowserDialog();
                diag.ShowNewFolderButton = true;
                var res = diag.ShowDialog();

                if(res == DialogResult.Cancel || res == DialogResult.No || res == DialogResult.Abort)
                {
                    Aborted = true;
                    return;
                }

                Folder = diag.SelectedPath;
            }

            Aborted = false;
            SaveDataset = saveElevation.Checked;
            SaveExtraData = includeData.Checked;
            ElevationDatasetName = elevationDatasetName.Text;
            HeightmapName = heightmapName.Text;
        }

        private void HeightmapName_TextChanged(object sender, EventArgs e)
        {
            if (!saveElevation.Checked)
            {
                elevationDatasetName.Text = heightmapName.Text + EDNStarter;
                elevationDatasetName.Refresh();
            }
        }

        private void SaveElevation_CheckedChanged(object sender, EventArgs e)
        {
            elevationDatasetName.Enabled = saveElevation.Checked;
        }
    }
}
