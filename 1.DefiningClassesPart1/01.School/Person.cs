namespace SchoolOrganisation
{
    using System;

    public abstract class Person
    {
        private string name;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        private string FirstName
        {
            set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        private string LastName
        {
            set
            {
                ValidateName(value);
                this.name += " " + value;
            }
        }

        public string Name
        {
            get { return this.name; }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty!");
            }

            foreach (var letter in name)
            {
                if (!char.IsLetter(letter))
                {
                    throw new ArgumentException("Name must contain only letters!");
                }
            }
        }
    }
}
