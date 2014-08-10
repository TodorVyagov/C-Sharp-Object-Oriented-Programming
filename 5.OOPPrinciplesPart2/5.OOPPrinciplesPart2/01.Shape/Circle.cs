namespace Shape
{
    using System;

    class Circle : Shape
    {
        public Circle(double radius) : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height * Math.PI; //S = Pi * r * r;
        }
    }
}
