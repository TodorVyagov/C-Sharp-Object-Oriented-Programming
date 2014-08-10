// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
namespace PrintNumbersDivisableBy3And7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrintNumbersDivisableBy3And7
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 42, 27, 84, 7, 21, 46, 49, 63, 15 };
            Console.WriteLine("This is our list of integers:");
            Console.WriteLine(string.Join(" ", numbers));

            var divisableBy3and7 = numbers.FindAll(num => num % 3 == 0 && num % 7 == 0);
            Console.WriteLine("\nLambda:\nThese numbers are divisable by 3 and 7:");
            divisableBy3and7.ToList().ForEach(Console.WriteLine);

            var divisableBy3and7linq = from number in numbers
                                       where number % 3 == 0 && number % 7 == 0
                                       select number;
            Console.WriteLine("\nLINQ:\nThese numbers are divisable by 3 and 7:");
            divisableBy3and7linq.ToList().ForEach(Console.WriteLine);
        }
    }
}
