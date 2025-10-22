// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1377334b8669bf4c743a34fd6998de7dcdc9a7c96530ac8e0ee7d4e82cae4118
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System.Reflection;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using System;
using System.Linq;
using System.Collections.Generic;
using LagoVista.IoT.DeviceMessaging.Models.Resources;
using System.Threading.Tasks;
using LagoVista.Core.Cloning;
using LagoVista.Core.Models.UIMetaData;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    public enum MessageContentTypes
    {
        [EnumLabel(DeviceMessageDefinition.ContentType_NoContent, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_NoContent, typeof(DeviceMessagingAdminResources))]
        NoContent,
        [EnumLabel(DeviceMessageDefinition.ContentType_Binary, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Binary, typeof(DeviceMessagingAdminResources))]
        Binary,
        [EnumLabel(DeviceMessageDefinition.ContentType_Delimited, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Delimited, typeof(DeviceMessagingAdminResources))]
        Delimited,
        [EnumLabel(DeviceMessageDefinition.ContentType_Json, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Json, typeof(DeviceMessagingAdminResources))]
        JSON,
        [EnumLabel(DeviceMessageDefinition.ContentType_StringRegEx, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_StringRegEx, typeof(DeviceMessagingAdminResources))]
        StringRegEx,
        [EnumLabel(DeviceMessageDefinition.ContentType_ProtoBuf, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_ProtoBuf, typeof(DeviceMessagingAdminResources))]
        ProtoBuf,
        [EnumLabel(DeviceMessageDefinition.ContentType_StringPosition, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_StringPosition, typeof(DeviceMessagingAdminResources))]
        StringPosition,
        [EnumLabel(DeviceMessageDefinition.ContentType_Xml, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Xml, typeof(DeviceMessagingAdminResources))]
        XML,
        [EnumLabel(DeviceMessageDefinition.ContentType_Media, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Media, typeof(DeviceMessagingAdminResources))]
        Media,
        [EnumLabel(DeviceMessageDefinition.ContentType_SevenSegementImage, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_SevenSegementImage, typeof(DeviceMessagingAdminResources))]
        SevenSegementImage,
        [EnumLabel(DeviceMessageDefinition.ContentType_PointArray, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_PointArray, typeof(DeviceMessagingAdminResources))]
        PointArray,
        [EnumLabel(DeviceMessageDefinition.ContentType_GeoPointArray, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_GeoPointArray, typeof(DeviceMessagingAdminResources))]
        GeoPointArray,
        /*        [EnumLabel(DeviceMessageDefinition.ContentType_Xml, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_MultiPart_Media, typeof(DeviceMessagingAdminResources))]
                MultiPartContent,
                [EnumLabel(DeviceMessageDefinition.ContentType_Xml, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_FormPost, typeof(DeviceMessagingAdminResources))]
                FormPost,*/

        //    [EnumLabel(DeviceMessageDefinition.ContentType_Custom, DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Custom, typeof(DeviceMessagingAdminResources))]
        //  Custom
    }


    public enum RESTMethod
    {
        [EnumLabel(DeviceMessageDefinition.RESTMethod_GET, DeviceMessagingAdminResources.Names.RESTMethod_GET, typeof(DeviceMessagingAdminResources))]
        GET,
        [EnumLabel(DeviceMessageDefinition.RESTMethod_PUT, DeviceMessagingAdminResources.Names.RESTMethod_PUT, typeof(DeviceMessagingAdminResources))]
        PUT,
        [EnumLabel(DeviceMessageDefinition.RESTMethod_POST, DeviceMessagingAdminResources.Names.RESTMethod_POST, typeof(DeviceMessagingAdminResources))]
        POST,
        [EnumLabel(DeviceMessageDefinition.RESTMethod_DELETE, DeviceMessagingAdminResources.Names.RESTMethod_DELETE, typeof(DeviceMessagingAdminResources))]
        DELETE
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

    public enum MessageDirections
    {
        [EnumLabel(DeviceMessageDefinition.MessageDirection_Incoming, DeviceMessagingAdminResources.Names.MessageDirection_Incoming, typeof(DeviceMessagingAdminResources))]
        Incoming,
        [EnumLabel(DeviceMessageDefinition.MessageDirection_Outgoing, DeviceMessagingAdminResources.Names.MessageDirection_Outgoing, typeof(DeviceMessagingAdminResources))]
        Outgoing,
        [EnumLabel(DeviceMessageDefinition.MessageDirection_IncomingAndOutgoing, DeviceMessagingAdminResources.Names.MessageDirection_IncomingOutgoing, typeof(DeviceMessagingAdminResources))]
        IncomingAndOutgoing
    }

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Title,
        DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Help, DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, typeof(DeviceMessagingAdminResources), Cloneable:true,
        SaveUrl: "/api/devicemessagetype", FactoryUrl: "/api/devicemessagetype/factory", GetUrl: "/api/devicemessagetype/{id}", GetListUrl: "/api/devicemessagetypes",
        DeleteUrl: "/api/devicemessagetype/{id}", Icon: "icon-fo-message-info", ListUIUrl: "/iotstudio/device/messages",  EditUIUrl: "/iotstudio/device/message/{id}", CreateUIUrl: "/iotstudio/device/message/add")]
    public class DeviceMessageDefinition : LagoVista.IoT.DeviceAdmin.Models.IoTModelBase, IValidateable, ICloneable<DeviceMessageDefinition>, IFormDescriptor, IFormDescriptorAdvanced, IFormConditionalFields,
        ICategorized, ISummaryFactory, IIconEntity
    {
        public const string ContentType_NoContent = "nocontent";
        public const string ContentType_Binary = "binary";
        public const string ContentType_StringPosition = "stringposition";
        public const string ContentType_StringRegEx = "stringregex";
        public const string ContentType_ProtoBuf = "protobuf";
        public const string ContentType_Delimited = "delimited";
        public const string ContentType_Json = "json";
        public const string ContentType_Xml = "xml";
        public const string ContentType_PointArray = "pointarray";
        public const string ContentType_GeoPointArray = "geopointarray";
        public const string ContentType_Media = "media";
        public const string ContentType_MultiPart = "multipart";
        public const string ContentType_SevenSegementImage = "sevensegementimage";
        public const string ContentType_FormPost = "formpost";

        public const string BinaryParsingStrategy_Absolute = "absolute";
        public const string BinaryParsingStrategy_Relative = "relative";
        public const string BinaryParsingStrategy_Script = "script";

        public const string StringParsingStrategy_NullTerminated = "nullterminated";
        public const string StringParsingStrategy_StringLength = "stringlength";

        public const string Endian_BigEndian = "bigendian";
        public const string Endian_LittleEndian = "littleendian";

        public const string RESTMethod_GET = "get";
        public const string RESTMethod_POST = "post";
        public const string RESTMethod_PUT = "put";
        public const string RESTMethod_DELETE = "delete";

        public const string MessageDirection_Incoming = "incoming";
        public const string MessageDirection_Outgoing = "outgoing";
        public const string MessageDirection_IncomingAndOutgoing = "IncomingAndOutgoing";

        public DeviceMessageDefinition()
        {
            Fields = new List<DeviceMessageDefinitionField>();
            FramingBytes = new List<MessageFramingBytes>();
            SampleMessages = new List<SampleMessage>();
            MessageDirection = EntityHeader<MessageDirections>.Create(MessageDirections.Incoming);
            Icon = "icon-fo-message-info";
        }

        public string OriginalId { get; set; }

        public EntityHeader OriginalOwnerOrganization { get; set; }
        public EntityHeader OriginalOwnerUser { get; set; }

        public EntityHeader OriginallyCreatedBy { get; set; }

        public string OriginalCreationDate { get; set; }


        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Fields, FieldType: FieldTypes.ChildListInline, ResourceType: typeof(DeviceMessagingAdminResources))]
        public List<DeviceMessageDefinitionField> Fields { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MessageId, FieldType: FieldTypes.Text, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MessageId_Help, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public string MessageId { get; set; }


        [CloneOptions(false)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Category, FieldType: FieldTypes.Category, WaterMark: DeviceMessagingAdminResources.Names.Common_Category_Select, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Category { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.Delimited, isRequired: false)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool QuotedText { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.ProtoBuf, isRequired: true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_QuotedText_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string ProtoBufDefintion { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.Delimited)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Delimiter, HelpResource:DeviceMessagingAdminResources.Names.DeviceMessage_Delimiter_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Delimiter { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_MediaContentType, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string MediaContentType { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Extension, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string FileExtension { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMesage_MessageDirection, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_MessageDirection_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.MessageDirection_Select, EnumType: typeof(MessageDirections), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<MessageDirections> MessageDirection { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_ContentType_Select, EnumType: typeof(MessageContentTypes), ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public EntityHeader<MessageContentTypes> ContentType { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_BinaryParsingStrategy_Select, EnumType: typeof(BinaryParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<BinaryParsingStrategy> BinaryParsingStrategy { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessgaeField_StringParsing_Strategy_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_StringParsingStrategy_Select, EnumType: typeof(StringParsingStrategy), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<StringParsingStrategy> StringParsingStrategy { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageField_String_LeadingLength, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageField_String_LeadingLength_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? StringLengthByteCount { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.Binary, true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Help, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_Endian_Select, EnumType: typeof(EndianTypes), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<EndianTypes> Endian { get; set; }

        [CloneOptions(true)]
        [AllowableMessageContentType(MessageContentTypes.StringRegEx)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_RegEx, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_RegEx_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string RegEx { get; set; }

        //[AllowableMessageContentType(MessageContentTypes.Custom)]
        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Script, FieldType: FieldTypes.NodeScript, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_Script_Watermark,
            ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Script { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_OutputMessageScript, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_OutputMessageScript_Help,
             WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_OutputScript_Watermark,
            FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string OutputMessageScript { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_RESTMethod, FieldType: FieldTypes.Picker, WaterMark: DeviceMessagingAdminResources.Names.DeviceMessage_RESTMethod_Select, EnumType: typeof(RESTMethod), ResourceType: typeof(DeviceMessagingAdminResources))]
        public EntityHeader<RESTMethod> RestMethod { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_PathAndQueryString, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_PathAndQueryString_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string PathAndQueryString { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ImportFields, FieldType: FieldTypes.Action, ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool ImportFieldsAction { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_ShowVerifiers, FieldType: FieldTypes.Action, ResourceType: typeof(DeviceMessagingAdminResources))]
        public bool ShowVerifiersAction { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_Topic, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_Topic_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Topic { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_FramingBytes, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_FramingBytes_Help, FieldType: FieldTypes.ChildListInline, ResourceType: typeof(DeviceMessagingAdminResources))]
        public List<MessageFramingBytes> FramingBytes { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_SampleMessages, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_SampleMessages_Help, FieldType: FieldTypes.ChildListInline, ResourceType: typeof(DeviceMessagingAdminResources))]
        public List<SampleMessage> SampleMessages { get; set; }

        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.DeviceMessage_StaleSeconds, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessage_StaleSeconds_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceMessagingAdminResources))]
        public int? StaleSeconds { get; set; }


        [CloneOptions(true)]
        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Icon, FieldType: FieldTypes.Icon, IsRequired:true, ResourceType: typeof(DeviceMessagingAdminResources))]
        public string Icon { get; set; }


        public string BackgroundColor { get; set; }

        public string SegementColor { get; set; }

        public string B64Image { get; set; }

        public bool IsSevenSegementImage { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(MessageId),
                nameof(IsPublic),
                nameof(MessageDirection),
                nameof(ContentType),
                nameof(Delimiter),
                nameof(Endian),
                nameof(QuotedText),
                nameof(RegEx),
                nameof(OutputMessageScript),
                nameof(RestMethod),
                nameof(PathAndQueryString),
                nameof(Topic),
                nameof(Script),
                nameof(StringParsingStrategy),
                nameof(StringLengthByteCount),
                nameof(BinaryParsingStrategy),
                nameof(Fields),
            };
        }

        public List<string> GetAdvancedFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(MessageId),
                nameof(IsPublic),
                nameof(MessageDirection),
                nameof(ContentType),
                nameof(Delimiter),
                nameof(Endian),
                nameof(QuotedText),
                nameof(RegEx),
                nameof(OutputMessageScript),
                nameof(RestMethod),
                nameof(PathAndQueryString),
                nameof(Topic),
                nameof(StaleSeconds),
                nameof(Script),
                nameof(StringParsingStrategy),
                nameof(StringLengthByteCount),
                nameof(BinaryParsingStrategy),
                nameof(ImportFieldsAction),
                nameof(ShowVerifiersAction),
                nameof(Fields),
                nameof(SampleMessages),
            };
        }

        public Task<DeviceMessageDefinition> CloneAsync(EntityHeader user, EntityHeader org, string name, string key)
        {
            return Task.FromResult(CloneService.Clone(this, user, org, name, key));
        }

        public DeviceMessageDefinitionSummary CreateSummary()
        {
            return new DeviceMessageDefinitionSummary()
            {
                Id = Id,
                Name = Name,
                Icon = Icon,
                Key = Key,
                IsPublic = IsPublic,
                Description = Description,
                Direction = MessageDirection.Text,
                Category = Category?.Text,
                CategoryId = Category?.Id,
                CategoryKey = Category?.Key
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


            if (ContentType == null || ContentType.IsEmpty())
            {
                //TODO: should arlready call core validation, if content type is null we went through an invalid path and we aren't localizing...sorry.
                result.Errors.Add(new ErrorMessage("Content Type is Required."));
                return;
            }

            if (ContentType.Value == MessageContentTypes.Binary &&
                !EntityHeader.IsNullOrEmpty(StringParsingStrategy) &&
                StringParsingStrategy.Value == Models.StringParsingStrategy.StringLength &&
                !StringLengthByteCount.HasValue)
            {
                result.Errors.Add(new ErrorMessage("If string parsing strategy is String Length, length of string is required."));
            }

            if (ContentType.Value == MessageContentTypes.Media &&
                (Fields.Where(fld => fld.StorageType.Value != DeviceAdmin.Models.ParameterTypes.MLInference && fld.SearchLocation.Value == SearchLocations.Body).Any() ||
                Fields.Where(fld => fld.SearchLocation.Value == SearchLocations.Body).Count() > 1)
                )
            {
                result.Errors.Add(new ErrorMessage("For messages with content type media, you can only have one field associated with the body of the message, and that field must be a ML Inference that can be passed to a workflow."));
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
                else if (value is Int32)
                {
                    hasValue = true;
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
                    var invalidTypeMsg = DeviceMessagingAdminResources.DeviceMessage_PropertyTypeHasValueButNotSupported.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, ContentType.Text);
                    result.Warnings.Add(new ErrorMessage(invalidTypeMsg));
                }

                foreach (var allowableProperty in allowableTypeProperties)
                {
                    if (!hasValue && allowableProperty.IsRequired && allowableProperty.ContentType == ContentType.Value)
                    {
                        var missingMessage = DeviceMessagingAdminResources.DeviceMessage_PropertyRequiredForContentType.Replace(Tokens.PROPERTYNAME, name).Replace(Tokens.MESSAGECONTENTTYPE, ContentType.Text);
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

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = { nameof(Delimiter), nameof(Endian), nameof(QuotedText), nameof(RegEx), nameof(Script), nameof(StringParsingStrategy), nameof(BinaryParsingStrategy), 
                        nameof(RestMethod), nameof(ImportFieldsAction), nameof(Topic), nameof(PathAndQueryString), nameof(StringLengthByteCount) },
                Conditionals = new List<FormConditional>()
                {
                     new FormConditional()
                     {
                         Field = nameof(ContentType),
                         Value = ContentType_Binary,
                         VisibleFields = { nameof(Endian), nameof(StringParsingStrategy), nameof(BinaryParsingStrategy), nameof(StringLengthByteCount)}
                     },
                     new FormConditional()
                     {
                         Field = nameof(ContentType),
                         Value = ContentType_Delimited,
                         VisibleFields = {nameof(QuotedText), nameof(Delimiter)}
                     },
                     new FormConditional()
                     {
                         Field = nameof(ContentType),
                         Value = ContentType_StringRegEx
                     },
                    new FormConditional()
                    {
                        Field = nameof(MessageDirection),
                        Value = MessageDirection_Outgoing,
                        VisibleFields = {nameof(RestMethod), nameof(Topic), nameof(PathAndQueryString), nameof(OutputMessageScript), nameof(OutputMessageScript)}
                    },
                    new FormConditional()
                    {
                        Field = nameof(StringParsingStrategy),
                        Value = StringParsingStrategy_StringLength,
                        VisibleFields = {nameof(StringLengthByteCount)}
                    },
                    new FormConditional()
                    {
                        Field = nameof(ContentType),
                        Value = ContentType_Json,
                        VisibleFields = {nameof(ImportFieldsAction)}
                    }
                }
            };
        }

        ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.DeviceMessageDefinitions_Title,
     DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Help, DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Description, EntityDescriptionAttribute.EntityTypes.Summary, 
        typeof(DeviceMessagingAdminResources), Icon: "icon-fo-message-info", Cloneable: true,
     SaveUrl: "/api/devicemessagetype", FactoryUrl: "/api/devicemessagetype/factory", GetUrl: "/api/devicemessagetype/{id}", GetListUrl: "/api/devicemessagetypes", DeleteUrl: "/api/devicemessagetype/{id}")]
    public class DeviceMessageDefinitionSummary : SummaryData
    {
        public string Direction { get; set; }

    }
}
