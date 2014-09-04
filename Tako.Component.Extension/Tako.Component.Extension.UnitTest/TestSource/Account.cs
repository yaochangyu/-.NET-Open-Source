using System;
using System.Collections.Generic;

namespace Tako.Component.Extension.UnitTest.TestSource
{
    [Serializable]
    internal class Account : IAccount
    {
        public Account()
        {
            this.AccountLogs = new HashSet<AccountLog>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual ICollection<AccountLog> AccountLogs { get; set; }
    }
}