// 9. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. Create a List<Student> 
//with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
// 10. Implement the previous using the same query expressed with extension methods.
// 11. Extract all students that have email in abv.bg. Use string methods and LINQ.
// 12. Extract all students with phones in Sofia. Use LINQ.
// 13. Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
// 14. Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
// 15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
// 16.* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. Extract all students 
//from "Mathematics" department. Use the Join operator.
namespace ActionsWithStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ActionsWithStudents
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
                {
                    new Student("Ivan", "Petrov", "701206", "+359888888888", "ivan@abv.bg", new List<int>() {6, 5, 6 , 4 ,3}, 3),
                    new Student("Peter", "Ivanov", "54311", "028535353", "pesho@yahoo.com", new List<int>() {3, 4, 2 , 3 ,2}, 2),
                    new Student("Ivan", "Ivanov", "90906", "+3598606060", "ivanivanov@hotmail.com", new List<int>() {6, 3, 5 , 4 ,4}, 3),
                    new Student("Peter", "Aleksandrov", "19191", "088565656", "peshoaleksandrov@gmail.com", new List<int>() {3, 5, 2 , 2 ,3}, 2),
                    new Student("Aleksander", "Krumov", "48306", "+3594589653", "krumov@abv.bg", new List<int>() {6, 5, 4 , 3 ,3}, 1),
                    new Student("Ivan", "Karakachanov", "12205", "02457896", "vankata@hotmail.com", new List<int>() {4, 5, 5 , 4 ,6}, 4),
                    new Student("Aleksander", "Aleksandrov", "58206", "+35989789789", "sasho@abv.bg", new List<int>() {5, 5, 5 , 5 ,5}, 3),
                };

            //Task 9.
            var group2Students = students
                .Where(st => st.GroupNumber == 2)
                .OrderBy(st => st.FirstName)
                .ThenBy(st => st.LastName);
            Console.WriteLine("LAMBDA:\nThese students are from group 2:");
            group2Students.ToList().ForEach(Console.WriteLine);
            
            //Task 10.
            var newGroup2Students = students.OrderStudentsFromGivenGroup(2);
            Console.WriteLine("\nExtension method:");
            newGroup2Students.ToList().ForEach(Console.WriteLine);

            //Task 11.
            var studentsWithABVmail = students
                .Where(st => st.Email.Substring(st.Email.IndexOf('@')) == "@abv.bg");
            Console.WriteLine("\nStudents with abv.bg email:");
            studentsWithABVmail.ToList().ForEach(Console.WriteLine);

            //Task 12.
            var studentsFormSofia = students
                .Where(st => st.Tel.IndexOf("02") == 0);
            Console.WriteLine("\nStudents with phone in Sofia:");
            studentsFormSofia.ToList().ForEach(Console.WriteLine);

            //Task 13.
            var excellentStudents = students
                .Where(st => st.Marks.Contains(6))
                .Select(st => new {FullnName = st.FirstName + " " + st.LastName, Marks = st.Marks});
            Console.WriteLine("\nStudents with at least one 6(excellent) mark:");
            foreach (var student in excellentStudents)
            {
                Console.WriteLine("Name: {0}, Marks: {1}.", student.FullnName, string.Join(", ", student.Marks));
            }

            //Task 14.
            var poorMarkStudents = students.StudentsWithGivenMarks(2, 2);
            Console.WriteLine("\nStudents exactly two poor(2) marks:");
            poorMarkStudents.ToList().ForEach(Console.WriteLine);

            //Task 15.
            var marksOfStudentsFrom2006 = students
                .Where(st => (st.FN.EndsWith("06")))
                .Select(st => st.Marks.ToList());
            Console.WriteLine("\nMarks of students enrolled in 2006:");

            foreach (var marks in marksOfStudentsFrom2006)
            {
                Console.Write(string.Join(" ", marks));
                Console.WriteLine();
            }

            //Task 16.*
            List<Group> groups = new List<Group>()
            {
                new Group(1, "Physics"),
                new Group(2, "Philosophy"),
                new Group(3, "Mathematics"),
                new Group(4, "Literature"),
                new Group(5, "Medicine"),
                new Group(6, "Biology"),
            };

            var matematicsStudents = from student in students
                                               join gr in groups on student.GroupNumber equals gr.GroupNumber
                                               where gr.DepartmentName.ToLower() == "mathematics"
                                               select student;

            Console.WriteLine("\nStudents in matematics department:");
            matematicsStudents.ToList().ForEach(Console.WriteLine);
            
        }
    }
}
