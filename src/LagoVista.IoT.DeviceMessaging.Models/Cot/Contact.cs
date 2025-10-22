// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 81bfecc5a73a2d6a64e738ff03005aa098050067d34fe57be413bb2b8d451ea5
// IndexVersion: 0
// --- END CODE INDEX META ---
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
