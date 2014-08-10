namespace SchoolOrganisation
{
    using System;
    using System.Collections.Generic;

    public class Discipline: ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises; 
        public IList<string> comments = new List<string>();

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Discipline name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of lectures cannot be negative!");
                }
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get { return this.numberOfExercises; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of exercises cannot be negative!");
                }
                this.numberOfExercises = value;
            }
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
            return this.Name + " lectures:" + this.NumberOfLectures + " exercises:" + this.NumberOfExercises;
        }
    }
}
