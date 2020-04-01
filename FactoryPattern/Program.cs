using System;

namespace FactoryPattern
{
    /* FACTORY PATTERN */

    // Factory pattern covers two topics 
    // 1- factory pattern 
    // 2- abstract factory pattern 

    // MOTIVATION
    // 1- object creation is too convoluted 
    // 2- constructor is not descriptive 
    //     - Name mandated by name of containing type
    //     - Cannot overload with same set of arguments with different names 
    //     - Can turn into 'optional parameter hell'
    // 3- Object creation (non - piecewise, unlike Builder) can be outsourced to 
    //     - A separate function (Factory Method)
    //     - That may exit in a separate class (Factory
    //
    //
    // )


    // ( Factory -> A Component responsible solely
    //              for the wholesale(not piecewise) creation of objects.
    // )

    /* one of the reasons is that factory exists because constructors are not that much good */

    // public enum CoordianteSystem
    // {
    //     Cartesian,
    //     Polar
    // }
    //
    // public class Point
    // {
    //     public double x, y;
    //
    //     /// <summary>
    //     ///     Initialise a point from EITHER cartesian or polar 
    //     /// </summary>
    //     /// <param name="a"> x if cartesian, rho if polar</param>
    //     /// <param name="b"></param>
    //     /// <param name="system"></param>
    //     /// <exception cref="ArgumentOutOfRangeException"></exception>
    //     public Point(double a, double b, CoordianteSystem system = CoordianteSystem.Cartesian)
    //     {
    //
    //         switch (system)
    //         {
    //             case CoordianteSystem.Cartesian:
    //                 x = a;
    //                 y = b;
    //                 break;
    //             case CoordianteSystem.Polar:
    //                 x = a * Math.Cos(a);
    //                 y = b * Math.Cos(b);
    //                 break;
    //             default:
    //                 throw new ArgumentOutOfRangeException(nameof(system), system, null);
    //         }
    //     }
    // }

    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }


    public class Point
    {
        // factory method

        public double x, y;

        private
            Point(double x,
                double y) // you can make constructor internal - that means one can consume the constructor inside the current assembly but will not be able to access the constructor from outside the assembly 
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        // Defining the origin of the point 
        // public static Point _origin => new Point(0, 0);
        public static Point _origin2 = new Point(0, 0); // this one is the better alternative

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Sin(rho), theta * Math.Cos(theta));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var point = Point.Factory.NewCartesianPoint(1.0, Math.PI / 2);

            Console.WriteLine(point);

            var origin = Point._origin2;
            Console.WriteLine(origin);

            Console.ReadKey();
        }
    }
}