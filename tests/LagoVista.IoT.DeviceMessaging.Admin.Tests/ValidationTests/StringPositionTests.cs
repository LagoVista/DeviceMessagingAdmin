// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 7c1d56207acbc64b12ed8fce0a238052a118bdf329df55d2fc5c71cdb28c49ca
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

    public class StringPositionTests : MessageFieldTestBase
    {
        [TestMethod]
        public void StringPositionMessage_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringPosition);
            AssertValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringPositionMessage_WithFields_NonGeoLocation_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringPosition);

            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringPosition, DeviceAdmin.Models.ParameterTypes.String);
            message.Fields.Add(field);
            AssertValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringPositionMessage_WithFields_GeoLocation_Valid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringPosition);

            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringPosition, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            field.LatStartIndex = 12;
            field.LonStartIndex = 24;
            field.Length = 12;
            message.Fields.Add(field);

            AssertValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringPositionMessage_NoStartIndex_NonGeolocation_Invalid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringPosition);
            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringPosition, DeviceAdmin.Models.ParameterTypes.String);
            field.StartIndex = null;
            message.Fields.Add(field);
            AssertInValid(Validator.Validate(message));
        }

        [TestMethod]
        public void StringPositionMessage_NoStartIndex_Geolocation_Invalid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringPosition);
            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringPosition, DeviceAdmin.Models.ParameterTypes.GeoLocation);
            field.StartIndex = null;
            field.LatStartIndex = null;
            field.LonStartIndex = null;
            message.Fields.Add(field);
            AssertInValid(Validator.Validate(message));
        }


        [TestMethod]
        public void StringPositionMessage_NoLength__NonGeolocationInvalid()
        {
            var message = base.GetValidMessage(MessageContentTypes.StringPosition);
            var field = CreateValidMessageField(SearchLocations.Body, MessageContentTypes.StringPosition, DeviceAdmin.Models.ParameterTypes.String);
            field.Length = null;
            message.Fields.Add(field);
            AssertInValid(Validator.Validate(message));
        }
    }
}
