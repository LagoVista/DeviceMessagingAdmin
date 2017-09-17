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
        public void StringMessage_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);
            message.RegEx = "^{somecrazyregex}$"; /* Nope, no reg ex on reg ex...maybe someday */

            var result = Validator.Validate(message);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
        }

        [TestMethod]
        public void StringMessage_WithFields_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);
            message.RegEx = "^{some{crazy}razyregex}$"; /* Nope, no reg ex on reg ex...maybe someday */

            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringRegEx, DeviceAdmin.Models.ParameterTypes.String);
            field.RegExGroupName = "crazy";
            message.Fields.Add(field);

            var result = Validator.Validate(message);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
        }



        [TestMethod]
        public void StringMessage_NoRegEx()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);
            message.RegEx = String.Empty;

            var result = Validator.Validate(message);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }


        [TestMethod]
        public void StringMessage_NoRegExWithField()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);
            message.RegEx = String.Empty;

            var fld = base.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringRegEx, DeviceAdmin.Models.ParameterTypes.String);
            fld.RegExGroupName = "somefield";

            var result = Validator.Validate(message);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
        }
    }
}
