using LagoVista.Core.Models.UIMetaData;
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
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetSevenSegmentDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync(ListRequest request);
        Task UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageDefinition);
        Task DeleteDeviceMessageDefinitionAsync(string id);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
