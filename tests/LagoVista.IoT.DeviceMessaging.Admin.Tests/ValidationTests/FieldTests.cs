using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void ShouldNotValidateIfContentTypeIsNull()
        {
            var message = new DeviceMessageDefinition();
            message.RegEx = String.Empty;

            var result = Validator.Validate(message);
            Assert.IsFalse(result.Successful);
        }


        [TestMethod]
        public void ShouldNotValidateIfFieldAsRegExGroupNameButMessageHasNoRegEx()
        {
            var message = new DeviceMessageDefinition();
            message.ContentType = new Core.Models.EntityHeader<MessageContentTypes>() { Id = "string" };
            message.RegEx = String.Empty;

            message.Fields.Add(new DeviceMessageDefinitionField()
            {
                RegExGroupName = "somefield"
            });

            var result = new ValidationResult();
            message.Validate(result);
            Assert.IsFalse(result.Successful);
        }
    }
}
