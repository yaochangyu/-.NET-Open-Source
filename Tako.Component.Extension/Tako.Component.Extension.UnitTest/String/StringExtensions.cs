using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tako.Component.Extension;

namespace TestProject1
{
    /// <summary>
    ///This is a test class for NewSyntaxTest and is intended
    ///to contain all NewSyntaxTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringExtensionsTest
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

        [TestMethod()]
        public void IsAllNumberTest_True()
        {
            string data = "123456";
            bool expected = true;
            bool actual;
            actual = data.IsAllNumber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsAllNumberTest_False()
        {
            string data = "123a456";
            bool expected = false;
            bool actual;
            actual = data.IsAllNumber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNumericTest_True()
        {
            string data = "123";
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = data.IsNumeric();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNumericTest_False()
        {
            string data = "123a";
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = data.IsNumeric();
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod()]
        //public void IsValidEmailAddressTest()
        //{
        //    string data = "yao.i@gamil.co";
        //    bool expected = true;
        //    bool actual;
        //    actual = data.IsEmail();
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod()]
        //public void EncryptTest()
        //{
        //    string data = "我跟你说yaochang.yu";
        //    string expected = "rFsNDzK3MclJBbduj8p+C1VtytPTCJYtZg5L4WdG8nc=";
        //    string actual;
        //    actual = data.Encrypt();
        //    Assert.AreEqual(expected, actual);
        //}

        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\非法字串解密測試.xml", "Item", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\非法字串解密測試.xml"), TestMethod()]
        //public void 非法字串解密()
        //{
        //    string data = TestContext.DataRow["Enecrypt"].ToString();
        //    string expected = TestContext.DataRow["Decrypt"].ToString();

        //    try
        //    {
        //        string actual = data.Decrypt();
        //        Assert.AreNotEqual(expected, actual);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreNotEqual(ex, null);
        //    }
        //}

