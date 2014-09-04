using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tako.Component.Extension.UnitTest.TestSource;

namespace Tako.Component.Extension.UnitTest.Object
{
    [TestClass]
    public class GenericObjectExtensionsUnitTest
    {
        [TestMethod]
        public void 深複製()
        {
            Account source = new Account() { Name = "余小章", Age = 18 };
            Account target = source.Clone();
            target.Age = 20;
            target.Name = "yao";

            Assert.AreNotEqual(source.Name, target.Name);
            Assert.AreNotEqual(source.Age, target.Age);
        }

        [TestMethod]
        public void 沒有深複製()
        {
            Account source = new Account() { Name = "余小章", Age = 18 };
            Account target = source;
            target.Age = 20;
            target.Name = "yao";

            Assert.AreEqual(source.Name, target.Name);
            Assert.AreEqual(source.Age, target.Age);
        }
    }
}