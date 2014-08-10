namespace Point3DProject
{
    using System;

    public struct Point3D
    {
        private static readonly string pointO = "(0, 0, 0)"; //Task 2.
        
        public int X { get; set; } //Task 1.

        public int Y { get; set; }

        public int Z { get; set; }

        public Point3D(int x, int y, int z) : this() //Task 1.
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static string PointO //Task 2.
        {
            get
            {
                return pointO;
            }
        }

        public override string ToString() //Task 1.
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}
