// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ee050b12bf8e708edc5239b7faa187025b9d534fb9e31be742b23b3cdc460229
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.MessgeGeneration
{
    [TestClass]
    public class CreateFromJSONTests
    {
        private void ShowResults(List<DeviceMessageDefinitionField> fields)
        {
            foreach (var msgField in fields)
            {
                Console.WriteLine($"{msgField.Name}, {msgField.Key}, {msgField.JsonPath}, {msgField.ParsedStringFieldType.Value}, {msgField.StorageType.Value}");
            }
        }

        [TestMethod]
        public void CreateFIeldsFromSimpleJSON()
        {
            var json = @"
{
    'field1':'one',
    'field2': 1,
    'field3': 1.7,
    'field4': true,
}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            ShowResults(response.Result);
        }

        [TestMethod]
        public void CreateSimpleFieldName()
        {
            var json = "{'field1':5}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("Field1", field.Name);
        }

        [TestMethod]
        public void CreateSimpleFieldKey()
        {
            var json = "{'field1':5}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("field1", field.Key);
        }

        [TestMethod]
        public void CreateSimpleFieldJSONPath()
        {
            var json = "{'field1':5}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("field1", field.JsonPath);
        }

        [TestMethod]
        public void CreateSingleNestedFieldName()
        {
            var json = "{'parent':{'field1':5}}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("Parent Field1", field.Name);
        }

        [TestMethod]
        public void CreateSingleNestedFieldKey()
        {
            var json = "{'parent':{'field1':5}}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("parentfield1", field.Key);
        }

        [TestMethod]
        public void CreateSingleNestedFieldJSONPath()
        {
            var json = "{'parent':{'field1':5}}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("parent.field1", field.JsonPath);
        }

        [TestMethod]
        public void CreateDoubleNestedFieldName()
        {
            var json = "{'parent':{'child1':{'field1':5}}}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("Parent Child1 Field1", field.Name);
        }

        [TestMethod]
        public void CreateDoubleNestedFieldKey()
        {
            var json = "{'parent':{'child1':{'field1':5}}}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("parentchild1field1", field.Key);
        }

        [TestMethod]
        public void CreateDoubleNestedFieldJSONPath()
        {
            var json = "{'parent':{'child1':{'field1':5}}}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual("parent.child1.field1", field.JsonPath);
        }

        [TestMethod]
        public void CreateIntField()
        {
            var json = "{'field1':1}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.Integer, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.WholeNumber, field.ParsedStringFieldType.Value);
        }

        [TestMethod]
        public void CreateFloatField()
        {
            var json = "{'field1':1.1}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.Decimal, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.RealNumber, field.ParsedStringFieldType.Value);
        }

        [TestMethod]
        public void CreateSstringField()
        {
            var json = "{'field1':'1.1'}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.String, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.String, field.ParsedStringFieldType.Value);
        }

        [TestMethod]
        public void CreateDateField()
        {
            var json = "{'field1':'2021-03-15T08:12:23.444Z'}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.DateTime, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.String, field.ParsedStringFieldType.Value);
        }

        [TestMethod]
        public void CreateTrueField()
        {
            var json = "{'field1':true}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.TrueFalse, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.String, field.ParsedStringFieldType.Value);
        }

        [TestMethod]
        public void CreateFalseField()
        {
            var json = "{'field1':false}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.TrueFalse, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.String, field.ParsedStringFieldType.Value);
        }

        [TestMethod]
        public void CreateFIeldsFromNestedJSON()
        {
            var json = @"
{
    'field1':'one',
    'field2': 1,
    'field3': 1.7,
    'date1': '2021-03-15T08:12:23.444Z',
    'field4': true,
    'children': {
        'test1':1,
        'test2':3,
        'test3':'hello',
        'veryNested': {
            'firstName': 'Kevio',
            'lastName': 'Wolf'
        }
    }
}";

            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            ShowResults(response.Result);
        }

        [TestMethod]
        public void CreateFromIntArray()
        {
            var json = @"
{
    'errorCodes':[1,2,3,4,5]
}";
            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.IntArray, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.WholeNumberArray, field.ParsedStringFieldType.Value);
            ShowResults(response.Result);
        }

        [TestMethod]
        public void CreateFromWFloatArray()
        {
            var json = @"
{
    'errorCodes':[1,2,3.5,4,5]
}";
            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.DecimalArray, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.RealNumberArray, field.ParsedStringFieldType.Value);
            ShowResults(response.Result);
        }


        [TestMethod]
        public void CreateFromWStringArray()
        {
            var json = @"
{
    'errorCodes':[1,2,3.5,'test',5]
}";
            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsTrue(response.Successful);
            var field = response.Result[0];
            Assert.AreEqual(ParameterTypes.StringArray, field.StorageType.Value);
            Assert.AreEqual(ParseStringValueType.StringArray, field.ParsedStringFieldType.Value);
            ShowResults(response.Result);
        }

        [TestMethod]
        public void InvalidJSON()
        {
            var json = @"
{
    'field1':'one'
    'field2': 1, 
}";
            var response = DeviceMessageDefinitionField.CreateFieldsFromJSON(json);
            Assert.IsFalse(response.Successful);
            Console.WriteLine(response.Errors[0].Message);
        }
    }
}
