namespace Point3DProject
{
    using System;
    using System.Collections.Generic;

    public class Path //Task 4.
    {
        private List<Point3D> points = new List<Point3D>();

        public List<Point3D> GetPath
        {
            get
            {
                return this.points;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public void InsertPoint(Point3D point, int index)
        {
            this.points.Insert(index, point);
        }

        public Point3D GetPointFromPath(int index)
        {
            return this.points[index];
        }

        public void DeletePointFromPath(int index)
        {
            this.points.RemoveAt(index);
        }

        public void PrintPath()
        {
            foreach (var point in this.points)
            {
                Console.WriteLine(point);
            }
        }
    }
}
