// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f8932addaf4435103ff260b54d96ece9170c89167845d06c56d606fbe55da3ee
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.DeviceMessaging.CloudRepos.Repos;
using LagoVista.IoT.Logging.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


namespace LagoVista.DependencyInjection
{
    public static class DeviceMessagingModule
    {
        public static void AddDeviceMessagingModule(this IServiceCollection services, IConfigurationRoot configRoot, IAdminLogger logger)
        {
            LagoVista.IoT.DeviceMessaging.CloudRepos.Startup.ConfigureServices(services);
            LagoVista.IoT.DeviceMessaging.Admin.Startup.ConfigureServices(services);
            services.AddMetaDataHelper<DeviceMessageDefinition>();
        }
    }
}