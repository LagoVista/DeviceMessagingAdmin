// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ad2decf1091bcd4fd6b71844ecdce6a434506a23977b96736a7807eb684b44ad
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AllowableMessageContentTypeAttribute : System.Attribute
    {
        public AllowableMessageContentTypeAttribute(MessageContentTypes contentType, bool isRequired = true, string customMessage = "")
        {
            ContentType = contentType;
            IsRequired = isRequired;
            CustomMessage = customMessage;
        }
        
        public MessageContentTypes ContentType { get; private set; }
        public bool IsRequired { get; private set; }
        public string CustomMessage { get; private set; }
    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AllowableStorageContentTypeAttribute : System.Attribute
    {
        public AllowableStorageContentTypeAttribute(ParameterTypes storageType, bool anyValueButThis = false, bool isRequired = true, string customMessage = "")
        {
            StorageType = storageType;
            IsRequired = isRequired;
            CustomMessage = customMessage;
            AnyValueButThis = anyValueButThis;
        }

        public ParameterTypes StorageType { get; private set; }
        public bool IsRequired { get; private set; }
        public bool AnyValueButThis { get; private set; }
        public string CustomMessage { get; private set; }
    }


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AllowableFieldTypeAttribute : System.Attribute
    {
        public AllowableFieldTypeAttribute(FieldType fieldType, bool isRequired = true, string customMessage = "")
        {
            FieldType = fieldType;
            IsRequired = isRequired;
            CustomMessage = customMessage;
        }



        public FieldType FieldType { get; private set; }
        public bool IsRequired { get; private set; }
        public string CustomMessage { get; private set; }
    }
}
