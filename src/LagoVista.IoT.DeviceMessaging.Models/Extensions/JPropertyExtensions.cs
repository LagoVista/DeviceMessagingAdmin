using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT
{
    public static class JPropertyExtensions
    {
        public static DeviceMessageDefinitionField ToDeviceMessageField(this JProperty prop, String parentPath = "")
        {
            EntityHeader<ParseStringValueType> parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.String);
            EntityHeader<ParameterTypes> storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.String); ;

            switch (prop.Value.Type)
            {
                case JTokenType.None:
                    break;
                case JTokenType.Object:
                    break;
                case JTokenType.Array:
                    var arrayValues = prop.Value as JArray;
                    if (arrayValues == null)
                    {
                        storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.IntArray);
                        parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.WholeNumberArray);
                    }
                    else
                    {
                        // Start out with simplest value, a value of a whole number.
                        // [1, 2, 3, 4, 5]
                        var arrayDataType = JTokenType.Integer;

                        foreach(var arrayValue in arrayValues)
                        {
                            // if we detect a floating point number, and we currently think it's an int,
                            // then the data type will be a float as in this example 
                            // [1, 2, 3, 3.3, 4.4]
                            if(arrayValue.Type == JTokenType.Float && arrayDataType == JTokenType.Integer)
                            {
                                arrayDataType = JTokenType.Float;
                            }

                            // if in any case we detect anything other then an integer or float, just create
                            // the array of type string.
                            // potentially an invalid json array but maybe there is some reason for this.
                            // [1, 2, 'three', true] 
                            if (arrayValue.Type != JTokenType.Integer && arrayValue.Type != JTokenType.Float)
                            {
                                arrayDataType = JTokenType.String;
                            }
                        }

                        switch(arrayDataType)
                        {
                            case JTokenType.Integer:
                                storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.IntArray);
                                parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.WholeNumberArray);
                                break;
                            case JTokenType.Float:
                                storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.DecimalArray);
                                parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.RealNumberArray);
                                break;
                            case JTokenType.String:
                                storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.StringArray);
                                parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.StringArray);
                                break;
                        }
                    }
                    break;
                case JTokenType.Constructor:
                    break;
                case JTokenType.Property:
                    break;
                case JTokenType.Comment:
                    break;
                case JTokenType.Integer:
                    storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.Integer);
                    parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.WholeNumber);
                    break;
                case JTokenType.Float:
                    storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.Decimal);
                    parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.RealNumber);
                    break;
                case JTokenType.String:
                    storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.String);
                    parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.String);
                    break;
                case JTokenType.Boolean:
                    storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.TrueFalse);
                    parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.String);
                    break;
                case JTokenType.Null:
                    break;
                case JTokenType.Undefined:
                    break;
                case JTokenType.Date:
                    storageType = EntityHeader<ParameterTypes>.Create(ParameterTypes.DateTime);
                    parsedStringType = EntityHeader<ParseStringValueType>.Create(ParseStringValueType.String);
                    break;
                case JTokenType.Raw:
                    break;
                case JTokenType.Bytes:
                    break;
                case JTokenType.Guid:
                    break;
                case JTokenType.Uri:
                    break;
                case JTokenType.TimeSpan:
                    break;
            }

            return new DeviceMessageDefinitionField()
            {
                Name = String.IsNullOrEmpty(parentPath) ? ToNameCase(prop.Name) : $"{ToNameCase(parentPath)} {ToNameCase(prop.Name)}",
                Key = String.IsNullOrEmpty(parentPath) ? prop.Name.ToLower() : $"{parentPath.Replace(".", "")}{prop.Name}".ToLower(),
                JsonPath = String.IsNullOrEmpty(parentPath) ? prop.Name : $"{parentPath}.{prop.Name}",
                ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.JSON),
                StorageType = storageType,
                ParsedStringFieldType = parsedStringType,
                SearchLocation = EntityHeader<SearchLocations>.Create(SearchLocations.Body),
            };
        }

        private static string ToNameCase(string name)
        {
            var nameParts = name.Split('.');
            var pascalCaseName = "";
            foreach(var namePart in nameParts)
            {
                pascalCaseName += $"{namePart.Substring(0, 1).ToUpper()}{namePart.Substring(1)} ";
            }
            return pascalCaseName.Trim();
        }
    }
}
