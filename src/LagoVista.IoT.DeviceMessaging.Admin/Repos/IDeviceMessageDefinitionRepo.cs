// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 55fe7ec408b9426522d887da5bb66a266f2f192845235a6b0b233abad0df9131
// IndexVersion: 0
// --- END CODE INDEX META ---
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
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetIncomingDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetOutgoingDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetSevenSegmentDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync(ListRequest request);
        Task UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageDefinition);
        Task DeleteDeviceMessageDefinitionAsync(string id);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
