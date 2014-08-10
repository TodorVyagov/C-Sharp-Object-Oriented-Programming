namespace DefineClassMobilePhone
{
    using System;

    public class Display
    {
        private int height;
        private int width;
        private int colors;

        public Display()
        {
        }

        public Display(int height, int width, int numberOfColors)
        {
            this.Height = height;
            this.Width = width;
            this.Colors = numberOfColors;
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display height cannot be negative!");
                }
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display width cannot be negative!");
                }
                this.width = value;
            }
        }

        public int Colors
        {
            get
            {
                return this.colors;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of colors cannot be negative!");
                }
                this.colors = value;
            }
        }
    }
}
