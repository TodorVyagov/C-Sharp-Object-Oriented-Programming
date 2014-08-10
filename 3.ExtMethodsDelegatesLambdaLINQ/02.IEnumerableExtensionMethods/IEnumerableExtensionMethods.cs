//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    static class IEnumerableExtensionMethods
    {
        public static T Sum<T>(this IEnumerable<T> collection) where T : IComparable
        {
            dynamic sum = 0;

            foreach (var num in collection)
            {
                sum += num;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection) where T : IComparable
        {
            dynamic product = 1;

            foreach (var num in collection)
            {
                product *= num;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T min = default(T);
            bool isFirst = true;

            foreach (var item in collection)
            {
                if (isFirst)
                {
                    min = item;
                    isFirst = false;
                }
                else
                {
                    if (min.CompareTo(item) > 0)
                    {
                        min = item;
                    }
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T max = default(T);
            bool isFirst = true;

            foreach (var item in collection)
            {
                if (isFirst)
                {
                    max = item;
                    isFirst = false;
                }
                else
                {
                    if (max.CompareTo(item) < 0)
                    {
                        max = item;
                    }
                }
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> collection) where T : IComparable
        {
            dynamic sum = 0;
            int counter = 0;

            foreach (var num in collection)
            {
                sum += num;
                counter++;
            }

            return sum/counter;
        }

        static void Main()
        {
            IEnumerable<int> list = new List<int>() { 16, -4, 2, -25, 17, 2, 5, 3, 10 };

            Console.WriteLine(string.Join(" ", list));

            Console.WriteLine("Max = " + list.Max());
            Console.WriteLine("Min = " + list.Min() + "\n");

            list = new List<int>() { 2, 5, 3, 10 }; //removed some of the numbers for better visualisation

            Console.WriteLine(string.Join(" ", list));

            Console.WriteLine("Sum = " + list.Sum());
            Console.WriteLine("Product = " + list.Product());
            Console.WriteLine("Average = " + list.Average());
        }
    }
}
