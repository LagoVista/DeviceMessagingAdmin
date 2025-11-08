// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 941a1605af84a9df8c6eedbc0d4f97f616db1c6e40759d2a30b60a4d98ddc7a7
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.IoT.DeviceMessaging.Models.Cot;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.MessgeGeneration
{
    [TestClass]
    public class COTMessage
    {

        [TestMethod]
        public void WriteMessage()
        {
            var message = new Event();

            message.Detail = new Detail();
            message.Detail.Points = new List<Link>
            {
                new Link()
                {
                    Latitude = 12.2,
                    Longitude = 13.3
                },
                new Link()
                {
                    Latitude = 12.3,
                    Longitude = 13.4
                },
                new Link()
                {
                    Latitude = 13.3,
                    Longitude = 15.4
                }
            };

            message.CalculatePoint();

            message.Detail.Contact = new Contact();
            message.Detail.Contact.Callsign = "KEVIN1";
            message.Detail.FillColor = new FillColor() { Color = 0x7FFF0000 };
            
            var xml = message.ToXmlString(true);
            Console.WriteLine(xml);
        }
    }
}
