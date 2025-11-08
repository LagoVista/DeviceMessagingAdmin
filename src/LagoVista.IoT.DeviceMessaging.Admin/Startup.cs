// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ef03f5d3a8c59ddca6f70afe8d4075ac21038bb9619eced1959d7d06608936cb
// IndexVersion: 2
// --- END CODE INDEX META ---
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
