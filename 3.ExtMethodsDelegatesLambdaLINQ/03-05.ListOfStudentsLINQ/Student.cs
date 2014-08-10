namespace ListOfStudentsLINQ
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public Student(string first, string last, int age)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                ValidateName(value);
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Incorrect value of age!");
                }
                this.age = value;
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty!");
            }
            
            if (name.Length < 3)
            {
                throw new ArgumentException("Name must contain at least 3 letters!");
            }

            foreach (var letter in name)
            {
                if (char.IsDigit(letter))
                {
                    throw new ArgumentException("Name cannot contain digits!");
                }
                else if (letter == ' ')
                {
                    throw new ArgumentException("Name cannot contain any white spaces(intervals)!");
                }

            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Age;
        }
    }
}
