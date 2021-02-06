using System;

namespace WorldHeightmap.Client
{
    public partial class CoreForm
    {
        private void AverageSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            roundSettings.Enabled = false;
            normalSettings.Enabled = true;
        }

        private void RoundSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            roundSettings.Enabled = true;
            normalSettings.Enabled = false;
        }

        private void NoSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            roundSettings.Enabled = false;
            normalSettings.Enabled = false;
        }

        private void CombinedSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            roundSettings.Enabled = true;
            normalSettings.Enabled = true;
        }
    }
}
