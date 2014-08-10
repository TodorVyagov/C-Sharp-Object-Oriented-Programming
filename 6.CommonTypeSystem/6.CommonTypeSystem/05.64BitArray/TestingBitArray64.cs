// Define a class BitArray64 to hold 64 bit values inside an ulong value.
// Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
namespace BitArray
{
    using System;

    class TestingBitArray64
    {
        static void Main()
        {
            BitArray64 array1 = new BitArray64();
            array1[3] = 1;
            array1[7] = 1;
            array1[9] = 1;
            array1[11] = 1;
            array1[12] = 1;
            array1[13] = 1;
            array1[42] = 1;
            array1[28] = 1;
            array1[39] = 1;
            
            Console.WriteLine("This is the binary array 1:");

            foreach (var bit in array1)
            {
                Console.Write(bit);
            }

            Console.WriteLine();

            BitArray64 array2 = new BitArray64();
            array2[3] = 1;
            array2[7] = 1;
            array2[9] = 1;
            array2[11] = 1;
            array2[12] = 1;
            array2[13] = 1;
            array2[42] = 1;
            array2[28] = 1;
            array2[39] = 1;

            Console.WriteLine("This is the binary array 2:");

            foreach (var bit in array2)
            {
                Console.Write(bit);
            }

            Console.WriteLine();

            Console.WriteLine("arr1 == arr2: " + (array1 == array2));

            Console.WriteLine("This is the binary array1 after changes:");
            array1[12] = 0;

            foreach (var bit in array1)
            {
                Console.Write(bit);
            }

            Console.WriteLine();
            array1 = new BitArray64(4096);
            Console.WriteLine("arr1 == arr2: " + (array1 == array2));
            Console.WriteLine("arr1 != arr2: " + (array1 != array2));
            Console.WriteLine("arr1 hash code: " + array1.GetHashCode());
        }
    }
}
