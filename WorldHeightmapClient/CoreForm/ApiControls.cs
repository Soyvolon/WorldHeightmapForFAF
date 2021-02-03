using System;
using System.Windows.Forms;

using Microsoft.Extensions.DependencyInjection;

using WorldHeightmapClient.Popups;
using WorldHeightmapClient.Properties;

namespace WorldHeightmapClient
{
    public partial class CoreForm
    {
        #region API Key
        private void ElevationAPIKey_Click(object sender, EventArgs e)
         => SaveNewElevationApiKey();

        private bool SaveNewElevationApiKey()
        {
            var popup = _services.GetRequiredService<ApiKeyForm>();

            var diagResult = popup.ShowDialog(this);
            if (diagResult == DialogResult.Yes)
            {
                Settings.Default.ApiKey = popup.GetApiKey();

                Settings.Default.Save();
                return true;
            }
            else if (diagResult == DialogResult.No)
            {
                Settings.Default.ApiKey = "";

                Settings.Default.Save();
            }

            return false;
        }

        private void SetEarthEngineKey_Click(object sender, EventArgs e)
            => SaveNewEarthEnginePrivateKey();

        private bool SaveNewEarthEnginePrivateKey()
        {
            var popup = _services.GetRequiredService<EarthEngineForm>();

            var diagResult = popup.ShowDialog(this);
            if (diagResult == DialogResult.Yes)
            {
                Settings.Default.EarthEngineKey = popup.GetEngineKey();

                Settings.Default.Save();
                return true;
            }
            else if (diagResult == DialogResult.No)
            {
                Settings.Default.ApiKey = "";

                Settings.Default.Save();
            }

            return false;
        }
        #endregion
    }
}
