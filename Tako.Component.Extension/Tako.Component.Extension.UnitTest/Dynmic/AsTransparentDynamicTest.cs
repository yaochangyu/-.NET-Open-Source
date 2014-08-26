using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Tako.Component.Extension.UnitTest.TestSource;

namespace Tako.Component.Extension.UnitTest
{
    [TestClass]
    public class AsTransparentDynamicTest
    {
        [TestMethod]
        public void 靜態類別_私有方法()
        {
            dynamic d = new StaticClassTransparentDynamicObject(typeof(Foo));
            var actual = d.Func1(1);
            Assert.AreEqual(2, actual);

            dynamic d1 = TransparentDynamicObjectExtensions.AsTransparentDynamicObject(typeof(Foo1));
            var actual1 = d1.Func1(2);
            Assert.AreEqual(3, actual1);
        }

        [TestMethod]
        public void 靜態類別_內部方法()
        {
            dynamic d = new StaticClassTransparentDynamicObject(typeof(Foo));
            var actual = d.Func2(1);
            Assert.AreEqual(2, actual);

            dynamic d1 = TransparentDynamicObjectExtensions.AsTransparentDynamicObject(typeof(Foo1));
            var actual1 = d1.Func2(2);
            Assert.AreEqual(3, actual1);
        }

        [TestMethod]
        public void 靜態類別_私有泛型方法()
        {
            dynamic d = new StaticClassTransparentDynamicObject(typeof(Foo));
            var actual = d.Func3<int>(1);
            Assert.AreEqual("1", actual);

            dynamic d1 = TransparentDynamicObjectExtensions.AsTransparentDynamicObject(typeof(Foo1));
            var actual1 = d1.Func3<Service>(new Service());
            Assert.AreEqual("Tako.Component.Extension.UnitTest.TestSource.Service", actual1);
        }

        [TestMethod]
        public void 靜態類別_私有屬性()
        {
            dynamic d = new StaticClassTransparentDynamicObject(typeof(Foo));
            d.Prop = 3;
            var actual = d.Prop;
            Assert.AreEqual(3, actual);

            dynamic d1 = TransparentDynamicObjectExtensions.AsTransparentDynamicObject(typeof(Foo1));
            d1.Prop = 3;
            var actual1 = d1.Prop;
            Assert.AreEqual(3, actual1);
        }

        [TestMethod]
        public void 靜態類別_私有欄位()
        {
            dynamic d = new StaticClassTransparentDynamicObject(typeof(Foo));
            d.Field1 = "3A";
            var actual = d.Field1;
            Assert.AreEqual("3A", actual);

            dynamic d1 = TransparentDynamicObjectExtensions.AsTransparentDynamicObject(typeof(Foo1));
            d1.Field1 = "我";
            var actual1 = d1.Field1;
            Assert.AreEqual("我", actual1);
        }

        [TestMethod]
        public void 私有方法()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var actual = d.Func1(1);
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void 保護方法()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var actual = d.Func2(1);
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void 內部方法()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var actual = d.Func3(1);
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void 私有靜態方法()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var actual = d.Func4(1);
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void 私有泛型方法()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            var actual = d.Func5<int>(5);
            Assert.AreEqual("5", actual);
        }

        [TestMethod]
        public void 私有屬性()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            d.Prop = 5;
            var actual = d.Prop;
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void 私有靜態屬性()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            d.Prop1 = 5;
            var actual = d.Prop1;
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void 私有靜態欄位()
        {
            dynamic d = new Service().AsTransparentDynamicObject();
            d.Field1 = "3A";
            var actual = d.Field1;
            Assert.AreEqual("3A", actual);
        }

        [TestMethod]
        public void 一般私有方法()
        {
            var assemblyType = typeof(Service);
            dynamic instance = Activator.CreateInstance(assemblyType);
            object[] para = new object[] { 1 };
            dynamic result = assemblyType.InvokeMember(
                      "Func1",
                      BindingFlags.InvokeMethod
                      | BindingFlags.Instance
                      | BindingFlags.NonPublic
                      | BindingFlags.Public,
                      null,
                      instance,
                      para);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void 一般泛型私有方法()
        {
            Service creator = new Service();
            int param = 5;
            var method = typeof(Service)
                .GetMethod("Func5", BindingFlags.InvokeMethod
                                             | BindingFlags.Instance
                                             | BindingFlags.NonPublic
                                             | BindingFlags.Public);
            method = method.MakeGenericMethod(param.GetType());
            var result = method.Invoke(creator, new object[] { param });
            Assert.AreEqual(param.ToString(), result);
        }
    }
}