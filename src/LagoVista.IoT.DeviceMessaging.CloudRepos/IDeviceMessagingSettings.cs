// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 4d8b83d4b03ad6f9512a6449281461cae1e4f2851921351276567556c245f8de
// IndexVersion: 2
// --- END CODE INDEX META ---
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
