namespace SchoolOrganisation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SchoolClass : ICommentable
    {
        private string uniqueTextIdentifier;
        private IList<Student> students;
        private IList<Teacher> teachers;
        public IList<string> comments = new List<string>();
        
        public SchoolClass(string identifier, IList<Student> students, IList<Teacher> teachers)
        {
            this.UniqueTextIdentifier = identifier;
            this.Students = students;
            this.Teachers = teachers;
        }

        public string UniqueTextIdentifier
        {
            get { return this.uniqueTextIdentifier; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Class identifier cannot be empty!");
                }
                this.uniqueTextIdentifier = value;
            }
        }

        public IList<Student> Students
        {
            get { return this.students; }
            private set
            {
                var uniqueNumbers = value
                   .GroupBy(i => i.ClassNumber)
                   .Where(g => g.Count() >= 1)
                   .Select(g => g.Count());

                foreach (var num in uniqueNumbers)
                {
                    if (num > 1)
                    {
                        throw new ArgumentException("Duplicate of student numbers! Each student must have unique class number!");
                    }
                }

                this.students = value;
            }
        }

        public IList<Teacher> Teachers
        {
            get { return this.teachers; }
            private set { this.teachers = value; }
        }

        public Student AddStudent
        {
            set { this.students.Add(value); }
        }

        public Student RemoveStudent
        {
            set { this.students.Remove(value); }
        }

        public Teacher AddTeacher
        {
            set { this.teachers.Add(value); }
        }

        public Teacher RemoveTeacher
        {
            set { this.teachers.Remove(value); }
        }

        public string Comments
        {
            get { return "Comments: " + string.Join("\n", this.comments); }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public void ClearComments()
        {
            this.comments.Clear();
        }

        public override string ToString()
        {
            return this.UniqueTextIdentifier + " Class\nStudents:\n\t" + string.Join("\n\t", this.Students) + "\nTeachers:\n" + string.Join("\n", this.Teachers);
        }
    }
}
