namespace AnimaHierarchy
{
    public abstract class Cat : Animal
    {
        public Cat(int age, string name, sex gender) : base(age, name, gender)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Meow! Meow!");
        }
    }
}
