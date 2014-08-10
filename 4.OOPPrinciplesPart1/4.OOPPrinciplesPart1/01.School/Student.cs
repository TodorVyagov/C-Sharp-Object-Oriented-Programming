namespace SchoolOrganisation
{
    using System;
    using System.Collections.Generic;

    public class Student : Person, ICommentable
    {
        private int uniqueClassNumber; 
        public IList<string> comments = new List<string>();

        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get { return this.uniqueClassNumber; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Class number cannot be negative or 0!");
                }
                this.uniqueClassNumber = value;
            }
        }

        public string Comments
        {
            get {return "Comments: " + string.Join("\n", this.comments); }
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
            return this.Name + " No:" + this.ClassNumber;
        }
    }
}
