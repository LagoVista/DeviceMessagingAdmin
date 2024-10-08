﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    [ProtoContract]
    public class Detail : IExtensible
    {
        private IExtension __pbn__extensionData;
        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            => Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [ProtoMember(1)]
        [DefaultValue("")]
        public string xmlDetail { get; set; } = "";

        [ProtoMember(2, Name = @"contact")]
        [XmlElement(ElementName = "contact", IsNullable = true)]
        public Contact Contact { get; set; }

        [ProtoMember(3, Name = @"group")]
        [XmlElement(ElementName = "__group", IsNullable = true)]
        public Group Group { get; set; }

        [ProtoMember(4)]
        [XmlElement(ElementName = @"precisionlocation", IsNullable = true)]
        public PrecisionLocation PrecisionLocation { get; set; }

        [ProtoMember(5, Name = @"status")]
        [XmlElement(ElementName = "status", IsNullable = true)]
        public Status Status { get; set; }

        [ProtoMember(6, Name = @"takv")]
        [XmlElement(ElementName = "takv", IsNullable = true)]
        public Takv Takv { get; set; }

        [ProtoMember(7, Name = @"track")]
        [XmlElement(ElementName = "track", IsNullable = true)]
        public Track Track { get; set; }

        [XmlElement(ElementName = "link", IsNullable = true)]
        public List<Link> Points { get; set; }


        [XmlElement(ElementName = "fillColor", IsNullable = true)]
        public FillColor FillColor { get; set; }
    }
}
