﻿using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class DelimitedMessageFieldTests : MessageFieldTestBase
    {
        [TestMethod]
        public void DelimitedMessageField_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Delimited);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Delimited, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void DelimitedMessageField_MissingStart_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Delimited);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Delimited, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.DelimitedIndex = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void DelimitedMessageField_ParsedBinaryField_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Delimited);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Delimited, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.ParsedStringFieldType = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }
    }
}
