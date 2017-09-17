using LagoVista.Core.Models;
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
    public class MessageIdDeviceIdParserTests : MessageFieldTestBase
    {

        [TestMethod]
        public void MessageIdDeviceId_InValid_NoContentType()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body);
            fld.ContentType = null;
            var result = fld.Validate();
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_NoSearchLocation()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body);
            fld.SearchLocation = null;
            var result = fld.Validate();
            AssertInValid(fld.Validate());
        }


        [TestMethod]
        public void MessageIdDeviceId_Valid_JSON()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.JSON);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.JSON);
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_JSON()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.JSON);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.JSON);
            fld.JsonPath = null;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_Valid_Delimiter()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.Delimited);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.Delimited);
            fld.Delimiter = ",";
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_Delimiter_NoDelimiter()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.Delimited);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.Delimited);
            fld.Delimiter = null;
            fld.DelimitedIndex = 3;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_Delimiter_NoIndex()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.Delimited);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.Delimited);
            fld.Delimiter = ",";
            fld.DelimitedIndex = null;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_Valid_XPath()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.XML);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.XML);
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_XPath_NoXPath()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Body, Models.MessageContentTypes.XML);
            fld.ContentType = EntityHeader<MessageContentTypes>.Create(MessageContentTypes.XML);
            fld.XPath = null;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_Valid_QueryString()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.QueryString);
            fld.QueryStringField = "field";
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_QueryString_NoQueryString()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.QueryString);
            fld.QueryStringField = null;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_Valid_Path()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Path);
            fld.PathLocator = "field";
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_Path_NoPath()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Path);
            fld.PathLocator = null;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_Valid_Header()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Header);
            fld.HeaderName = "someheader";
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_Header_NoHeader()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Header);
            fld.HeaderName = null;
            AssertInValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_Valid_Topic()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Topic);
            fld.TopicRegEx = "^somecrazyregex$";
            AssertValid(fld.Validate());
        }

        [TestMethod]
        public void MessageIdDeviceId_InValid_Topic_NoTopic()
        {
            var fld = CreateValidMessageField(Models.SearchLocations.Topic);
            fld.TopicRegEx = null;
            AssertInValid(fld.Validate());
        }

    }
}
