using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class FieldTests : MessageTestsBase
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

            var result = Validator.Validate(message);
            Assert.IsFalse(result.Successful);
        }
    }
}
