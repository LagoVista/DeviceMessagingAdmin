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