        [TestMethod()]
        public void LeftTest()
        {
            string data = "我跟你说yaochang.yu妳不要跟別人說唷ya";
            string expected = "我跟你说y";
            string actual;
            actual = data.Left(5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RightTest()
        {
            string data = "我跟你说yaochang.yu妳不要跟別人說唷ya";
            string expected = "別人說唷ya";
            string actual;
            actual = data.Right(6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest()
        {
            int i = "123".Parse<int>();
            Assert.AreEqual(i, 123);
            DateTime dt = new DateTime(2008, 01, 12);
            DateTime d = "01/12/2008".Parse<DateTime>();
            Assert.AreEqual(d, dt);
        }

        [TestMethod()]
        public void IsGuidTest()
        {
            string value = Guid.NewGuid().ToString();
            bool expected = true;
            bool actual;
            actual = value.IsGuid();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToTitleCaseTest()
        {
            string value = "i lOve mycOuntRy";
            string expected = "I Love Mycountry";
            string actual;
            actual = value.ToTitleCase();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitTest_Char()
        {
            string value = "  12,  123,  4123  ";
            int[] expected = new int[] { 12, 123, 4123 };
            IEnumerable<int> actual = value.Split<int>(',');
            int index = 0;
            foreach (var item in actual)
            {
                Assert.AreEqual(expected[index], item);
                index++;
            }
        }

        [TestMethod()]
        public void SplitTest_String()
        {
            string value = "12,123,4123  ";
            int[] expected = new int[] { 12, 123, 4123 };
            IEnumerable<int> actual = value.Split<int>(",");
            int index = 0;
            foreach (var item in actual)
            {
                Assert.AreEqual(expected[index], item);
                index++;
            }
        }

        [TestMethod()]
        public void MaskTest()
        {
            string value = "123-45-6789";
            int Exposed = 4; // TODO: Initialize to an appropriate value
            string expected = "*******6789";
            string actual;
            actual = value.Mask(Exposed);
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod()]
        //public void SaveTest()
        //{
        //    string value = "111";
        //    string FullFileName = @"SaveTest.txt";
        //    value.Save(FullFileName);
        //    Assert.AreEqual(File.Exists(FullFileName), true);
        //    string expected = value;
        //    string actual = FullFileName.Load();
        //    if (expected == actual)
        //    {
        //    }
        //    Assert.AreEqual("111", actual);
        //}

        //        [TestMethod()]
        //        [DeploymentItem("LoadTest.txt")]
        //        public void LoadTest()
        //        {
        //            string expected = @"﻿112
        //123
        //789
        //999
        //我跟你說你不要跟別人說
        //abcdned
        //1234qwer!@#$%";
        //            string FullFileName = "LoadTest.txt";

        //            string actual = FullFileName.Load();
        //            Assert.AreEqual(expected, actual);
        //        }

        //[TestMethod()]
        //[DeploymentItem("LoadTest.txt")]
        //public void LoadLineTest()
        //{
        //    string expected = @"123";
        //    string FullFileName = "LoadTest.txt";
        //    string actual = FullFileName.LoadLine(2);

        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod()]
        public void TruncateTest()
        {
            string value = @"下午最新消息，新北市五股一家工廠，一名30多歲男子疑似遭反鎖在冷凍庫內，被活活凍死，目前警方已抵達現場展開調查，釐清到底是人為反鎖，還是意外受困。
意外發生在新北市五股一家製藥工廠，廠方因為要冰存藥品，因此租用冷凍櫃，沒想到發生凍死人意外，據了解，這名死者姓潘、剛新婚，才30多歲，意外發生後，死者父親及太太來到現場都相當難過。
而死者妻子表示，她先生平常辦公地點並不在五股工業區，不解今天為什麼會到這裡來，而警方目前已經到場調查，是人為刻意反鎖還是意外受困，有待進一步釐清。 ";
            int MaxLength = 6; // TODO: Initialize to an appropriate value
            string expected = "下午最...";
            string actual;
            actual = value.Truncate(MaxLength);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("合法IP.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\合法IP.xml", "IP", DataAccessMethod.Sequential)]
        public void 合法Ip測試()
        {
            string Value = TestContext.DataRow[0].ToString();
            bool expected = true;
            bool actual;
            actual = Value.IsIpAddress();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("非法IP.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\非法IP.xml", "IP", DataAccessMethod.Sequential)]
        public void 非法Ip測試()
        {
            string Value = TestContext.DataRow[0].ToString();
            bool expected = false;
            bool actual;
            actual = Value.IsIpAddress();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeepCloneTest()
        {
            Person expected = new Person()
            {
                Age = 18,
                Address = "地球村",
                Name = new Name("余", "小章"),
                Phones = new List<CellPhone>()
                {
                    new CellPhone()
                    {
                        CountryCode="+886",
                        Phone="12312121212",
                    },
                    new CellPhone()
                    {
                        CountryCode="+886",
                        Phone="1232434",
                    },
                    new CellPhone()
                    {
                        CountryCode="+886",
                        Phone="34535123243124",
                    }
                }
            };

            Person actual = expected.Clone();
            actual.Phones[0].Phone = "";
            Assert.AreNotEqual(expected.Phones[0].Phone, actual.Phones[0].Phone);
        }
    }

    [Serializable]
    public class Person
    {
        public int Age { get; set; }

        public string Address { get; set; }

        public Name Name { get; set; }

        private List<CellPhone> _Phones = new List<CellPhone>();

        public List<CellPhone> Phones
        {
            get { return this._Phones; }
            set { this._Phones = value; }
        }

        //public Person DeepClone()
        //{
        //    using (MemoryStream memory = new MemoryStream())
        //    {
        //        XmlSerializer xs = new XmlSerializer(GetType());
        //        xs.Serialize(memory, this);
        //        memory.Seek(0, SeekOrigin.Begin);
        //        return xs.Deserialize(memory) as Person;
        //    }
        //}

        //public Person DeepClone()
        //{
        //    using (MemoryStream memory = new MemoryStream())
        //    {
        //                       XmlSerializer xs = new XmlSerializer(GetType());
        //        xs.Serialize(memory, this);
        //        memory.Seek(0, SeekOrigin.Begin);
        //        return xs.Deserialize(memory) as Person;
        //    }
        //}

        //public Person DeepClone()
        //{
        //    Person person = new Person();

        //    person.Age = this.Age;
        //    person.Address = this.Address;
        //    person.Name = this.Name;

        //    List<CellPhone> phones = new List<CellPhone>();
        //    foreach (var item in this.Phones)
        //    {
        //        phones.Add(item);
        //    }

        //    return person;
        //}
    }

    [Serializable]
    public class Name
    {
        public string FristName { get; set; }

        public string LastName { get; set; }

        public Name(string frisName, string lastName)
        {
            this.FristName = frisName;
            this.LastName = lastName;
        }
    }

    [Serializable]
    public class CellPhone
    {
        public string CountryCode { get; set; }

        public string Phone { get; set; }

        private string _FullCellPhone;

        public string FullCellPhone
        {
            get
            {
                _FullCellPhone = CountryCode + Phone;
                return _FullCellPhone;
            }
            internal set
            {
                _FullCellPhone = value;
            }
        }
    }
}