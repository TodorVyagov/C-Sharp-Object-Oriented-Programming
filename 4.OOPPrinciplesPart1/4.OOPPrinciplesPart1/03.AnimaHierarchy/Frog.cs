namespace AnimaHierarchy
{
    public class Frog : Animal
    {
        public Frog(int age, string name, sex gender) : base(age, name, gender)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Croak! Croak!");
        }
    }
}
