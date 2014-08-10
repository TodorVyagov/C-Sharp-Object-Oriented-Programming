namespace AnimaHierarchy
{
    public abstract class Cat : Animal
    {
        public Cat(int age, string name, Sex gender) : base(age, name, gender)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Meow! Meow!");
        }
    }
}
