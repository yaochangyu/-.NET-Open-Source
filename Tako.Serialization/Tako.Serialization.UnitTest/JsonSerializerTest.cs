using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tako.Serialization.UnitTest
{
    /// <summary>
    ///This is a test class for JsonSerializerTest and is intended
    ///to contain all JsonSerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JsonSerializerTest
    {
        [TestMethod()]
        public void 序列化_反序列化檔案測試()
        {
            var file = "user.json";
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializer = new SerializerFactory().CreateSerializer(EnumSerializerType.JSON);
            var serializeStream = serializer.Serialize(expected, file);
            Assert.IsTrue(serializeStream.Length > 0);

            var deserializer = new SerializerFactory().CreateSerializer(EnumSerializerType.JSON);
            var user = deserializer.Deserialize<User>(file);
            Assert.AreEqual(expected.Name, user.Name);
            Assert.AreEqual(expected.Age, user.Age);
        }
    }
}