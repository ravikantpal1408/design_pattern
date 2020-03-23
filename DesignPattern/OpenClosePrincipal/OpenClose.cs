using System;
using System.Collections.Generic;

namespace DesignPattern.OpenClosePrincipal
{
    public class OpenClose
    {
        /* A class should be open to extension ✅ and closed for modification ❌ */
        /* Therefore to extend the class we use inheritance  */
        /* to avoid violation of open-close principal - SPECIFICATION PATTERN IS COMMONLY USED */
    }


    public enum Color // product color 🧩
    {
        Red,
        Green,
        Blue
    }

    public enum Size // product size 🌐
    {
        Small,
        Medium,
        Large,
        Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }

            Name = name;
            Color = color;
            Size = size;
        }
    }


    // to implement specification pattern - lets create an interface 👾
    public interface ISpecification<T> // takes a predicate of any type T 
    {
        // this interface implements the specification pattern
        // It also dictate that whether or not a product specify a particular criteria  
        bool
            IsSatisfied(T t); // allow people to make specification and to check whether or not that specification satisfy the criteria or not 
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        /*
         you feed this interface with bunch of items and you tell it specification of those items should be and
         you get the bunch of filtered items back.
         */
    }

    // To filter items by color - you make color specification 
    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }


        public bool IsSatisfied(Product t)
        {
            return t.Color == _color;
        }
    }

    public class AddSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _first, _second;

        public AddSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            _first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            _second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return _first.IsSatisfied(t) && _second.IsSatisfied(t);
        }
    }


    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied((item)))
                {
                    yield return item;
                }
            }
        }
    }

    public class SizeFilter : ISpecification<Product>
    {
        private Size _size;

        public SizeFilter(Size size)
        {
            _size = size;
        }


        public bool IsSatisfied(Product t)
        {
            return t.Size == _size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }

                /*
                 * To use "yield return", you just need to create a method with a return type that is an IEnumerable
                 * (arrays and collections in .Net implements IEnumerable interface) with a loop and use "yield return"
                 * to return a value to set in the loop body.Some examples are of a function with two arguments
                 * (int start, int number) made ​​in even numbers starting from the starting number.
                 */
            }
        }


        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }

                /*
                 * To use "yield return", you just need to create a method with a return type that is an IEnumerable
                 * (arrays and collections in .Net implements IEnumerable interface) with a loop and use "yield return"
                 * to return a value to set in the loop body.Some examples are of a function with two arguments
                 * (int start, int number) made ​​in even numbers starting from the starting number.
                 */
            }
        }
    }
}