using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static LagoVista.Core.Models.AuthorizeResult;

namespace LagoVista.IoT.DeviceMessaging.Admin.Managers
{
    public class DeviceMessageDefinitionManager : ManagerBase, IDeviceMessageDefinitionManager
    {
        IDeviceMessageDefinitionRepo _deviceMessageDefinitionRepo;

        public DeviceMessageDefinitionManager (IDeviceMessageDefinitionRepo deviceMessageDefinitionRepo, IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) :
            base(logger, appConfig, depmanager, security)
        {
            _deviceMessageDefinitionRepo = deviceMessageDefinitionRepo;
        }

        public async Task<InvokeResult> AddDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageConfiguration, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceMessageConfiguration, AuthorizeActions.Create, user, org);
            ValidationCheck(deviceMessageConfiguration, Actions.Create);
            await _deviceMessageDefinitionRepo.AddDeviceMessageDefinitionAsync(deviceMessageConfiguration);
            return InvokeResult.Success;
        }

        public async Task<DeviceMessageDefinition> GetDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceMessageDefinition = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            await AuthorizeAsync(deviceMessageDefinition, AuthorizeActions.Read, org, user);
            return deviceMessageDefinition;
        }

        public Task<DeviceMessageDefinition> LoadFullDeviceMessageDefinitionAsync(string id)
        {
            return _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
        }

        public async Task<IEnumerable<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceMessageDefinition));
            return await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionsForOrgAsync(orgId);
        }

        public async Task<InvokeResult> UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageConfiguration, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceMessageConfiguration, AuthorizeActions.Update, org, user);
            ValidationCheck(deviceMessageConfiguration, Actions.Update);
            await _deviceMessageDefinitionRepo.UpdateDeviceMessageDefinitionAsync(deviceMessageConfiguration);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            var messageDefinition = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            await AuthorizeAsync(messageDefinition, AuthorizeActions.Delete, org, user);
            await ConfirmNoDepenenciesAsync(messageDefinition);
            await _deviceMessageDefinitionRepo.DeleteDeviceMessageDefinitionAsync(id);
            return InvokeResult.Success;
        }

        public Task<bool> QueryDeviceMessageDefinitionKeyInUseAsync(string key, string orgId)
        {
            return _deviceMessageDefinitionRepo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<DependentObjectCheckResult> CheckDeviceMessageInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceMessageConfiguration = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            await AuthorizeAsync(deviceMessageConfiguration, AuthorizeActions.Read, user, org);
            return await base.CheckForDepenenciesAsync(deviceMessageConfiguration);
        }
    }
}
