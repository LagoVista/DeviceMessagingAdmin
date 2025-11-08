// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 18a631824466b12d64b5c19c38ade955cee60dbbad39645c435d09e589fe9424
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
    public partial class PrecisionLocation : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1, Name = @"geopointsrc")]
        [DefaultValue("")]
        [XmlAttribute(AttributeName = "geopointsrc")]
        public string Geopointsrc { get; set; } = "";

        [ProtoMember(2, Name = @"altsrc")]
        [DefaultValue("")]
        [XmlAttribute(AttributeName = "altsrc")]
        public string Altsrc { get; set; } = "";

    }
}
