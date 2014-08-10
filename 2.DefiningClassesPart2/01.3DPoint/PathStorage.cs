namespace Point3DProject
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class PathStorage //Task 4.
    {
        public static void SavePathIntoFile(List<Point3D> points)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\PathOfPoints.path"))
            {
                foreach (var point in points)
                {
                    sw.WriteLine("{0} {1} {2}", point.X, point.Y, point.Z);
                }
            }

            Console.WriteLine("Text file successfully saved!");
        }

        public static Path LoadPathFromFile(string directory = @"..\..\PathOfPoints.path")
        {
            Path points = new Path();

            using (StreamReader sr = new StreamReader(directory))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    var point = new Point3D();
                    string[] coordinates = line.Split(' ');
                    point.X = int.Parse(coordinates[0]);
                    point.Y = int.Parse(coordinates[1]);
                    point.Z = int.Parse(coordinates[2]);
                    points.AddPoint(point);

                    line = sr.ReadLine();
                }
            }
            Console.WriteLine("Path successfully loaded!");

            return points;
        }


    }
}
