namespace ActionsWithStudents
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string fn;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, string fn, string telephone, string email, List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = telephone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, string fn, string telephone, string email, List<int> marks, int groupNumber, string departmentName) : this(firstName, lastName, fn, telephone, email, marks, groupNumber)
        {
            this.GroupName = new Group(groupNumber, departmentName);
        }

        public Group GroupName { get; private set; } //Task 16.

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

        public string FN
        {
            get { return this.fn; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FN cannot be empty!");
                }
                this.fn = value;
            }
        }

        public string Tel
        {
            get { return this.tel; }
            private set
            {
                for (int digit = 0; digit < value.Length; digit++)
                {
                    if (!char.IsDigit(value[digit]) && !(value[digit] == '+' && digit == 0))
                    {
                        throw new ArgumentException("Incorrect phone number! Phone must contain only digits and may have leading '+'");
                    }
                }
                this.tel = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (!Regex.IsMatch(value, @"[\w.]{2,20}@[\w]{2,20}[.]{1}[\w.]{2,6}")) //taken from homework - Strings and text processing
                {
                    throw new ArgumentException("Invalid e-mail!");
                }
                this.email = value;
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
            private set
            {
                foreach (var mark in value)
                {
                    if (mark < 2 || mark > 6)
                    {
                        throw new ArgumentException("Marks must be between 2 and 6 inclusive!");
                    }
                }
                this.marks = value;
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Incorrect group number!");
                }
                this.groupNumber = value;
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
            return this.FirstName + " " + this.LastName + " FN:" + this.FN + " Tel:" + this.Tel + ", " + this.Email + " Marks:" + string.Join(" ", this.Marks);
        }
    }
}
