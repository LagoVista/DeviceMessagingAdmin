using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace LagoVista.IoT.DeviceMessaging.Models.Cot
{
    public class Link
    {
        [XmlIgnore]
        public double Latitude { get; set; }

        [XmlIgnore]
        public double Longitude { get; set; }

        [XmlAttribute(AttributeName = "point")]
        public string Point 
        { 
            get { return $"{Latitude},{Longitude}"; }
            set { } 
        }
    }
}
