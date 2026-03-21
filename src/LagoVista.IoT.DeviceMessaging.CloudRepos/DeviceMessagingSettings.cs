using LagoVista.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.CloudRepos
{
    public class DeviceMessagingSettings : IDeviceMessagingSettings
    {
        public IConnectionSettings DeviceMessagingDocDbStorage { get; }
        public IConnectionSettings DeviceMessagingTableStorage { get; }
    
        public DeviceMessagingSettings(IConfiguration configuration)
        {
            DeviceMessagingDocDbStorage = configuration.CreateDefaultDBStorageSettings();
            DeviceMessagingTableStorage = configuration.CreateDefaultTableStorageSettings();
        }
    }
}
