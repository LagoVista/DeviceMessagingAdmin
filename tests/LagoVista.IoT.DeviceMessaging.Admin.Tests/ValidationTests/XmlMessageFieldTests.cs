// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: e41cc92f9d49f619999d433fea5bb781b65ddaa1e187d7e24923f13361efc15d
// IndexVersion: 2
// --- END CODE INDEX META ---
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
        public void XmlMessageField_NonGeoLocation_Valid()
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
        public void XmlMessageField_GeoLocation_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.XML);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.XML, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            msg.Fields.Add(fld);
            fld.XPath = null;
            fld.LatXPath = "/getthis/lat";
            fld.LonXPath = "/getthis/lon";

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }


        [TestMethod]
        public void XmlMessageField_MissingXPath_Non_GeoLocation_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.XML);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.XML, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.XPath = null;
            fld.LatXPath = null;
            fld.LonXPath = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }


        [TestMethod]
        public void XmlMessageField_MissingXPath_GeoLocation_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.XML);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.XML, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            msg.Fields.Add(fld);

            fld.XPath = null;
            fld.LatXPath = null;
            fld.LonXPath = null;

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
