// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 613691d7da2d6b449a0ac5be7a79f9f778e3697e26a8edce6cb1c067339b77fd
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
    public class MessageFieldTests : MessageFieldTestBase
    {
        [TestMethod]
        public void MessageField_Header_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Binary, DeviceAdmin.Models.ParameterTypes.Integer);
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
        }


        [TestMethod]
        public void MessageField_MissingSearchLocation_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Binary, DeviceAdmin.Models.ParameterTypes.Integer);
            fld.SearchLocation = null;
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }

        [TestMethod]
        public void MessageField_MissingStorageType_InValid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.Binary);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.Binary, DeviceAdmin.Models.ParameterTypes.Integer);
            fld.StorageType = null;
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }

        [TestMethod]
        public void MessageField_UnitSet_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.ValueWithUnit);
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);

        }

        [TestMethod]
        public void MessageField_MissingUnitSet_Invalid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.ValueWithUnit);
            fld.UnitSet = null;
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }

        [TestMethod]
        public void MessageField_StateSet_Valid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.State);
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
        }

        [TestMethod]
        public void MessageField_MissingStateSet_Invalid()
        {
            var msg = this.GetValidMessage(Models.MessageContentTypes.JSON);
            var fld = this.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.JSON, DeviceAdmin.Models.ParameterTypes.State);
            fld.StateSet = null;
            msg.Fields.Add(fld);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }
    }
}
