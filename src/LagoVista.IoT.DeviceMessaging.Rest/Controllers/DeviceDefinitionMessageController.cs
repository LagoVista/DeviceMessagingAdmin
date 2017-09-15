using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.Core;
using LagoVista.IoT.Web.Common.Controllers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Managers;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Models.Users;

namespace LagoVista.IoT.DeviceMessaging.Rest.Controllers
{
    [Authorize]  
    public class DeviceMessageDefinitionController : LagoVistaBaseController
    {
        
        IDeviceMessageDefinitionManager _deviceConfigManager;
        /// <summary>
        /// Creates an instance of a DeciceMessageDefinitionController
        /// </summary>
        public DeviceMessageDefinitionController(IDeviceMessageDefinitionManager deviceConfigManager, UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _deviceConfigManager = deviceConfigManager;
        }


        /// <summary>
        /// Device Message Type - Add New
        /// </summary>
        /// <param name="deviceMessageConfiguration"></param>
        /// <returns></returns>
        [HttpPost("/api/devicemessagetype")]
        public Task<InvokeResult> AddDeviceMessageConfigurationAsync([FromBody] DeviceMessageDefinition deviceMessageConfiguration)
        {
            return _deviceConfigManager.AddDeviceMessageDefinitionAsync(deviceMessageConfiguration, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Message Type - Update Config
        /// </summary>
        /// <param name="deviceMessageConfiguration"></param>
        /// <returns></returns>
        [HttpPut("/api/devicemessagetype")]
        public Task<InvokeResult> UpdateDeviceMessageConfigurationAsync([FromBody] DeviceMessageDefinition deviceMessageConfiguration)
        {
            SetUpdatedProperties(deviceMessageConfiguration);
            return _deviceConfigManager.UpdateDeviceMessageDefinitionAsync(deviceMessageConfiguration, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Message Type - Get Configs for Org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetypes")]
        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetDeviceMessageConfigurationsForOrgAsync()
        {
            var deviceMessageConfiguration = await _deviceConfigManager.GetDeviceMessageDefinitionsForOrgsAsync(OrgEntityHeader.Id, UserEntityHeader);
            return ListResponse<DeviceMessageDefinitionSummary>.Create(deviceMessageConfiguration);
        }

        /// <summary>
        /// Device Message Type - Get A Configuration
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/{id}")]
        public async Task<DetailResponse<DeviceMessageDefinition>> GetDeviceMessageConfigurationAsync(String id)
        {
            var deviceMessageConfiguration = await _deviceConfigManager.GetDeviceMessageDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<DeviceMessageDefinition>.Create(deviceMessageConfiguration);
        }

        /// <summary>
        /// Device Message Type - Check in Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/{id}/inuse")]
        public Task<DependentObjectCheckResult> InUseCheck(String id)
        {
            return _deviceConfigManager.CheckDeviceMessageInUseAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Message Type - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/{key}/keyinuse")]
        public Task<bool> DeviceConfigKeyInUse(String key)
        {
            return _deviceConfigManager.QueryDeviceMessageDefinitionKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Device Message Type - Delete
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/devicemessagetype/{id}")]
        public Task<InvokeResult> DeleteDeviceMessageConfigurationAsync(string id)
        {
            return _deviceConfigManager.DeleteDeviceMessageDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        ///  Device Message Type - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/factory")]
        public DetailResponse<DeviceMessageDefinition> CreateDeviceMessageConfigurartion()
        {
            var response = DetailResponse<DeviceMessageDefinition>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);

            return response;
        }

        /// <summary>
        ///  Device Message Type, Sample- Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/samplemessage/factory")]
        public DetailResponse<SampleMessage> CreateSampleMessage()
        {
            return DetailResponse<SampleMessage>.Create();
        }

        /// <summary>
        ///  Device Message Type, Framing Byte - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/framingbyte/factory")]
        public DetailResponse<MessageFramingBytes> CreateFramingByte()
        {
            return DetailResponse<MessageFramingBytes>.Create();
        }


        /// <summary>
        ///  Device Message Type, Field - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/field/factory")]
        public DetailResponse<DeviceMessageDefinitionField> CreateDeviceMessageField()
        {
            return DetailResponse<DeviceMessageDefinitionField>.Create();
        }
    }
}
