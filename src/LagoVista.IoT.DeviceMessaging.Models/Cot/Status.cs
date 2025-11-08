// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 7071914097483e06137af12a8c097d29603d3caf1f027c2cd885e74950f0e85b
// IndexVersion: 2
// --- END CODE INDEX META ---
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    [ProtoContract()]
    public partial class Status : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"battery")]
        [XmlAttribute(AttributeName = "battery")]
        public uint Battery { get; set; }

    }
}
