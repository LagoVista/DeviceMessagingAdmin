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
        public void BinaryMessageField_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Binary, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }


        [TestMethod]
        public void BinaryMessageField_MissingBindaryOffset_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Binary, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.BinaryOffset = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessageField_ParsedBinaryField_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Binary, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.ParsedBinaryFieldType = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }
    }
}
