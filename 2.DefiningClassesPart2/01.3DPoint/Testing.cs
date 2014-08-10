namespace Point3DProject
{
    using System;

    class Testing
    {
        static void Main()
        {
            //Testing Point3D
            Point3D point = new Point3D();
            point.X = 25;
            point.Y = 2;
            point.Z = 5;
            Console.WriteLine(point);
            Console.WriteLine(Point3D.PointO);
            var secondPoint = new Point3D(15, 10 , 5);
            var thirdPoint = new Point3D();

            //Testing class DistanceBetween3DPoints
            double distance = DistanceBetween3DPoints.DistanceCalculator(secondPoint, point);
            Console.WriteLine("Distance between points: {0} and {1} is: {2}", point, secondPoint, distance);
            distance = DistanceBetween3DPoints.DistanceCalculator(secondPoint, thirdPoint);
            Console.WriteLine("Distance between points: {0} and {1} is: {2}", thirdPoint, secondPoint, distance);

            //Testing Path
            Path pathOfPoints = new Path();
            pathOfPoints.AddPoint(new Point3D(2, 4 ,6));
            pathOfPoints.AddPoint(new Point3D(10, 15, 20));
            pathOfPoints.AddPoint(new Point3D(0, 6, 3));
            pathOfPoints.AddPoint(new Point3D(9, 7, 12));

            pathOfPoints.PrintPath();
            
            //Testing PathStorage
            PathStorage.SavePathIntoFile(pathOfPoints.GetPath);

            Path newPath = PathStorage.LoadPathFromFile(); //Loading path of points into new Path
            newPath.PrintPath();
        }
    }
}
