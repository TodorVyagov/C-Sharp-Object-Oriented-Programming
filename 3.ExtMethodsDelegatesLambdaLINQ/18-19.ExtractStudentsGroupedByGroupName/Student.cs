namespace ExtractStudentsGroupedByGroupName
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string groupName;

        public Student(string first, string last, string groupName)
        {
            this.FirstName = first;
            this.LastName = last;
            this.GroupName = groupName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                ValidateName(value, true);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                ValidateName(value, true);
                this.lastName = value;
            }
        }

        public string GroupName
        {
            get { return this.groupName; }
            private set
            {
                ValidateName(value, false);
                this.groupName = value;
            }
        }

        private void ValidateName(string name, bool isName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty!");
            }
            
            if (name.Length < 3)
            {
                throw new ArgumentException("Name must contain at least 3 letters!");
            }

            if (!isName)//because group name can contain white spaces and intervals
            {
                return;
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
            return this.FirstName + " " + this.LastName + "    Group: " + this.GroupName;
        }
    }
}
