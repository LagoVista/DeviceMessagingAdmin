using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    public enum ParseBinaryValueType
    {
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_String, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_String, typeof(DeviceMessagingAdminResources))]
        String,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Boolean, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Boolean, typeof(DeviceMessagingAdminResources))]
        Boolean,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Char, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Char, typeof(DeviceMessagingAdminResources))]
        Char,

        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_UInt8, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_UInt8, typeof(DeviceMessagingAdminResources))]
        UInt8,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Int8, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Int8, typeof(DeviceMessagingAdminResources))]
        Int8,


        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_UInt16, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_UInt16, typeof(DeviceMessagingAdminResources))]
        UInt16,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Int16, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Int16, typeof(DeviceMessagingAdminResources))]
        Int16,

        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_UInt32, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_UInt32, typeof(DeviceMessagingAdminResources))]
        UInt32,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Int32, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Int32, typeof(DeviceMessagingAdminResources))]
        Int32,

        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_UInt64, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_UInt64, typeof(DeviceMessagingAdminResources))]
        UInt64,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Int64, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Int64, typeof(DeviceMessagingAdminResources))]
        Int64,

        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_SinglePrecisionFloatingPoint, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_SinglePrecisionFloatingPoint, typeof(DeviceMessagingAdminResources))]
        SinglePrecisionFloatingPoint,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_DoublePrecisionFloatingPoint, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_DoublePrecisionFloatingPoint, typeof(DeviceMessagingAdminResources))]
        DoublePrecisionFloatingPoint,
    }

    public enum ParseStringValueType
    {
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_String, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_String, typeof(DeviceMessagingAdminResources))]
        String,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_WholeNumber, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_WholeNumber, typeof(DeviceMessagingAdminResources))]
        WholeNumber,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_RealNumber, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_FloatingPointNumber, typeof(DeviceMessagingAdminResources))]
        RealNumber,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_Boolean, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_Boolean, typeof(DeviceMessagingAdminResources))]
        Boolean
    }

    public enum SearchLocations
    {
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Headers, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Headers, typeof(DeviceMessagingAdminResources))]
        Header,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_QueryString, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_QueryString, typeof(DeviceMessagingAdminResources))]
        QueryString,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Path, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Path, typeof(DeviceMessagingAdminResources))]
        Path,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Body, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Body, typeof(DeviceMessagingAdminResources))]
        Body
    }

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceMessageField_Title, DeviceMessagingAdminResources.Names.DeviceMessageField_Help, DeviceMessagingAdminResources.Names.DeviceMessageField_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminResources))]
    public class DeviceMessageDefinitionField : IKeyedEntity, INamedEntity, IValidateable
    {
        public DeviceMessageDefinitionField()
        {
            Id = Guid.NewGuid().ToId();
        }

        public const string ParserBinaryType_String = "string";
        public const string ParserBinaryType_Boolean = "boolean";
        public const string ParserBinaryType_Char = "char";

        public const string ParserBinaryType_UInt8 = "uint8";
        public const string ParserBinaryType_Int8 = "int8";

        public const string ParserBinaryType_UInt16 = "uint16";
        public const string ParserBinaryType_Int16 = "int16";

        public const string ParserBinaryType_UInt32 = "uint32";
        public const string ParserBinaryType_Int32 = "int32";

        public const string ParserBinaryType_UInt64 = "uint64";
        public const string ParserBinaryType_Int64 = "int64";

        public const string ParserBinaryType_SinglePrecisionFloatingPoint = "singleprecisionfloatingpoint";
        public const string ParserBinaryType_DoublePrecisionFloatingPoint = "dingleprecisionfloatingpoint";


        public const string ParserStringType_String = "string";
        public const string ParserStringType_WholeNumber = "wholenumber";
        public const string ParserStringType_RealNumber = "realnumber";
        public const string ParserStringType_Boolean = "boolean";

        public const string SearchLocation_Headers = "headers";
        public const string SearchLocation_QueryString = "querystring";
        public const string SearchLocation_Path = "path";
        public const string SearchLocation_Body = "body";


        public String Id { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Key, HelpResource: DeviceMessagingAdminResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: DeviceMessagingAdminResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Name { get; set; }


        /* Can search anywhere */
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation, EnumType: (typeof(SearchLocations)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Select, IsRequired: true)]
        public EntityHeader<SearchLocations> SearchLocation { get; set; }


        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType, EnumType: (typeof(ParseBinaryValueType)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Select)]
        public EntityHeader<ParseBinaryValueType> ParsedBinaryFieldType { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Custom)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [AllowableMessageContentType(MessageContentTypes.String)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType, EnumType: (typeof(ParseStringValueType)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Select)]
        public EntityHeader<ParseStringValueType> ParsedStringFieldType { get; set; }


        /* Required for all fields */
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType, EnumType: (typeof(ParameterTypes)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType_Select, IsRequired: true)]
        public EntityHeader<ParameterTypes> StorageType { get; set; }

        /* Can be used after extracting value */
        [AllowableStorageContentType(ParameterTypes.String)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValidation, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValidation_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExValidation { get; set; }

        [AllowableMessageContentType(MessageContentTypes.String)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValueSelector, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValueSelector_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExValueSelector { get; set; }


        [AllowableMessageContentType(MessageContentTypes.String)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExGroupName { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Attribute_UnitSet, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }

        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Delimited_Index, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Delimited_Index_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? DelimitedIndex { get; set; }

        [AllowableMessageContentType(MessageContentTypes.String)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StartIndex, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? StartIndex { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Index, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.MessageFramingByte_Index_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? FieldIndex { get; set; }

        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string XPath { get; set; }

        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string JsonPath { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_IsRequired, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_PathLocator, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_PathLocator_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string PathLocator { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string QueryStringField { get; set; }


        [AllowableStorageContentType(ParameterTypes.Integer)]
        [AllowableStorageContentType(ParameterTypes.Decimal)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MinValue, FieldType: FieldTypes.Decimal, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MinValue_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public double? MinValue { get; set; }

        [AllowableStorageContentType(ParameterTypes.Integer)]
        [AllowableStorageContentType(ParameterTypes.Decimal)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MaxValue, FieldType: FieldTypes.Decimal, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MaxValue_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public double? MaxValue { get; set; }

        private bool HasValue(PropertyInfo property)
        {
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
            else if(value is Int32)
            {
                hasValue = true;
            }

            return hasValue;
        }

        private String GetDisplayName(PropertyInfo property)
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

            return name;
        }

        private void AddWarningForUnsedProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
            if (hasValue && allowableTypeProperties.Any() && !allowableTypeProperties.Where(allowable => allowable.ContentType == contentType.Value).Any())
            {
                var invalidTypeMsg = Resources.DeviceMessagingAdminResources.DeviceMessage_PropertyTypeHasValueButNotSupported.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
                result.Warnings.Add(new ErrorMessage(invalidTypeMsg));
            }
        }

        private void AddErrorsForMissingProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
            foreach (var allowableProperty in allowableTypeProperties)
            {
                if (!hasValue && allowableProperty.IsRequired && allowableProperty.ContentType == contentType.Value)
                {
                    var missingMessage = Resources.DeviceMessagingAdminResources.DeviceMessage_PropertyRequiredForContentType.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
                    result.Errors.Add(new ErrorMessage(missingMessage));
                }
            }
        }

        public ValidationResult Validate(DeviceMessageDefinition messageDefinition)
        {
            var result = Validator.Validate(this);
            /* If base validation doesn't work, don't bother getting into the details */
            if (result.Successful)
            {
                switch (SearchLocation.Value)
                {
                    case SearchLocations.Body:
                        foreach (var property in typeof(DeviceMessageDefinitionField).GetTypeInfo().DeclaredProperties)
                        {
                            var name = GetDisplayName(property);
                            var hasValue = HasValue(property);

                            AddWarningForUnsedProperties(result, messageDefinition.ContentType, property, name, hasValue);
                            AddErrorsForMissingProperties(result, messageDefinition.ContentType, property, name, hasValue);
                        }
                        break;
                    case SearchLocations.Header:
                        break;
                    case SearchLocations.Path:
                        break;
                    case SearchLocations.QueryString:
                        break;
                }
            }

            return result;
        }
    }
}
