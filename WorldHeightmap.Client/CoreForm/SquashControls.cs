using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldHeightmap.Client
{
    public partial class CoreForm
    {
        private void CompressSquash_CheckedChanged(object sender, EventArgs e)
        {
            compressSettings.Enabled = true;
            flattenSettings.Enabled = false;
        }

        private void FlattenSquash_CheckedChanged(object sender, EventArgs e)
        {
            compressSettings.Enabled = false;
            flattenSettings.Enabled = true;
        }

        private void NoSquash_CheckedChanged(object sender, EventArgs e)
        {
            compressSettings.Enabled = false;
            flattenSettings.Enabled = false;
        }
    }
}
