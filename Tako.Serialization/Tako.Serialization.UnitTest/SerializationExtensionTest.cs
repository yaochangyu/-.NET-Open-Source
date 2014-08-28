using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        [TestMethod()]
        public void Xml序列化_反序列化檔案測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var outputFileName = "output.xml";
            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                expected.Serialize(outputStream, EnumSerializerType.XML);
            }
            using (var inputStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
            {
                var actual = inputStream.Deserialize<User>(EnumSerializerType.XML);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Age, actual.Age);
            }
        }

        [TestMethod()]
        public void binaray序列化_反序列化檔案測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var outputFileName = "output.bin";
            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                expected.Serialize(outputStream);
            }
            using (var inputStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
            {
                var actual = inputStream.Deserialize<User>();
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Age, actual.Age);
            }
        }

        [TestMethod()]
        public void Soap序列化_反序列化檔案測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var outputFileName = "output.soap";
            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                expected.Serialize(outputStream, EnumSerializerType.SOAP);
            }
            using (var inputStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
            {
                var actual = inputStream.Deserialize<User>(EnumSerializerType.SOAP);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Age, actual.Age);
            }
        }

        [TestMethod()]
        public void Json序列化_反序列化檔案測試()
        {
            var expected = new User() { Name = "小章魚", Age = 19 };
            var outputFileName = "output.json";
            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                expected.Serialize(outputStream, EnumSerializerType.JSON);
            }
            using (var inputStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
            {
                var actual = inputStream.Deserialize<User>(EnumSerializerType.JSON);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Age, actual.Age);
            }
        }
    }
}