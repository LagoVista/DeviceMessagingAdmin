// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c4b155c0f644a8f25c8cbf5f5796d90e4993c5a5de4e073ee2819d6b91b09a1c
// IndexVersion: 2
// --- END CODE INDEX META ---
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
