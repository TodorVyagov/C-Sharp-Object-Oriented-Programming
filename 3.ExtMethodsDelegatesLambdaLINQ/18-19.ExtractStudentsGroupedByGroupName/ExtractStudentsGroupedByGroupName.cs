// 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
// 19. Rewrite the previous using extension methods.
namespace ExtractStudentsGroupedByGroupName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class ExtractStudentsGroupedByGroupName
    {
        public static List<Student> GroupStudents(this List<Student> students)
        {
            IEnumerable<Student> groupedStudents = from student in students
                                                   orderby student.GroupName, student.FirstName, student.LastName
                                                   select student;
            return groupedStudents.ToList();
        }

        static void Main()
        {
            List<Student> students = new List<Student>()
                {
                    new Student("Ivan", "Petrov", "Light"),
                    new Student("Peter", "Ivanov", "Ultimate"),
                    new Student("Ivan", "Ivanov", "Enterprise"),
                    new Student("Peter", "Aleksandrov", "Light"),
                    new Student("Aleksander", "Krumov", "Enterprise"),
                    new Student("Ivan", "Karakachanov", "Ultimate"),
                    new Student("Aleksander", "Aleksandrov", "Enterprise"),
                };
            Console.WriteLine("These are our students:");
            students.ToList().ForEach(Console.WriteLine);


            //Task 18.
            var groupedStudents = students
                .OrderBy(st => st.GroupName)
                .ThenBy(st => st.FirstName)
                .ThenBy(st => st.LastName);
            Console.WriteLine("\nStudents grouped by group and then by their names:");
            groupedStudents.ToList().ForEach(Console.WriteLine);

            //Task 19.
            var newGroupedStudents = students.GroupStudents();
            Console.WriteLine("\nExtension method\nStudents grouped by group and then by their names:");
            groupedStudents.ToList().ForEach(Console.WriteLine);
        }
    }
}
