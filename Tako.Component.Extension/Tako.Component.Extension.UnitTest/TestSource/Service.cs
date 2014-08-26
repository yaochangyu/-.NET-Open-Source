namespace Tako.Component.Extension.UnitTest.TestSource
{
    public class Service
    {
        private int Func1(int a)
        {
            var result = a += 1;
            return result;
        }

        protected int Func2(int a)
        {
            var result = a += 1;
            return result;
        }

        internal int Func3(int a)
        {
            var result = a += 1;
            return result;
        }

        private static int Func4(int a)
        {
            var result = a += 1;
            return result;
        }

        private int Prop { get; set; }

        private static int Prop1 { get; set; }

        private string Field1;

        private string Func5<T>(T a)
        {
            return a.ToString();
        }
    }
}