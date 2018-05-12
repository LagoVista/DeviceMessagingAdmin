using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.DeviceMessaging.Models.Resources;
using System;
using System.Linq;
using System.Reflection;


namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    #region Enum Defs
    public enum ParseBinaryValueType
    {
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_String, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_String, typeof(DeviceMessagingAdminResources))]
        String,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Boolean, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Boolean, typeof(DeviceMessagingAdminResources))]
        Boolean,
        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Char, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Char, typeof(DeviceMessagingAdminResources))]
        Char,

        [EnumLabel(DeviceMessageDefinitionField.ParserBinaryType_Byte, DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryParser_Byte, typeof(DeviceMessagingAdminResources))]
        Byte,


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
        Boolean,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_File, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_File, typeof(DeviceMessagingAdminResources))]
        File
    }

    public enum SearchLocations
    {
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Headers, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Headers, typeof(DeviceMessagingAdminResources))]
        Header,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_QueryString, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_QueryString, typeof(DeviceMessagingAdminResources))]
        QueryString,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Path, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Path, typeof(DeviceMessagingAdminResources))]
        Path,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Topic, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Topic, typeof(DeviceMessagingAdminResources))]
        Topic,
        [EnumLabel(DeviceMessageDefinitionField.SearchLocation_Body, DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Body, typeof(DeviceMessagingAdminResources))]
        Body
    }

    public enum FieldType
    {
        [EnumLabel(DeviceMessageDefinitionField.FieldType_MessageId, DeviceMessagingAdminResources.Names.DeviceMessageField_FieldType_MessageId, typeof(DeviceMessagingAdminResources))]
        MessageId,
        [EnumLabel(DeviceMessageDefinitionField.FieldType_DeviceId, DeviceMessagingAdminResources.Names.DeviceMessageField_FieldType_DeviceId, typeof(DeviceMessagingAdminResources))]
        DeviceId,
        [EnumLabel(DeviceMessageDefinitionField.FieldType_Content, DeviceMessagingAdminResources.Names.DeviceMessageField_FieldType_Content, typeof(DeviceMessagingAdminResources))]
        Content,
    }

    public enum DateTimeZoneOptions
    {
        [EnumLabel(DeviceMessageDefinitionField.DateTimeZone_NoTimeZone, DeviceMessagingAdminResources.Names.DateTimeZone_NoTimeZone, typeof(DeviceMessagingAdminResources))]
        NoTimeZone,
        [EnumLabel(DeviceMessageDefinitionField.DateTimeZone_Server, DeviceMessagingAdminResources.Names.DateTimeZone_Server, typeof(DeviceMessagingAdminResources))]
        UseServerTimeZone,
        [EnumLabel(DeviceMessageDefinitionField.DateTimeZone_Universal, DeviceMessagingAdminResources.Names.DateTimeZone_Universal, typeof(DeviceMessagingAdminResources))]
        UniversalTimeZone,
        [EnumLabel(DeviceMessageDefinitionField.DateTimeZone_8601, DeviceMessagingAdminResources.Names.DateTimeZone_8601, typeof(DeviceMessagingAdminResources))]
        ISO8601
    }
    #endregion

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceMessageField_Title, DeviceMessagingAdminResources.Names.DeviceMessageField_Help, DeviceMessagingAdminResources.Names.DeviceMessageField_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminResources))]
    public class DeviceMessageDefinitionField : IKeyedEntity, INamedEntity, IValidateable
    {
        #region Constructor
        public DeviceMessageDefinitionField()
        {
            DecimalScaler = 1.0;
            Id = Guid.NewGuid().ToId();
        }
        #endregion

        #region Constants used for setting values on enums
        public const string DateTimeZone_NoTimeZone = "notimezone";
        public const string DateTimeZone_Server = "servertimezone";
        public const string DateTimeZone_Universal = "universaltimezone";
        public const string DateTimeZone_8601 = "iso8601";

        public const string ParserBinaryType_String = "string";
        public const string ParserBinaryType_Boolean = "boolean";
        public const string ParserBinaryType_Char = "char";
        public const string ParserBinaryType_Byte = "byte";

        public const string ParserBinaryType_UInt16 = "uint16";
        public const string ParserBinaryType_Int16 = "int16";

        public const string ParserBinaryType_UInt32 = "uint32";
        public const string ParserBinaryType_Int32 = "int32";

        public const string ParserBinaryType_UInt64 = "uint64";
        public const string ParserBinaryType_Int64 = "int64";

        public const string ParserBinaryType_SinglePrecisionFloatingPoint = "singleprecisionfloatingpoint";
        public const string ParserBinaryType_DoublePrecisionFloatingPoint = "doubleprecisionfloatingpoint";


        public const string ParserStringType_String = "string";
        public const string ParserStringType_WholeNumber = "wholenumber";
        public const string ParserStringType_RealNumber = "realnumber";
        public const string ParserStringType_Boolean = "boolean";
        public const string ParserStringType_File = "file";

        public const string SearchLocation_Headers = "headers";
        public const string SearchLocation_QueryString = "querystring";
        public const string SearchLocation_Path = "path";
        public const string SearchLocation_Body = "body";
        public const string SearchLocation_Topic = "topic";

        public const string FieldType_Content = "content";
        public const string FieldType_MessageId = "messageid";
        public const string FieldType_DeviceId = "deviceid";
        #endregion

        #region Id/Key/Name Properties
        public String Id { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Key, HelpResource: DeviceMessagingAdminResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: DeviceMessagingAdminResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Name { get; set; }
        #endregion

        #region Common Fields
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? FieldIndex { get; set; }

        /* Can search anywhere */
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation, EnumType: (typeof(SearchLocations)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_SearchLocation_Select, IsRequired: true)]
        public EntityHeader<SearchLocations> SearchLocation { get; set; }

        /* Required for all fields */
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType, EnumType: (typeof(ParameterTypes)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType_Select, IsRequired:true)]
        public EntityHeader<ParameterTypes> StorageType { get; set; }

        [AllowableStorageContentType(ParameterTypes.ValueWithUnit)]
        [FormField(LabelResource: DeviceLibraryResources.Names.Attribute_UnitSet, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [AllowableStorageContentType(ParameterTypes.State)]
        [FormField(LabelResource: DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }
        #endregion

        #region Values for parsing message and device id fields
        /* 
         * Normally these values would be present in the message definition, since we are using the same parsing
         * meta data for both device id/message id and to extract values from content we need to provide these values for 
         * message id/device id parsers
         */

        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValueSelector, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValueSelector_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExValueSelector { get; set; }

        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [AllowableMessageContentType(MessageContentTypes.Delimited, isRequired: false)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool QuotedText { get; set; }


        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Delimiter, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Delimiter { get; set; }


        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<MessageContentTypes> ContentType { get; set; }
        #endregion

        #region Values to extract values from a binary message
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType, EnumType: (typeof(ParseBinaryValueType)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Select)]
        public EntityHeader<ParseBinaryValueType> ParsedBinaryFieldType { get; set; }


        [AllowableStorageContentType(ParameterTypes.TrueFalse)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_String_LeadingLength, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_String_LeadingLength_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? StringLengthByteCount { get; set; }

        [AllowableStorageContentType(ParameterTypes.Decimal)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Scaler, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_ScalerHelp, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceMessagingAdminResources))]
        public double DecimalScaler { get; set; }

        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsingStrategy_Select, EnumType: typeof(BinaryParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<BinaryParsingStrategy> BinaryParsingStrategy { get; set; }

        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [AllowableStorageContentType(ParameterTypes.TrueFalse)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_StringParsingStrategy_Select, EnumType: typeof(StringParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<StringParsingStrategy> StringParsingStrategy { get; set; }

        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Select, EnumType: typeof(EndianTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<EndianTypes> Endian { get; set; }
        #endregion

        #region Values for text type content messages
        //[AllowableMessageContentType(MessageContentTypes.Custom)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType, EnumType: (typeof(ParseStringValueType)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_MessageFieldType_Select)]
        public EntityHeader<ParseStringValueType> ParsedStringFieldType { get; set; }
        #endregion

        #region Locator Fields    
        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExGroupName { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatGroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatRegExGroupName { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonGroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonRegExGroupName { get; set; }


        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string JsonPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatJSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatJsonPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonJSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonJsonPath { get; set; }



        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Delimited_Index, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Delimited_Index_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? DelimitedIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatDelimitedIndex, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LatDelimitedIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonDelimitedIndex, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LonDelimitedIndex { get; set; }




        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? BinaryOffset { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatBinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LatBinaryOffset { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonBinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LonBinaryOffset { get; set; }



        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? StartIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatStartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LatStartIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonStartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LonStartIndex { get; set; }

        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Length, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? Length { get; set; }


        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string XPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatXPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatXPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonXPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonXPath { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatQueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatQueryStringField { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonQueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonQueryStringField { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_HeaderName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_HeaderName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string HeaderName { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string QueryStringField { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_PathLocator, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_PathLocator_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string PathLocator { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_TopicLocator, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_TopicLocator_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string TopicLocator { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_DefaultValue, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_DefaultValue_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string DefaultValue { get; set; }
        #endregion

        #region Misc Values
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DateTimeZone_Time_Zone, EnumType: (typeof(DateTimeZoneOptions)), HelpResource: DeviceMessagingAdminResources.Names.DateTimeZone_Time_Zone_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DateTimeZone_Select, IsRequired: false)]
        public EntityHeader<DateTimeZoneOptions> DateTimeZone { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Notes, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Notes { get; set; }
        #endregion

        #region Fields to do validation on value that is extracted
        /* Can be used after extracting value */
        [AllowableStorageContentType(ParameterTypes.String)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValidation, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValidation_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExValidation { get; set; }



        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_IsRequired, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool IsRequired { get; set; }

        [AllowableStorageContentType(ParameterTypes.Integer)]
        [AllowableStorageContentType(ParameterTypes.Decimal)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MinValue, FieldType: FieldTypes.Decimal, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MinValue_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public double? MinValue { get; set; }

        [AllowableStorageContentType(ParameterTypes.Integer)]
        [AllowableStorageContentType(ParameterTypes.Decimal)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MaxValue, FieldType: FieldTypes.Decimal, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_MaxValue_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public double? MaxValue { get; set; }
        #endregion

        #region Methods to perform validation against meta data, based on content of meta data.
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
            else if (value is Int32)
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

        private void AddWarningForUnsedProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue, bool fieldParser)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
            if (hasValue && allowableTypeProperties.Any() && !allowableTypeProperties.Where(allowable => allowable.ContentType == contentType.Value).Any())
            {
                var invalidTypeMsg = DeviceMessagingAdminResources.DeviceMessage_PropertyTypeHasValueButNotSupported.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
                result.Warnings.Add(new ErrorMessage(invalidTypeMsg));
            }
        }

        private void AddErrorsForMissingProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue, bool fieldParser)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
            var storageTypeValidators = property.GetCustomAttributes<AllowableStorageContentTypeAttribute>();

            var allowableFieldType = property.GetCustomAttributes<AllowableFieldTypeAttribute>().FirstOrDefault();
            if (allowableFieldType != null && (allowableFieldType.FieldType == FieldType.DeviceId || allowableFieldType.FieldType == FieldType.MessageId))
            {
                if (!fieldParser)
                {
                    return;
                }
            }

            foreach (var storageTypeValidator in storageTypeValidators)
            {
                if (storageTypeValidator.AnyValueButThis && StorageType.Value == storageTypeValidator.StorageType)
                {
                    return;
                }
            }

            var hasStorageTypeValidators = storageTypeValidators.Count() > 0;
            if (hasStorageTypeValidators)
            {
                if (storageTypeValidators.Where(stv => stv.StorageType == StorageType.Value && stv.AnyValueButThis).Any())
                {
                    /* If we want anything BUT the match, and we have the match, then don't validate */
                    return;
                }

                if (storageTypeValidators.Where(stv => stv.StorageType != StorageType.Value && !stv.AnyValueButThis).Any())
                {
                    /* We expect a match, but the storage types are different, then don't validate */
                    return;
                }
            }

            foreach (var allowableProperty in allowableTypeProperties)
            {
                if (!hasValue && allowableProperty.IsRequired &&
                    allowableProperty.ContentType == contentType.Value)
                {
                    var missingMessage = DeviceMessagingAdminResources.DeviceMessage_PropertyRequiredForContentType.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
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
                            AddWarningForUnsedProperties(result, messageDefinition.ContentType, property, name, hasValue, false);
                            AddErrorsForMissingProperties(result, messageDefinition.ContentType, property, name, hasValue, false);
                        }

                        break;
                    case SearchLocations.Header:
                        if (String.IsNullOrEmpty(HeaderName)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_HeaderNameMissing));
                        break;
                    case SearchLocations.Path:
                        if (String.IsNullOrEmpty(PathLocator)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_PathNameMissing));
                        break;
                    case SearchLocations.QueryString:
                        if (String.IsNullOrEmpty(QueryStringField)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_QueryStringNameMissing));
                        break;
                    case SearchLocations.Topic:
                        if (String.IsNullOrEmpty(TopicLocator)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_TopicRegEx));
                        break;
                }

                if (StorageType.Value == ParameterTypes.ValueWithUnit && EntityHeader.IsNullOrEmpty(UnitSet)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_FieldDefinitionMissing_UnitSet));
                if (StorageType.Value == ParameterTypes.State && EntityHeader.IsNullOrEmpty(StateSet)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_FieldDefinitionMissing_StateSet));

                if (StorageType.Value == ParameterTypes.Image && messageDefinition.ContentType.Value != MessageContentTypes.Media) result.AddUserError("Image storage type is only valid when the message definition content type is media.");
                if (StorageType.Value == ParameterTypes.Image && SearchLocation.Value != SearchLocations.Body) result.AddUserError("Field types of image are only valid when associated with the body of the message.");
            }

            return result;
        }

        /// <summary>
        /// This comes in when validating a device id and message id parser.
        /// </summary>
        /// <returns></returns>
        public ValidationResult Validate()
        {
            /* Will always use strings for device and message ids */
            StorageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.String);

            var result = Validator.Validate(this);

            /* If base validation doesn't work, don't bother getting into the details */
            if (result.Successful)
            {
                if (EntityHeader.IsNullOrEmpty(ContentType) && SearchLocation.Value == SearchLocations.Body)
                {
                    result.Errors.Add(Resources.DeviceMessagingAdminErrorCodes.CouldNotDetermineDeviceId.ToErrorMessage());
                }
                else
                {
                    switch (SearchLocation.Value)
                    {
                        case SearchLocations.Body:
                            foreach (var property in typeof(DeviceMessageDefinitionField).GetTypeInfo().DeclaredProperties)
                            {
                                var name = GetDisplayName(property);
                                var hasValue = HasValue(property);
                                AddWarningForUnsedProperties(result, ContentType, property, name, hasValue, true);
                                AddErrorsForMissingProperties(result, ContentType, property, name, hasValue, true);
                            }

                            break;
                        case SearchLocations.Header:
                            if (String.IsNullOrEmpty(HeaderName)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_HeaderNameMissing));
                            break;
                        case SearchLocations.Path:
                            if (String.IsNullOrEmpty(PathLocator)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_PathNameMissing));
                            break;
                        case SearchLocations.QueryString:
                            if (String.IsNullOrEmpty(QueryStringField)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_QueryStringNameMissing));
                            break;
                        case SearchLocations.Topic:
                            if (String.IsNullOrEmpty(TopicLocator)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_TopicRegEx));
                            if (!String.IsNullOrEmpty(RegExValueSelector) && String.IsNullOrEmpty(RegExGroupName)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_TopicGroupNameMissing));
                            break;
                    }
                }

                if (StorageType.Value == ParameterTypes.ValueWithUnit && EntityHeader.IsNullOrEmpty(UnitSet)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_FieldDefinitionMissing_UnitSet));
                if (StorageType.Value == ParameterTypes.State && EntityHeader.IsNullOrEmpty(StateSet)) result.Errors.Add(new ErrorMessage(DeviceMessagingAdminResources.Err_FieldDefinitionMissing_StateSet));
            }

            return result;
        }
        #endregion
    }
}