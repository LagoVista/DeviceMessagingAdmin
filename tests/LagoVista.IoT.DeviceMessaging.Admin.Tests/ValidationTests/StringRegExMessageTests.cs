// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 4b68eb3f7c6094d50af9167bbec5349a8eea1fe2656831064183873d63346d74
// IndexVersion: 2
// --- END CODE INDEX META ---
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    [TestClass]
    public class StringRegExMessageTests : MessageFieldTestBase
    {
        [TestMethod]
        public void StringRegExMessage_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);
            AssertValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringRegExMessage_WithFields_NonGeoLocation_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);

            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringRegEx, DeviceAdmin.Models.ParameterTypes.String);
            field.RegExGroupName = "crazy";
            message.Fields.Add(field);

            AssertValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringRegExMessage_WithFields_GeoLocation_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);

            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringRegEx, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            field.RegExGroupName = null;
            field.LatRegExGroupName = "crazy";
            field.LonRegExGroupName = "crazy";
            message.Fields.Add(field);

            AssertValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringRegExMessage_NoRegEx_Invalid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);
            message.RegEx = String.Empty;
            AssertInValid(Validator.Validate(message));
        }


        [TestMethod]
        public void StringRegExMessage_NoRegExWithField_NonGeoLocation_Invalid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);

            var fld = base.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringRegEx, DeviceAdmin.Models.ParameterTypes.String);
            fld.RegExGroupName = "";
            message.Fields.Add(fld);

            AssertInValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringRegExMessage_NoRegExWithField_GeoLocation_Invalid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringRegEx);

            var fld = base.CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringRegEx, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            fld.RegExGroupName = "";
            fld.LatRegExGroupName = null;
            fld.LonRegExGroupName = null;
            message.Fields.Add(fld);

            AssertInValid(Validator.Validate(message));
        }
    }
}
