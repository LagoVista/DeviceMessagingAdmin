// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f8932addaf4435103ff260b54d96ece9170c89167845d06c56d606fbe55da3ee
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.DeviceMessaging.CloudRepos.Repos;

namespace LagoVista.IoT.DeviceMessaging.CloudRepos
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDeviceMessageDefinitionRepo, DeviceMessageDefinitionRepo>();
        }
    }
}
