namespace StudentActions
{
    using System;

    class Program
    {
        static void Main()
        {
            //tasks are in Tasks.txt

            var student1 = new Student("Petar", "Kirov", "Dyankov", 123456789, "Zona B5, 12, Sofia", "+359888121314",
                "p.dyankov@abv.bg", 3, Specialty.JavaScriptProgrammer, University.SoftwareUniversity, Faculty.Programming);
            var student2 = new Student("Petar", "Kirov", "Dankov", 987654321, "Knyajevo, 33, Sofia", "0884989796", 
                "stoyan@abv.bg", 3, Specialty.QAEngineer, University.TechnicalUniversity, Faculty.Engineering);
            var student3 = new Student("Nikolay", "Dimitrov", "Stanimirov", 358123789, "Lulin, 102, Sofia", "+359896101010",
                "niki89@abv.bg", 3, Specialty.FrontEndDeveloper, University.NewBulgarianUniversity, Faculty.Development);
            var student4 = new Student("Petar", "Kirov", "Dyankov", 123456789, "Manastirski Livadi, 2, Sofia", "0888909090",
                "p.dyankov@gmail.com", 3, Specialty.CSharpProgrammer, University.AmericanUniversity, Faculty.Programming);

            Console.WriteLine(student1.ToString());
            Console.WriteLine("Student1 hash code: " + student1.GetHashCode());
            Console.WriteLine("Student1 == Student2 - " + (student1 == student2));
            Console.WriteLine("Student1 == Student4 - " + (student1 == student4));
            Console.WriteLine("Student1 != Student4 - " + (student1 != student4));

            Console.WriteLine();
            Console.WriteLine("pesho".CompareTo("pesh"));
            Console.WriteLine(123.CompareTo(1111));
            Console.WriteLine(student1.CompareTo(student2));

            //Student studentCopy = student1.Clone();
            //I made the fields and properties in class Student public to be able to test if the copy is deep with changing the fields of copy.
            //But in class Student there are no reference types so I think that MemberwiseClone() can do the same thing.

            //studentCopy.address = "Sofia";
            //studentCopy.firstName = "Boyan";
            //studentCopy.ssn = 100000000;
            //studentCopy.email = "zombi@abv.bg";
            //studentCopy.course = 101;
            //studentCopy.Specialty = Specialty.dotNETDeveloper;
            //studentCopy.University = University.SofiaUniversity;
            //studentCopy.Faculty = Faculty.Engineering;

            //Console.WriteLine(studentCopy);

            //Console.WriteLine(student1);
        }
    }
}
