using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class XmlMessageFieldTests : MessageFieldTestBase
    {
        [TestMethod]
        public void XmlMessageField_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.XML);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.XML, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void XmlMessageField_MissingXPath_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.XML);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.XML, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.XPath = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void XmlMessageField_MissingParsedStringType_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.XML);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.XML, DeviceAdmin.Models.ParameterTypes.Integer);
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
