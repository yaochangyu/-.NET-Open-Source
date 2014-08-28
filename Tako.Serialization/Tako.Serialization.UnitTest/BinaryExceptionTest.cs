using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tako.Serialization.UnitTest
{
    [TestClass]
    public class BinaryExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void 序列化物件例外測試()
        {
            User user = null;
            user.Serialize();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void 反序列化物件例外測試()
        {
            byte[] user = null;
            user.Deserialize<User>();
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void 序列化物件到檔案例外測試1()
        {
            User user = null;
            BinarySerializer serializer = new BinarySerializer();
            serializer.Serialize(user, "");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void 序列化物件到檔案例外測試2()
        {
            User user = new User();
            BinarySerializer serializer = new BinarySerializer();
            serializer.Serialize(user, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void 序列化物件到檔案例外測試3()
        {
            User user = null;
            Stream outputStream = null;
            BinarySerializer serializer = new BinarySerializer();
            serializer.Serialize(user, outputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void 序列化物件到檔案例外測試4()
        {
            User user = new User();
            Stream outputStream = null;
            BinarySerializer serializer = new BinarySerializer();
            serializer.Serialize(user, outputStream);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void 反序列化檔案到物件例外測試1()
        {
            BinarySerializer serializer = new BinarySerializer();
            serializer.Deserialize<User>("");
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void 反序列化檔案到物件例外測試2()
        {
            Stream inputStream = null;
            BinarySerializer serializer = new BinarySerializer();
            serializer.Deserialize<User>(inputStream);
        }
    }
}