namespace ActionsWithStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static List<Student> OrderStudentsFromGivenGroup(this List<Student> students, int group) //Task 10.
        {
            //Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.

            IEnumerable<Student> sortedStudents = students
                .Where(st => st.GroupNumber == group)
                .OrderBy(st => st.FirstName)
                .ThenBy(st => st.LastName);

            return sortedStudents.ToList();
        }
         
        public static List<Student> StudentsWithGivenMarks(this List<Student> students, int numberOfMarks, int mark)
        {
            if (numberOfMarks > students.Count)
            {
                throw new ArgumentException("Number of marks cannot be bigger than total count of marks for the student!");                   
            }
            else if (mark < 2 || mark > 6)
            {
                throw new ArgumentException("Incorrect mark! Mark must be: mark >= 2 && mark <= 6!");
            }

            IEnumerable<Student> newStudents = students
                .Where(st => st.Marks.Count(x => x == mark) == numberOfMarks);
            return newStudents.ToList();
        }
    }
}
