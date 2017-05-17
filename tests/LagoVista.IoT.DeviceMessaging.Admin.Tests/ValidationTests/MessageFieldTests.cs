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
        public void MessageField_MissingStorageLocation_InValid()
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

    }
}
