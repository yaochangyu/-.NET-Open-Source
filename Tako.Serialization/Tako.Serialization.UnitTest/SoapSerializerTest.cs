using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tako.Serialization.UnitTest
{
    /// <summary>
    ///This is a test class for BinarySerializerTest and is intended
    ///to contain all BinarySerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SoapSerializerTest
    {
        [TestMethod()]
        public void 序列化_反序列化檔案測試()
        {
            var file = "user.soap";
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializer = new SerializerFactory().CreateSerializer(EnumSerializerType.SOAP);
            var serializeStream = serializer.Serialize(expected, file);
            Assert.IsTrue(serializeStream.Length > 0);

            var deserializer = new SerializerFactory().CreateSerializer(EnumSerializerType.SOAP);
            var user = deserializer.Deserialize<User>(file);
            Assert.AreEqual(expected.Name, user.Name);
            Assert.AreEqual(expected.Age, user.Age);
        }
    }
}