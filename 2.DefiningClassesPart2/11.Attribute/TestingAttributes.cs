namespace UsingAttribute
{
    using System;

    [Version(2, 0)]
    class TestingAttributes
    {
        static void Main()
        {
            Type type = typeof(TestingAttributes);
            object[] version = type.GetCustomAttributes(false);

            foreach (Version attribute in version)
            {
                Console.WriteLine("This clas is Version({0}.{1}).", attribute.Major, attribute.Minor);
            }
        }
    }
}
