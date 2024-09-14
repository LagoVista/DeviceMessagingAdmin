using ProtoBuf;
using System.ComponentModel;
using System.Xml.Serialization;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    [ProtoContract()]
    public partial class Contact : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"endpoint")]
        [DefaultValue("")]
        [XmlAttribute(AttributeName = "endpoint")]
        public string Endpoint { get; set; } = "";

        [ProtoMember(2, Name = @"callsign")]
        [DefaultValue("")]
        [XmlAttribute(AttributeName = "callsign")]
        public string Callsign { get; set; } = "";

    }
}
