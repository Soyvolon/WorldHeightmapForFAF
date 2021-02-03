using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldHeightmapClient.Popups
{
    public partial class EarthEngineForm : Form
    {
        public EarthEngineForm()
        {
            InitializeComponent();
        }

        private void ApiKeyCreationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            privateKeyCreationLink.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://developers.google.com/earth-engine/reference/Quickstart");
        }

        internal string GetEngineKey()
            => apiTextBox.Text;
    }
}
