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
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}