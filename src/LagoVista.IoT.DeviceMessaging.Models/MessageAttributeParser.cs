// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1c9896c415aee49dda26ce9183d0cb32cde5682d7040bf3eaf8473434737c9e8
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.IoT.DeviceMessaging.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceField_Title, DeviceMessagingAdminResources.Names.DeviceField_Help,
         DeviceMessagingAdminResources.Names.DeviceField_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminResources), FactoryUrl: "/api/messageattributeparser/factory")]
    public class MessageAttributeParser : IKeyedEntity, INamedEntity, IValidateable, IFormDescriptor, IFormConditionalFields, IFormAdditionalActions
    {
        #region Constructor
        public MessageAttributeParser()
        {
            Id = Guid.NewGuid().ToId();
        }
        #endregion

        #region Constants used for setting values on enums
        public const string DateTimeZone_NoTimeZone = "notimezone";
        public const string DateTimeZone_Server = "servertimezone";
        public const string DateTimeZone_Universal = "universaltimezone";
        public const string DateTimeZone_8601 = "iso8601";
        public const string DateTimeZone_EpochSeconds = "epochseconds";
        public const string DateTimeZone_EpochMS = "epochms";

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
        public const string ParserStringType_StringArray = "stringarray";
        public const string ParserStringType_RealNummberArray = "realarray";
        public const string ParserStringType_WholeNumberArray = "wholenumberarray";

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
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help,
            FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
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


        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.JSON)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JSONPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_JsonPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string JsonPath { get; set; }


        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.Binary)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_BinaryOffset_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? BinaryOffset { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_StartIndex, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? StartIndex { get; set; }


        [AllowableMessageContentType(MessageContentTypes.StringPosition)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Length, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_SubString_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? Length { get; set; }


        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.XML)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_XPath_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string XPath { get; set; }

        [AllowableStorageContentType(ParameterTypes.GeoLocation, anyValueButThis: true)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Delimited_Index, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_Delimited_Index_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? DelimitedIndex { get; set; }



        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_HeaderName, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_HeaderName_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string HeaderName { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_QueryStringField_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string QueryStringField { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_PathLocator, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_PathLocator_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string PathLocator { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_TopicLocator, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_TopicLocator_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string TopicLocator { get; set; }
        #endregion


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Notes, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Notes { get; set; }

        #region Fields to do validation on value that is extracted
        /* Can be used after extracting value */
        [AllowableStorageContentType(ParameterTypes.String)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValidation, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_RegExValidation_Help, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegExValidation { get; set; }
        #endregion

        #region Methods to perform validation against meta data, based on content of meta data.
        protected bool HasValue(PropertyInfo property)
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

        protected String GetDisplayName(PropertyInfo property)
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

        protected virtual void AddWarningForUnsedProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue, bool fieldParser)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();
            if (hasValue && allowableTypeProperties.Any() && !allowableTypeProperties.Where(allowable => allowable.ContentType == contentType.Value).Any())
            {
                var invalidTypeMsg = DeviceMessagingAdminResources.DeviceMessage_PropertyTypeHasValueButNotSupported.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
                result.Warnings.Add(new ErrorMessage(invalidTypeMsg));
            }
        }

        protected virtual void AddErrorsForMissingProperties(ValidationResult result, EntityHeader<MessageContentTypes> contentType, PropertyInfo property, String name, bool hasValue, bool fieldParser)
        {
            var allowableTypeProperties = property.GetCustomAttributes<AllowableMessageContentTypeAttribute>();

            var allowableFieldType = property.GetCustomAttributes<AllowableFieldTypeAttribute>().FirstOrDefault();
            if (allowableFieldType != null && (allowableFieldType.FieldType == FieldType.DeviceId || allowableFieldType.FieldType == FieldType.MessageId))
            {
                if (!fieldParser)
                {
                    return;
                }
            }

           
            foreach (var allowableProperty in allowableTypeProperties)
            {
                if (!hasValue && allowableProperty.IsRequired && allowableProperty.ContentType == contentType.Value)
                {
                    var missingMessage = DeviceMessagingAdminResources.DeviceMessage_PropertyRequiredForContentType.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, contentType.Text);
                    result.Errors.Add(new ErrorMessage(missingMessage));
                }
            }
        }
        #endregion


        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),

                nameof(Key),

                nameof(SearchLocation),
                nameof(ContentType),
                nameof(Endian),
                nameof(ParsedBinaryFieldType),
                nameof(ParsedStringFieldType),

                nameof(FieldIndex),

                nameof(PathLocator),

                nameof(Delimiter),
                nameof(DelimitedIndex),


                nameof(StartIndex),

                nameof(QueryStringField),

                nameof(TopicLocator),

                nameof(JsonPath),

                nameof(HeaderName),
                nameof(XPath),

                nameof(BinaryOffset),

                nameof(RegExValueSelector),
                nameof(RegExGroupName),

                nameof(RegExValidation),

                nameof(Notes)

            };
        }

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = new List<string>() { nameof(StateSet), nameof(UnitSet), nameof(HeaderName), nameof(TopicLocator), 
                                                         nameof(XPath), 
                                                         nameof(ContentType),
                                                         nameof(StartIndex), 
                                                         nameof(JsonPath),
                                                         nameof(BinaryOffset), 
                                                         nameof(Delimiter),
                                                         nameof(DelimitedIndex), 
                                                         nameof(Endian),
                                                         nameof(FieldIndex), nameof(RegExValueSelector), nameof(QueryStringField), 
                                                         nameof(PathLocator), nameof(ParsedStringFieldType), nameof(ParsedBinaryFieldType),
                                                         nameof(RegExGroupName), nameof(RegExValidation)},
                Conditionals = new List<FormConditional>()
                {   
                    new FormConditional()
                    {
                         Field = nameof(SearchLocation),
                         Value = SearchLocation_Headers,
                         VisibleFields = new List<string>() { nameof(HeaderName), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(HeaderName)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(SearchLocation),
                         Value = SearchLocation_Topic,
                         VisibleFields = new List<string>() { nameof(TopicLocator), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(TopicLocator)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(SearchLocation),
                         Value = SearchLocation_QueryString,
                         VisibleFields = new List<string>() { nameof(QueryStringField), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(QueryStringField) }
                    },
                    new FormConditional()
                    {
                         Field = nameof(SearchLocation),
                         Value = SearchLocation_Path,
                         VisibleFields = new List<string>() { nameof(PathLocator), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(PathLocator) }
                    },
                    new FormConditional()
                    {
                         Field = nameof(SearchLocation),
                         Value = SearchLocation_Body,
                         VisibleFields = new List<string>() { nameof(ContentType)},
                         RequiredFields = new List<string>() { nameof(ContentType)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Json,
                         VisibleFields = new List<string>() { nameof(JsonPath), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(JsonPath) }
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_StringPosition,
                         VisibleFields = new List<string>() { nameof(StartIndex), nameof(Length)},
                         RequiredFields = new List<string>() { nameof(StartIndex), nameof(Length) }
                    },
                    new FormConditional()
                    {
                         Field = nameof(RegExValueSelector),
                         Value = "*",
                         VisibleFields = new List<string>() { nameof(RegExGroupName)},
                         RequiredFields = new List<string>() { nameof(RegExGroupName)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_StringRegEx,
                         VisibleFields = new List<string>() { nameof(RegExValueSelector), nameof(RegExGroupName)},
                         RequiredFields = new List<string>() { nameof(RegExValueSelector), nameof(RegExGroupName)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Xml,
                         VisibleFields = new List<string>() { nameof(XPath), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(XPath)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Delimited,
                         VisibleFields = new List<string>() { nameof(Delimiter), nameof(DelimitedIndex), nameof(RegExValueSelector) },
                         RequiredFields = new List<string>() { nameof(Delimiter), nameof(DelimitedIndex)}
                    },
                    new FormConditional()
                    {
                         Field = nameof(ContentType),
                         Value = DeviceMessageDefinition.ContentType_Binary,
                         VisibleFields = new List<string>() { nameof(ParsedBinaryFieldType), nameof(BinaryOffset),nameof(Endian)},
                         RequiredFields = new List<string>() { nameof(ParsedBinaryFieldType), nameof(BinaryOffset), nameof(Endian) }
                    },
                }
            };
        }

        public MessageAttributeParser Clone(bool newId = false, EntityHeader org = null, EntityHeader user = null)
        {
            var fld = new MessageAttributeParser()
            {
                Id = newId ? Guid.NewGuid().ToId() : Id,
                Key = Key,
                Name = Name,
                Notes = Notes,

                SearchLocation = SearchLocation.Clone(),
                ContentType = ContentType.Clone(),

                BinaryOffset = BinaryOffset,
                BinaryParsingStrategy = BinaryParsingStrategy?.Clone(),
                Endian = Endian?.Clone(),
                ParsedBinaryFieldType = ParsedBinaryFieldType.Clone(),

                DelimitedIndex = DelimitedIndex,
                Delimiter = Delimiter,
                FieldIndex = FieldIndex,

                HeaderName = HeaderName,

                JsonPath = JsonPath,

                ParsedStringFieldType = ParsedStringFieldType?.Clone(),
                Length = Length,
                QuotedText = QuotedText,

                PathLocator = PathLocator,

                QueryStringField = QueryStringField,
                                
                RegExGroupName = RegExGroupName,
                RegExValidation = RegExValidation,
                RegExValueSelector = RegExValueSelector,

                StartIndex = StartIndex,
                StringLengthByteCount = StringLengthByteCount,
                TopicLocator = TopicLocator,
                StringParsingStrategy = StringParsingStrategy?.Clone(),
                XPath = XPath,
            };

            return fld;
        }

        public ValidationResult Validate()
        {
            /* Will always use strings for device and message ids */
           
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
            }

            return result;
        }

        public List<FormAdditionalAction> GetAdditionalActions()
        {
            return new List<FormAdditionalAction>()
            {
                 new FormAdditionalAction()
                 {
                      Icon = "fa-regular fa-flask-vial",
                      Title = "Edit Verifiers",
                      Key = "verifiers",
                      Help = DeviceMessagingAdminResources.DeviceField_Verifiers_Help,
                      ForCreate = false
                 }
            };
        }
    }

}