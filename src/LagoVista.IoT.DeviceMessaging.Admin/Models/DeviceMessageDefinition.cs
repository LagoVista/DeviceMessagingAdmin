using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System.Reflection;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using System;
using System.Linq;
using System.Collections.Generic;

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
        public const string BinaryParsingStrategy_Relative = "relative";
        public const string BinaryParsingStrategy_Script = "script";

        public const string StringParsingStrategy_NullTerminated = "nullterminated";
        public const string StringParsingStrategy_StringLength = "stringlength";

        public const string Endian_BigEndian = "bigendian";
        public const string Endian_LittleEndian = "littleendian";

        public DeviceMessageDefinition()
        {
            Fields = new List<DeviceMessageDefinitionField>();
            FramingBytes = new List<MessageFramingBytes>();
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }

        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Key, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: DeviceMessagingAdminResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Fields, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceMessagingAdminResources))]
        public List<DeviceMessageDefinitionField> Fields { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MessageId, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MessageId_Help, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public string MessageId { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Delimited, isRequired:false)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool QuotedText { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Delimiter, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Delimiter { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<MessageContentTypes> ContentType { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsingStrategy_Select, EnumType: typeof(BinaryParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<BinaryParsingStrategy> BinaryParsingStrategy { get; set; }


        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_StringParsingStrategy_Select, EnumType: typeof(StringParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<StringParsingStrategy> StringParsingStrategy { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Select, EnumType: typeof(EndianTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<EndianTypes> Endian { get; set; }

        [AllowableMessageContentType(MessageContentTypes.String)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_RegEx, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_RegEx_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegEx { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Custom)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Script, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Script { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_FramingBytes, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_FramingBytes_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceMessagingAdminResources))]
        public List<MessageFramingBytes> FramingBytes { get; set; }

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

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            /* Introduces business logic to validate model specific properties that can not be specified in the FormField attribute, if we 
             * get here and there is already an error, just bail out, if the core of the model isn't valid don't bother doing second level
             * validation */
            if (!result.Successful)
            {
                return;
            }

            if(ContentType == null || ContentType.IsEmpty())
            {
                if(ContentType == null || ContentType.IsEmpty())
                {
                    //TODO: should arlready call core validation, if content type is null we went through an invalid path and we aren't localizing...sorry.
                    result.Errors.Add(new ErrorMessage("Content Type is Required."));
                    return;
                }
            }

            foreach (var property in typeof(DeviceMessageDefinition).GetTypeInfo().DeclaredProperties)
            {
                var name = property.Name;

                var formFieldAttr = property.GetCustomAttribute<FormFieldAttribute>();

                if (formFieldAttr != null && !String.IsNullOrEmpty(formFieldAttr.LabelDisplayResource))
                {
                    if (formFieldAttr.ResourceType == null)
                    {
                        throw new Exception($"Building Metadata - label is defined, but Resource Type is not defined on {name} {formFieldAttr.LabelDisplayResource}");
                    }

                    var labelProperty = formFieldAttr.ResourceType.GetTypeInfo().GetDeclaredProperty(formFieldAttr.LabelDisplayResource);
                    name = (string)labelProperty.GetValue(labelProperty.DeclaringType, null);
                }

                var value = property.GetValue(this);
                var hasValue = false;
                if (value == null)
                {
                    hasValue = false;

                }
                else if (value is string)
                {
                    hasValue = !String.IsNullOrEmpty(value.ToString());
                }
                else if (value is EntityHeader)
                {
                    var eh = value as EntityHeader;
                    hasValue = !eh.IsEmpty();
                }

                var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
                if (hasValue && allowableTypeProperties.Any() && !allowableTypeProperties.Where(allowable => allowable.ContentType == ContentType.Value).Any())
                {
                    var invalidTypeMsg = Resources.DeviceMessagingAdminResources.DeviceMessage_PropertyTypeHasValueButNotSupported.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, ContentType.Text);
                    result.Warnings.Add(new ErrorMessage(invalidTypeMsg));
                }

                foreach (var allowableProperty in allowableTypeProperties)
                {
                    if (!hasValue && allowableProperty.IsRequired && allowableProperty.ContentType == ContentType.Value)
                    {
                        var missingMessage = Resources.DeviceMessagingAdminResources.DeviceMessage_PropertyRequiredForContentType.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, ContentType.Text);
                        result.Errors.Add(new ErrorMessage(missingMessage));
                    }
                }
            }


            foreach (var field in Fields)
            {
                var fieldValidationResult = field.Validate(this);
                result.Concat(fieldValidationResult);
            }
        }
    }

    public class DeviceMessageDefinitionSummary : LagoVista.Core.Models.SummaryData
    {

    }
}
