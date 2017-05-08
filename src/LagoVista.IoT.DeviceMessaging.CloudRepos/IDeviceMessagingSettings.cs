using LagoVista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.CloudRepos
{
    public interface IDeviceMessagingSettings
    {

        IConnectionSettings DeviceMessagingDocDbStorage { get; set; }
        IConnectionSettings DeviceMessagingTableStorage { get; set; }

        bool ShouldConsolidateCollections { get; }
    }
}
