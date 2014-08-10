namespace PersonActions
{
    using System;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        private int Age
        {
            set
            {
                if (value < 0 || value > 130)
                {
                    throw new ArgumentException("Age cannot be negative or above 130!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            string result = "Name: " + this.Name + "\nAge: ";
            int age = this.age ?? -1;
            
            if (age == -1)
            {
                result += "Not specified!";
            }
            else
            {
                result += this.age;
            }

            return result;
        }
    }
}
