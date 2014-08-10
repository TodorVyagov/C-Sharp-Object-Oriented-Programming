namespace Point3DProject
{
    using System;

    public static class DistanceBetween3DPoints //task 3.
    {
        /// <summary>
        /// Calculates distance between two 3D points(Point3D).
        /// </summary>
        public static double DistanceCalculator(Point3D first, Point3D second) //Task 3.
        {
            int x = second.X - first.X;
            int y = second.Y - first.Y;
            int z = second.Z - first.Z;
            int sumOfSquares = x * x + y * y + z * z;
            double distance = Math.Sqrt(sumOfSquares);

            return distance;
        }
    }
}
