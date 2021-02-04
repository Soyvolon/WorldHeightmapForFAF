using System.Windows.Forms;

using WorldHeightmap.Client.Properties;

namespace WorldHeightmap.Client.Popups
{
    public partial class ApiKeyForm : Form
    {
        public ApiKeyForm()
        {
            InitializeComponent();
            apiTextBox.Text = Settings.Default.ApiKey;
        }

        private void ApiKeyCreationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            apiKeyCreationLink.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://developers.google.com/maps/documentation/elevation/get-api-key?hl=en_US");
        }

        private void ApiBillingInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            apiBillingInfoLink.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://cloud.google.com/maps-platform/pricing");
        }

        public string GetApiKey()
            => apiTextBox.Text;
    }
}
