using System;

namespace Liskov
{
    static class Program
    {
        // LISKOV PRINCIPAL
        // This solid principal is named after - Barber Liskov
        /* Idea is to substitute base type to sub-type */

        public static int Area(Rectangle r) => r.Width * r.Height; // expression based function 

        static void Main(string[] args)
        {
            Console.WriteLine("LISKOV PRINCIPAL");

            // Rectangle Area 
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");
            
            // Square Area
            /* below if i change the Square alias to Rectangle then it should be ok - but wait its not - because then i am setting only width property
             not the other Height property - so to overcome this situation we implement virtual keyword in Rectangle class */
            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
                
            


            Console.ReadKey();
        }

        // Now i require to calculate the area of square     
        public class Square : Rectangle // inheriting the rectangle class
        {
            // so square is basically a rectangle but equal width & height 
            public override int Width // this is workable
            {
                set { base.Height = base.Width = value; }
            }

            public override int Height // this is workable
            {
                set { base.Height = base.Width = value; }
            }
        }

        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public Rectangle()
            {
                // Default constructor 
            }

            public Rectangle(int width, int height)
            {
                // Parametrized constructor
                Width = width;
                Height = height;
            }

            public override string ToString()
            {
                return $"{nameof(Width)} : {Width}, {nameof(Height)} : {Height} ";
                
            }
        }
    }
}