/*We are given a school. In the school there are classes of students. Each class has a set of teachers.
 * Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have
 * unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of
 * exercises. Both teachers and students are people. Students, classes, teachers and disciplines could
 * have optional comments (free text block).
	Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate
 * their fields, define the class hierarchy and create a class diagram with Visual Studio.*/
namespace SchoolOrganisation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestProgram
    {
        static void Main()
        {
            IList<Student> students = new List<Student> 
            {
                new Student("Pesho", "Kirov", 1),
                new Student("Kolio", "Petrov", 4),
                new Student("Ivan", "Kirov", 5)
            };

            IList<Teacher> teachers = new List<Teacher> 
            {
                new Teacher("Ivan", "Ivanov", new List<Discipline> {new Discipline("English", 40, 20), new Discipline("Literature", 30, 15)}),
                new Teacher("Stoyan", "Kirilov", new List<Discipline> {new Discipline("Mathematics", 25, 15), new Discipline("Physics", 20, 15)}),
            };

            School school = new School();
            school.AddClass = new SchoolClass("2a", students, teachers);

            Console.WriteLine(school);

            Student kiril = new Student("Kiril", "Petrov", 4);
            kiril.AddComment("Excellent student!");
            kiril.AddComment("Fined 100$ for breaking school properties!");
            Console.WriteLine(kiril.Name);
            Console.WriteLine(kiril.Comments);
        }
    }
}
