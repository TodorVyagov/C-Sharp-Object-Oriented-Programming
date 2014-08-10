namespace HumanActions
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
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
                this.lastName += " " + value;
            }
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
