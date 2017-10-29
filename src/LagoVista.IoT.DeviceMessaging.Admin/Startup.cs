using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceMessaging.Admin.Managers;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.Logging;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]

namespace LagoVista.IoT.DeviceMessaging.Admin
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDeviceMessageDefinitionManager, DeviceMessageDefinitionManager>();

            ErrorCodes.Register(typeof(DeviceMessagingAdminErrorCodes));
        }
    }
}
