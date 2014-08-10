namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class BitArray64 : IEnumerable<int>
    {
        private ulong array;

        public BitArray64()
        {

        }

        public BitArray64(ulong decimalRepresentationOfArray)
        {
            this.array = decimalRepresentationOfArray;
        }

        public int this[int index]
        {
            get 
            {
                return (int)(this.array >> index) & 1;
            }
            set
            {
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Bit value must be 0 or 1!");
                }

                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException("Index of 64 bit array must be between 0 and 63 inclusive!");
                }

                this.SetBitAtPosition(value, index);
            }
        }

        private void SetBitAtPosition(int bitValue, int index)
        {
            ulong mask = (ulong)1 << index;

            if (bitValue == 0)
            {
                mask = ~mask;
                this.array &= mask; 
            }
            else //(bitValue == 1)
            {
                this.array |= mask;
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 arrToCompare = obj as BitArray64;

            if (arrToCompare == null)
            {
                return false;
            }

            if (arrToCompare.array != this.array)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return ~this.array.GetHashCode();
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            return BitArray64.Equals(arr1, arr2);
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            return !(BitArray64.Equals(arr1, arr2));
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 63; index >= 0; index--)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
