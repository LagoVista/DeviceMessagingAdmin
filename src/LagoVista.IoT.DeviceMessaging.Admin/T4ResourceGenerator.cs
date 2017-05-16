using System.Globalization;
using System.Reflection;

//Resources:DeviceMessagingAdminResources:Common_Description
namespace LagoVista.IoT.DeviceMessaging.Admin.Resources
{
	public class DeviceMessagingAdminResources
	{
        private static global::System.Resources.ResourceManager _resourceManager;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(_resourceManager, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.IoT.DeviceMessaging.Admin.Resources.DeviceMessagingAdminResources", typeof(DeviceMessagingAdminResources).GetTypeInfo().Assembly);
                    _resourceManager = temp;
                }
                return _resourceManager;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = CultureInfo.CurrentCulture;;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
		/*
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static HtmlString GetResourceHtmlString(string key, params string[] tokens)
		{
			var str = GetResourceString(key, tokens);
							
			if(str.StartsWith("HTML:"))
				str = str.Substring(5);

			return new HtmlString(str);
        }*/
		
		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:DeviceMessagingAdminResources:Common_Id

		public static string Common_Id { get { return GetResourceString("Common_Id"); } }
//Resources:DeviceMessagingAdminResources:Common_IsPublic

		public static string Common_IsPublic { get { return GetResourceString("Common_IsPublic"); } }
//Resources:DeviceMessagingAdminResources:Common_Key

		public static string Common_Key { get { return GetResourceString("Common_Key"); } }
//Resources:DeviceMessagingAdminResources:Common_Key_Help

		public static string Common_Key_Help { get { return GetResourceString("Common_Key_Help"); } }
//Resources:DeviceMessagingAdminResources:Common_Key_Validation

		public static string Common_Key_Validation { get { return GetResourceString("Common_Key_Validation"); } }
//Resources:DeviceMessagingAdminResources:Common_Name

		public static string Common_Name { get { return GetResourceString("Common_Name"); } }
//Resources:DeviceMessagingAdminResources:Common_Notes

