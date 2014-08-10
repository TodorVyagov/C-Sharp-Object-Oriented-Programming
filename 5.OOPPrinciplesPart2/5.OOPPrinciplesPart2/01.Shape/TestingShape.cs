/*Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
 * Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of
 * the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable 
 * constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() 
 * method. Write a program that tests the behavior of  the CalculateSurface() method for different shapes 
 * (Circle, Rectangle, Triangle) stored in an array.*/
namespace Shape
{
    using System;
    using System.Collections.Generic;

    class TestingShape
    {
        static void Main()
        {
            IEnumerable<Shape> shapes = new List<Shape>
            {
                new Circle(10),
                new Triangle(10, 2),
                new Rectangle(3.5, 4.5),
                new Circle(3.14),
                new Rectangle(10, 1.5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{1} has surface: {0:0.00} square santimeters.", shape.CalculateSurface(), shape.GetType());
            }
        }
    }
}
