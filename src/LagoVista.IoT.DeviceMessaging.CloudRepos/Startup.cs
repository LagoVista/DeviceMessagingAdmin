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
            services.AddTransient<IDeviceMessagingSettings, DeviceMessagingSettings>();
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