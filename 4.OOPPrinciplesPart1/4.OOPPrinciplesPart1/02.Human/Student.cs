namespace HumanActions
{
    using System;

    class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) 
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
            private set
            {
                if (value < 1 || value > 13)
                {
                    throw new ArgumentException("Invalid grade! Grade must be between 1 and 13!");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " Grade: " + this.Grade;
        }
    }
}
