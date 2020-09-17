using System;

namespace Vectors
{



    class Program
    {
        static Random R = new Random(123);

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

            if (n > 0 && n < 1000)
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
                return Math.Sqrt(width * width + height * height);;
            }


        }

        static void ClosestPoint(Point[] points)
        {
            double distance = 0;
            double closestDistance = 0;
            double previousDistance = 0;

            // First Point
            int x1 = 0, y1 = 0, z1 = 0;

            // Second Point
            int x2 = 0, y2 = 0, z2 = 0;

            // Closest Element
            int firstPoint = 0, secondPoint



            for (int c = 0; c < points.Length; c++)
            {
                for (int b = 0; b < points.Length; b++)
                {
                    if (c != b)
                    {
                        distance =GetDistance(points[c], points[b])
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------First Part-------------------------------------------");
            Console.WriteLine($"Eculidean Distance between (2) Two-Dimentional Points: |{GetDis2Point()}|");
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------Second Part------------------------------------------");
            Console.WriteLine($"Closest Eculidean Distance Between (100) Two-Dimentional Points: |{FindClosest(GetPoints(100))}|");
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------Third And Fourth Part--------------------------------");
            Console.WriteLine($"With a Distance of: |{FindClosest(GetPoints(1000))}|");
            Console.WriteLine("----------------------------------------------------------------------------");
        }




    }
}
