// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: e04039f5f16d98dd5ea1d5ae4e76d712c5d1d57267e1d3d3f33911d24e1d4849
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core;
using LagoVista.Core.Cloning;
using LagoVista.Core.Exceptions;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LagoVista.Core.Models.AuthorizeResult;

namespace LagoVista.IoT.DeviceMessaging.Admin.Managers
{
    public class DeviceMessageDefinitionManager : ManagerBase, IDeviceMessageDefinitionManager
    {
        IDeviceMessageDefinitionRepo _deviceMessageDefinitionRepo;
        IDeviceAdminManager _deviceAdminManager;

        public DeviceMessageDefinitionManager(IDeviceMessageDefinitionRepo deviceMessageDefinitionRepo, IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security, IDeviceAdminManager deviceAdminManager) :
            base(logger, appConfig, depmanager, security)
        {
            _deviceMessageDefinitionRepo = deviceMessageDefinitionRepo;
            _deviceAdminManager = deviceAdminManager;
        }

        private void AddGeoPointArrayFields(DeviceMessageDefinition deviceMessageConfiguration)
        {
            deviceMessageConfiguration.Fields.Clear();

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Start Time Stamp",
                Key = "starttimestamp",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Start Time Stamp",
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                IsRequired = true,
                FieldIndex = 0,
                BinaryOffset = 0,
                DateTimeZone = EntityHeader<DateTimeZoneOptions>.Create(DateTimeZoneOptions.UniversalTimeZone),
                Notes = "Time in seconds from UTC epoch (1/1/1970).",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt32),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Integer)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Point Count",
                Key = "pointcount",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Point Count",
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                IsRequired = true,
                FieldIndex = 2,
                BinaryOffset = 6,
                MinValue = 1,
                MaxValue = 2500,
                Notes = "Number of points that make up this point array.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Integer)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Interval",
                Key = "interval",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Interval",
                IsRequired = true,
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                FieldIndex = 3,
                BinaryOffset = 8,
                MinValue = 0,
                MaxValue = 600,
                Notes = "Interval (16 bit unsigned decimal scaled to one decimal point) between sample collection points.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Decimal)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField
            {
                Name = "Geo Point Array",
                Key = "geopointarray",
                Id = Guid.NewGuid().ToId(),
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Geo Point Array",
                IsRequired = true,
                FieldIndex = 4,
                BinaryOffset = 10,
                Notes = "Collection of points (16 bit unsigned scaled decimal to two decimal points) that make up the data collected from the device.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.Int16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.DecimalArray)
            });
        }

        private void AddPointArrayFields(DeviceMessageDefinition deviceMessageConfiguration)
        {
            deviceMessageConfiguration.Fields.Clear();

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Start Time Stamp",
                Key = "starttimestamp",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Start Time Stamp",
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                IsRequired = true,
                FieldIndex = 0,
                BinaryOffset = 0,
                DateTimeZone = EntityHeader<DateTimeZoneOptions>.Create(DateTimeZoneOptions.UniversalTimeZone),
                Notes = "Time in seconds from UTC epoch (1/1/1970).",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt32),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Integer)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Sensor Index",
                Key = "sensorindex",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Sensor Index",
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                IsRequired = true,
                FieldIndex = 1,
                BinaryOffset = 4,
                MinValue = 0,
                MaxValue = 65535,
                Notes = "Sensor index from the device for this point array.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Integer)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Point Count",
                Key = "pointcount",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Point Count",
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                IsRequired = true,
                FieldIndex = 2,
                BinaryOffset = 6,
                MinValue = 1,
                MaxValue = 2500,
                Notes = "Number of points that make up this point array.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Integer)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField()
            {
                Name = "Interval",
                Key = "interval",
                Id = Guid.NewGuid().ToId(),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Interval",
                IsRequired = true,
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                FieldIndex = 3,
                BinaryOffset = 8,
                MinValue = 0,
                MaxValue = 600,
                Notes = "Interval (16 bit unsigned decimal scaled to one decimal point) between sample collection points.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.UInt16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Decimal)
            });

            deviceMessageConfiguration.Fields.Add(new DeviceMessageDefinitionField
            {
                Name = "Point Array",
                Key = "pointarray",
                Id = Guid.NewGuid().ToId(),
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
                Endian = EntityHeader<EndianTypes>.Create(EndianTypes.BigEndian),
                HeaderName = "Point Array",
                IsRequired = true,
                FieldIndex = 4,
                BinaryOffset = 10,
                Notes = "Collection of points (16 bit unsigned scaled decimal to two decimal points) that make up the data collected from the device.",
                ParsedBinaryFieldType = EntityHeader<ParseBinaryValueType>.Create(ParseBinaryValueType.Int16),
                StorageType = EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.DecimalArray)
            });
        }

        public async Task<InvokeResult> AddDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageConfiguration, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceMessageConfiguration, AuthorizeActions.Create, user, org);
            ValidationCheck(deviceMessageConfiguration, Actions.Create);
          
            if (deviceMessageConfiguration.ContentType.Value == MessageContentTypes.PointArray)
            {
                AddPointArrayFields(deviceMessageConfiguration);
            }
            else if (deviceMessageConfiguration.ContentType.Value == MessageContentTypes.GeoPointArray)
            {
                AddGeoPointArrayFields(deviceMessageConfiguration);
            }

            await _deviceMessageDefinitionRepo.AddDeviceMessageDefinitionAsync(deviceMessageConfiguration);

            return InvokeResult.Success;
        }

        public async Task<DeviceMessageDefinition> GetDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceMessageDefinition = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            await AuthorizeAsync(deviceMessageDefinition, AuthorizeActions.Read, user, org);
            return deviceMessageDefinition;
        }

        public async Task<InvokeResult<DeviceMessageDefinition>> LoadFullDeviceMessageDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            DeviceMessageDefinition message = null;

            try
            {
                message = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(id);
            }
            catch (RecordNotFoundException)
            {
                return InvokeResult<DeviceMessageDefinition>.FromErrors(Resources.DeviceMessagingAdminErrorCodes.CouldNotLoadDeviceMessageDefinition.ToErrorMessage($"MessageId={id}"));
            }

            var result = new InvokeResult<DeviceMessageDefinition>();

            foreach (var field in message.Fields)
            {
                if (!EntityHeader.IsNullOrEmpty(field.UnitSet))
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

            if (result.Successful)
            {
                return InvokeResult<DeviceMessageDefinition>.Create(message);
            }

            return result;
        }

        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync(ListRequest listRequest)
        {
            return await _deviceMessageDefinitionRepo.GetPublicDeviceMessageDefinitionsAsync(listRequest);
        }

        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceMessageDefinition));
            return await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionsForOrgAsync(orgId, listRequest);
        }

        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetIncomingDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceMessageDefinition));
            return await _deviceMessageDefinitionRepo.GetIncomingDeviceMessageDefinitionsForOrgAsync(orgId, listRequest);
        }

        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetOutgoingDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceMessageDefinition));
            return await _deviceMessageDefinitionRepo.GetOutgoingDeviceMessageDefinitionsForOrgAsync(orgId, listRequest);
        }

        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetSevenSegementDeviceMessageDefinitionsForOrgsAsync(string orgId, EntityHeader user, ListRequest listRequest)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceMessageDefinition));
            return await _deviceMessageDefinitionRepo.GetSevenSegmentDeviceMessageDefinitionsForOrgAsync(orgId, listRequest);
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
            if (await _deviceMessageDefinitionRepo.QueryKeyInUseAsync(request.NewKey, org.Id))
            {
                throw new System.Exception($"Key [{request.NewKey}] is currently in use.");
            }

            var message = await _deviceMessageDefinitionRepo.GetDeviceMessageDefinitionAsync(request.OriginalId);
            if (!message.IsPublic && message.OwnerOrganization.Id != org.Id)
            {
                throw new NotAuthorizedException("Could not clone non public message definition or one from a different organization.");
            }

            var clonedMessage = await message.CloneAsync(user, org, request.NewName, request.NewKey);
            await this._deviceMessageDefinitionRepo.AddDeviceMessageDefinitionAsync(clonedMessage);

            return InvokeResult.Success;
        }
    }
}
