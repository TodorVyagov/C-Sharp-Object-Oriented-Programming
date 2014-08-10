namespace GenericListOperations
{
    using System;
    using System.Threading;
    using Point3DProject;

    class TestingGenericList
    {
        static void Main()
        {
            Console.WriteLine("Test with int list:");
            GenericList<int> listOfInts = new GenericList<int>(6);

            for (int index = 0; index < 5; index++)
            {
                listOfInts.AddElement(index * 4);
            }

            //Testing Count, removing and printing - ToString() override
            Console.WriteLine("Elements in the list are: " + listOfInts.Count);
            Console.WriteLine(listOfInts);
            listOfInts.RemoveAt(0);
            Console.WriteLine("List[0] element removed\n" + listOfInts);
            listOfInts.RemoveAt(3);
            Console.WriteLine("List[3] element removed\n" + listOfInts);

            //Testing insert
            listOfInts.InsertAt(0, 2400);
            Console.WriteLine("Added 2400 at 0-th index\n" + listOfInts);
            listOfInts.InsertAt(3, 5432);
            Console.WriteLine("Added 5432 at 3-rd index\n" + listOfInts);

            //Testing Find
            Console.WriteLine("Check for 254 in the list:\nIndex = " + listOfInts.Find(254));
            Console.WriteLine("Check for 2400\nIndex = " + listOfInts.Find(2400));

            //Testing Min and Max
            Console.WriteLine("Maximal value in the list is: " + listOfInts.Max<int>());
            Console.WriteLine("Minimal value in the list is: " + listOfInts.Min<int>());

            Console.WriteLine("\nTest with string list:");
            GenericList<string> listOfStrings = new GenericList<string>(1);

            for (int index = 0; index < 5; index++)
            {
                char symbol1 = (char)((('a' + index)));
                char symbol2 = (char)((('B' + index)));
                char symbol3 = (char)((('g' + index)));
                //Testing Auto increasing capacity Initial capacity is 1 and we add 5 elements
                listOfStrings.AddElement((symbol1.ToString() + symbol2.ToString() + symbol3.ToString()));
            }

            //Testing Count, removing and printing - ToString() override
            Console.WriteLine("Elements in the list are: " + listOfStrings.Count);
            Console.WriteLine(listOfStrings);
            listOfStrings.RemoveAt(4);
            Console.WriteLine("List[4] element removed\n" + listOfStrings);
            listOfStrings.RemoveAt(3);
            Console.WriteLine("List[3] element removed\n" + listOfStrings);

            //Testing insert
            listOfStrings.InsertAt(0, "DD");
            Console.WriteLine("Added 2400 at 0-th index\n" + listOfStrings);
            listOfStrings.InsertAt(3, "ABCDE");
            Console.WriteLine("Added 5432 at 3-rd index\n" + listOfStrings);

            //Testing Find
            Console.WriteLine("Check for 254 in the list:\nIndex = " + listOfStrings.Find("254"));
            Console.WriteLine("Check for 2400\nIndex = " + listOfStrings.Find("2400"));

            //Testing Min and Max
            Console.WriteLine("Maximal length in the list is: " + listOfStrings.Max<string>());
            Console.WriteLine("Minimal length in the list is: " + listOfStrings.Min<string>());

            //New test with 3D points from Task 1.(01-04.3DPoint Project added as Reference and new using included)
            Console.WriteLine("\nTest with 3D points list:");
            GenericList<Point3D> listOfPoints = new GenericList<Point3D>(2);
            listOfPoints.AddElement(new Point3D(2, 5, 12));
            listOfPoints.AddElement(new Point3D(4, 15, 2));
            listOfPoints.AddElement(new Point3D(8, 7, 6));
            listOfPoints.AddElement(new Point3D(1, 2, 3));

            Console.WriteLine("Elements in the list are: {0}\n{1}", listOfPoints.Count, listOfPoints);
            listOfPoints.RemoveAt(3);
            Console.WriteLine("List[3] element removed\n" + listOfPoints);
            listOfPoints.InsertAt(1, new Point3D(2, 20 , 200));
            Console.WriteLine("Added (2, 20 , 200) at 1-st index\n" + listOfPoints);
            Console.WriteLine("Check for (4, 15, 2) in the list:\nIndex = " + listOfPoints.Find(new Point3D(4, 15, 2)));
            Console.WriteLine("Check for (4, 15, 1) in the list:\nIndex = " + listOfPoints.Find(new Point3D(4, 15, 1)));
        }
    }
}
