// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 9bf3dcbdda1fbfdc8a14fdb9affe7d15daea92f764c2709b40395c8f749d650b
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using LagoVista.Core;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class BinaryMessageTests : MessageTestsBase
    {

        [TestMethod]
        public void BinaryMessage_MissingEncoding_Null()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.Endian = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_MissingEncoding_MissingId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.Endian.Id = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_MissingEncoding_EmptyStringId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.Endian.Id = String.Empty;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }
    
        [TestMethod]
        public void BinaryMessage_MissingStringParsingStrategy_Null()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.StringParsingStrategy = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_MissingStringParsingStrategy_MissingId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.StringParsingStrategy.Id = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_MissingStringParsingStrategy_EmptyStringId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.StringParsingStrategy.Id = String.Empty;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }


        [TestMethod]
        public void BinaryMessage_MissingBinaryParsingStrategy_Null()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.BinaryParsingStrategy = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_MissingBinaryParsingStrategy_MissingId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.BinaryParsingStrategy.Id = null;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_MissingBinaryParsingStrategy_EmptyStringId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.BinaryParsingStrategy.Id = String.Empty;
            var result = Validator.Validate(msg);
            ShowErrors(result);
            Assert.IsFalse(result.Successful);
            Assert.AreEqual(0, result.Warnings.Count);
        }

        [TestMethod]
        public void BinaryMessage_RegExNotApplicable_EmptyStringId()
        {
            var msg = GetValidMessage(MessageContentTypes.Binary);
            msg.RegEx = "soemthing not empty.";
            var result = Validator.Validate(msg);
            ShowErrors(result);
            ShowWarnings(result);
            Assert.AreEqual(1, result.Warnings.Count);
        }

    }
}
