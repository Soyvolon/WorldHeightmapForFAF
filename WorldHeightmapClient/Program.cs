using System;
using System.Windows.Forms;

using Microsoft.Extensions.DependencyInjection;

using WorldHeightmapClient.Popups;

using WorldHeightmapCore.Http;
using WorldHeightmapCore.Services;

namespace WorldHeightmapClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(Properties.Settings.Default.UpgradeSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeSettings = false;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new();

            ConfigureServices(services);

            using var provider = services.BuildServiceProvider();

            Application.Run(provider.GetRequiredService<CoreForm>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<CoreForm>()
                .AddSingleton<HeightmapGeneratorService>()
                .AddTransient<ApiKeyForm>()
                .AddTransient<EarthEngineForm>();

            services.AddHttpClient<ElevationClient>();
            services.AddHttpClient<EarthClient>();
        }
    }
}
