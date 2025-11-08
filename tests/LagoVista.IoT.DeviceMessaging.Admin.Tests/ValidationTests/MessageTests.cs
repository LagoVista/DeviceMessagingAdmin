// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 89654069cfe330503fa7d29b16f80553e8b92360a4a71929fd80c97297bce30d
// IndexVersion: 2
// --- END CODE INDEX META ---
using System;
using System.Linq;
using LagoVista.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class MessageTests : MessageTestsBase
    {
        [TestMethod]
        public void MessageDefintiion_Binary_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        /*
        [TestMethod]
        public void MessageDefinition_Custom_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.Custom);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }*/

        [TestMethod]
        public void MessageDefinition_Delimited_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.Delimited);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void MessageDefinition_JSON_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.JSON);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void MessageDefinition_StringRegEx_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.StringRegEx);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void MessageDefinition_StringPosition_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.StringPosition);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }



        [TestMethod]
        public void MessageDefinition_Xml_Valid()
        {
            var msg = GetValidMessage(MessageContentTypes.XML);
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsTrue(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void MessageDefinition_MissingMessageId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.MessageId = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void MessageDefinition_NullContentType()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.ContentType = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void MessageDefinition_MissingContentType()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.ContentType = new Core.Models.EntityHeader<MessageContentTypes>() { Id = "" };
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }
    }
}
