﻿using LagoVista.Core.Cloning;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Managers
{
    public interface IDeviceMessageDefinitionManager
    {
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync(ListRequest listRequest);
        Task<InvokeResult> CloneDeviceMessageDefinition(CloneRequest request, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageConfiguration, EntityHeader org, EntityHeader user);
        Task<DeviceMessageDefinition> GetDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult<DeviceMessageDefinition>> LoadFullDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user);

        Task<DependentObjectCheckResult> CheckDeviceMessageInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetSevenSegementDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest);
        Task<ListResponse<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest);
        Task<InvokeResult> UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageConfiguration, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryDeviceMessageDefinitionKeyInUseAsync(string key, string orgId);
    }
}