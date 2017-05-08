using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.MessageFramingByte_Byte, DeviceMessagingAdminResources.Names.MessageFramingByte_Byte_Help, DeviceMessagingAdminResources.Names.MessageFramingByte_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminDomain))]
    public class MessageFramingBytes
    {
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Byte, FieldType:FieldTypes.Byte, HelpResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Byte_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Byte { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Index, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Index_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int Index { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Description, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Description { get; set; }
    }
}
