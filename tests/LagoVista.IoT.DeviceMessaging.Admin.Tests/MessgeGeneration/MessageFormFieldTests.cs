// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 11519b128a4ee0f657f8991dd32ff16daf6c3be099ec14d69ebf7578f80fa8da
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.MessgeGeneration
{
    [TestClass]
    public class MessageFormFieldTests
    {
        [TestMethod]
        public void CreateForMField()
        {
            var msg = new DeviceMessageDefinition();
            msg.SampleMessages.Add(new SampleMessage()
            {
                Id = "abc"
            });

            msg.Fields.Add(new DeviceMessageDefinitionField()
            {
                Id = "def"
            });

            var response = DetailResponse<DeviceMessageDefinition>.Create(msg);

            Assert.IsNotNull(response.View[nameof(DeviceMessageDefinition.SampleMessages).ToCamelCase()].FormFields);
            Assert.IsNotNull(response.View[nameof(DeviceMessageDefinition.Fields).ToCamelCase()].FormFields);
            Assert.AreNotEqual(response.View[nameof(DeviceMessageDefinition.SampleMessages).ToCamelCase()].FormFields.Count, 0);
            Assert.AreNotEqual(response.View[nameof(DeviceMessageDefinition.Fields).ToCamelCase()].FormFields.Count, 0);
        }
    }

    public static class Extensions
    {
        public static string ToCamelCase(this string value)
        {
            return value.Substring(0, 1).ToLower() + value.Substring(1);
        }

    }
}
