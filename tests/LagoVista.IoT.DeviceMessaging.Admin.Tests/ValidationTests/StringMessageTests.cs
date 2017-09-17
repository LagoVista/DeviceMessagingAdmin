using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class StringMessageTests : MessageFieldTestBase
    {
        [TestMethod]
        public void StringMessage_NoRegEx()
        {
            var message = base.GetValidMessage(MessageContentTypes.String);
            message.RegEx = String.Empty;

            var result = Validator.Validate(message);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }


        [TestMethod]
        public void StringMessage_NoRegExWithField()
        {
            var message = base.GetValidMessage(MessageContentTypes.String);
            message.RegEx = String.Empty;

            var fld = base.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.String, DeviceAdmin.Models.ParameterTypes.String);
            fld.RegExGroupName = "somefield";

            var result = Validator.Validate(message);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }
    }
}
