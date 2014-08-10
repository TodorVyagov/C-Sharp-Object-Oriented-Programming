namespace AnimaHierarchy
{
    using System;
    
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private Sex gender;

        public Animal(int age, string name, Sex gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative!");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }

                foreach (var letter in value)
                {
                    if (!char.IsLetter(letter))
                    {
                        throw new ArgumentException("Name must contain only letters!");
                    }
                }
                this.name = value;
            }
        }

        public Sex Gender
        {
            get { return this.gender; }
            private set
            {
                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("I am animal!");
        }
    }
}
