// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: c804afcd75a6ba8b46c1ca4316509c71e16ba1c9b434d3d3c2f7d4094aea340e
// IndexVersion: 0
// --- END CODE INDEX META ---
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Models
{
    public class DisplayImageSegment
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string B64Image { get; set; }
    }
}
