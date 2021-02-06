using System.Windows.Forms;

namespace WorldHeightmap.Client.Popups
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
