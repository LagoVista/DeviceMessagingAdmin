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
    public class JsonMessageFieldTests : MessageFieldTestBase
    {
        [TestMethod]
        public void JsonMessageFieldNonGeoLocation_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }


        [TestMethod]
        public void JsonMessageFieldGeoLocation_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            msg.Fields.Add(fld);

            fld.JsonPath = null;
            fld.LatJsonPath = "this.lat";
            fld.LonJsonPath = "this.lon";

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void JsonMessageField_MissingJSONPathNonGeoLocation_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);

            fld.JsonPath = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void JsonMessageField_MissingJSONPathGeoLocation_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            msg.Fields.Add(fld);

            fld.JsonPath = null;
            fld.LatJsonPath = null;
            fld.LonJsonPath = null;

            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void JsondMessageField_ParsedStringField_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.Integer);
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
