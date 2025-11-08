// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b6851fdce731842de1ae236bb4c7b4acf209a3c062af8d7b00ab2d1987c81f1f
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class FileTypeValidationTests : MessageTestsBase
    {
        [TestMethod]
        public void FileTypeMessage_Valid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                ContentType = Core.Models.EntityHeader<Models.MessageContentTypes>.Create(Models.MessageContentTypes.Media),
                Key = "mykey",
                Id = "BC364E26A7D74094A600939AA5509048",
                Name = "My File",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.MLInference)
            });

            var result = Validator.Validate(msg);
            AssertValid(result);
        }

        [TestMethod]
        public void FileTypeMessage_WithoutField_Valid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

            var result = Validator.Validate(msg);
            AssertValid(result);
        }

        [TestMethod]
        public void FileTypeMessage_StorageTypeImage_MessageNotMediaType_InValid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.JSON);

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey",
                Id = "BC364E26A7D74094A600939AA5509048",
                Name = "My File",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Image)
            });

            var result = Validator.Validate(msg);
            AssertInValid(result, "JSON Path is required for content type JSON.", "Message Field Type is required for content type JSON.", "Image storage type is only valid when the message definition content type is media.");
        }

        [TestMethod]
        public void FileTypeMessage_StorageTypeImage_NotOnMessagebody_InValid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey",
                Id = "BC364E26A7D74094A600939AA5509048",
                Name = "My File",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Path),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Image)
            });

            var result = Validator.Validate(msg);
            AssertInValid(result, "Must provide Path Locator to extract field from URL Path", "Field types of image are only valid when associated with the body of the message.");
        }



        [TestMethod]
        public void FileTypeMessage_MultipleImagesOnFields_InValid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey",
                Id = "BC364E26A7D74094A600939AA5509048",
                Name = "My File",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Image)
            });

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey2",
                Id = "33364E26A7D74094A600939AA55090AA",
                Name = "My File 2",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Image)
            });

            var result = Validator.Validate(msg);
            AssertInValid(result, "For messages with content type media, you can only have one field associated with the body of the message, and that field must be a ML Inference that can be passed to a workflow.");
        }


        [TestMethod]
        public void FileTypeMessage_ImageFromBodyFieldFromPath_Valid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey",
                Id = "BC364E26A7D74094A600939AA5509048",
                Name = "My File",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.MLInference)
            });

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey2",
                Id = "33364E26A7D74094A600939AA55090AA",
                Name = "My File 2",
                QueryStringField = "/foo/fee",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.QueryString),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.String)
            });

            var result = Validator.Validate(msg);
            AssertValid(result);
        }

        [TestMethod]
        public void FileTypeMessage_Image_And_MultipleFieldTyeps_InValid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey",
                Id = "BC364E26A7D74094A600939AA5509048",
                Name = "My File",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.Image)
            });

            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey2",
                Id = "33364E26A7D74094A600939AA55090AA",
                Name = "Field Two",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.String)
            });

            var result = Validator.Validate(msg);
            AssertInValid(result, "For messages with content type media, you can only have one field associated with the body of the message, and that field must be a ML Inference that can be passed to a workflow.");
        }

        [TestMethod]
        public void FileTypeMessage_Image_And_DifferentTypeOnField_InValid()
        {
            var msg = GetValidMessage(Models.MessageContentTypes.Media);

          
            msg.Fields.Add(new Models.DeviceMessageDefinitionField()
            {
                Key = "mykey2",
                Id = "33364E26A7D74094A600939AA55090AA",
                Name = "Field Two",
                SearchLocation = Core.Models.EntityHeader<Models.SearchLocations>.Create(Models.SearchLocations.Body),
                StorageType = Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>.Create(DeviceAdmin.Models.ParameterTypes.String)
            });

            var result = Validator.Validate(msg);
            AssertInValid(result, "For messages with content type media, you can only have one field associated with the body of the message, and that field must be a ML Inference that can be passed to a workflow.");
        }


    }
}
