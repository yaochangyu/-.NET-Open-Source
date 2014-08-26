using System;

namespace Tako.Serialization.UnitTest
{
    [Serializable]
    public class User
    {
        private string _name = "小章魚";
        private int _age = 19;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}