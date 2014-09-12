using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tako.Component.Extension.UnitTest.TestSource;

namespace Tako.Component.Extension.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod] public void 物件欄位轉移() {
        //    Account account = new Account() { Name = "yao", Age = 29 };
        //    Migration m = new Migration();
        //    var accountLog = m.Migrate(account, new AccountLog());
        //    Assert.AreEqual(account.Name, accountLog.Name);
        //    Assert.AreEqual(account.Age, accountLog.Age);
        //}

        [TestMethod]
        public void 物件欄位轉移1()
        {
            Account account = new Account() { Name = "yao", Age = 29 };
            Migration m = new Migration();
            var accountLog = m.Migrate(typeof(IAccount), account, new AccountLog());
            Assert.AreEqual(account.Name, accountLog.Name);
            Assert.AreEqual(account.Age, accountLog.Age);
        }

        [TestMethod]
        public void 物件欄位轉移_擴充方法()
        {
            Account account = new Account() { Name = "yao", Age = 29 };
            var accountLog = typeof(IAccount).Migrate(account, new AccountLog());

            Assert.AreEqual(account.Name, accountLog.Name);
            Assert.AreEqual(account.Age, accountLog.Age);
        }
    }
}