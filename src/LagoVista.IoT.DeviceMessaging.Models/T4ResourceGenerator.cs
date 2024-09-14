/*9/14/2024 8:23:42 AM*/
using System.Globalization;
using System.Reflection;

//Resources:DeviceMessagingAdminResources:Common_Category
namespace LagoVista.IoT.DeviceMessaging.Models.Resources
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.IoT.DeviceMessaging.Models.Resources.DeviceMessagingAdminResources", typeof(DeviceMessagingAdminResources).GetTypeInfo().Assembly);
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
		
		public static string Common_Category { get { return GetResourceString("Common_Category"); } }
//Resources:DeviceMessagingAdminResources:Common_Category_Select

		public static string Common_Category_Select { get { return GetResourceString("Common_Category_Select"); } }
//Resources:DeviceMessagingAdminResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:DeviceMessagingAdminResources:Common_Icon

		public static string Common_Icon { get { return GetResourceString("Common_Icon"); } }
//Resources:DeviceMessagingAdminResources:Common_Id

		public static string Common_Id { get { return GetResourceString("Common_Id"); } }
//Resources:DeviceMessagingAdminResources:Common_IsPublic

		public static string Common_IsPublic { get { return GetResourceString("Common_IsPublic"); } }
//Resources:DeviceMessagingAdminResources:Common_IsPublic_Help

		public static string Common_IsPublic_Help { get { return GetResourceString("Common_IsPublic_Help"); } }
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
//Resources:DeviceMessagingAdminResources:DateTimeZone_8601

		public static string DateTimeZone_8601 { get { return GetResourceString("DateTimeZone_8601"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_EpochMS

		public static string DateTimeZone_EpochMS { get { return GetResourceString("DateTimeZone_EpochMS"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_EpochSeconds

		public static string DateTimeZone_EpochSeconds { get { return GetResourceString("DateTimeZone_EpochSeconds"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_NoTimeZone

		public static string DateTimeZone_NoTimeZone { get { return GetResourceString("DateTimeZone_NoTimeZone"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_Select

		public static string DateTimeZone_Select { get { return GetResourceString("DateTimeZone_Select"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_Server

		public static string DateTimeZone_Server { get { return GetResourceString("DateTimeZone_Server"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_Time_Zone

		public static string DateTimeZone_Time_Zone { get { return GetResourceString("DateTimeZone_Time_Zone"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_Time_Zone_Help

		public static string DateTimeZone_Time_Zone_Help { get { return GetResourceString("DateTimeZone_Time_Zone_Help"); } }
//Resources:DeviceMessagingAdminResources:DateTimeZone_Universal

		public static string DateTimeZone_Universal { get { return GetResourceString("DateTimeZone_Universal"); } }
//Resources:DeviceMessagingAdminResources:DeviceField_Help

		public static string DeviceField_Help { get { return GetResourceString("DeviceField_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceField_Title

		public static string DeviceField_Title { get { return GetResourceString("DeviceField_Title"); } }
//Resources:DeviceMessagingAdminResources:DeviceField_Verifiers

		public static string DeviceField_Verifiers { get { return GetResourceString("DeviceField_Verifiers"); } }
//Resources:DeviceMessagingAdminResources:DeviceField_Verifiers_Help

		public static string DeviceField_Verifiers_Help { get { return GetResourceString("DeviceField_Verifiers_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMesage_MessageDirection

		public static string DeviceMesage_MessageDirection { get { return GetResourceString("DeviceMesage_MessageDirection"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_FormPost

		public static string DeviceMessage_ContentType_FormPost { get { return GetResourceString("DeviceMessage_ContentType_FormPost"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_GeoPointArray

		public static string DeviceMessage_ContentType_GeoPointArray { get { return GetResourceString("DeviceMessage_ContentType_GeoPointArray"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Help

		public static string DeviceMessage_ContentType_Help { get { return GetResourceString("DeviceMessage_ContentType_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Json

		public static string DeviceMessage_ContentType_Json { get { return GetResourceString("DeviceMessage_ContentType_Json"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Media

		public static string DeviceMessage_ContentType_Media { get { return GetResourceString("DeviceMessage_ContentType_Media"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_MultiPart_Media

		public static string DeviceMessage_ContentType_MultiPart_Media { get { return GetResourceString("DeviceMessage_ContentType_MultiPart_Media"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_NoContent

		public static string DeviceMessage_ContentType_NoContent { get { return GetResourceString("DeviceMessage_ContentType_NoContent"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_PointArray

		public static string DeviceMessage_ContentType_PointArray { get { return GetResourceString("DeviceMessage_ContentType_PointArray"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_ProtoBuf

		public static string DeviceMessage_ContentType_ProtoBuf { get { return GetResourceString("DeviceMessage_ContentType_ProtoBuf"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Select

		public static string DeviceMessage_ContentType_Select { get { return GetResourceString("DeviceMessage_ContentType_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_SevenSegementImage

		public static string DeviceMessage_ContentType_SevenSegementImage { get { return GetResourceString("DeviceMessage_ContentType_SevenSegementImage"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_StringPosition

		public static string DeviceMessage_ContentType_StringPosition { get { return GetResourceString("DeviceMessage_ContentType_StringPosition"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_StringRegEx

		public static string DeviceMessage_ContentType_StringRegEx { get { return GetResourceString("DeviceMessage_ContentType_StringRegEx"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ContentType_Xml

		public static string DeviceMessage_ContentType_Xml { get { return GetResourceString("DeviceMessage_ContentType_Xml"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Delimiter

		public static string DeviceMessage_Delimiter { get { return GetResourceString("DeviceMessage_Delimiter"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Delimiter_Help

		public static string DeviceMessage_Delimiter_Help { get { return GetResourceString("DeviceMessage_Delimiter_Help"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessage_ImportFields

		public static string DeviceMessage_ImportFields { get { return GetResourceString("DeviceMessage_ImportFields"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_MessageDirection_Help

		public static string DeviceMessage_MessageDirection_Help { get { return GetResourceString("DeviceMessage_MessageDirection_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_OutputMessageScript

		public static string DeviceMessage_OutputMessageScript { get { return GetResourceString("DeviceMessage_OutputMessageScript"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_OutputMessageScript_Help

		public static string DeviceMessage_OutputMessageScript_Help { get { return GetResourceString("DeviceMessage_OutputMessageScript_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_OutputScript_Watermark

		public static string DeviceMessage_OutputScript_Watermark { get { return GetResourceString("DeviceMessage_OutputScript_Watermark"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_PathAndQueryString

		public static string DeviceMessage_PathAndQueryString { get { return GetResourceString("DeviceMessage_PathAndQueryString"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_PathAndQueryString_Help

		public static string DeviceMessage_PathAndQueryString_Help { get { return GetResourceString("DeviceMessage_PathAndQueryString_Help"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessage_RESTMethod

		public static string DeviceMessage_RESTMethod { get { return GetResourceString("DeviceMessage_RESTMethod"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_RESTMethod_Select

		public static string DeviceMessage_RESTMethod_Select { get { return GetResourceString("DeviceMessage_RESTMethod_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Script_Watermark

		public static string DeviceMessage_Script_Watermark { get { return GetResourceString("DeviceMessage_Script_Watermark"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_ShowVerifiers

		public static string DeviceMessage_ShowVerifiers { get { return GetResourceString("DeviceMessage_ShowVerifiers"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_StaleSeconds

		public static string DeviceMessage_StaleSeconds { get { return GetResourceString("DeviceMessage_StaleSeconds"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_StaleSeconds_Help

		public static string DeviceMessage_StaleSeconds_Help { get { return GetResourceString("DeviceMessage_StaleSeconds_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_StringParsingStrategy_Select

		public static string DeviceMessage_StringParsingStrategy_Select { get { return GetResourceString("DeviceMessage_StringParsingStrategy_Select"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Topic

		public static string DeviceMessage_Topic { get { return GetResourceString("DeviceMessage_Topic"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessage_Topic_Help

		public static string DeviceMessage_Topic_Help { get { return GetResourceString("DeviceMessage_Topic_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_DefaultValue

		public static string DeviceMessageDefinition_DefaultValue { get { return GetResourceString("DeviceMessageDefinition_DefaultValue"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_DefaultValue_Help

		public static string DeviceMessageDefinition_DefaultValue_Help { get { return GetResourceString("DeviceMessageDefinition_DefaultValue_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Description

		public static string DeviceMessageDefinition_Description { get { return GetResourceString("DeviceMessageDefinition_Description"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Extension

		public static string DeviceMessageDefinition_Extension { get { return GetResourceString("DeviceMessageDefinition_Extension"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Fields

		public static string DeviceMessageDefinition_Fields { get { return GetResourceString("DeviceMessageDefinition_Fields"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Help

		public static string DeviceMessageDefinition_Help { get { return GetResourceString("DeviceMessageDefinition_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Key_Help

		public static string DeviceMessageDefinition_Key_Help { get { return GetResourceString("DeviceMessageDefinition_Key_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_MediaContentType

		public static string DeviceMessageDefinition_MediaContentType { get { return GetResourceString("DeviceMessageDefinition_MediaContentType"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_MessageId

		public static string DeviceMessageDefinition_MessageId { get { return GetResourceString("DeviceMessageDefinition_MessageId"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_MessageId_Help

		public static string DeviceMessageDefinition_MessageId_Help { get { return GetResourceString("DeviceMessageDefinition_MessageId_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_SampleMessages

		public static string DeviceMessageDefinition_SampleMessages { get { return GetResourceString("DeviceMessageDefinition_SampleMessages"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_SampleMessages_Help

		public static string DeviceMessageDefinition_SampleMessages_Help { get { return GetResourceString("DeviceMessageDefinition_SampleMessages_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Script

		public static string DeviceMessageDefinition_Script { get { return GetResourceString("DeviceMessageDefinition_Script"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinition_Title

		public static string DeviceMessageDefinition_Title { get { return GetResourceString("DeviceMessageDefinition_Title"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageDefinitions_Title

		public static string DeviceMessageDefinitions_Title { get { return GetResourceString("DeviceMessageDefinitions_Title"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_AltitudeBinaryOffset

		public static string DeviceMessageField_AltitudeBinaryOffset { get { return GetResourceString("DeviceMessageField_AltitudeBinaryOffset"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_AltitudeFieldIndex

		public static string DeviceMessageField_AltitudeFieldIndex { get { return GetResourceString("DeviceMessageField_AltitudeFieldIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_AltitudeGroupName

		public static string DeviceMessageField_AltitudeGroupName { get { return GetResourceString("DeviceMessageField_AltitudeGroupName"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_AltitudeJSONPath

		public static string DeviceMessageField_AltitudeJSONPath { get { return GetResourceString("DeviceMessageField_AltitudeJSONPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_AltitudeQueryStringField

		public static string DeviceMessageField_AltitudeQueryStringField { get { return GetResourceString("DeviceMessageField_AltitudeQueryStringField"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_AltitudeStartIndex

		public static string DeviceMessageField_AltitudeStartIndex { get { return GetResourceString("DeviceMessageField_AltitudeStartIndex"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessageField_FieldIndex

		public static string DeviceMessageField_FieldIndex { get { return GetResourceString("DeviceMessageField_FieldIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_FieldIndex_Help

		public static string DeviceMessageField_FieldIndex_Help { get { return GetResourceString("DeviceMessageField_FieldIndex_Help"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessageField_HeaderName

		public static string DeviceMessageField_HeaderName { get { return GetResourceString("DeviceMessageField_HeaderName"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_HeaderName_Help

		public static string DeviceMessageField_HeaderName_Help { get { return GetResourceString("DeviceMessageField_HeaderName_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Help

		public static string DeviceMessageField_Help { get { return GetResourceString("DeviceMessageField_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_IsRequired

		public static string DeviceMessageField_IsRequired { get { return GetResourceString("DeviceMessageField_IsRequired"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_JSONPath

		public static string DeviceMessageField_JSONPath { get { return GetResourceString("DeviceMessageField_JSONPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_JsonPath_Help

		public static string DeviceMessageField_JsonPath_Help { get { return GetResourceString("DeviceMessageField_JsonPath_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatBinaryOffset

		public static string DeviceMessageField_LatBinaryOffset { get { return GetResourceString("DeviceMessageField_LatBinaryOffset"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatDelimitedIndex

		public static string DeviceMessageField_LatDelimitedIndex { get { return GetResourceString("DeviceMessageField_LatDelimitedIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatFieldIndex

		public static string DeviceMessageField_LatFieldIndex { get { return GetResourceString("DeviceMessageField_LatFieldIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatGroupName

		public static string DeviceMessageField_LatGroupName { get { return GetResourceString("DeviceMessageField_LatGroupName"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatJSONPath

		public static string DeviceMessageField_LatJSONPath { get { return GetResourceString("DeviceMessageField_LatJSONPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatQueryStringField

		public static string DeviceMessageField_LatQueryStringField { get { return GetResourceString("DeviceMessageField_LatQueryStringField"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatStartIndex

		public static string DeviceMessageField_LatStartIndex { get { return GetResourceString("DeviceMessageField_LatStartIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LatXPath

		public static string DeviceMessageField_LatXPath { get { return GetResourceString("DeviceMessageField_LatXPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Length

		public static string DeviceMessageField_Length { get { return GetResourceString("DeviceMessageField_Length"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonBinaryOffset

		public static string DeviceMessageField_LonBinaryOffset { get { return GetResourceString("DeviceMessageField_LonBinaryOffset"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonDelimitedIndex

		public static string DeviceMessageField_LonDelimitedIndex { get { return GetResourceString("DeviceMessageField_LonDelimitedIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonFieldIndex

		public static string DeviceMessageField_LonFieldIndex { get { return GetResourceString("DeviceMessageField_LonFieldIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonGroupName

		public static string DeviceMessageField_LonGroupName { get { return GetResourceString("DeviceMessageField_LonGroupName"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonJSONPath

		public static string DeviceMessageField_LonJSONPath { get { return GetResourceString("DeviceMessageField_LonJSONPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonQueryStringField

		public static string DeviceMessageField_LonQueryStringField { get { return GetResourceString("DeviceMessageField_LonQueryStringField"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonStartIndex

		public static string DeviceMessageField_LonStartIndex { get { return GetResourceString("DeviceMessageField_LonStartIndex"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_LonXPath

		public static string DeviceMessageField_LonXPath { get { return GetResourceString("DeviceMessageField_LonXPath"); } }
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

		public static string DeviceMessageField_PathLocator_Help { get { return GetResourceString("DeviceMessageField_PathLocator_Help"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Scaler

		public static string DeviceMessageField_Scaler { get { return GetResourceString("DeviceMessageField_Scaler"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_ScalerHelp

		public static string DeviceMessageField_ScalerHelp { get { return GetResourceString("DeviceMessageField_ScalerHelp"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SearchLocation_Topic

		public static string DeviceMessageField_SearchLocation_Topic { get { return GetResourceString("DeviceMessageField_SearchLocation_Topic"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_File

		public static string DeviceMessageField_StringParser_File { get { return GetResourceString("DeviceMessageField_StringParser_File"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_FloatingPointNumber

		public static string DeviceMessageField_StringParser_FloatingPointNumber { get { return GetResourceString("DeviceMessageField_StringParser_FloatingPointNumber"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_RealNumberArray

		public static string DeviceMessageField_StringParser_RealNumberArray { get { return GetResourceString("DeviceMessageField_StringParser_RealNumberArray"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_String

		public static string DeviceMessageField_StringParser_String { get { return GetResourceString("DeviceMessageField_StringParser_String"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_StringArray

		public static string DeviceMessageField_StringParser_StringArray { get { return GetResourceString("DeviceMessageField_StringParser_StringArray"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_WholeNumber

		public static string DeviceMessageField_StringParser_WholeNumber { get { return GetResourceString("DeviceMessageField_StringParser_WholeNumber"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_StringParser_WholeNumberArray

		public static string DeviceMessageField_StringParser_WholeNumberArray { get { return GetResourceString("DeviceMessageField_StringParser_WholeNumberArray"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_SubString_Help

		public static string DeviceMessageField_SubString_Help { get { return GetResourceString("DeviceMessageField_SubString_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_Title

		public static string DeviceMessageField_Title { get { return GetResourceString("DeviceMessageField_Title"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_TopicLocator

		public static string DeviceMessageField_TopicLocator { get { return GetResourceString("DeviceMessageField_TopicLocator"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_TopicLocator_Help

		public static string DeviceMessageField_TopicLocator_Help { get { return GetResourceString("DeviceMessageField_TopicLocator_Help"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_XPath

		public static string DeviceMessageField_XPath { get { return GetResourceString("DeviceMessageField_XPath"); } }
//Resources:DeviceMessagingAdminResources:DeviceMessageField_XPath_Help

		public static string DeviceMessageField_XPath_Help { get { return GetResourceString("DeviceMessageField_XPath_Help"); } }
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
//Resources:DeviceMessagingAdminResources:DeviceMssageField_AltitudeXPath

		public static string DeviceMssageField_AltitudeXPath { get { return GetResourceString("DeviceMssageField_AltitudeXPath"); } }
//Resources:DeviceMessagingAdminResources:DeviecMessage_ProtoBuf_Definition

		public static string DeviecMessage_ProtoBuf_Definition { get { return GetResourceString("DeviecMessage_ProtoBuf_Definition"); } }
//Resources:DeviceMessagingAdminResources:DeviecMessage_ProtoBuf_Definition_Help

		public static string DeviecMessage_ProtoBuf_Definition_Help { get { return GetResourceString("DeviecMessage_ProtoBuf_Definition_Help"); } }
//Resources:DeviceMessagingAdminResources:Err_FieldDefinitionMissing_StateSet

		public static string Err_FieldDefinitionMissing_StateSet { get { return GetResourceString("Err_FieldDefinitionMissing_StateSet"); } }
//Resources:DeviceMessagingAdminResources:Err_FieldDefinitionMissing_UnitSet

		public static string Err_FieldDefinitionMissing_UnitSet { get { return GetResourceString("Err_FieldDefinitionMissing_UnitSet"); } }
//Resources:DeviceMessagingAdminResources:Err_HeaderNameMissing

		public static string Err_HeaderNameMissing { get { return GetResourceString("Err_HeaderNameMissing"); } }
//Resources:DeviceMessagingAdminResources:Err_PathNameMissing

		public static string Err_PathNameMissing { get { return GetResourceString("Err_PathNameMissing"); } }
//Resources:DeviceMessagingAdminResources:Err_QueryStringNameMissing

		public static string Err_QueryStringNameMissing { get { return GetResourceString("Err_QueryStringNameMissing"); } }
//Resources:DeviceMessagingAdminResources:Err_TopicGroupNameMissing

		public static string Err_TopicGroupNameMissing { get { return GetResourceString("Err_TopicGroupNameMissing"); } }
//Resources:DeviceMessagingAdminResources:Err_TopicRegEx

		public static string Err_TopicRegEx { get { return GetResourceString("Err_TopicRegEx"); } }
//Resources:DeviceMessagingAdminResources:MessageDirection_Incoming

		public static string MessageDirection_Incoming { get { return GetResourceString("MessageDirection_Incoming"); } }
//Resources:DeviceMessagingAdminResources:MessageDirection_IncomingOutgoing

		public static string MessageDirection_IncomingOutgoing { get { return GetResourceString("MessageDirection_IncomingOutgoing"); } }
//Resources:DeviceMessagingAdminResources:MessageDirection_Outgoing

		public static string MessageDirection_Outgoing { get { return GetResourceString("MessageDirection_Outgoing"); } }
//Resources:DeviceMessagingAdminResources:MessageDirection_Select

		public static string MessageDirection_Select { get { return GetResourceString("MessageDirection_Select"); } }
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
//Resources:DeviceMessagingAdminResources:RESTMethod_DELETE

		public static string RESTMethod_DELETE { get { return GetResourceString("RESTMethod_DELETE"); } }
//Resources:DeviceMessagingAdminResources:RESTMethod_GET

		public static string RESTMethod_GET { get { return GetResourceString("RESTMethod_GET"); } }
//Resources:DeviceMessagingAdminResources:RESTMethod_POST

		public static string RESTMethod_POST { get { return GetResourceString("RESTMethod_POST"); } }
//Resources:DeviceMessagingAdminResources:RESTMethod_PUT

		public static string RESTMethod_PUT { get { return GetResourceString("RESTMethod_PUT"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_Description

		public static string SampleMessage_Description { get { return GetResourceString("SampleMessage_Description"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_HeaderName

		public static string SampleMessage_HeaderName { get { return GetResourceString("SampleMessage_HeaderName"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_Headers

		public static string SampleMessage_Headers { get { return GetResourceString("SampleMessage_Headers"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_HeaderValue

		public static string SampleMessage_HeaderValue { get { return GetResourceString("SampleMessage_HeaderValue"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_Help

		public static string SampleMessage_Help { get { return GetResourceString("SampleMessage_Help"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_MessageId

		public static string SampleMessage_MessageId { get { return GetResourceString("SampleMessage_MessageId"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_MessageId_Help

		public static string SampleMessage_MessageId_Help { get { return GetResourceString("SampleMessage_MessageId_Help"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_PathAndQueryString

		public static string SampleMessage_PathAndQueryString { get { return GetResourceString("SampleMessage_PathAndQueryString"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_Payload

		public static string SampleMessage_Payload { get { return GetResourceString("SampleMessage_Payload"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_Title

		public static string SampleMessage_Title { get { return GetResourceString("SampleMessage_Title"); } }
//Resources:DeviceMessagingAdminResources:SampleMessage_Topic

		public static string SampleMessage_Topic { get { return GetResourceString("SampleMessage_Topic"); } }
//Resources:DeviceMessagingAdminResources:SampleMessageHeader_HeaderName

		public static string SampleMessageHeader_HeaderName { get { return GetResourceString("SampleMessageHeader_HeaderName"); } }
//Resources:DeviceMessagingAdminResources:SampleMessageheader_HeaderValue

		public static string SampleMessageheader_HeaderValue { get { return GetResourceString("SampleMessageheader_HeaderValue"); } }
//Resources:DeviceMessagingAdminResources:SampleMessageHeader_Help

		public static string SampleMessageHeader_Help { get { return GetResourceString("SampleMessageHeader_Help"); } }
//Resources:DeviceMessagingAdminResources:SampleMessageHeader_TItle

		public static string SampleMessageHeader_TItle { get { return GetResourceString("SampleMessageHeader_TItle"); } }

		public static class Names
		{
			public const string Common_Category = "Common_Category";
			public const string Common_Category_Select = "Common_Category_Select";
			public const string Common_Description = "Common_Description";
			public const string Common_Icon = "Common_Icon";
			public const string Common_Id = "Common_Id";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_IsPublic_Help = "Common_IsPublic_Help";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_Name = "Common_Name";
			public const string Common_Notes = "Common_Notes";
			public const string DateTimeZone_8601 = "DateTimeZone_8601";
			public const string DateTimeZone_EpochMS = "DateTimeZone_EpochMS";
			public const string DateTimeZone_EpochSeconds = "DateTimeZone_EpochSeconds";
			public const string DateTimeZone_NoTimeZone = "DateTimeZone_NoTimeZone";
			public const string DateTimeZone_Select = "DateTimeZone_Select";
			public const string DateTimeZone_Server = "DateTimeZone_Server";
			public const string DateTimeZone_Time_Zone = "DateTimeZone_Time_Zone";
			public const string DateTimeZone_Time_Zone_Help = "DateTimeZone_Time_Zone_Help";
			public const string DateTimeZone_Universal = "DateTimeZone_Universal";
			public const string DeviceField_Help = "DeviceField_Help";
			public const string DeviceField_Title = "DeviceField_Title";
			public const string DeviceField_Verifiers = "DeviceField_Verifiers";
			public const string DeviceField_Verifiers_Help = "DeviceField_Verifiers_Help";
			public const string DeviceMesage_MessageDirection = "DeviceMesage_MessageDirection";
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
			public const string DeviceMessage_ContentType_FormPost = "DeviceMessage_ContentType_FormPost";
			public const string DeviceMessage_ContentType_GeoPointArray = "DeviceMessage_ContentType_GeoPointArray";
			public const string DeviceMessage_ContentType_Help = "DeviceMessage_ContentType_Help";
			public const string DeviceMessage_ContentType_Json = "DeviceMessage_ContentType_Json";
			public const string DeviceMessage_ContentType_Media = "DeviceMessage_ContentType_Media";
			public const string DeviceMessage_ContentType_MultiPart_Media = "DeviceMessage_ContentType_MultiPart_Media";
			public const string DeviceMessage_ContentType_NoContent = "DeviceMessage_ContentType_NoContent";
			public const string DeviceMessage_ContentType_PointArray = "DeviceMessage_ContentType_PointArray";
			public const string DeviceMessage_ContentType_ProtoBuf = "DeviceMessage_ContentType_ProtoBuf";
			public const string DeviceMessage_ContentType_Select = "DeviceMessage_ContentType_Select";
			public const string DeviceMessage_ContentType_SevenSegementImage = "DeviceMessage_ContentType_SevenSegementImage";
			public const string DeviceMessage_ContentType_StringPosition = "DeviceMessage_ContentType_StringPosition";
			public const string DeviceMessage_ContentType_StringRegEx = "DeviceMessage_ContentType_StringRegEx";
			public const string DeviceMessage_ContentType_Xml = "DeviceMessage_ContentType_Xml";
			public const string DeviceMessage_Delimiter = "DeviceMessage_Delimiter";
			public const string DeviceMessage_Delimiter_Help = "DeviceMessage_Delimiter_Help";
			public const string DeviceMessage_Endian = "DeviceMessage_Endian";
			public const string DeviceMessage_Endian_Help = "DeviceMessage_Endian_Help";
			public const string DeviceMessage_Endian_Select = "DeviceMessage_Endian_Select";
			public const string DeviceMessage_FramingBytes = "DeviceMessage_FramingBytes";
			public const string DeviceMessage_FramingBytes_Help = "DeviceMessage_FramingBytes_Help";
			public const string DeviceMessage_ImportFields = "DeviceMessage_ImportFields";
			public const string DeviceMessage_MessageDirection_Help = "DeviceMessage_MessageDirection_Help";
			public const string DeviceMessage_OutputMessageScript = "DeviceMessage_OutputMessageScript";
			public const string DeviceMessage_OutputMessageScript_Help = "DeviceMessage_OutputMessageScript_Help";
			public const string DeviceMessage_OutputScript_Watermark = "DeviceMessage_OutputScript_Watermark";
			public const string DeviceMessage_PathAndQueryString = "DeviceMessage_PathAndQueryString";
			public const string DeviceMessage_PathAndQueryString_Help = "DeviceMessage_PathAndQueryString_Help";
			public const string DeviceMessage_PropertyRequiredForContentType = "DeviceMessage_PropertyRequiredForContentType";
			public const string DeviceMessage_PropertyTypeHasValueButNotSupported = "DeviceMessage_PropertyTypeHasValueButNotSupported";
			public const string DeviceMessage_QuotedText = "DeviceMessage_QuotedText";
			public const string DeviceMessage_QuotedText_Help = "DeviceMessage_QuotedText_Help";
			public const string DeviceMessage_RegEx = "DeviceMessage_RegEx";
			public const string DeviceMessage_RegEx_Help = "DeviceMessage_RegEx_Help";
			public const string DeviceMessage_RESTMethod = "DeviceMessage_RESTMethod";
			public const string DeviceMessage_RESTMethod_Select = "DeviceMessage_RESTMethod_Select";
			public const string DeviceMessage_Script_Watermark = "DeviceMessage_Script_Watermark";
			public const string DeviceMessage_ShowVerifiers = "DeviceMessage_ShowVerifiers";
			public const string DeviceMessage_StaleSeconds = "DeviceMessage_StaleSeconds";
			public const string DeviceMessage_StaleSeconds_Help = "DeviceMessage_StaleSeconds_Help";
			public const string DeviceMessage_StringParsingStrategy_Select = "DeviceMessage_StringParsingStrategy_Select";
			public const string DeviceMessage_Topic = "DeviceMessage_Topic";
			public const string DeviceMessage_Topic_Help = "DeviceMessage_Topic_Help";
			public const string DeviceMessageDefinition_DefaultValue = "DeviceMessageDefinition_DefaultValue";
			public const string DeviceMessageDefinition_DefaultValue_Help = "DeviceMessageDefinition_DefaultValue_Help";
			public const string DeviceMessageDefinition_Description = "DeviceMessageDefinition_Description";
			public const string DeviceMessageDefinition_Extension = "DeviceMessageDefinition_Extension";
			public const string DeviceMessageDefinition_Fields = "DeviceMessageDefinition_Fields";
			public const string DeviceMessageDefinition_Help = "DeviceMessageDefinition_Help";
			public const string DeviceMessageDefinition_Key_Help = "DeviceMessageDefinition_Key_Help";
			public const string DeviceMessageDefinition_MediaContentType = "DeviceMessageDefinition_MediaContentType";
			public const string DeviceMessageDefinition_MessageId = "DeviceMessageDefinition_MessageId";
			public const string DeviceMessageDefinition_MessageId_Help = "DeviceMessageDefinition_MessageId_Help";
			public const string DeviceMessageDefinition_SampleMessages = "DeviceMessageDefinition_SampleMessages";
			public const string DeviceMessageDefinition_SampleMessages_Help = "DeviceMessageDefinition_SampleMessages_Help";
			public const string DeviceMessageDefinition_Script = "DeviceMessageDefinition_Script";
			public const string DeviceMessageDefinition_Title = "DeviceMessageDefinition_Title";
			public const string DeviceMessageDefinitions_Title = "DeviceMessageDefinitions_Title";
			public const string DeviceMessageField_AltitudeBinaryOffset = "DeviceMessageField_AltitudeBinaryOffset";
			public const string DeviceMessageField_AltitudeFieldIndex = "DeviceMessageField_AltitudeFieldIndex";
			public const string DeviceMessageField_AltitudeGroupName = "DeviceMessageField_AltitudeGroupName";
			public const string DeviceMessageField_AltitudeJSONPath = "DeviceMessageField_AltitudeJSONPath";
			public const string DeviceMessageField_AltitudeQueryStringField = "DeviceMessageField_AltitudeQueryStringField";
			public const string DeviceMessageField_AltitudeStartIndex = "DeviceMessageField_AltitudeStartIndex";
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
			public const string DeviceMessageField_FieldIndex = "DeviceMessageField_FieldIndex";
			public const string DeviceMessageField_FieldIndex_Help = "DeviceMessageField_FieldIndex_Help";
			public const string DeviceMessageField_FieldType_Content = "DeviceMessageField_FieldType_Content";
			public const string DeviceMessageField_FieldType_DeviceId = "DeviceMessageField_FieldType_DeviceId";
			public const string DeviceMessageField_FieldType_Help = "DeviceMessageField_FieldType_Help";
			public const string DeviceMessageField_FieldType_MessageId = "DeviceMessageField_FieldType_MessageId";
			public const string DeviceMessageField_GroupName = "DeviceMessageField_GroupName";
			public const string DeviceMessageField_GroupName_Help = "DeviceMessageField_GroupName_Help";
			public const string DeviceMessageField_HeaderName = "DeviceMessageField_HeaderName";
			public const string DeviceMessageField_HeaderName_Help = "DeviceMessageField_HeaderName_Help";
			public const string DeviceMessageField_Help = "DeviceMessageField_Help";
			public const string DeviceMessageField_IsRequired = "DeviceMessageField_IsRequired";
			public const string DeviceMessageField_JSONPath = "DeviceMessageField_JSONPath";
			public const string DeviceMessageField_JsonPath_Help = "DeviceMessageField_JsonPath_Help";
			public const string DeviceMessageField_LatBinaryOffset = "DeviceMessageField_LatBinaryOffset";
			public const string DeviceMessageField_LatDelimitedIndex = "DeviceMessageField_LatDelimitedIndex";
			public const string DeviceMessageField_LatFieldIndex = "DeviceMessageField_LatFieldIndex";
			public const string DeviceMessageField_LatGroupName = "DeviceMessageField_LatGroupName";
			public const string DeviceMessageField_LatJSONPath = "DeviceMessageField_LatJSONPath";
			public const string DeviceMessageField_LatQueryStringField = "DeviceMessageField_LatQueryStringField";
			public const string DeviceMessageField_LatStartIndex = "DeviceMessageField_LatStartIndex";
			public const string DeviceMessageField_LatXPath = "DeviceMessageField_LatXPath";
			public const string DeviceMessageField_Length = "DeviceMessageField_Length";
			public const string DeviceMessageField_LonBinaryOffset = "DeviceMessageField_LonBinaryOffset";
			public const string DeviceMessageField_LonDelimitedIndex = "DeviceMessageField_LonDelimitedIndex";
			public const string DeviceMessageField_LonFieldIndex = "DeviceMessageField_LonFieldIndex";
			public const string DeviceMessageField_LonGroupName = "DeviceMessageField_LonGroupName";
			public const string DeviceMessageField_LonJSONPath = "DeviceMessageField_LonJSONPath";
			public const string DeviceMessageField_LonQueryStringField = "DeviceMessageField_LonQueryStringField";
			public const string DeviceMessageField_LonStartIndex = "DeviceMessageField_LonStartIndex";
			public const string DeviceMessageField_LonXPath = "DeviceMessageField_LonXPath";
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
			public const string DeviceMessageField_Scaler = "DeviceMessageField_Scaler";
			public const string DeviceMessageField_ScalerHelp = "DeviceMessageField_ScalerHelp";
			public const string DeviceMessageField_SearchLocation = "DeviceMessageField_SearchLocation";
			public const string DeviceMessageField_SearchLocation_Body = "DeviceMessageField_SearchLocation_Body";
			public const string DeviceMessageField_SearchLocation_Headers = "DeviceMessageField_SearchLocation_Headers";
			public const string DeviceMessageField_SearchLocation_Help = "DeviceMessageField_SearchLocation_Help";
			public const string DeviceMessageField_SearchLocation_Path = "DeviceMessageField_SearchLocation_Path";
			public const string DeviceMessageField_SearchLocation_QueryString = "DeviceMessageField_SearchLocation_QueryString";
			public const string DeviceMessageField_SearchLocation_Select = "DeviceMessageField_SearchLocation_Select";
			public const string DeviceMessageField_SearchLocation_Topic = "DeviceMessageField_SearchLocation_Topic";
			public const string DeviceMessageField_StartIndex = "DeviceMessageField_StartIndex";
			public const string DeviceMessageField_StorageFieldType = "DeviceMessageField_StorageFieldType";
			public const string DeviceMessageField_StorageFieldType_Help = "DeviceMessageField_StorageFieldType_Help";
			public const string DeviceMessageField_StorageFieldType_Select = "DeviceMessageField_StorageFieldType_Select";
			public const string DeviceMessageField_String_LeadingLength = "DeviceMessageField_String_LeadingLength";
			public const string DeviceMessageField_String_LeadingLength_Help = "DeviceMessageField_String_LeadingLength_Help";
			public const string DeviceMessageField_StringParser_Boolean = "DeviceMessageField_StringParser_Boolean";
			public const string DeviceMessageField_StringParser_File = "DeviceMessageField_StringParser_File";
			public const string DeviceMessageField_StringParser_FloatingPointNumber = "DeviceMessageField_StringParser_FloatingPointNumber";
			public const string DeviceMessageField_StringParser_RealNumberArray = "DeviceMessageField_StringParser_RealNumberArray";
			public const string DeviceMessageField_StringParser_String = "DeviceMessageField_StringParser_String";
			public const string DeviceMessageField_StringParser_StringArray = "DeviceMessageField_StringParser_StringArray";
			public const string DeviceMessageField_StringParser_WholeNumber = "DeviceMessageField_StringParser_WholeNumber";
			public const string DeviceMessageField_StringParser_WholeNumberArray = "DeviceMessageField_StringParser_WholeNumberArray";
			public const string DeviceMessageField_SubString_Help = "DeviceMessageField_SubString_Help";
			public const string DeviceMessageField_Title = "DeviceMessageField_Title";
			public const string DeviceMessageField_TopicLocator = "DeviceMessageField_TopicLocator";
			public const string DeviceMessageField_TopicLocator_Help = "DeviceMessageField_TopicLocator_Help";
			public const string DeviceMessageField_XPath = "DeviceMessageField_XPath";
			public const string DeviceMessageField_XPath_Help = "DeviceMessageField_XPath_Help";
			public const string DeviceMessgaeField_Endian_BigEndian = "DeviceMessgaeField_Endian_BigEndian";
			public const string DeviceMessgaeField_Endian_LittleEndian = "DeviceMessgaeField_Endian_LittleEndian";
			public const string DeviceMessgaeField_Notes = "DeviceMessgaeField_Notes";
			public const string DeviceMessgaeField_StringParsing_Strategy = "DeviceMessgaeField_StringParsing_Strategy";
			public const string DeviceMessgaeField_StringParsing_Strategy_Help = "DeviceMessgaeField_StringParsing_Strategy_Help";
			public const string DeviceMessgaeField_StringParsing_Strategy_LengthProvided = "DeviceMessgaeField_StringParsing_Strategy_LengthProvided";
			public const string DeviceMessgaeField_StringParsing_Strategy_NullTerminated = "DeviceMessgaeField_StringParsing_Strategy_NullTerminated";
			public const string DeviceMessgaeField_StringSize_CharacterCount = "DeviceMessgaeField_StringSize_CharacterCount";
			public const string DeviceMessgaeField_StringSize_CharacterCount_Help = "DeviceMessgaeField_StringSize_CharacterCount_Help";
			public const string DeviceMssageField_AltitudeXPath = "DeviceMssageField_AltitudeXPath";
			public const string DeviecMessage_ProtoBuf_Definition = "DeviecMessage_ProtoBuf_Definition";
			public const string DeviecMessage_ProtoBuf_Definition_Help = "DeviecMessage_ProtoBuf_Definition_Help";
			public const string Err_FieldDefinitionMissing_StateSet = "Err_FieldDefinitionMissing_StateSet";
			public const string Err_FieldDefinitionMissing_UnitSet = "Err_FieldDefinitionMissing_UnitSet";
			public const string Err_HeaderNameMissing = "Err_HeaderNameMissing";
			public const string Err_PathNameMissing = "Err_PathNameMissing";
			public const string Err_QueryStringNameMissing = "Err_QueryStringNameMissing";
			public const string Err_TopicGroupNameMissing = "Err_TopicGroupNameMissing";
			public const string Err_TopicRegEx = "Err_TopicRegEx";
			public const string MessageDirection_Incoming = "MessageDirection_Incoming";
			public const string MessageDirection_IncomingOutgoing = "MessageDirection_IncomingOutgoing";
			public const string MessageDirection_Outgoing = "MessageDirection_Outgoing";
			public const string MessageDirection_Select = "MessageDirection_Select";
			public const string MessageFramingByte_AfterPayload = "MessageFramingByte_AfterPayload";
			public const string MessageFramingByte_AfterPayload_Help = "MessageFramingByte_AfterPayload_Help";
			public const string MessageFramingByte_Byte = "MessageFramingByte_Byte";
			public const string MessageFramingByte_Byte_Help = "MessageFramingByte_Byte_Help";
			public const string MessageFramingByte_Description = "MessageFramingByte_Description";
			public const string MessageFramingByte_Help = "MessageFramingByte_Help";
			public const string MessageFramingByte_Index = "MessageFramingByte_Index";
			public const string MessageFramingByte_Index_Help = "MessageFramingByte_Index_Help";
			public const string MessageFramingByte_Title = "MessageFramingByte_Title";
			public const string RESTMethod_DELETE = "RESTMethod_DELETE";
			public const string RESTMethod_GET = "RESTMethod_GET";
			public const string RESTMethod_POST = "RESTMethod_POST";
			public const string RESTMethod_PUT = "RESTMethod_PUT";
			public const string SampleMessage_Description = "SampleMessage_Description";
			public const string SampleMessage_HeaderName = "SampleMessage_HeaderName";
			public const string SampleMessage_Headers = "SampleMessage_Headers";
			public const string SampleMessage_HeaderValue = "SampleMessage_HeaderValue";
			public const string SampleMessage_Help = "SampleMessage_Help";
			public const string SampleMessage_MessageId = "SampleMessage_MessageId";
			public const string SampleMessage_MessageId_Help = "SampleMessage_MessageId_Help";
			public const string SampleMessage_PathAndQueryString = "SampleMessage_PathAndQueryString";
			public const string SampleMessage_Payload = "SampleMessage_Payload";
			public const string SampleMessage_Title = "SampleMessage_Title";
			public const string SampleMessage_Topic = "SampleMessage_Topic";
			public const string SampleMessageHeader_HeaderName = "SampleMessageHeader_HeaderName";
			public const string SampleMessageheader_HeaderValue = "SampleMessageheader_HeaderValue";
			public const string SampleMessageHeader_Help = "SampleMessageHeader_Help";
			public const string SampleMessageHeader_TItle = "SampleMessageHeader_TItle";
		}
	}
}

