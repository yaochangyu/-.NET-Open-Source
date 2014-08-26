using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tako.Component.Extension.UnitTest.TestSource;

namespace Tako.Component.Extension.UnitTest
{
    [TestClass]
    public class AsTransparentDynamicExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void 設定不存在的屬性()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            d.MissMember = "MissMember";
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void 取得不存在的屬性()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var MissMember = d.MissMember;
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void 調用不存在的方法()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var MissMember = d.MissMember();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void 初始化非靜態類別()
        {
            dynamic d = new StaticClassTransparentDynamicObject(typeof(Service));
        }
    }
}