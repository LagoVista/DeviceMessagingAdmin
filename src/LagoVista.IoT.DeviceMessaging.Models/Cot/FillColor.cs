// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 9f9596820251f31e465a05b8df638ad8daa9b9c352f12a60a8bdcd9dd6aaa52a
// IndexVersion: 2
// --- END CODE INDEX META ---
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    public class FillColor
    {
        [XmlAttribute(AttributeName = "value")]
        public long Color { get; set; }
    }
}
