namespace Tako.Component.Extension.UnitTest.TestSource
{
    public static class Foo
    {
        private static int Func1(int a)
        {
            var result = a += 1;
            return result;
        }

        internal static int Func2(int a)
        {
            var result = a += 1;
            return result;
        }

        private static int Prop { get; set; }

        private static string Field1;

        private static string Func3<T>(T a)
        {
            return a.ToString();
        }
    }

    public static class Foo1
    {
        private static int Func1(int a)
        {
            var result = a += 1;
            return result;
        }

        internal static int Func2(int a)
        {
            var result = a += 1;
            return result;
        }

        private static int Prop { get; set; }

        private static string Field1;

        private static string Func3<T>(T a)
        {
            return a.ToString();
        }
    }
}