// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c5f45d15b47c61dd7f339bd8d21c0d695bcb068101082ca26e8775714acdd97a
// IndexVersion: 2
// --- END CODE INDEX META ---
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    [ProtoContract()]
    public partial class Group : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"name")]
        [DefaultValue("")]
        [XmlAttribute(AttributeName = @"name")]
        public string Name { get; set; } = "";

        [ProtoMember(2, Name = @"role")]
        [DefaultValue("")]
        [XmlAttribute(AttributeName = @"role")]
        public string Role { get; set; } = "";

    }
}
