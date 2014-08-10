// 3. Write a method that from a given array of students finds all students whose first name
// is before its last name alphabetically. Use LINQ query operators.

// 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

// 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first
// name and last name in descending order. Rewrite the same with LINQ.
namespace ListOfStudentsLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfStudentsLINQ
    {
        static void PrintList<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        static void Main()
        {
            List<Student> students = new List<Student>()
                {
                    new Student("Ivan", "Petrov", 15),
                    new Student("Peter", "Ivanov", 23),
                    new Student("Ivan", "Ivanov", 40),
                    new Student("Peter", "Aleksandrov", 24),
                    new Student("Aleksander", "Krumov", 22),
                    new Student("Ivan", "Karakachanov", 18),
                    new Student("Aleksander", "Aleksandrov", 31),
                };
            Console.WriteLine("These are our students:");
            PrintList(students);

            Console.WriteLine("List of students, whose first name is before its last name alphabetically");
            var newStudents = from student in students 
                              where student.FirstName.CompareTo(student.LastName) < 0
                              select student;
            PrintList(newStudents);

            //Task 3. is above
            //Task 4. is below, but using the list of students
            Console.WriteLine("List of students, whose age is betweeen 18 and 24.");
            var newAgeSelectedStudents = from student in students
                                         where student.Age >= 18 && student.Age <= 24
                                         select student;
            PrintList(newAgeSelectedStudents);

            //Task 4 is above.
            //Task 5. is below.
            Console.WriteLine("Sorted students by their names descending with Lambda:");
            var sortedStudents = students.OrderByDescending(st => st.FirstName)
                                         .ThenByDescending(st => st.LastName);
            PrintList(sortedStudents);

            Console.WriteLine("Sorted students by their names descending with LINQ:");
            var newSortedStudents = from student in students
                                    orderby student.FirstName descending, student.LastName descending
                                    select student;
            PrintList(newSortedStudents);
        }
    }
}
