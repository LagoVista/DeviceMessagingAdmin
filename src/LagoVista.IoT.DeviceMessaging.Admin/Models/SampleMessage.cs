using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LagoVista.Core;
using LagoVista.IoT.DeviceMessaging.Admin.Resources;
using LagoVista.Core.Attributes;

namespace LagoVista.IoT.DeviceMessaging.Admin.Models
{
    [EntityDescription(DeviceMessagingAdminDomain.DeviceMessagingAdmin, DeviceMessagingAdminResources.Names.SampleMessage_Title, DeviceMessagingAdminResources.Names.SampleMessage_Help, DeviceMessagingAdminResources.Names.SampleMessage_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceMessagingAdminDomain))]
    public class SampleMessage
    {
        public SampleMessage()
        {
            Id = Guid.NewGuid().ToId();
            Headers = new ObservableCollection<Header>();
        }

        public String Id { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Key, HelpResource: DeviceMessagingAdminResources.Names.DeviceMessageDefinition_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: DeviceMessagingAdminResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: true)]
        public String Key { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.SampleMessage_PathAndQueryString, FieldType: FieldTypes.MultiLineText,  ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: false)]
        public String PathAndQueryString { get; set; }


        [FormField(LabelResource: DeviceMessagingAdminResources.Names.SampleMessage_Topic, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: false)]
        public String Topic { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.SampleMessage_Payload, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: false)]
        public String Payload { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: false)]
        public String Description { get; set; }

        [FormField(LabelResource: DeviceMessagingAdminResources.Names.SampleMessage_Headers, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceMessagingAdminResources), IsRequired: false)]
        public ObservableCollection<Header> Headers { get; set; }
    }

    public class Header
    {
        public String Name { get; set; }
        public String Value { get; set; }
    }
}
