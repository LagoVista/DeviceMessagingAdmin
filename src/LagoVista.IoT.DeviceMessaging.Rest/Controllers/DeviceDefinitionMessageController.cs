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
using LagoVista.Core.Cloning;
using LagoVista.IoT.DeviceMessaging.Admin.Services;
using LagoVista.IoT.DeviceMessaging.Models;
using System.Collections.Generic;
using System.Linq;

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
        /// Device Message Type - Test parsing a seven segement message.
        /// </summary>
        /// <param name="deviceMessageConfiguration"></param>
        /// <returns></returns>
        [HttpPost("/api/devicemessagetype/sevensegement/test")]
        public InvokeResult<List<SevenSegementParseResult>> TestParseConfiguration([FromBody] DeviceMessageDefinition deviceMessageConfiguration)
        {
            return SevenSegementImageParser.Parse(deviceMessageConfiguration);
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
            return await _deviceConfigManager.GetDeviceMessageDefinitionsForOrgsAsync(OrgEntityHeader.Id, UserEntityHeader, GetListRequestFromHeader());
        }

        /// <summary>
        /// Device Message Type - Get Configs for Org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetypes/sevenseg")]
        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetSevenSegmentDeviceMessageConfigurationsForOrgAsync()
        {
            return await _deviceConfigManager.GetSevenSegementDeviceMessageDefinitionsForOrgsAsync(OrgEntityHeader.Id, UserEntityHeader, GetListRequestFromHeader());
        }

        /// <summary>
        /// Device Message Type - Get Public  Message Types
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetypes/public")]
        public async Task<ListResponse<DeviceMessageDefinitionSummary>> GetPublishMessageTypesForOrgAsync()
        {
            return await _deviceConfigManager.GetPublicDeviceMessageDefinitionsAsync(GetListRequestFromHeader());
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
        /// Device Message Type - Get A Configuration
        /// </summary>
        /// <param name="cloneRequest"></param>
        /// <returns></returns>
        [HttpGet("/api/devicemessagetype/clone")]
        public Task<InvokeResult> CloneMessageDefintion([FromBody] CloneRequest cloneRequest)
        {
            return _deviceConfigManager.CloneDeviceMessageDefinition(cloneRequest, OrgEntityHeader, UserEntityHeader);
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

        /// <summary>
        ///  Device Message Type, Field - Create New
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/messageattributeparser/factory")]
        public DetailResponse<MessageAttributeParser> CreateDeviceEnvelopeMessageField()
        {
            var result = DetailResponse<MessageAttributeParser>.Create();

            var contentOptions = result.View[nameof(MessageAttributeParser.ContentType).CamelCase()].Options;
            contentOptions.Remove(contentOptions.Single(opt => opt.Id == DeviceMessageDefinition.ContentType_Media));
            contentOptions.Remove(contentOptions.Single(opt => opt.Id == DeviceMessageDefinition.ContentType_GeoPointArray));
            contentOptions.Remove(contentOptions.Single(opt => opt.Id == DeviceMessageDefinition.ContentType_NoContent));
            contentOptions.Remove(contentOptions.Single(opt => opt.Id == DeviceMessageDefinition.ContentType_SevenSegementImage));
            contentOptions.Remove(contentOptions.Single(opt => opt.Id == DeviceMessageDefinition.ContentType_PointArray));
            contentOptions.Remove(contentOptions.Single(opt => opt.Id == DeviceMessageDefinition.ContentType_ProtoBuf));
            return result;
        }



        /// <summary>
        ///  Device Message Type, Validate Message Field
        /// </summary>
        /// <returns></returns>
        [HttpPut("/api/devicemessagetype/field/validate")]
        public ValidationResult ValidateMessageField([FromBody] MessageFieldValidator field)
        {
            return field.Field.Validate(field.MessageDefinition);
        }


        /// <summary>
        ///  Device Message Type, Validate Message Id/Device Id Parser
        /// </summary>
        /// <returns></returns>
        [HttpPut("/api/devicemessagetype/fieldparser/validate")]
        public ValidationResult ValidateMessageField([FromBody] DeviceMessageDefinitionField field)
        {
            return field.Validate();
        }

        /// <summary>
        /// Device Message Type - Create fields from JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("/api/devicemessagetype/fields/parse")]
        public InvokeResult<List<DeviceMessageDefinitionField>> CreateFromJSON([FromBody] Object json)
        {
            if (json == null)
            {
                return InvokeResult<List<DeviceMessageDefinitionField>>.FromError("Empty payload provided.");
            }

            if (String.IsNullOrEmpty(json.ToString()))
            {
                return InvokeResult<List<DeviceMessageDefinitionField>>.FromError("Empty payload provided.");
            }

            Console.WriteLine(json.ToString());

           return DeviceMessageDefinitionField.CreateFieldsFromJSON(json.ToString());
        }
    }
}
