namespace GenericListOperations
{
    using System;

    public static class ExtensionMethodsGenericList
    {
        public static T Min<T>(this GenericList<T> listOfElements)
            where T : IComparable<T>, IComparable
        {
            T minElement = listOfElements.ReturnElementByIndex(0);

            for (int index = 1; index < listOfElements.Count; index++)
            {
                if (minElement.CompareTo(listOfElements.ReturnElementByIndex(index)) > 0)
                {
                    minElement = listOfElements.ReturnElementByIndex(index);
                }
            }

            return minElement;
        }

        public static T Max<T>(this GenericList<T> listOfElements)
            where T : IComparable<T>, IComparable
        {
            T maxElement = listOfElements.ReturnElementByIndex(0);

            for (int index = 0; index < listOfElements.Count; index++)
            {
                if (maxElement.CompareTo(listOfElements.ReturnElementByIndex(index)) < 0)
                {
                    maxElement = listOfElements.ReturnElementByIndex(index);
                }
            }

            return maxElement;
        }
    }
}
