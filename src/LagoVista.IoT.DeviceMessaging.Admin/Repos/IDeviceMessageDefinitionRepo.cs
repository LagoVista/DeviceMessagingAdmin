using LagoVista.IoT.DeviceMessaging.Admin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Repos
{
    public interface IDeviceMessageDefinitionRepo
    {
        Task AddDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageDefinition);
        Task<DeviceMessageDefinition> GetDeviceMessageDefinitionAsync(string id);
        Task<IEnumerable<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgAsync(string orgId);
        Task<IEnumerable<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync();
        Task UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageDefinition);
        Task DeleteDeviceMessageDefinitionAsync(string id);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
