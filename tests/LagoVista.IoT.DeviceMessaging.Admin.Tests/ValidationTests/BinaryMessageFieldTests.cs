using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class BinaryMessageFieldTests : MessageFieldTestBase
    {
        [TestMethod]
        public void ExtractBinaryField()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = new DeviceMessageDefinitionField();
            fld.Key = "key";
            fld.Name = "fld1";
            fld.StartIndex = 1;
            fld.SearchLocation = new Core.Models.EntityHeader<SearchLocations>() { Id = DeviceMessageDefinitionField.SearchLocation_Body, Text = "Body" };
            fld.ParsedBinaryFieldType = new Core.Models.EntityHeader<ParseBinaryValueType>() { Id = DeviceMessageDefinitionField.ParserBinaryType_UInt64, Text = "uint64" };
            fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = "string", Text = "read" };
            msg.Fields.Add(fld);

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }
    }
}
