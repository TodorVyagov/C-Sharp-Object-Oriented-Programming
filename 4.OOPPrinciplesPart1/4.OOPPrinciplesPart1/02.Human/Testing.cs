/*Define abstract class Human with first name and last name. Define new class Student which is derived from Human
 * and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay 
 * and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and 
 * properties for this hierarchy. Initialize a list of 10 students and sort them by grade in ascending order (use LINQ
 * or OrderBy() extension method). Initialize a list of 10 workers and sort them by money per hour in descending order.
 * Merge the lists and sort them by first name and last name.*/
namespace HumanActions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Testing
    {
        static void Main()
        {
            Console.WriteLine("List of students:");
            IList<Student> students = new List<Student>
            {
                new Student("Ivan","Petrov", 10),
                new Student("Kiril","Gospodinov", 12),
                new Student("Asen","Bosev", 6),
                new Student("Yavor","Yavorov", 10),
                new Student("Todor","Penev", 3),
                new Student("Petar","Ivanov", 12),
                new Student("Kaloyan","Penev", 9),
                new Student("Ivan","Ivanov", 10),
                new Student("Dimitar","Dimitrov", 13),
                new Student("Stoyan","Spasov", 4),
            };
            students.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\nStudents sorted by their grade:");
            var sortedStudents = students.OrderBy(st => st.Grade);
            sortedStudents.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\nList of workers:");
            IList<Worker> workers = new List<Worker>
            {
                new Worker("Stoyan","Petrov", 145, 8),
                new Worker("Asen","Gospodinov", 120, 8),
                new Worker("Asen","Borisov", 200, 12),
                new Worker("Dimitar","Yavorov", 90, 4),
                new Worker("Kiril","Penev", 100, 8),
                new Worker("Ivan","Ivanov", 120, 8),
                new Worker("Kaloyan","Penev", 90, 8),
                new Worker("Petar","Ivanov", 130, 10),
                new Worker("Kaloyan","Dimitrov", 135, 12),
                new Worker("Todor","Spasov", 60, 4),
            };
            workers.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\nWorkers sorted by their money per hour:");
            var sortedWorkers = workers.OrderBy(w => w.MoneyPerHour());
            sortedWorkers.ToList().ForEach(Console.WriteLine);

            var listOfWorkersAndStudents = students.Concat<Human>(workers);
            Console.WriteLine("\nConcatenated lists of students and workers:");
            listOfWorkersAndStudents.ToList().ForEach(Console.WriteLine);

            Console.WriteLine("\nLast list sorted by their names:");
            var sortedPeople = listOfWorkersAndStudents
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);
            sortedPeople.ToList().ForEach(Console.WriteLine);
        }
    }
}
