//Write a program to return the string with maximum length from an array of strings. Use LINQ.
namespace LongestStringFromArrOfStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestStringFromArrOfStrings
    {
        static void Main()
        {
            List<string> listOfStrings = new List<string>() { "one", "three", "seventeen", "eighty", "eighteen", "twenty five", "zero", "sixteen" };
            int longest = listOfStrings.Max(st => st.Length); //finding the longest string
            string longersString = listOfStrings.Single(st => st.Length == longest); //searching for the string with length that we already found
            Console.WriteLine("Longest string from list:\n{0}\nis '{1}' with {2} characters.", string.Join(", ", listOfStrings), longersString, longest);
        }
    }
}
