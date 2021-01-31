using System;
using System.Windows.Forms;

using WorldHeightmapClient.Popups;
using WorldHeightmapClient.Properties;

namespace WorldHeightmapClient
{
    public partial class CoreForm
    {
        #region API Key
        private void ElevationAPIKey_Click(object sender, EventArgs e)
         => SaveNewElevationApiKey();

        private void SaveNewElevationApiKey()
        {
            using var popup = new ApiKeyForm();

            var diagResult = popup.ShowDialog(this);
            if (diagResult == DialogResult.Yes)
            {
                Settings.Default.ApiKey = popup.GetApiKey();
            }
            else if (diagResult == DialogResult.No)
            {
                Settings.Default.ApiKey = "";
            }

            Settings.Default.Save();
        }
        #endregion
    }
}
