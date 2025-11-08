// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 2676fbd194466858f728c868e6c3e4cc594af0f0e7cb9baf2af2ee8f3aaa295e
// IndexVersion: 2
// --- END CODE INDEX META ---
using ProtoBuf;
using System.ComponentModel;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    [ProtoContract()]
    public partial class TakControl : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        public uint minProtoVersion { get; set; }

        [ProtoMember(2)]
        public uint maxProtoVersion { get; set; }

        [ProtoMember(3)]
        [DefaultValue("")]
        public string contactUid { get; set; } = "";
    }
}