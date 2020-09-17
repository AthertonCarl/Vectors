using System;

namespace Vectors
{

    class Program
    {
        static Random R = new Random();

        struct Point
        {
            public int x;
            public int y;
            public int z;
        }

        static Point[] GetPoints(int plotPoints = 100)
        {
            int n = plotPoints;
            Point[] points = new Point[n];

            if (n >= 2 && n < 1000)
            {
                for (int i = 0; i < n; i++)
                {
                    points[i] = new Point
                    {
                        x = R.Next(1, 100),
                        y = R.Next(1, 100),
                        z = 0
                    };
                }

            }

            if (n == 1000)
            {
                for (int i = 0; i < n; i ++)
                {
                    points[i] = new Point
                    {
                        x = R.Next(1, 1000),
                        y = R.Next(1, 1000),
                        z = R.Next(1, 1000),
                    };
                }
            }

            return points;
        }

        static double GetDistance(Point A, Point B)
        {
            int width = Math.Abs(A.x) - Math.Abs(B.x);
            int height = Math.Abs(A.y) - Math.Abs(B.y);
            int depth = Math.Abs(A.z) - Math.Abs(B.z);

            if (A.z != 0)
            {
                return Math.Sqrt(width * width + height * height + depth * depth);
                
            }
            else 
            {
                return Math.Sqrt(width * width + height * height);
            }
        }

        static double ClosestPoint(Point[] points)
        {
            double  distance = 0;
            double closestDistance = 0;
            double previousDistance = 1000;

            // First Point
            int x1 = 0, y1 = 0, z1 = 0;

            // Second Point
            int x2 = 0, y2 = 0, z2 = 0;

            // Closest Element
            int firstPoint = 0, secondPoint = 0;

            for (int l = 0; l < points.Length; l++)
            {
                for (int k = 0; k < points.Length; k++)
                {
                    if (l != k)
                    {
                        distance = GetDistance(points[l], points[k]);
                    }

                    if (distance < previousDistance && distance != 0)
                    {
                        closestDistance = distance;
                        previousDistance = distance;

                        // Cosnsole.Write X & Y values

                        // First Point 
                        x1 = points[l].x;
                        y1 = points[l].y;
                        z1 = points[l].z;
                        
                        // Second Point
                        x2 = points[k].x;
                        y2 = points[k].y;
                        z2 = points[k].z;

                        // Closest Element in array
                        firstPoint = l;
                        secondPoint = k;
                    }
                }
            }
            Console.WriteLine($"The closest points are \nArray Element: " +
                $"|{firstPoint}| X:{x1}, Y:{y1}, Z:{z1} \n\nAND \n\nArray Element: " +
                $"|{secondPoint}| X:{x2}, Y:{y2}, Z:{z2}");

            return closestDistance;
        }

        private static double GetDis2Point()
        {
            Point[] arrayOfPoints = GetPoints(2);

            return GetDistance(arrayOfPoints[0], arrayOfPoints[1]);
        }

        private static void PrintPoints(Point[] providedPoints)
        {
            Point[] pointsToPrint = providedPoints;
            Console.WriteLine($"You have successfully created a container with {pointsToPrint.Length} random two-dimensional points.");
            Console.WriteLine("\n");
            for (int i = 0; i < pointsToPrint.Length; i++)
            {
                
                Console.WriteLine($"Array Element: |{i}| X: {pointsToPrint[i].x}, Y: {pointsToPrint[i].y}, Z: {pointsToPrint[i].z}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------First Part-------------------------------------------");
            Console.WriteLine("\n");
            //GetPoints(100);
            //Console.WriteLine($"How many elements would you like inside your new container? Please enter a valid positive number: ");
            //Point[] newPointsContainer = GetPoints(Convert.ToInt32(Console.ReadLine()));
            Point[] newPointsContainer = GetPoints();
            PrintPoints(newPointsContainer);
            Console.WriteLine("\n");
            Console.WriteLine("-----------------------Second Part------------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine($"Closest Euclidean Distance Between (100) Two-Dimentional Points: |{ClosestPoint(newPointsContainer)}|");
            Console.WriteLine("\n");
            Console.WriteLine("-----------------------Third And Fourth Part--------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine($"With a Distance of: |{ClosestPoint(GetPoints(1000))}|");
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------------------------------------------------------");
        }
    }
}
