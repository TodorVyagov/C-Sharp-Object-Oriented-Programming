namespace GenericListOperations
{
    using System;
    using System.Text;

    public class GenericList<T>
    {
        private T[] collection;
        private int elementsCount;

        public GenericList(int capacity)
        {
            this.Collection = capacity;
            this.elementsCount = 0;
        }

        private int Collection
        {
            set
            {
                if(value < 1)
                {
                    throw new ArgumentOutOfRangeException("Capacity of list cannot be negative or zero!");
                }

                this.collection = new T[value];
            }
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.elementsCount)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ExtendList() //Task 6.
        {
            T[] tempArr = this.collection;
            int newLength = this.collection.Length * 2;
            this.collection = new T[newLength]; //we make it twice bigger
            this.elementsCount = 0;

            foreach (var item in tempArr)
            {
                AddElement(item);
            }
        }

        public void AddElement(T value)
        {
            if (this.elementsCount == this.collection.Length)
            {
                ExtendList();
            }

            this.collection[this.elementsCount] = value;
            this.elementsCount++;
        }

        /// <summary>
        /// Returns element at a given position.
        /// </summary>
        public T ReturnElementByIndex(int index)
        {
            ValidateIndex(index);
            return this.collection[index];
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            if (index == this.elementsCount - 1)
            {
                this.elementsCount--; //it is not really deleted but Our list will overwrite it if we add new element
                return;
            }

            for (int i = index; i < elementsCount; i++) //This will overwrite the element and move elements with higher index
            {
                this.collection[i] = this.collection[i + 1];
            }

            this.elementsCount--; //the last element will be no more accessible
        }

        public void InsertAt(int index, T value)
        {
            ValidateIndex(index);
            
            if (this.elementsCount == this.collection.Length) 
            {
                ExtendList();
            }

            for (int i = this.elementsCount - 1; i >= index; i--) //Moving elements with index >= InsertIndex with one position in the array
            {
                this.collection[i + 1] = this.collection[i]; 
            }

            this.elementsCount++;
            this.collection[index] = value;
        }

        public void Clear()
        {
            this.elementsCount = 0;
        }

        /// <summary>
        /// Returns index of first found element.
        /// If such element do not exist returns -1.
        /// </summary>
        public int Find(T value)
        {
            for (int index = 0; index < this.elementsCount; index++)
            {
                if (value.ToString() == this.collection[index].ToString())
                {
                    return index;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < this.elementsCount; index++)
            {
                result.Append(collection[index]);

                if (index < this.elementsCount - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }
    }
}
