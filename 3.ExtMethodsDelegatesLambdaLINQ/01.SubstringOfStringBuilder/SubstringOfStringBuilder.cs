//Implement an extension method Substring(int index, int length) for the class StringBuilder that returns 
//new StringBuilder and has the same functionality as Substring in the class String.
namespace SubstringOfStringBuilder
{
    using System;
    using System.Text;

    static class SubstringOfStringBuilder
    {
        static StringBuilder SubString(this StringBuilder text, int index, int length)
        {
            if (index < 0 || length < 0)
            {
                throw new ArgumentOutOfRangeException("Start and/or length index cannot be less than zero!");
            }
            else if (index + length > text.Length)
            {
                throw new ArgumentOutOfRangeException("Index and length must refer to a location within the string!");
            }

            StringBuilder subString = new StringBuilder();

            for (int charIndex = index; charIndex < index + length; charIndex++)
            {
                subString.Append(text[charIndex]);
            }

            return subString;
        }

        static void Main()
        {
            StringBuilder longText = new StringBuilder("The little red riding hood.");
            Console.WriteLine(longText.SubString(7, 20));
            
            // This below is used for testing.
            string text = "The little red riding hood.";
            Console.WriteLine(text.Substring(7, 20));

        }
    }
}
