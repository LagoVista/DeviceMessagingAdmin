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
        public AllowableStorageContentTypeAttribute(ParameterTypes contentType, bool isRequired = true, string customMessage = "")
        {
            ContentType = contentType;
            IsRequired = isRequired;
            CustomMessage = customMessage;
        }

        public ParameterTypes ContentType { get; private set; }
        public bool IsRequired { get; private set; }
        public string CustomMessage { get; private set; }
    }
}
