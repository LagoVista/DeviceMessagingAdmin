using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    public enum MessageContentTypes
    {
        [EnumLabel(DeviceMessageDefinition.ContentType_Binary, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Binary, typeof(DeviceMessagingAdminResources))]
        Binary,
        [EnumLabel(DeviceMessageDefinition.ContentType_String, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_String, typeof(DeviceMessagingAdminResources))]
        String,
        [EnumLabel(DeviceMessageDefinition.ContentType_Delimited, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Delimited, typeof(DeviceMessagingAdminResources))]
        Delimited,
        [EnumLabel(DeviceMessageDefinition.ContentType_Json, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Json, typeof(DeviceMessagingAdminResources))]
        JSON,
        [EnumLabel(DeviceMessageDefinition.ContentType_Xml, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Xml, typeof(DeviceMessagingAdminResources))]
        XML,
        [EnumLabel(DeviceMessageDefinition.ContentType_Custom, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Custom, typeof(DeviceMessagingAdminResources))]
        Custom
    }

    public enum BinaryParsingStrategy
    {
        [EnumLabel(DeviceMessageDefinition.BinaryParsingStrategy_Absolute, DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Absolute, typeof(DeviceMessagingAdminResources))]
        Absolute,
        [EnumLabel(DeviceMessageDefinition.BinaryParsingStrategy_Relative, DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Relative, typeof(DeviceMessagingAdminResources))]
        Relative,
        [EnumLabel(DeviceMessageDefinition.BinaryParsingStrategy_Script, DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Script, typeof(DeviceMessagingAdminResources))]
        Script
    }

    public enum StringParsingStrategy
    {
        [EnumLabel(DeviceMessageDefinition.StringParsingStrategy_NullTerminated, DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy_NullTerminated, typeof(DeviceMessagingAdminResources))]
        NullTerminated,
        [EnumLabel(DeviceMessageDefinition.StringParsingStrategy_StringLength, DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy_LengthProvided, typeof(DeviceMessagingAdminResources))]
        StringLength
    }

    public enum EndianTypes
    {
        [EnumLabel(DeviceMessageDefinition.Endian_BigEndian, DeviceMessagingAdminResources.Names.DeviceMessgaeField_Endian_BigEndian, typeof(DeviceMessagingAdminResources))]
        BigEndian,
        [EnumLabel(DeviceMessageDefinition.Endian_LittleEndian, DeviceMessagingAdminResources.Names.DeviceMessgaeField_Endian_LittleEndian, typeof(DeviceMessagingAdminResources))]
        LittleEndian
    }

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Title, DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Help, DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminDomain))]
    public class DeviceMessageDefinition : LagoVista.IoT.DeviceAdmin.Models.IoTModelBase, IValidateable, IKeyedEntity, IOwnedEntity, INoSQLEntity
    {
        public const string ContentType_Binary = "binary";
        public const string ContentType_String = "string";
        public const string ContentType_Delimited = "delimited";
        public const string ContentType_Json = "json";
        public const string ContentType_Xml = "xml";
        public const string ContentType_Custom = "custom";

        public const string BinaryParsingStrategy_Absolute = "absolute";
        public const string BinaryParsingStrategy_Relative= "relative";
        public const string BinaryParsingStrategy_Script = "script";

        public const string StringParsingStrategy_NullTerminated = "nullterminated";
        public const string StringParsingStrategy_StringLength = "stringlength";

        public const string Endian_BigEndian = "bigendian";
        public const string Endian_LittleEndian = "littleendian";

        public DeviceMessageDefinition()
        {
            Fields = new List<DeviceMessageField>();
            FramingBytes = new List<MessageFramingBytes>();
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }

        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public bool QuotedText { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public string Delimiter { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MessageId, FieldType:FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MessageId_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string MessageId { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<MessageContentTypes> ContentType { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsingStrategy_Select, EnumType: typeof(BinaryParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<BinaryParsingStrategy> BinaryParsingStrategy { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_StringParsingStrategy_Select, EnumType: typeof(StringParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<StringParsingStrategy> StringParsingStrategy { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Select, EnumType: typeof(EndianTypes), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<EndianTypes> Endian { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_RegEx, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_RegEx_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public string RegEx { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Key, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: DeviceMessagingAdminResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Fields, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public List<DeviceMessageField> Fields { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Script, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public string Script { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_FramingBytes, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_FramingBytes_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public List<MessageFramingBytes> FramingBytes {get; set;}

        public DeviceMessageDefinitionSummary CreateSummary()
        {
            return new DeviceMessageDefinitionSummary()
            {
                Id = Id,
                Name = Name,
                Key = Key,
                IsPublic = IsPublic,
                Description = Description
            };
        }
    }

    public class DeviceMessageDefinitionSummary : LagoVista.Core.Models.SummaryData
    {

    }
}
