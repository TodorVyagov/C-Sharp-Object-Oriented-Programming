namespace AnimaHierarchy
{
    public class Dog : Animal
    {
        public Dog(int age, string name, sex gender) : base(age, name, gender)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Bau! Bau!");
        }

    }
}
