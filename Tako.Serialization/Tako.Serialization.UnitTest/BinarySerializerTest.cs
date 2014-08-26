using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tako.Serialization.UnitTest
{
    /// <summary>
    ///This is a test class for BinarySerializerTest and is intended
    ///to contain all BinarySerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BinarySerializerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion Additional test attributes

        private SerializerFactory m_Factory = null;
        private ISerializer m_Serializer = null;

        public BinarySerializerTest()
        {
            this.m_Factory = new SerializerFactory();
            this.m_Serializer = m_Factory.CreateSerializer(EnumSerializerType.Binary);
        }

        [TestMethod()]
        public void 序列化_反序列化檔案測試()
        {
            var file = "user.bin";
            var expected = new User() { Name = "小章魚", Age = 19 };
            var serializer = new SerializerFactory().CreateSerializer(EnumSerializerType.Binary);
            var serializeStream = serializer.Serialize(expected, file);
            Assert.IsTrue(serializeStream.Length > 0);

            var deserializer = new SerializerFactory().CreateSerializer(EnumSerializerType.Binary);
            var user = deserializer.Deserialize<User>(file);
            Assert.AreEqual(expected.Name, user.Name);
            Assert.AreEqual(expected.Age, user.Age);
        }
    }
}