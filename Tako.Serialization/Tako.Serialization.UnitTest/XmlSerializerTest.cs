using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tako.Serialization.UnitTest
{
    /// <summary>
    ///This is a test class for XmlSerializerTest and is intended
    ///to contain all XmlSerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlSerializerTest
    {
        [TestMethod()]
        public void 序列化_反序列化檔案測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializer = new SerializerFactory().CreateSerializer(EnumSerializerType.XML);
            var serializeStream = serializer.Serialize(expected, "user.xml");
            Assert.IsTrue(serializeStream.Length > 0);

            var deserializer = new SerializerFactory().CreateSerializer(EnumSerializerType.XML);
            var user = deserializer.Deserialize<User>(serializeStream);
            Assert.AreEqual(expected.Name, user.Name);
            Assert.AreEqual(expected.Age, user.Age);
        }
    }
}