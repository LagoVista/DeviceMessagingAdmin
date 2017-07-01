using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.Core;
using LagoVista.IoT.Web.Common.Controllers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LagoVista.Core.PlatformSupport;
using LagoVista.UserAdmin.Models.Account;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Managers;
using LagoVista.IoT.Logging.Loggers;

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
        /// Device Message Config - Add New
        /// </summary>
        /// <param name="deviceMessageConfiguration"></param>
        /// <returns></returns>
        [HttpPost("/api/devicemessageconfig")]
        public Task<InvokeResult> AddDeviceMessageConfigurationAsync([FromBody] DeviceMessageDefinition deviceMessageConfiguration)
        {
            return _deviceConfigManager.AddDeviceMessageDefinitionAsync(deviceMessageConfiguration, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Message Config - Update Config
        /// </summary>
        /// <param name="deviceMessageConfiguration"></param>
        /// <returns></returns>
        [HttpPut("/api/devicemessageconfig")]
        public Task<InvokeResult> UpdateDeviceMessageConfigurationAsync([FromBody] DeviceMessageDefinition deviceMessageConfiguration)
        {
            SetUpdatedProperties(deviceMessageConfiguration);
            return _deviceConfigManager.UpdateDeviceMessageDefinitionAsync(deviceMessageConfiguration, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Message Config - Get Configs for Org
        /// </summary>
        /// <param name="orgId">Organization Id</param>
        /// <returns></returns>
        [HttpGet("/api/org/{orgid}/devicemessageconfigs")]
        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetDeviceMessageConfigurationsForOrgAsync(String orgId)
        {
            var deviceMessageConfiguration = await _deviceConfigManager.GetDeviceMessageDefinitionsForOrgsAsync(orgId, UserEntityHeader);
            return ListResponse<DeviceMessageDefinitionSummary>.Create(deviceMessageConfiguration);
        }

        /// <summary>
        /// Device Message Config - Get A Configuration
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/devicemessageconfig/{id}")]
        public async Task<DetailResponse<DeviceMessageDefinition>> GetDeviceMessageConfigurationAsync(String id)
        {
            var deviceMessageConfiguration = await _deviceConfigManager.GetDeviceMessageDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<DeviceMessageDefinition>.Create(deviceMessageConfiguration);
        }

        /// <summary>
        /// Device Message Config - Check in Use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/devicemessageconfig/{id}/inuse")]
        public Task<DependentObjectCheckResult> InUseCheck(String id)
        {
            return _deviceConfigManager.CheckDeviceMessageInUseAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// Device Message Config - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessageconfig/{key}/keyinuse")]
        public Task<bool> DeviceConfigKeyInUse(String key)
        {
            return _deviceConfigManager.QueryDeviceMessageDefinitionKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// Device Message Config - Delete
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/api/devicemessageconfig/{id}")]
        public Task<InvokeResult> DeleteDeviceMessageConfigurationAsync(string id)
        {
            return _deviceConfigManager.DeleteDeviceMessageDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        ///  Device Message Config - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessageconfig/factory")]
        public DetailResponse<DeviceMessageDefinition> CreateDeviceMessageConfigurartion()
        {
            var response = DetailResponse<DeviceMessageDefinition>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(response.Model);
            SetOwnedProperties(response.Model);

            return response;
        }

        /// <summary>
        ///  Device Message Sample- Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessageconfig/samplemessage/factory")]
        public DetailResponse<SampleMessage> CreateSampleMessage()
        {
            return DetailResponse<SampleMessage>.Create();
        }

        /// <summary>
        ///  Device Message Faming Byte - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessageconfig/framingbyte/factory")]
        public DetailResponse<MessageFramingBytes> CreateFramingByte()
        {
            return DetailResponse<MessageFramingBytes>.Create();
        }


        /// <summary>
        ///  Device Message Config - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagefield/factory")]
        public DetailResponse<DeviceMessageDefinitionField> CreateDeviceMessageField()
        {
            var response = DetailResponse<DeviceMessageDefinitionField>.Create();
            return response;
        }
    }
}
