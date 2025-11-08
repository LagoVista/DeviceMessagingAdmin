// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 14bd263a1e145097c17bd737a951b80013beab4269c8e0d65538ac093c6f0af2
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.DeviceMessaging.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.MessageFramingByte_Byte, DeviceMessagingAdminResources.Names.MessageFramingByte_Byte_Help, 
        DeviceMessagingAdminResources.Names.MessageFramingByte_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminDomain), FactoryUrl: "/api/devicemessagetype/framingbyte/factory")]
    public class MessageFramingBytes
    {
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Byte, FieldType:FieldTypes.Byte, HelpResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Byte_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Byte { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Index, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Index_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int Index { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Description, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Description { get; set; }

        public byte? ToByte()
        {
            if(System.Byte.TryParse(Byte, System.Globalization.NumberStyles.HexNumber, null, out byte output))
            {
                return output;
            }
            else
            {
                return null;
            }
        }
    }
}
