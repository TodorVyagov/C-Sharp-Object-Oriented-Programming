﻿namespace Shape
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative or equal to zero!");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative or equal to zero!");
                }
                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
