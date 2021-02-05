using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void combinedSmoothing_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
