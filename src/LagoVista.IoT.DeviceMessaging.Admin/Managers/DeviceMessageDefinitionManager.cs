using LagoVista.Core.Cloning;
using LagoVista.Core.Exceptions;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.Logging.Loggers;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LagoVista.Core.Models.AuthorizeResult;

namespace LagoVista.IoT.DeviceMessaging.Admin.Managers
{
    public class DeviceMessageDefinitionManager : ManagerBase, IDeviceMessageDefinitionManager
    {
        IDeviceMessageDefinitionRepo _deviceMessageDefinitionRepo;
        IDeviceAdminManager _deviceAdminManager;

        public DeviceMessageDefinitionManager (IDeviceMessageDefinitionRepo deviceMessageDefinitionRepo, IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security, IDeviceAdminManager deviceAdminManager) :
            base(logger, appConfig, depmanager, security)
        {
            _deviceMessageDefinitionRepo = deviceMessageDefinitionRepo;
            _deviceAdminManager = deviceAdminManager;
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
            await AuthorizeAsync(deviceMessageDefinition, AuthorizeActions.Read, user, org);
            return deviceMessageDefinition;
        }

        public async Task<InvokeResult<DeviceMessageDefinition>> LoadFullDeviceMessageDefinitionAsync(string id,EntityHeader org, EntityHeader user)
        {
            DeviceMessageDefinition message = null;

            try
            {
                message = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            }
            catch(RecordNotFoundException)
            {
                return InvokeResult<DeviceMessageDefinition>.FromErrors(Resources.DeviceMessagingAdminErrorCodes.CouldNotLoadDeviceMessageDefinition.ToErrorMessage($"MessageId={id}"));
            }

            var result = new InvokeResult<DeviceMessageDefinition>();

            foreach(var field in message.Fields)
            {
                if(!EntityHeader.IsNullOrEmpty( field.UnitSet))
                {
                    try
                    {
                        field.UnitSet.Value = await _deviceAdminManager.GetAttributeUnitSetAsync(field.UnitSet.Id, org, user);
                    }
                    catch (RecordNotFoundException)
                    {
                        result.Errors.Add(DeviceMessagingAdminErrorCodes.CouldNotLoadUnitSet.ToErrorMessage($"MessageId={id},UnitSetId={field.UnitSet.Id}"));
                    }
                }

                if (!EntityHeader.IsNullOrEmpty(field.StateSet))
                {
                    try
                    {
                        field.StateSet.Value = await _deviceAdminManager.GetStateSetAsync(field.StateSet.Id, org, user);
                    }
                    catch (RecordNotFoundException)
                    {
                        result.Errors.Add(DeviceMessagingAdminErrorCodes.CouldNotLoadStateSet.ToErrorMessage($"MessageId={id},StateSetId={field.StateSet.Id}"));
                    }
                }
            }

            if(result.Successful)
            {
                return InvokeResult<DeviceMessageDefinition>.Create(message);
            }

            return result;
        }

        public async Task<IEnumerable<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync()
        {
            return await _deviceMessageDefinitionRepo.GetPublicDeviceMessageDefinitionsAsync();
        }

        public async Task<IEnumerable<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceMessageDefinition));
            return await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionsForOrgAsync(orgId);
        }

        public async Task<InvokeResult> UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageConfiguration, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceMessageConfiguration, AuthorizeActions.Update, user, org);
            ValidationCheck(deviceMessageConfiguration, Actions.Update);
            await _deviceMessageDefinitionRepo.UpdateDeviceMessageDefinitionAsync(deviceMessageConfiguration);
            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            var messageDefinition = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            await AuthorizeAsync(messageDefinition, AuthorizeActions.Delete, user, org);
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

        public async Task<InvokeResult> CloneDeviceMessageDefinition(CloneRequest request, EntityHeader org, EntityHeader user)
        {
            if(await _deviceMessageDefinitionRepo.QueryKeyInUseAsync(request.NewKey, org.Id))
            {
                throw new System.Exception($"Key [{request.NewKey}] is currently in use.");
            }

            var message = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(request.OriginalId);
            if(!message.IsPublic && message.OwnerOrganization.Id != org.Id)
            {
                throw new NotAuthorizedException("Could not clone non public message definition or one from a different organization.");
            }

            var clonedMessage = await message.CloneAsync(user, org, request.NewName, request.NewKey);
            await this._deviceMessageDefinitionRepo.AddDeviceMessageDefinitionAsync(clonedMessage);

            return InvokeResult.Success;
        }
    }
}
