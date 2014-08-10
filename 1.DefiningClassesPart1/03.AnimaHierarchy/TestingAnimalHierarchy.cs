/*Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals.
 * All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by
 * age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. Create arrays 
 * of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).*/
namespace AnimaHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum Sex
    {
        Male,
        Female
    }
    
    class TestingAnimalHierarchy
    {
        static void Main()
        {
            //I made only animal to inherit ISound to be able to override the ProduceSound() Method for each animal. 
            //And now each animal from the animals list can produce its own sound.
            var animals = new List<Animal>
            {
                new Kitten(10, "Pisi"),
                new Tomcat(6, "Tom"),
                new Frog(3, "Jabcho", Sex.Female),
                new Dog(15, "Rex", Sex.Male),
                new Kitten(4, "Lisa"),
                new Dog(2, "Roxy", Sex.Female)
            };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name + " Age:" + animal.Age + " Sex:" + animal.Gender);
                animal.ProduceSound();
            }

            var averageAge = animals.Average(an => an.Age);
            Console.WriteLine("Average age of our list of animals is: {0:F2} years.", averageAge);
        }
    }
}
