using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NetApi;

namespace UniTest.NetApi
{
    [TestClass]
    public class JSONtests
    {
        string text = "Text for serialize; текст: сериализация";

        int int_val = -123;

        Exception exception = new Exception("JSON TEXT");

        int[] int_arr_vall = new int[] { 1, 2, 3, 0, -5 };

        [TestMethod]
        public void Create()
        {
            JSON json = new JSON();
        }

        [TestMethod]
        public void SerializeText()
        {
            JSON json = new JSON();
            json.Serialize(text);
        }

        [TestMethod]
        public void SerializeInt()
        {
            JSON json = new JSON();
            json.Serialize(int_val);
        }

        [TestMethod]
        public void SerializeIntArr()
        {
            JSON json = new JSON();
            json.Serialize(int_arr_vall);
        }

        [TestMethod]
        public void SerializeExcept()
        {
            JSON json = new JSON();
            json.Serialize(exception);
        }

        [TestMethod]
        public void SerializeSelfObj()
        {
            JSON json = new JSON();
            json.Serialize(json);
        }

        [TestMethod]
        public void DeSerializeTypeInt()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(int_val);
            object int_value = json.Deserialize(result);
            int type = 123;
            Assert.AreEqual(type.GetType(), int_value.GetType());
        }

        [TestMethod]
        public void DeSerializeValyeInt()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(int_val);
            object int_value = json.Deserialize(result);
            Assert.AreEqual(int_val, (int)int_value);
        }

        [TestMethod]
        public void DeSerializeTypeString()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(text);
            object string_value = json.Deserialize(result);
            Assert.AreEqual(text.GetType(), string_value.GetType());
        }

        [TestMethod]
        public void DeSerializeValueString()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(text);
            object string_value = json.Deserialize(result);
            Assert.AreEqual(text, (string)string_value);
        }

        [TestMethod]
        public void DeSerializeTypeException()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(exception);
            object exception_value = json.Deserialize(result);
            Assert.AreEqual(exception.GetType(), exception_value.GetType());
        }

        [TestMethod]
        public void DeSerializeValueException()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(exception);
            Exception exception_value = (Exception)json.Deserialize(result);
            Assert.AreEqual(exception.Message, exception_value.Message);
        }

        [TestMethod]
        public void DeSerializeTypeIntArr()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(int_arr_vall);
            int[] arr = (Int32[])json.Deserialize(result);
            Assert.AreEqual(int_arr_vall.ToString(), arr.ToString());
        }

        [TestMethod]
        public void DeSerializeValueIntArr()
        {
            JSON json = new JSON();
            byte[] result = json.Serialize(int_arr_vall);
            int[] arr = (Int32[])json.Deserialize(result);
            for(int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(int_arr_vall[i], arr[i]);
            }
        }
    }
}
