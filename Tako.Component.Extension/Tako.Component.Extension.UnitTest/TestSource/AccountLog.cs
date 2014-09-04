using System;

namespace Tako.Component.Extension.UnitTest.TestSource
{
    [Serializable]
    internal class AccountLog : IAccount
    {
        public int AccountLogId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual Account CurrentAccount { get; set; }
    }
}