		public static string Common_Notes { get { return GetResourceString("Common_Notes"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_BinaryParsing_Strategy

		public static string DeviceMessage_BinaryParsing_Strategy { get { return GetResourceString("DeviceMessage_BinaryParsing_Strategy"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_BinaryParsing_Strategy_Absolute

		public static string DeviceMessage_BinaryParsing_Strategy_Absolute { get { return GetResourceString("DeviceMessage_BinaryParsing_Strategy_Absolute"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_BinaryParsing_Strategy_Help

		public static string DeviceMessage_BinaryParsing_Strategy_Help { get { return GetResourceString("DeviceMessage_BinaryParsing_Strategy_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_BinaryParsing_Strategy_Relative

		public static string DeviceMessage_BinaryParsing_Strategy_Relative { get { return GetResourceString("DeviceMessage_BinaryParsing_Strategy_Relative"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_BinaryParsing_Strategy_Script

		public static string DeviceMessage_BinaryParsing_Strategy_Script { get { return GetResourceString("DeviceMessage_BinaryParsing_Strategy_Script"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_BinaryParsingStrategy_Select

		public static string DeviceMessage_BinaryParsingStrategy_Select { get { return GetResourceString("DeviceMessage_BinaryParsingStrategy_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType

		public static string DeviceMessage_ContentType { get { return GetResourceString("DeviceMessage_ContentType"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Binary

		public static string DeviceMessage_ContentType_Binary { get { return GetResourceString("DeviceMessage_ContentType_Binary"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Custom

		public static string DeviceMessage_ContentType_Custom { get { return GetResourceString("DeviceMessage_ContentType_Custom"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Delimited

		public static string DeviceMessage_ContentType_Delimited { get { return GetResourceString("DeviceMessage_ContentType_Delimited"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Help

		public static string DeviceMessage_ContentType_Help { get { return GetResourceString("DeviceMessage_ContentType_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Json

		public static string DeviceMessage_ContentType_Json { get { return GetResourceString("DeviceMessage_ContentType_Json"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Select

		public static string DeviceMessage_ContentType_Select { get { return GetResourceString("DeviceMessage_ContentType_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_String

		public static string DeviceMessage_ContentType_String { get { return GetResourceString("DeviceMessage_ContentType_String"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Xml

		public static string DeviceMessage_ContentType_Xml { get { return GetResourceString("DeviceMessage_ContentType_Xml"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Delimiter

		public static string DeviceMessage_Delimiter { get { return GetResourceString("DeviceMessage_Delimiter"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Endian

		public static string DeviceMessage_Endian { get { return GetResourceString("DeviceMessage_Endian"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Endian_Help

		public static string DeviceMessage_Endian_Help { get { return GetResourceString("DeviceMessage_Endian_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Endian_Select

		public static string DeviceMessage_Endian_Select { get { return GetResourceString("DeviceMessage_Endian_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_FramingBytes

		public static string DeviceMessage_FramingBytes { get { return GetResourceString("DeviceMessage_FramingBytes"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_FramingBytes_Help

		public static string DeviceMessage_FramingBytes_Help { get { return GetResourceString("DeviceMessage_FramingBytes_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_PropertyRequiredForContentType


		///<summary>
		///The tokens [PROPERTYNAME] and [CONTENTTYPE] will be replaced by the property that has the error and the content type such as binary, string, etc...
		///</summary>
		public static string DeviceMessage_PropertyRequiredForContentType { get { return GetResourceString("DeviceMessage_PropertyRequiredForContentType"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_PropertyTypeHasValueButNotSupported


		///<summary>
		///The tokens [PROPERTYNAME] and [CONTENTTYPE] will be replaced by the property that has the error and the content type such as binary, string, etc...
		///</summary>
		public static string DeviceMessage_PropertyTypeHasValueButNotSupported { get { return GetResourceString("DeviceMessage_PropertyTypeHasValueButNotSupported"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_QuotedText

		public static string DeviceMessage_QuotedText { get { return GetResourceString("DeviceMessage_QuotedText"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_QuotedText_Help

		public static string DeviceMessage_QuotedText_Help { get { return GetResourceString("DeviceMessage_QuotedText_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_RegEx

		public static string DeviceMessage_RegEx { get { return GetResourceString("DeviceMessage_RegEx"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_RegEx_Help

		public static string DeviceMessage_RegEx_Help { get { return GetResourceString("DeviceMessage_RegEx_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_StringParsingStrategy_Select

		public static string DeviceMessage_StringParsingStrategy_Select { get { return GetResourceString("DeviceMessage_StringParsingStrategy_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Description

		public static string DeviceMessageDefinition_Description { get { return GetResourceString("DeviceMessageDefinition_Description"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Fields

		public static string DeviceMessageDefinition_Fields { get { return GetResourceString("DeviceMessageDefinition_Fields"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Help

		public static string DeviceMessageDefinition_Help { get { return GetResourceString("DeviceMessageDefinition_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Key_Help

		public static string DeviceMessageDefinition_Key_Help { get { return GetResourceString("DeviceMessageDefinition_Key_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_MessageId

		public static string DeviceMessageDefinition_MessageId { get { return GetResourceString("DeviceMessageDefinition_MessageId"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_MessageId_Help

		public static string DeviceMessageDefinition_MessageId_Help { get { return GetResourceString("DeviceMessageDefinition_MessageId_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Script

		public static string DeviceMessageDefinition_Script { get { return GetResourceString("DeviceMessageDefinition_Script"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Title

		public static string DeviceMessageDefinition_Title { get { return GetResourceString("DeviceMessageDefinition_Title"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryOffset

		public static string DeviceMessageField_BinaryOffset { get { return GetResourceString("DeviceMessageField_BinaryOffset"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryOffset_Help

		public static string DeviceMessageField_BinaryOffset_Help { get { return GetResourceString("DeviceMessageField_BinaryOffset_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_Boolean

		public static string DeviceMessageField_BinaryParser_Boolean { get { return GetResourceString("DeviceMessageField_BinaryParser_Boolean"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_Byte

		public static string DeviceMessageField_BinaryParser_Byte { get { return GetResourceString("DeviceMessageField_BinaryParser_Byte"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_Char

		public static string DeviceMessageField_BinaryParser_Char { get { return GetResourceString("DeviceMessageField_BinaryParser_Char"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_DoublePrecisionFloatingPoint

		public static string DeviceMessageField_BinaryParser_DoublePrecisionFloatingPoint { get { return GetResourceString("DeviceMessageField_BinaryParser_DoublePrecisionFloatingPoint"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_Int16

		public static string DeviceMessageField_BinaryParser_Int16 { get { return GetResourceString("DeviceMessageField_BinaryParser_Int16"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_Int32

		public static string DeviceMessageField_BinaryParser_Int32 { get { return GetResourceString("DeviceMessageField_BinaryParser_Int32"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_Int64

		public static string DeviceMessageField_BinaryParser_Int64 { get { return GetResourceString("DeviceMessageField_BinaryParser_Int64"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_SinglePrecisionFloatingPoint

		public static string DeviceMessageField_BinaryParser_SinglePrecisionFloatingPoint { get { return GetResourceString("DeviceMessageField_BinaryParser_SinglePrecisionFloatingPoint"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_String

		public static string DeviceMessageField_BinaryParser_String { get { return GetResourceString("DeviceMessageField_BinaryParser_String"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_UInt16

		public static string DeviceMessageField_BinaryParser_UInt16 { get { return GetResourceString("DeviceMessageField_BinaryParser_UInt16"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_UInt32

		public static string DeviceMessageField_BinaryParser_UInt32 { get { return GetResourceString("DeviceMessageField_BinaryParser_UInt32"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_BinaryParser_UInt64

		public static string DeviceMessageField_BinaryParser_UInt64 { get { return GetResourceString("DeviceMessageField_BinaryParser_UInt64"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Delimited_Index

		public static string DeviceMessageField_Delimited_Index { get { return GetResourceString("DeviceMessageField_Delimited_Index"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Delimited_Index_Help

		public static string DeviceMessageField_Delimited_Index_Help { get { return GetResourceString("DeviceMessageField_Delimited_Index_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Description

		public static string DeviceMessageField_Description { get { return GetResourceString("DeviceMessageField_Description"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_FieldType_Content

		public static string DeviceMessageField_FieldType_Content { get { return GetResourceString("DeviceMessageField_FieldType_Content"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_FieldType_DeviceId

		public static string DeviceMessageField_FieldType_DeviceId { get { return GetResourceString("DeviceMessageField_FieldType_DeviceId"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_FieldType_Help

		public static string DeviceMessageField_FieldType_Help { get { return GetResourceString("DeviceMessageField_FieldType_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_FieldType_MessageId

		public static string DeviceMessageField_FieldType_MessageId { get { return GetResourceString("DeviceMessageField_FieldType_MessageId"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_GroupName

		public static string DeviceMessageField_GroupName { get { return GetResourceString("DeviceMessageField_GroupName"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_GroupName_Help

		public static string DeviceMessageField_GroupName_Help { get { return GetResourceString("DeviceMessageField_GroupName_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Help

		public static string DeviceMessageField_Help { get { return GetResourceString("DeviceMessageField_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_IsRequired

		public static string DeviceMessageField_IsRequired { get { return GetResourceString("DeviceMessageField_IsRequired"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_JSONPath

		public static string DeviceMessageField_JSONPath { get { return GetResourceString("DeviceMessageField_JSONPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_JsonPath_Help

		public static string DeviceMessageField_JsonPath_Help { get { return GetResourceString("DeviceMessageField_JsonPath_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Length

		public static string DeviceMessageField_Length { get { return GetResourceString("DeviceMessageField_Length"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MaxValue

		public static string DeviceMessageField_MaxValue { get { return GetResourceString("DeviceMessageField_MaxValue"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MaxValue_Help

		public static string DeviceMessageField_MaxValue_Help { get { return GetResourceString("DeviceMessageField_MaxValue_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MessageFieldType

		public static string DeviceMessageField_MessageFieldType { get { return GetResourceString("DeviceMessageField_MessageFieldType"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MessageFieldType_Help

		public static string DeviceMessageField_MessageFieldType_Help { get { return GetResourceString("DeviceMessageField_MessageFieldType_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MessageFieldType_Select

		public static string DeviceMessageField_MessageFieldType_Select { get { return GetResourceString("DeviceMessageField_MessageFieldType_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MinValue

		public static string DeviceMessageField_MinValue { get { return GetResourceString("DeviceMessageField_MinValue"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_MinValue_Help

		public static string DeviceMessageField_MinValue_Help { get { return GetResourceString("DeviceMessageField_MinValue_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_PathLocator

		public static string DeviceMessageField_PathLocator { get { return GetResourceString("DeviceMessageField_PathLocator"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_PathLocator_Help

		public static string DeviceMessageField_PathLocator_Help( string messageid) { return GetResourceString("DeviceMessageField_PathLocator_Help", "{messageid}", messageid); }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_PropertyRequiredForContentType

		public static string DeviceMessageField_PropertyRequiredForContentType { get { return GetResourceString("DeviceMessageField_PropertyRequiredForContentType"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_QueryStringField

		public static string DeviceMessageField_QueryStringField { get { return GetResourceString("DeviceMessageField_QueryStringField"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_QueryStringField_Help

		public static string DeviceMessageField_QueryStringField_Help { get { return GetResourceString("DeviceMessageField_QueryStringField_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_RegExValidation

		public static string DeviceMessageField_RegExValidation { get { return GetResourceString("DeviceMessageField_RegExValidation"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_RegExValidation_Help

		public static string DeviceMessageField_RegExValidation_Help { get { return GetResourceString("DeviceMessageField_RegExValidation_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_RegExValueSelector

		public static string DeviceMessageField_RegExValueSelector { get { return GetResourceString("DeviceMessageField_RegExValueSelector"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_RegExValueSelector_Help

		public static string DeviceMessageField_RegExValueSelector_Help { get { return GetResourceString("DeviceMessageField_RegExValueSelector_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation

		public static string DeviceMessageField_SearchLocation { get { return GetResourceString("DeviceMessageField_SearchLocation"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_Body

		public static string DeviceMessageField_SearchLocation_Body { get { return GetResourceString("DeviceMessageField_SearchLocation_Body"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_Headers

		public static string DeviceMessageField_SearchLocation_Headers { get { return GetResourceString("DeviceMessageField_SearchLocation_Headers"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_Help

		public static string DeviceMessageField_SearchLocation_Help { get { return GetResourceString("DeviceMessageField_SearchLocation_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_Path

		public static string DeviceMessageField_SearchLocation_Path { get { return GetResourceString("DeviceMessageField_SearchLocation_Path"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_QueryString

		public static string DeviceMessageField_SearchLocation_QueryString { get { return GetResourceString("DeviceMessageField_SearchLocation_QueryString"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_Select

		public static string DeviceMessageField_SearchLocation_Select { get { return GetResourceString("DeviceMessageField_SearchLocation_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StartIndex

		public static string DeviceMessageField_StartIndex { get { return GetResourceString("DeviceMessageField_StartIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StorageFieldType

		public static string DeviceMessageField_StorageFieldType { get { return GetResourceString("DeviceMessageField_StorageFieldType"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StorageFieldType_Help

		public static string DeviceMessageField_StorageFieldType_Help { get { return GetResourceString("DeviceMessageField_StorageFieldType_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StorageFieldType_Select

		public static string DeviceMessageField_StorageFieldType_Select { get { return GetResourceString("DeviceMessageField_StorageFieldType_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_String_LeadingLength

		public static string DeviceMessageField_String_LeadingLength { get { return GetResourceString("DeviceMessageField_String_LeadingLength"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_String_LeadingLength_Help

		public static string DeviceMessageField_String_LeadingLength_Help { get { return GetResourceString("DeviceMessageField_String_LeadingLength_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_Boolean

		public static string DeviceMessageField_StringParser_Boolean { get { return GetResourceString("DeviceMessageField_StringParser_Boolean"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_FloatingPointNumber

		public static string DeviceMessageField_StringParser_FloatingPointNumber { get { return GetResourceString("DeviceMessageField_StringParser_FloatingPointNumber"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_String

		public static string DeviceMessageField_StringParser_String { get { return GetResourceString("DeviceMessageField_StringParser_String"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_WholeNumber

		public static string DeviceMessageField_StringParser_WholeNumber { get { return GetResourceString("DeviceMessageField_StringParser_WholeNumber"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SubString_Help

		public static string DeviceMessageField_SubString_Help { get { return GetResourceString("DeviceMessageField_SubString_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Title

		public static string DeviceMessageField_Title { get { return GetResourceString("DeviceMessageField_Title"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_XPath

		public static string DeviceMessageField_XPath { get { return GetResourceString("DeviceMessageField_XPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_Endian_BigEndian

		public static string DeviceMessgaeField_Endian_BigEndian { get { return GetResourceString("DeviceMessgaeField_Endian_BigEndian"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_Endian_LittleEndian

		public static string DeviceMessgaeField_Endian_LittleEndian { get { return GetResourceString("DeviceMessgaeField_Endian_LittleEndian"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_Notes

		public static string DeviceMessgaeField_Notes { get { return GetResourceString("DeviceMessgaeField_Notes"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_StringParsing_Strategy

		public static string DeviceMessgaeField_StringParsing_Strategy { get { return GetResourceString("DeviceMessgaeField_StringParsing_Strategy"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_StringParsing_Strategy_Help

		public static string DeviceMessgaeField_StringParsing_Strategy_Help { get { return GetResourceString("DeviceMessgaeField_StringParsing_Strategy_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_StringParsing_Strategy_LengthProvided

		public static string DeviceMessgaeField_StringParsing_Strategy_LengthProvided { get { return GetResourceString("DeviceMessgaeField_StringParsing_Strategy_LengthProvided"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_StringParsing_Strategy_NullTerminated

		public static string DeviceMessgaeField_StringParsing_Strategy_NullTerminated { get { return GetResourceString("DeviceMessgaeField_StringParsing_Strategy_NullTerminated"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_StringSize_CharacterCount

		public static string DeviceMessgaeField_StringSize_CharacterCount { get { return GetResourceString("DeviceMessgaeField_StringSize_CharacterCount"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessgaeField_StringSize_CharacterCount_Help

		public static string DeviceMessgaeField_StringSize_CharacterCount_Help { get { return GetResourceString("DeviceMessgaeField_StringSize_CharacterCount_Help"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_AfterPayload

		public static string MessageFramingByte_AfterPayload { get { return GetResourceString("MessageFramingByte_AfterPayload"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_AfterPayload_Help

		public static string MessageFramingByte_AfterPayload_Help { get { return GetResourceString("MessageFramingByte_AfterPayload_Help"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Byte

		public static string MessageFramingByte_Byte { get { return GetResourceString("MessageFramingByte_Byte"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Byte_Help

		public static string MessageFramingByte_Byte_Help { get { return GetResourceString("MessageFramingByte_Byte_Help"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Description

		public static string MessageFramingByte_Description { get { return GetResourceString("MessageFramingByte_Description"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Help

		public static string MessageFramingByte_Help { get { return GetResourceString("MessageFramingByte_Help"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Index

		public static string MessageFramingByte_Index { get { return GetResourceString("MessageFramingByte_Index"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Index_Help

		public static string MessageFramingByte_Index_Help { get { return GetResourceString("MessageFramingByte_Index_Help"); } }
//Resources:DeviceMessagingAdminResources:MessageFramingByte_Title

		public static string MessageFramingByte_Title { get { return GetResourceString("MessageFramingByte_Title"); } }

		public static class Names
		{
			public const string Common_Description = "Common_Description";
			public const string Common_Id = "Common_Id";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_Name = "Common_Name";
			public const string Common_Notes = "Common_Notes";
			public const string DeviceMessage_BinaryParsing_Strategy = "DeviceMessage_BinaryParsing_Strategy";
			public const string DeviceMessage_BinaryParsing_Strategy_Absolute = "DeviceMessage_BinaryParsing_Strategy_Absolute";
			public const string DeviceMessage_BinaryParsing_Strategy_Help = "DeviceMessage_BinaryParsing_Strategy_Help";
			public const string DeviceMessage_BinaryParsing_Strategy_Relative = "DeviceMessage_BinaryParsing_Strategy_Relative";
			public const string DeviceMessage_BinaryParsing_Strategy_Script = "DeviceMessage_BinaryParsing_Strategy_Script";
			public const string DeviceMessage_BinaryParsingStrategy_Select = "DeviceMessage_BinaryParsingStrategy_Select";
			public const string DeviceMessage_ContentType = "DeviceMessage_ContentType";
			public const string DeviceMessage_ContentType_Binary = "DeviceMessage_ContentType_Binary";
			public const string DeviceMessage_ContentType_Custom = "DeviceMessage_ContentType_Custom";
			public const string DeviceMessage_ContentType_Delimited = "DeviceMessage_ContentType_Delimited";
			public const string DeviceMessage_ContentType_Help = "DeviceMessage_ContentType_Help";
			public const string DeviceMessage_ContentType_Json = "DeviceMessage_ContentType_Json";
			public const string DeviceMessage_ContentType_Select = "DeviceMessage_ContentType_Select";
			public const string DeviceMessage_ContentType_String = "DeviceMessage_ContentType_String";
			public const string DeviceMessage_ContentType_Xml = "DeviceMessage_ContentType_Xml";
			public const string DeviceMessage_Delimiter = "DeviceMessage_Delimiter";
			public const string DeviceMessage_Endian = "DeviceMessage_Endian";
			public const string DeviceMessage_Endian_Help = "DeviceMessage_Endian_Help";
			public const string DeviceMessage_Endian_Select = "DeviceMessage_Endian_Select";
			public const string DeviceMessage_FramingBytes = "DeviceMessage_FramingBytes";
			public const string DeviceMessage_FramingBytes_Help = "DeviceMessage_FramingBytes_Help";
			public const string DeviceMessage_PropertyRequiredForContentType = "DeviceMessage_PropertyRequiredForContentType";
			public const string DeviceMessage_PropertyTypeHasValueButNotSupported = "DeviceMessage_PropertyTypeHasValueButNotSupported";
			public const string DeviceMessage_QuotedText = "DeviceMessage_QuotedText";
			public const string DeviceMessage_QuotedText_Help = "DeviceMessage_QuotedText_Help";
			public const string DeviceMessage_RegEx = "DeviceMessage_RegEx";
			public const string DeviceMessage_RegEx_Help = "DeviceMessage_RegEx_Help";
			public const string DeviceMessage_StringParsingStrategy_Select = "DeviceMessage_StringParsingStrategy_Select";
			public const string DeviceMessageDefinition_Description = "DeviceMessageDefinition_Description";
			public const string DeviceMessageDefinition_Fields = "DeviceMessageDefinition_Fields";
			public const string DeviceMessageDefinition_Help = "DeviceMessageDefinition_Help";
			public const string DeviceMessageDefinition_Key_Help = "DeviceMessageDefinition_Key_Help";
			public const string DeviceMessageDefinition_MessageId = "DeviceMessageDefinition_MessageId";
			public const string DeviceMessageDefinition_MessageId_Help = "DeviceMessageDefinition_MessageId_Help";
			public const string DeviceMessageDefinition_Script = "DeviceMessageDefinition_Script";
			public const string DeviceMessageDefinition_Title = "DeviceMessageDefinition_Title";
			public const string DeviceMessageField_BinaryOffset = "DeviceMessageField_BinaryOffset";
			public const string DeviceMessageField_BinaryOffset_Help = "DeviceMessageField_BinaryOffset_Help";
			public const string DeviceMessageField_BinaryParser_Boolean = "DeviceMessageField_BinaryParser_Boolean";
			public const string DeviceMessageField_BinaryParser_Byte = "DeviceMessageField_BinaryParser_Byte";
			public const string DeviceMessageField_BinaryParser_Char = "DeviceMessageField_BinaryParser_Char";
			public const string DeviceMessageField_BinaryParser_DoublePrecisionFloatingPoint = "DeviceMessageField_BinaryParser_DoublePrecisionFloatingPoint";
			public const string DeviceMessageField_BinaryParser_Int16 = "DeviceMessageField_BinaryParser_Int16";
			public const string DeviceMessageField_BinaryParser_Int32 = "DeviceMessageField_BinaryParser_Int32";
			public const string DeviceMessageField_BinaryParser_Int64 = "DeviceMessageField_BinaryParser_Int64";
			public const string DeviceMessageField_BinaryParser_SinglePrecisionFloatingPoint = "DeviceMessageField_BinaryParser_SinglePrecisionFloatingPoint";
			public const string DeviceMessageField_BinaryParser_String = "DeviceMessageField_BinaryParser_String";
			public const string DeviceMessageField_BinaryParser_UInt16 = "DeviceMessageField_BinaryParser_UInt16";
			public const string DeviceMessageField_BinaryParser_UInt32 = "DeviceMessageField_BinaryParser_UInt32";
			public const string DeviceMessageField_BinaryParser_UInt64 = "DeviceMessageField_BinaryParser_UInt64";
			public const string DeviceMessageField_Delimited_Index = "DeviceMessageField_Delimited_Index";
			public const string DeviceMessageField_Delimited_Index_Help = "DeviceMessageField_Delimited_Index_Help";
			public const string DeviceMessageField_Description = "DeviceMessageField_Description";
			public const string DeviceMessageField_FieldType_Content = "DeviceMessageField_FieldType_Content";
			public const string DeviceMessageField_FieldType_DeviceId = "DeviceMessageField_FieldType_DeviceId";
			public const string DeviceMessageField_FieldType_Help = "DeviceMessageField_FieldType_Help";
			public const string DeviceMessageField_FieldType_MessageId = "DeviceMessageField_FieldType_MessageId";
			public const string DeviceMessageField_GroupName = "DeviceMessageField_GroupName";
			public const string DeviceMessageField_GroupName_Help = "DeviceMessageField_GroupName_Help";
			public const string DeviceMessageField_Help = "DeviceMessageField_Help";
			public const string DeviceMessageField_IsRequired = "DeviceMessageField_IsRequired";
			public const string DeviceMessageField_JSONPath = "DeviceMessageField_JSONPath";
			public const string DeviceMessageField_JsonPath_Help = "DeviceMessageField_JsonPath_Help";
			public const string DeviceMessageField_Length = "DeviceMessageField_Length";
			public const string DeviceMessageField_MaxValue = "DeviceMessageField_MaxValue";
			public const string DeviceMessageField_MaxValue_Help = "DeviceMessageField_MaxValue_Help";
			public const string DeviceMessageField_MessageFieldType = "DeviceMessageField_MessageFieldType";
			public const string DeviceMessageField_MessageFieldType_Help = "DeviceMessageField_MessageFieldType_Help";
			public const string DeviceMessageField_MessageFieldType_Select = "DeviceMessageField_MessageFieldType_Select";
			public const string DeviceMessageField_MinValue = "DeviceMessageField_MinValue";
			public const string DeviceMessageField_MinValue_Help = "DeviceMessageField_MinValue_Help";
			public const string DeviceMessageField_PathLocator = "DeviceMessageField_PathLocator";
			public const string DeviceMessageField_PathLocator_Help = "DeviceMessageField_PathLocator_Help";
			public const string DeviceMessageField_PropertyRequiredForContentType = "DeviceMessageField_PropertyRequiredForContentType";
			public const string DeviceMessageField_QueryStringField = "DeviceMessageField_QueryStringField";
			public const string DeviceMessageField_QueryStringField_Help = "DeviceMessageField_QueryStringField_Help";
			public const string DeviceMessageField_RegExValidation = "DeviceMessageField_RegExValidation";
			public const string DeviceMessageField_RegExValidation_Help = "DeviceMessageField_RegExValidation_Help";
			public const string DeviceMessageField_RegExValueSelector = "DeviceMessageField_RegExValueSelector";
			public const string DeviceMessageField_RegExValueSelector_Help = "DeviceMessageField_RegExValueSelector_Help";
			public const string DeviceMessageField_SearchLocation = "DeviceMessageField_SearchLocation";
			public const string DeviceMessageField_SearchLocation_Body = "DeviceMessageField_SearchLocation_Body";
			public const string DeviceMessageField_SearchLocation_Headers = "DeviceMessageField_SearchLocation_Headers";
			public const string DeviceMessageField_SearchLocation_Help = "DeviceMessageField_SearchLocation_Help";
			public const string DeviceMessageField_SearchLocation_Path = "DeviceMessageField_SearchLocation_Path";
			public const string DeviceMessageField_SearchLocation_QueryString = "DeviceMessageField_SearchLocation_QueryString";
			public const string DeviceMessageField_SearchLocation_Select = "DeviceMessageField_SearchLocation_Select";
			public const string DeviceMessageField_StartIndex = "DeviceMessageField_StartIndex";
			public const string DeviceMessageField_StorageFieldType = "DeviceMessageField_StorageFieldType";
			public const string DeviceMessageField_StorageFieldType_Help = "DeviceMessageField_StorageFieldType_Help";
			public const string DeviceMessageField_StorageFieldType_Select = "DeviceMessageField_StorageFieldType_Select";
			public const string DeviceMessageField_String_LeadingLength = "DeviceMessageField_String_LeadingLength";
			public const string DeviceMessageField_String_LeadingLength_Help = "DeviceMessageField_String_LeadingLength_Help";
			public const string DeviceMessageField_StringParser_Boolean = "DeviceMessageField_StringParser_Boolean";
			public const string DeviceMessageField_StringParser_FloatingPointNumber = "DeviceMessageField_StringParser_FloatingPointNumber";
			public const string DeviceMessageField_StringParser_String = "DeviceMessageField_StringParser_String";
			public const string DeviceMessageField_StringParser_WholeNumber = "DeviceMessageField_StringParser_WholeNumber";
			public const string DeviceMessageField_SubString_Help = "DeviceMessageField_SubString_Help";
			public const string DeviceMessageField_Title = "DeviceMessageField_Title";
			public const string DeviceMessageField_XPath = "DeviceMessageField_XPath";
			public const string DeviceMessgaeField_Endian_BigEndian = "DeviceMessgaeField_Endian_BigEndian";
			public const string DeviceMessgaeField_Endian_LittleEndian = "DeviceMessgaeField_Endian_LittleEndian";
			public const string DeviceMessgaeField_Notes = "DeviceMessgaeField_Notes";
			public const string DeviceMessgaeField_StringParsing_Strategy = "DeviceMessgaeField_StringParsing_Strategy";
			public const string DeviceMessgaeField_StringParsing_Strategy_Help = "DeviceMessgaeField_StringParsing_Strategy_Help";
			public const string DeviceMessgaeField_StringParsing_Strategy_LengthProvided = "DeviceMessgaeField_StringParsing_Strategy_LengthProvided";
			public const string DeviceMessgaeField_StringParsing_Strategy_NullTerminated = "DeviceMessgaeField_StringParsing_Strategy_NullTerminated";
			public const string DeviceMessgaeField_StringSize_CharacterCount = "DeviceMessgaeField_StringSize_CharacterCount";
			public const string DeviceMessgaeField_StringSize_CharacterCount_Help = "DeviceMessgaeField_StringSize_CharacterCount_Help";
			public const string MessageFramingByte_AfterPayload = "MessageFramingByte_AfterPayload";
			public const string MessageFramingByte_AfterPayload_Help = "MessageFramingByte_AfterPayload_Help";
			public const string MessageFramingByte_Byte = "MessageFramingByte_Byte";
			public const string MessageFramingByte_Byte_Help = "MessageFramingByte_Byte_Help";
			public const string MessageFramingByte_Description = "MessageFramingByte_Description";
			public const string MessageFramingByte_Help = "MessageFramingByte_Help";
			public const string MessageFramingByte_Index = "MessageFramingByte_Index";
			public const string MessageFramingByte_Index_Help = "MessageFramingByte_Index_Help";
			public const string MessageFramingByte_Title = "MessageFramingByte_Title";
		}
	}
}
