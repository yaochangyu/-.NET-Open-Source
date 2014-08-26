using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tako.Serialization.UnitTest
{
    [TestClass()]
    public class SerializationExtensionTest
    {
        [TestMethod()]
        public void Binary序列化_反序列化物件測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializeArray = expected.Serialize();
            var actual = serializeArray.Deserialize<User>(EnumSerializerType.Binary);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
        }

        [TestMethod()]
        public void Json序列化_反序列化物件測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializeArray = expected.Serialize(EnumSerializerType.JSON);
            var actual = serializeArray.Deserialize<User>(EnumSerializerType.JSON);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
        }

        [TestMethod()]
        public void Soap序列化_反序列化物件測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializeArray = expected.Serialize(EnumSerializerType.SOAP);
            var actual = serializeArray.Deserialize<User>(EnumSerializerType.SOAP);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
        }

        [TestMethod()]
        public void Xml序列化_反序列化物件測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializeArray = expected.Serialize(EnumSerializerType.XML);
            var actual = serializeArray.Deserialize<User>(EnumSerializerType.XML);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
        }
    }
}