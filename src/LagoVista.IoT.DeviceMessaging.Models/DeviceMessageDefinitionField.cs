using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.DeviceMessaging.Models;
using LagoVista.IoT.DeviceMessaging.Models.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        File,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_WholeNumberArray, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_WholeNumberArray, typeof(DeviceMessagingAdminResources))]
        WholeNumberArray,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_RealNummberArray, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_RealNumberArray, typeof(DeviceMessagingAdminResources))]
        RealNumberArray,
        [EnumLabel(DeviceMessageDefinitionField.ParserStringType_StringArray, DeviceMessagingAdminResources.Names.DeviceMessageField_StringParser_StringArray, typeof(DeviceMessagingAdminResources))]
        StringArray,
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
        ISO8601,
        [EnumLabel(DeviceMessageDefinitionField.DateTimeZone_EpochSeconds, DeviceMessagingAdminResources.Names.DateTimeZone_EpochSeconds, typeof(DeviceMessagingAdminResources))]
        UnixEPOCH_Seconds,
        [EnumLabel(DeviceMessageDefinitionField.DateTimeZone_EpochMS, DeviceMessagingAdminResources.Names.DateTimeZone_EpochMS, typeof(DeviceMessagingAdminResources))]
        UnixEPOCH_MS,
    }

#endregion

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceMessageField_Title, DeviceMessagingAdminResources.Names.DeviceMessageField_Help,
        DeviceMessagingAdminResources.Names.DeviceMessageField_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminResources), FactoryUrl: "/api/devicemessagetype/field/factory")]
    public class DeviceMessageDefinitionField : MessageAttributeParser, IKeyedEntity, INamedEntity, IValidateable, IFormDescriptor, IFormConditionalFields
    {
        public DeviceMessageDefinitionField()
        {
            Id = Guid.NewGuid().ToId();
            SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body);
            DecimalScaler = 1.0;
            Segments = new List<DisplayImageSegment>();
        }

        public new List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),

                nameof(Key),

                nameof(ContentType),

                nameof(SearchLocation),
                nameof(ParsedBinaryFieldType),
                nameof(ParsedStringFieldType),
                nameof(StorageType),
                nameof(UnitSet),
                nameof(StateSet),

                nameof(IsRequired),

                nameof(DateTimeZone),

                nameof(FieldIndex),

                nameof(PathLocator),

                nameof(DelimitedIndex),
                nameof(LatDelimitedIndex),
                nameof(LonDelimitedIndex),
                nameof(AltitudeDelimitedIndex),

                nameof(StartIndex),
                nameof(LatStartIndex),
                nameof(LonStartIndex),
                nameof(AltitudeStartIndex),

                nameof(QueryStringField),
                nameof(LatQueryStringField),
                nameof(LonQueryStringField),
                nameof(AltitudeQueryStringField),

                nameof(TopicLocator),

                nameof(JsonPath),

                nameof(LatJsonPath),
                nameof(LonJsonPath),
                nameof(AltitudeJsonPath),

                nameof(HeaderName),
                nameof(XPath),
                nameof(LatXPath),
                nameof(LonXPath),
                nameof(AltitudeXPath),

                nameof(BinaryOffset),

                nameof(RegExValueSelector),
                nameof(RegExGroupName),

                nameof(MinValue),
                nameof(MaxValue),
                nameof(RegExValidation),

                nameof(Notes)

            };
        }


        //TODO: Not Being Used, probably need to think through this a bit, we are using this definition for
        //      both message parsers and message id/device id parser, each one is different.  For now, just 
        //      implementing in front end logic.
        public new FormConditionals GetConditionalFields()
        {
            return new FormConditionals();
            /*return new FormConditionals()
            {
                ConditionalFields = new List<string>() { nameof(StateSet), nameof(UnitSet), nameof(HeaderName), nameof(TopicLocator), nameof(DecimalScaler),
                                                         nameof(XPath), nameof(LatXPath), nameof(LonXPath), nameof(AltitudeXPath),
                                                         nameof(StartIndex), nameof(LatStartIndex), nameof(LonStartIndex), nameof(AltitudeStartIndex),
                                                         nameof(JsonPath), nameof(LatJsonPath), nameof(LonJsonPath), nameof(AltitudeJsonPath),
                                                         nameof(BinaryOffset), nameof(LatBinaryOffset), nameof(LonBinaryOffset), nameof(AltitudeBinaryOffset),
                                                         nameof(DelimitedIndex), nameof(LatDelimitedIndex), nameof(LonDelimitedIndex), nameof(AltitudeDelimitedIndex),
                                                         nameof(FieldIndex), nameof(RegExValueSelector), nameof(QueryStringField), nameof(LatQueryStringField), nameof(LonQueryStringField), nameof(AltitudeQueryStringField),
                                                         nameof(PathLocator), nameof(ParsedStringFieldType), nameof(ParsedBinaryFieldType),
                                                         nameof(RegExGroupName), nameof(LatRegExGroupName),nameof(LonRegExGroupName), nameof(AltitudeRegExGroupName),
                                                         nameof(MinValue), nameof(MaxValue), nameof(DateTimeZone), nameof(RegExValidation)},
                Conditionals = new List<FormConditional>()
                {
                    new FormConditional()
                    {
                         Field = nameof(StorageType),
                         Values = new List<string>() {TypeSystem.Decimal, TypeSystem.Integer},
                         VisibleFields = new List<string>() { nameof(MinValue), nameof(MaxValue)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(StorageType),
                         Value = TypeSystem.DateTime,
                         VisibleFields = new List<string>() { nameof(DateTimeZone)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(StorageType),
                         Value = TypeSystem.String,
                         VisibleFields = new List<string>() { nameof(RegExValidation), nameof(RegExValueSelector)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(SearchLocation),
                         Value = SearchLocation_Body,
                         VisibleFields = new List<string>() { nameof(ContentType)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Json,
                         VisibleFields = new List<string>() { nameof(JsonPath)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Xml,
                         VisibleFields = new List<string>() { nameof(XPath)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Delimited,
                         VisibleFields = new List<string>() { nameof(Delimiter), nameof(DelimitedIndex)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Binary,
                         VisibleFields = new List<string>() { nameof(ParsedBinaryFieldType)}
                    },
                }
            };*/
        }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_DefaultValue, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_DefaultValue_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string DefaultValue { get; set; }

        /* Required for all fields */
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType, EnumType: (typeof(ParameterTypes)), HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DeviceMessageField_StorageFieldType_Select, IsRequired: true)]
        public EntityHeader<ParameterTypes> StorageType { get; set; }



        [AllowableStorageContentType(ParameterTypes.Decimal)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Scaler, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_ScalerHelp, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceMessagingAdminResources))]
        public double DecimalScaler { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DateTimeZone_Time_Zone, EnumType: (typeof(DateTimeZoneOptions)), HelpResource: DeviceMessagingAdminResources.Names.DateTimeZone_Time_Zone_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceMessagingAdminResources), WaterMark: DeviceMessagingAdminResources.Names.DateTimeZone_Select, IsRequired: false)]
        public EntityHeader<DateTimeZoneOptions> DateTimeZone { get; set; }

        [AllowableFieldType(FieldType.DeviceId)]
        [AllowableFieldType(FieldType.MessageId)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public new EntityHeader<MessageContentTypes> ContentType { get; set; }

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

        [FKeyProperty(nameof(UnitSet), "Fields[*].UnitSet.Id = {0}","")]
        [AllowableStorageContentType(ParameterTypes.ValueWithUnit)]
        [FormField(LabelResource: DeviceLibraryResources.Names.Attribute_UnitSet, FieldType: FieldTypes.EntityHeaderPicker,  WaterMark: DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FKeyProperty(nameof(UnitSet), "Fields[*].StateSet.Id = {0}", "")]
        [AllowableStorageContentType(ParameterTypes.State)]
        [FormField(LabelResource: DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }

        protected override void AddWarningForUnsedProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue, bool fieldParser)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
            if (hasValue && allowableTypeProperties.Any() && !allowableTypeProperties.Where(allowable => allowable.ContentType == contentType.Value).Any())
            {
                var invalidTypeMsg = DeviceMessagingAdminResources.DeviceMessage_PropertyTypeHasValueButNotSupported.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
                result.Warnings.Add(new ErrorMessage(invalidTypeMsg));
            }
        }


        protected  override void AddErrorsForMissingProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue, bool fieldParser)
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
        public new ValidationResult Validate()
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

        public static InvokeResult<List<DeviceMessageDefinitionField>> CreateFieldsFromJSON(String json)
        {
            try
            {
                var jobj = JsonConvert.DeserializeObject(json) as JObject;
                if (jobj == null)
                {
                    return InvokeResult<List<DeviceMessageDefinitionField>>.FromError("Could not create parse JSON");
                }
                else
                {
                    return CreateFromJObject(jobj);
                }
            }
            catch (JsonReaderException ex)
            {
                return InvokeResult<List<DeviceMessageDefinitionField>>.FromError(ex.Message);
            }
        }


        public static InvokeResult<List<DeviceMessageDefinitionField>> CreateFromJObject(JObject jobj, string parentPath = "")
        {

            var fields = new List<DeviceMessageDefinitionField>();
            foreach (var child in jobj.Children())
            {
                if (child is JProperty prop)

                {
                    var thisPath = String.IsNullOrEmpty(parentPath) ? prop.Name : $"{parentPath}.{prop.Name}";

                    if (prop.Value is JObject childObject)
                    {
                        var resposne = CreateFromJObject(childObject, thisPath);
                        if (resposne.Successful)
                        {
                            fields.AddRange(resposne.Result);
                        }
                        else
                        {
                            return resposne;
                        }
                    }
                    else
                    {
                        var field = prop.ToDeviceMessageField(parentPath);
                        fields.Add(field);
                    }
                }
            }

            return InvokeResult<List<DeviceMessageDefinitionField>>.Create(fields);
        }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatGroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatRegExGroupName { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonGroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonRegExGroupName { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_AltitudeGroupName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_GroupName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string AltitudeRegExGroupName { get; set; }




        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatXPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatXPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonXPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonXPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMssageField_AltitudeXPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string AltitudeXPath { get; set; }



        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatQueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatQueryStringField { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonQueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonQueryStringField { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_AltitudeQueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string AltitudeQueryStringField { get; set; }


        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatBinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LatBinaryOffset { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonBinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LonBinaryOffset { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_AltitudeBinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? AltitudeBinaryOffset { get; set; }



        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatJSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LatJsonPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonJSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string LonJsonPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_AltitudeJSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string AltitudeJsonPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatDelimitedIndex, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LatDelimitedIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonDelimitedIndex, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LonDelimitedIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_AltitudeFieldIndex, FieldType: FieldTypes.Integer, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_FieldIndex_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? AltitudeDelimitedIndex { get; set; }


        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LatStartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LatStartIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_LonStartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? LonStartIndex { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_AltitudeStartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? AltitudeStartIndex { get; set; }

        public List<DisplayImageSegment> Segments { get; set; }



        public new DeviceMessageDefinitionField Clone(bool newId = false, EntityHeader org = null, EntityHeader user = null)
        {
            var fld = new DeviceMessageDefinitionField()
            {
                Id = newId ? Guid.NewGuid().ToId() : Id,
                AltitudeJsonPath = AltitudeJsonPath,
                AltitudeRegExGroupName = AltitudeRegExGroupName,
                AltitudeBinaryOffset = AltitudeBinaryOffset,
                AltitudeXPath = AltitudeXPath,
                AltitudeQueryStringField = AltitudeQueryStringField,
                AltitudeDelimitedIndex = AltitudeDelimitedIndex,
                AltitudeStartIndex = AltitudeStartIndex,
                BinaryOffset = BinaryOffset,
                BinaryParsingStrategy = BinaryParsingStrategy.Clone(),
                ContentType = ContentType.Clone(),
                DateTimeZone = DateTimeZone.Clone(),
                DecimalScaler = DecimalScaler,
                DefaultValue = DefaultValue,
                DelimitedIndex = DelimitedIndex,
                Delimiter = Delimiter,
                Endian = Endian.Clone(),
                FieldIndex = FieldIndex,
                HeaderName = HeaderName,
                IsRequired = IsRequired,
                JsonPath = JsonPath,
                Key = Key,
                LatBinaryOffset = LatBinaryOffset,
                LatDelimitedIndex = LatDelimitedIndex,
                LatJsonPath = LatJsonPath,
                LatQueryStringField = LatQueryStringField,
                LatRegExGroupName = LatRegExGroupName,
                LatStartIndex = LatStartIndex,
                LatXPath = LatXPath,
                Length = Length,
                LonBinaryOffset = LonBinaryOffset,
                LonDelimitedIndex = LonDelimitedIndex,
                LonJsonPath = LonJsonPath,
                LonQueryStringField = LonQueryStringField,
                LonRegExGroupName = LonRegExGroupName,
                LonStartIndex = LonStartIndex,

                LonXPath = LonXPath,
                MaxValue = MaxValue,
                MinValue = MinValue,
                Name = Name,
                Notes = Notes,
                ParsedBinaryFieldType = ParsedBinaryFieldType.Clone(),
                ParsedStringFieldType = ParsedStringFieldType.Clone(),
                PathLocator = PathLocator,
                QueryStringField = QueryStringField,
                QuotedText = QuotedText,
                RegExGroupName = RegExGroupName,
                RegExValidation = RegExValidation,
                RegExValueSelector = RegExValueSelector,
                SearchLocation = SearchLocation.Clone(),
                StartIndex = StartIndex,
                StorageType = StorageType.Clone(),
                StringLengthByteCount = StringLengthByteCount,
                TopicLocator = TopicLocator,
                StringParsingStrategy = StringParsingStrategy.Clone(),
                XPath = XPath,
                Segments = Segments
            };

            fld.StateSet = new EntityHeader<DeviceAdmin.Models.StateSet>()
            {
                Id = StateSet.Id,
                Text = StateSet.Text,
            };

            fld.StateSet.Value = StateSet.Value.Clone(newId, org, user);

            fld.UnitSet = new EntityHeader<DeviceAdmin.Models.UnitSet>()
            {
                Id = UnitSet.Id,
                Text = UnitSet.Text,
            };

            fld.UnitSet.Value = UnitSet.Value.Clone(newId, org, user);


            return fld;
        }
    }

}